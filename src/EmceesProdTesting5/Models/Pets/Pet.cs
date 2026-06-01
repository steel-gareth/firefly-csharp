using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Exceptions;

namespace EmceesProdTesting5.Models.Pets;

[JsonConverter(typeof(JsonModelConverter<Pet, PetFromRaw>))]
public sealed record class Pet : JsonModel
{
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public required IReadOnlyList<string> PhotoUrls
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("photoUrls");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "photoUrls",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public long? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    public Category? Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Category>("category");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("category", value);
        }
    }

    /// <summary>
    /// pet status in the store
    /// </summary>
    public ApiEnum<string, PetStatus>? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PetStatus>>("status");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    public IReadOnlyList<Tag>? Tags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Tag>>("tags");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Tag>?>(
                "tags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        _ = this.PhotoUrls;
        _ = this.ID;
        this.Category?.Validate();
        this.Status?.Validate();
        foreach (var item in this.Tags ?? [])
        {
            item.Validate();
        }
    }

    public Pet() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Pet(Pet pet)
        : base(pet) { }
#pragma warning restore CS8618

    public Pet(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Pet(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PetFromRaw.FromRawUnchecked"/>
    public static Pet FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PetFromRaw : IFromRawJson<Pet>
{
    /// <inheritdoc/>
    public Pet FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Pet.FromRawUnchecked(rawData);
}

/// <summary>
/// pet status in the store
/// </summary>
[JsonConverter(typeof(PetStatusConverter))]
public enum PetStatus
{
    Available,
    Pending,
    Sold,
}

sealed class PetStatusConverter : JsonConverter<PetStatus>
{
    public override PetStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "available" => PetStatus.Available,
            "pending" => PetStatus.Pending,
            "sold" => PetStatus.Sold,
            _ => (PetStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PetStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PetStatus.Available => "available",
                PetStatus.Pending => "pending",
                PetStatus.Sold => "sold",
                _ => throw new MoreConflictingInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
