using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Core;

namespace EmceesProdTesting5.Models.Autocomplete;

[JsonConverter(
    typeof(JsonModelConverter<
        AutocompleteListPiggyBanksResponse,
        AutocompleteListPiggyBanksResponseFromRaw
    >)
)]
public sealed record class AutocompleteListPiggyBanksResponse : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Name of the piggy bank found by an auto-complete search.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Currency code for this piggy bank. This will always be the currency of the
    /// piggy bank, never the user's primary currency.
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
    /// Number of decimal places for the currency used by this piggy bank. This will
    /// always be the currency of the piggy bank, never the user's primary currency.
    /// </summary>
    public int? CurrencyDecimalPlaces
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("currency_decimal_places");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("currency_decimal_places", value);
        }
    }

    /// <summary>
    /// Currency ID for this piggy bank. This will always be the currency of the
    /// piggy bank, never the user's primary currency.
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
    /// Currency name for the currency used by this piggy bank. This will always be
    /// the currency of the piggy bank, never the user's primary currency.
    /// </summary>
    public string? CurrencyName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("currency_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("currency_name", value);
        }
    }

    public string? CurrencySymbol
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("currency_symbol");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("currency_symbol", value);
        }
    }

    /// <summary>
    /// The group ID of the group this object is part of. NULL if no group.
    /// </summary>
    public string? ObjectGroupID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("object_group_id");
        }
        init { this._rawData.Set("object_group_id", value); }
    }

    /// <summary>
    /// The name of the group. NULL if no group.
    /// </summary>
    public string? ObjectGroupTitle
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("object_group_title");
        }
        init { this._rawData.Set("object_group_title", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
        _ = this.CurrencyCode;
        _ = this.CurrencyDecimalPlaces;
        _ = this.CurrencyID;
        _ = this.CurrencyName;
        _ = this.CurrencySymbol;
        _ = this.ObjectGroupID;
        _ = this.ObjectGroupTitle;
    }

    public AutocompleteListPiggyBanksResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AutocompleteListPiggyBanksResponse(
        AutocompleteListPiggyBanksResponse autocompleteListPiggyBanksResponse
    )
        : base(autocompleteListPiggyBanksResponse) { }
#pragma warning restore CS8618

    public AutocompleteListPiggyBanksResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AutocompleteListPiggyBanksResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AutocompleteListPiggyBanksResponseFromRaw.FromRawUnchecked"/>
    public static AutocompleteListPiggyBanksResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AutocompleteListPiggyBanksResponseFromRaw : IFromRawJson<AutocompleteListPiggyBanksResponse>
{
    /// <inheritdoc/>
    public AutocompleteListPiggyBanksResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AutocompleteListPiggyBanksResponse.FromRawUnchecked(rawData);
}
