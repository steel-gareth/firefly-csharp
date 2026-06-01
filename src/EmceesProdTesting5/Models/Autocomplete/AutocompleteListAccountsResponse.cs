using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Core;

namespace EmceesProdTesting5.Models.Autocomplete;

[JsonConverter(
    typeof(JsonModelConverter<
        AutocompleteListAccountsResponse,
        AutocompleteListAccountsResponseFromRaw
    >)
)]
public sealed record class AutocompleteListAccountsResponse : JsonModel
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
    /// Currency code for the currency used by this account. If the user prefers amounts
    /// converted to their primary currency, this primary currency is used instead.
    /// </summary>
    public required string CurrencyCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("currency_code");
        }
        init { this._rawData.Set("currency_code", value); }
    }

    /// <summary>
    /// Number of decimal places for the currency used by this account. If the user
    /// prefers amounts converted to their primary currency, this primary currency
    /// is used instead.
    /// </summary>
    public required int CurrencyDecimalPlaces
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("currency_decimal_places");
        }
        init { this._rawData.Set("currency_decimal_places", value); }
    }

    /// <summary>
    /// ID for the currency used by this account. If the user prefers amounts converted
    /// to their primary currency, this primary currency is used instead.
    /// </summary>
    public required string CurrencyID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("currency_id");
        }
        init { this._rawData.Set("currency_id", value); }
    }

    /// <summary>
    /// Currency name for the currency used by this account. If the user prefers amounts
    /// converted to their primary currency, this primary currency is used instead.
    /// </summary>
    public required string CurrencyName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("currency_name");
        }
        init { this._rawData.Set("currency_name", value); }
    }

    /// <summary>
    /// Currency symbol for the currency used by this account. If the user prefers
    /// amounts converted to their primary currency, this primary currency is used instead.
    /// </summary>
    public required string CurrencySymbol
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("currency_symbol");
        }
        init { this._rawData.Set("currency_symbol", value); }
    }

    /// <summary>
    /// Name of the account found by an auto-complete search.
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
    /// Asset accounts and liabilities have a second field with the given date's
    /// account balance in the account currency or primary currency.
    /// </summary>
    public required string NameWithBalance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name_with_balance");
        }
        init { this._rawData.Set("name_with_balance", value); }
    }

    /// <summary>
    /// Account type of the account found by the auto-complete search.
    /// </summary>
    public required string Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Code for the currency used by this account. Even if "convertToPrimary" is
    /// on, the account currency code is displayed here.
    /// </summary>
    public string? AccountCurrencyCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("account_currency_code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("account_currency_code", value);
        }
    }

    /// <summary>
    /// Number of decimal places for the currency used by this account. Even if "convertToPrimary"
    /// is on, the account currency code is displayed here.
    /// </summary>
    public int? AccountCurrencyDecimalPlaces
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("account_currency_decimal_places");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("account_currency_decimal_places", value);
        }
    }

    /// <summary>
    /// ID for the currency used by this account. Even if "convertToPrimary" is on,
    /// the account currency ID is displayed here.
    /// </summary>
    public string? AccountCurrencyID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("account_currency_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("account_currency_id", value);
        }
    }

    /// <summary>
    /// Name for the currency used by this account. Even if "convertToPrimary" is
    /// on, the account currency name is displayed here.
    /// </summary>
    public string? AccountCurrencyName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("account_currency_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("account_currency_name", value);
        }
    }

    /// <summary>
    /// Code for the currency used by this account. Even if "convertToPrimary" is
    /// on, the account currency code is displayed here.
    /// </summary>
    public string? AccountCurrencySymbol
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("account_currency_symbol");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("account_currency_symbol", value);
        }
    }

    /// <summary>
    /// Is the bill active or not?
    /// </summary>
    public bool? Active
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("active");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("active", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CurrencyCode;
        _ = this.CurrencyDecimalPlaces;
        _ = this.CurrencyID;
        _ = this.CurrencyName;
        _ = this.CurrencySymbol;
        _ = this.Name;
        _ = this.NameWithBalance;
        _ = this.Type;
        _ = this.AccountCurrencyCode;
        _ = this.AccountCurrencyDecimalPlaces;
        _ = this.AccountCurrencyID;
        _ = this.AccountCurrencyName;
        _ = this.AccountCurrencySymbol;
        _ = this.Active;
    }

    public AutocompleteListAccountsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AutocompleteListAccountsResponse(
        AutocompleteListAccountsResponse autocompleteListAccountsResponse
    )
        : base(autocompleteListAccountsResponse) { }
#pragma warning restore CS8618

    public AutocompleteListAccountsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AutocompleteListAccountsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AutocompleteListAccountsResponseFromRaw.FromRawUnchecked"/>
    public static AutocompleteListAccountsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AutocompleteListAccountsResponseFromRaw : IFromRawJson<AutocompleteListAccountsResponse>
{
    /// <inheritdoc/>
    public AutocompleteListAccountsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AutocompleteListAccountsResponse.FromRawUnchecked(rawData);
}
