using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Firefly.Core;

namespace Firefly.Models.RuleGroups;

[JsonConverter(typeof(JsonModelConverter<RuleGroupSingle, RuleGroupSingleFromRaw>))]
public sealed record class RuleGroupSingle : JsonModel
{
    public required RuleGroupRead Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<RuleGroupRead>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public RuleGroupSingle() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RuleGroupSingle(RuleGroupSingle ruleGroupSingle)
        : base(ruleGroupSingle) { }
#pragma warning restore CS8618

    public RuleGroupSingle(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RuleGroupSingle(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RuleGroupSingleFromRaw.FromRawUnchecked"/>
    public static RuleGroupSingle FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public RuleGroupSingle(RuleGroupRead data)
        : this()
    {
        this.Data = data;
    }
}

class RuleGroupSingleFromRaw : IFromRawJson<RuleGroupSingle>
{
    /// <inheritdoc/>
    public RuleGroupSingle FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        RuleGroupSingle.FromRawUnchecked(rawData);
}
