using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Firefly.Core;
using Firefly.Models.Accounts;
using Firefly.Models.Rules;

namespace Firefly.Models.Bills;

[JsonConverter(typeof(JsonModelConverter<RuleArray, RuleArrayFromRaw>))]
public sealed record class RuleArray : JsonModel
{
    public required IReadOnlyList<RuleRead> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<RuleRead>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<RuleRead>>(
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

    public RuleArray() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RuleArray(RuleArray ruleArray)
        : base(ruleArray) { }
#pragma warning restore CS8618

    public RuleArray(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RuleArray(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RuleArrayFromRaw.FromRawUnchecked"/>
    public static RuleArray FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RuleArrayFromRaw : IFromRawJson<RuleArray>
{
    /// <inheritdoc/>
    public RuleArray FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        RuleArray.FromRawUnchecked(rawData);
}
