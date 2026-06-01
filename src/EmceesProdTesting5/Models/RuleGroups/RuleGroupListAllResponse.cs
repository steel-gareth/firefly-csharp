using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Accounts;

namespace EmceesProdTesting5.Models.RuleGroups;

[JsonConverter(
    typeof(JsonModelConverter<RuleGroupListAllResponse, RuleGroupListAllResponseFromRaw>)
)]
public sealed record class RuleGroupListAllResponse : JsonModel
{
    public required IReadOnlyList<RuleGroupRead> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<RuleGroupRead>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<RuleGroupRead>>(
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

    public RuleGroupListAllResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RuleGroupListAllResponse(RuleGroupListAllResponse ruleGroupListAllResponse)
        : base(ruleGroupListAllResponse) { }
#pragma warning restore CS8618

    public RuleGroupListAllResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RuleGroupListAllResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RuleGroupListAllResponseFromRaw.FromRawUnchecked"/>
    public static RuleGroupListAllResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RuleGroupListAllResponseFromRaw : IFromRawJson<RuleGroupListAllResponse>
{
    /// <inheritdoc/>
    public RuleGroupListAllResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RuleGroupListAllResponse.FromRawUnchecked(rawData);
}
