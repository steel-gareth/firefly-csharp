using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Exceptions;

namespace EmceesProdTesting5.Models;

[JsonConverter(typeof(JsonModelConverter<Order, OrderFromRaw>))]
public sealed record class Order : JsonModel
{
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

    public bool? Complete
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("complete");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("complete", value);
        }
    }

    public long? PetID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("petId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("petId", value);
        }
    }

    public int? Quantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("quantity");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("quantity", value);
        }
    }

    public DateTimeOffset? ShipDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("shipDate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("shipDate", value);
        }
    }

    /// <summary>
    /// Order Status
    /// </summary>
    public ApiEnum<string, Status>? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Status>>("status");
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Complete;
        _ = this.PetID;
        _ = this.Quantity;
        _ = this.ShipDate;
        this.Status?.Validate();
    }

    public Order() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Order(Order order)
        : base(order) { }
#pragma warning restore CS8618

    public Order(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Order(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OrderFromRaw.FromRawUnchecked"/>
    public static Order FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OrderFromRaw : IFromRawJson<Order>
{
    /// <inheritdoc/>
    public Order FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Order.FromRawUnchecked(rawData);
}

/// <summary>
/// Order Status
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Placed,
    Approved,
    Delivered,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "placed" => Status.Placed,
            "approved" => Status.Approved,
            "delivered" => Status.Delivered,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Placed => "placed",
                Status.Approved => "approved",
                Status.Delivered => "delivered",
                _ => throw new MoreConflictingInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
