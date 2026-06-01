using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Core;

namespace EmceesProdTesting5.Models.Rules;

[JsonConverter(typeof(JsonModelConverter<RuleSingle, RuleSingleFromRaw>))]
public sealed record class RuleSingle : JsonModel
{
    public required RuleRead Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<RuleRead>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public RuleSingle() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RuleSingle(RuleSingle ruleSingle)
        : base(ruleSingle) { }
#pragma warning restore CS8618

    public RuleSingle(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RuleSingle(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RuleSingleFromRaw.FromRawUnchecked"/>
    public static RuleSingle FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public RuleSingle(RuleRead data)
        : this()
    {
        this.Data = data;
    }
}

class RuleSingleFromRaw : IFromRawJson<RuleSingle>
{
    /// <inheritdoc/>
    public RuleSingle FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        RuleSingle.FromRawUnchecked(rawData);
}
