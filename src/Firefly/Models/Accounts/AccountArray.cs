using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Firefly.Core;

namespace Firefly.Models.Accounts;

[JsonConverter(typeof(JsonModelConverter<AccountArray, AccountArrayFromRaw>))]
public sealed record class AccountArray : JsonModel
{
    public required IReadOnlyList<AccountRead> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<AccountRead>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<AccountRead>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
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
        this.Meta.Validate();
    }

    public AccountArray() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccountArray(AccountArray accountArray)
        : base(accountArray) { }
#pragma warning restore CS8618

    public AccountArray(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AccountArray(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AccountArrayFromRaw.FromRawUnchecked"/>
    public static AccountArray FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AccountArrayFromRaw : IFromRawJson<AccountArray>
{
    /// <inheritdoc/>
    public AccountArray FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AccountArray.FromRawUnchecked(rawData);
}
