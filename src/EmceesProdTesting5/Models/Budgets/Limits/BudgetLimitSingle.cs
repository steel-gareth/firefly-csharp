using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Core;

namespace EmceesProdTesting5.Models.Budgets.Limits;

[JsonConverter(typeof(JsonModelConverter<BudgetLimitSingle, BudgetLimitSingleFromRaw>))]
public sealed record class BudgetLimitSingle : JsonModel
{
    public required BudgetLimitRead Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BudgetLimitRead>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public BudgetLimitSingle() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BudgetLimitSingle(BudgetLimitSingle budgetLimitSingle)
        : base(budgetLimitSingle) { }
#pragma warning restore CS8618

    public BudgetLimitSingle(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BudgetLimitSingle(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BudgetLimitSingleFromRaw.FromRawUnchecked"/>
    public static BudgetLimitSingle FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BudgetLimitSingle(BudgetLimitRead data)
        : this()
    {
        this.Data = data;
    }
}

class BudgetLimitSingleFromRaw : IFromRawJson<BudgetLimitSingle>
{
    /// <inheritdoc/>
    public BudgetLimitSingle FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BudgetLimitSingle.FromRawUnchecked(rawData);
}
