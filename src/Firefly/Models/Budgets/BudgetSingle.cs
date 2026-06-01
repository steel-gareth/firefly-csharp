using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Firefly.Core;

namespace Firefly.Models.Budgets;

[JsonConverter(typeof(JsonModelConverter<BudgetSingle, BudgetSingleFromRaw>))]
public sealed record class BudgetSingle : JsonModel
{
    public required BudgetRead Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BudgetRead>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public BudgetSingle() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BudgetSingle(BudgetSingle budgetSingle)
        : base(budgetSingle) { }
#pragma warning restore CS8618

    public BudgetSingle(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BudgetSingle(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BudgetSingleFromRaw.FromRawUnchecked"/>
    public static BudgetSingle FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BudgetSingle(BudgetRead data)
        : this()
    {
        this.Data = data;
    }
}

class BudgetSingleFromRaw : IFromRawJson<BudgetSingle>
{
    /// <inheritdoc/>
    public BudgetSingle FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BudgetSingle.FromRawUnchecked(rawData);
}
