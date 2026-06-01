using System.Text.Json;
using EmceesProdTesting5.Exceptions;
using EmceesProdTesting5.Models;
using Orders = EmceesProdTesting5.Models.Store.Orders;
using Pets = EmceesProdTesting5.Models.Pets;

namespace EmceesProdTesting5.Core;

/// <summary>
/// The base class for all API objects with properties.
///
/// <para>API objects such as enums do not inherit from this class.</para>
/// </summary>
public abstract record class ModelBase
{
    protected ModelBase(ModelBase modelBase)
    {
        // Nothing to copy. Just so that subclasses can define copy constructors.
    }

    internal static readonly JsonSerializerOptions SerializerOptions = new()
    {
        Converters =
        {
            new FrozenDictionaryConverterFactory(),
            new ApiEnumConverter<string, Status>(),
            new ApiEnumConverter<string, Pets::PetStatus>(),
            new ApiEnumConverter<string, Pets::Status>(),
            new ApiEnumConverter<string, Pets::PetUpdateParamsStatus>(),
            new ApiEnumConverter<string, Pets::PetFindByStatusParamsStatus>(),
            new ApiEnumConverter<string, Orders::Status>(),
        },
    };

    internal static readonly JsonSerializerOptions ToStringSerializerOptions = new(
        SerializerOptions
    )
    {
        WriteIndented = true,
    };

    /// <summary>
    /// Validates that all required fields are set and that each field's value is of the expected type.
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="MoreConflictingInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public abstract void Validate();
}
