using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Firefly.Core;
using Firefly.Exceptions;

namespace Firefly.Models.Data;

/// <summary>
/// A call to this endpoint deletes the requested data type. Use it with care and
/// always with user permission. The demo user is incapable of using this endpoint.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class DataDestroyParams : ParamsBase
{
    /// <summary>
    /// The type of data that you wish to destroy. You can only use one at a time.
    /// </summary>
    public required ApiEnum<string, Objects> Objects
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNotNullClass<ApiEnum<string, Objects>>("objects");
        }
        init { this._rawQueryData.Set("objects", value); }
    }

    public string? XTraceID
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableClass<string>("X-Trace-Id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawHeaderData.Set("X-Trace-Id", value);
        }
    }

    public DataDestroyParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DataDestroyParams(DataDestroyParams dataDestroyParams)
        : base(dataDestroyParams) { }
#pragma warning restore CS8618

    public DataDestroyParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DataDestroyParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static DataDestroyParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(DataDestroyParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v1/data/destroy")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

/// <summary>
/// The type of data that you wish to destroy. You can only use one at a time.
/// </summary>
[JsonConverter(typeof(ObjectsConverter))]
public enum Objects
{
    NotAssetsLiabilities,
    Budgets,
    Bills,
    PiggyBanks,
    Rules,
    Recurring,
    Categories,
    Tags,
    ObjectGroups,
    Accounts,
    AssetAccounts,
    ExpenseAccounts,
    RevenueAccounts,
    Liabilities,
    Transactions,
    Withdrawals,
    Deposits,
    Transfers,
}

sealed class ObjectsConverter : JsonConverter<Objects>
{
    public override Objects Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_assets_liabilities" => Objects.NotAssetsLiabilities,
            "budgets" => Objects.Budgets,
            "bills" => Objects.Bills,
            "piggy_banks" => Objects.PiggyBanks,
            "rules" => Objects.Rules,
            "recurring" => Objects.Recurring,
            "categories" => Objects.Categories,
            "tags" => Objects.Tags,
            "object_groups" => Objects.ObjectGroups,
            "accounts" => Objects.Accounts,
            "asset_accounts" => Objects.AssetAccounts,
            "expense_accounts" => Objects.ExpenseAccounts,
            "revenue_accounts" => Objects.RevenueAccounts,
            "liabilities" => Objects.Liabilities,
            "transactions" => Objects.Transactions,
            "withdrawals" => Objects.Withdrawals,
            "deposits" => Objects.Deposits,
            "transfers" => Objects.Transfers,
            _ => (Objects)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Objects value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Objects.NotAssetsLiabilities => "not_assets_liabilities",
                Objects.Budgets => "budgets",
                Objects.Bills => "bills",
                Objects.PiggyBanks => "piggy_banks",
                Objects.Rules => "rules",
                Objects.Recurring => "recurring",
                Objects.Categories => "categories",
                Objects.Tags => "tags",
                Objects.ObjectGroups => "object_groups",
                Objects.Accounts => "accounts",
                Objects.AssetAccounts => "asset_accounts",
                Objects.ExpenseAccounts => "expense_accounts",
                Objects.RevenueAccounts => "revenue_accounts",
                Objects.Liabilities => "liabilities",
                Objects.Transactions => "transactions",
                Objects.Withdrawals => "withdrawals",
                Objects.Deposits => "deposits",
                Objects.Transfers => "transfers",
                _ => throw new FireflyInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
