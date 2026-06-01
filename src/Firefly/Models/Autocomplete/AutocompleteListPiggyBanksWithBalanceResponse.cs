using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Firefly.Core;

namespace Firefly.Models.Autocomplete;

[JsonConverter(
    typeof(JsonModelConverter<
        AutocompleteListPiggyBanksWithBalanceResponse,
        AutocompleteListPiggyBanksWithBalanceResponseFromRaw
    >)
)]
public sealed record class AutocompleteListPiggyBanksWithBalanceResponse : JsonModel
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
    /// Currency code for the currency used by this piggy bank. This will always be
    /// the piggy bank's currency, never the primary currency.
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
    /// Currency decimal places for the currency used by this piggy bank. This will
    /// always be the piggy bank's currency, never the primary currency.
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
    /// Currency ID for the currency used by this piggy bank. This will always be
    /// the piggy bank's currency, never the primary currency.
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
    /// Currency symbol for the currency used by this piggy bank. This will always
    /// be the piggy bank's currency, never the primary currency.
    /// </summary>
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
    /// Name of the piggy bank found by an auto-complete search, including the currently
    /// saved amount and the target amount.
    /// </summary>
    public string? NameWithBalance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name_with_balance");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name_with_balance", value);
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
        _ = this.CurrencySymbol;
        _ = this.NameWithBalance;
        _ = this.ObjectGroupID;
        _ = this.ObjectGroupTitle;
    }

    public AutocompleteListPiggyBanksWithBalanceResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AutocompleteListPiggyBanksWithBalanceResponse(
        AutocompleteListPiggyBanksWithBalanceResponse autocompleteListPiggyBanksWithBalanceResponse
    )
        : base(autocompleteListPiggyBanksWithBalanceResponse) { }
#pragma warning restore CS8618

    public AutocompleteListPiggyBanksWithBalanceResponse(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AutocompleteListPiggyBanksWithBalanceResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AutocompleteListPiggyBanksWithBalanceResponseFromRaw.FromRawUnchecked"/>
    public static AutocompleteListPiggyBanksWithBalanceResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AutocompleteListPiggyBanksWithBalanceResponseFromRaw
    : IFromRawJson<AutocompleteListPiggyBanksWithBalanceResponse>
{
    /// <inheritdoc/>
    public AutocompleteListPiggyBanksWithBalanceResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AutocompleteListPiggyBanksWithBalanceResponse.FromRawUnchecked(rawData);
}
