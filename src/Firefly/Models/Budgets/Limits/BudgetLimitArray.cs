using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Firefly.Core;
using Firefly.Models.Accounts;

namespace Firefly.Models.Budgets.Limits;

[JsonConverter(typeof(JsonModelConverter<BudgetLimitArray, BudgetLimitArrayFromRaw>))]
public sealed record class BudgetLimitArray : JsonModel
{
    public required IReadOnlyList<BudgetLimitRead> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BudgetLimitRead>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BudgetLimitRead>>(
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

    public BudgetLimitArray() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BudgetLimitArray(BudgetLimitArray budgetLimitArray)
        : base(budgetLimitArray) { }
#pragma warning restore CS8618

    public BudgetLimitArray(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BudgetLimitArray(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BudgetLimitArrayFromRaw.FromRawUnchecked"/>
    public static BudgetLimitArray FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BudgetLimitArrayFromRaw : IFromRawJson<BudgetLimitArray>
{
    /// <inheritdoc/>
    public BudgetLimitArray FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BudgetLimitArray.FromRawUnchecked(rawData);
}
