using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Core;

namespace EmceesProdTesting5.Models.Insight.Transfer;

[JsonConverter(
    typeof(JsonModelConverter<
        TransferListByAssetAccountResponse,
        TransferListByAssetAccountResponseFromRaw
    >)
)]
public sealed record class TransferListByAssetAccountResponse : JsonModel
{
    /// <summary>
    /// This ID is a reference to the original object.
    /// </summary>
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
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

    /// <summary>
    /// The currency code of the expenses listed for this account.
    /// </summary>
    public string? CurrencyCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("currency_code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("currency_code", value);
        }
    }

    /// <summary>
    /// The currency ID of the expenses listed for this account.
    /// </summary>
    public string? CurrencyID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("currency_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("currency_id", value);
        }
    }

    /// <summary>
    /// The total amount transferred between start date and end date, a number defined
    /// as a string, for this asset account.
    /// </summary>
    public string? Difference
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("difference");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("difference", value);
        }
    }

    /// <summary>
    /// The total amount transferred between start date and end date, a number as
    /// a float, for this asset account. May have rounding errors.
    /// </summary>
    public double? DifferenceFloat
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("difference_float");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("difference_float", value);
        }
    }

    /// <summary>
    /// The total amount transferred TO this account between start date and end date,
    /// a number defined as a string, for this asset account.
    /// </summary>
    public string? In
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("in");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("in", value);
        }
    }

    /// <summary>
    /// The total amount transferred FROM this account between start date and end
    /// date, a number as a float, for this asset account. May have rounding errors.
    /// </summary>
    public double? InFloat
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("in_float");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("in_float", value);
        }
    }

    /// <summary>
    /// This is the name of the object.
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <summary>
    /// The total amount transferred FROM this account between start date and end
    /// date, a number defined as a string, for this asset account.
    /// </summary>
    public string? Out
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("out");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("out", value);
        }
    }

    /// <summary>
    /// The total amount transferred TO this account between start date and end date,
    /// a number as a float, for this asset account. May have rounding errors.
    /// </summary>
    public double? OutFloat
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("out_float");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("out_float", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CurrencyCode;
        _ = this.CurrencyID;
        _ = this.Difference;
        _ = this.DifferenceFloat;
        _ = this.In;
        _ = this.InFloat;
        _ = this.Name;
        _ = this.Out;
        _ = this.OutFloat;
    }

    public TransferListByAssetAccountResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TransferListByAssetAccountResponse(
        TransferListByAssetAccountResponse transferListByAssetAccountResponse
    )
        : base(transferListByAssetAccountResponse) { }
#pragma warning restore CS8618

    public TransferListByAssetAccountResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TransferListByAssetAccountResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TransferListByAssetAccountResponseFromRaw.FromRawUnchecked"/>
    public static TransferListByAssetAccountResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TransferListByAssetAccountResponseFromRaw : IFromRawJson<TransferListByAssetAccountResponse>
{
    /// <inheritdoc/>
    public TransferListByAssetAccountResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TransferListByAssetAccountResponse.FromRawUnchecked(rawData);
}
