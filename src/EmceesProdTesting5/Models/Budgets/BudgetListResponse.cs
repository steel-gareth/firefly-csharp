using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Accounts;

namespace EmceesProdTesting5.Models.Budgets;

[JsonConverter(typeof(JsonModelConverter<BudgetListResponse, BudgetListResponseFromRaw>))]
public sealed record class BudgetListResponse : JsonModel
{
    public required IReadOnlyList<BudgetRead> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BudgetRead>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BudgetRead>>(
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

    public BudgetListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BudgetListResponse(BudgetListResponse budgetListResponse)
        : base(budgetListResponse) { }
#pragma warning restore CS8618

    public BudgetListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BudgetListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BudgetListResponseFromRaw.FromRawUnchecked"/>
    public static BudgetListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BudgetListResponseFromRaw : IFromRawJson<BudgetListResponse>
{
    /// <inheritdoc/>
    public BudgetListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BudgetListResponse.FromRawUnchecked(rawData);
}
