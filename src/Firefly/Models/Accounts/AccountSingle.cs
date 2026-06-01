using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Firefly.Core;

namespace Firefly.Models.Accounts;

[JsonConverter(typeof(JsonModelConverter<AccountSingle, AccountSingleFromRaw>))]
public sealed record class AccountSingle : JsonModel
{
    public required AccountRead Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AccountRead>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public AccountSingle() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountSingle(AccountSingle accountSingle)
        : base(accountSingle) { }
#pragma warning restore CS8618

    public AccountSingle(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountSingle(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountSingleFromRaw.FromRawUnchecked"/>
    public static AccountSingle FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AccountSingle(AccountRead data)
        : this()
    {
        this.Data = data;
    }
}

class AccountSingleFromRaw : IFromRawJson<AccountSingle>
{
    /// <inheritdoc/>
    public AccountSingle FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AccountSingle.FromRawUnchecked(rawData);
}
