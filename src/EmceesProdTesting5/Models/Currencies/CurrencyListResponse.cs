using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Accounts;

namespace EmceesProdTesting5.Models.Currencies;

[JsonConverter(typeof(JsonModelConverter<CurrencyListResponse, CurrencyListResponseFromRaw>))]
public sealed record class CurrencyListResponse : JsonModel
{
    public required IReadOnlyList<CurrencyRead> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<CurrencyRead>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<CurrencyRead>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required PageLink Links
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PageLink>("links");
        }
        init { this._rawData.Set("links", value); }
    }

    public required Meta Meta
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Meta>("meta");
        }
        init { this._rawData.Set("meta", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        this.Links.Validate();
        this.Meta.Validate();
    }

    public CurrencyListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CurrencyListResponse(CurrencyListResponse currencyListResponse)
        : base(currencyListResponse) { }
#pragma warning restore CS8618

    public CurrencyListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CurrencyListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CurrencyListResponseFromRaw.FromRawUnchecked"/>
    public static CurrencyListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CurrencyListResponseFromRaw : IFromRawJson<CurrencyListResponse>
{
    /// <inheritdoc/>
    public CurrencyListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CurrencyListResponse.FromRawUnchecked(rawData);
}
