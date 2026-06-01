using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Accounts;

namespace EmceesProdTesting5.Models.AvailableBudgets;

[JsonConverter(typeof(JsonModelConverter<AvailableBudgetArray, AvailableBudgetArrayFromRaw>))]
public sealed record class AvailableBudgetArray : JsonModel
{
    public required IReadOnlyList<AvailableBudgetRead> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<AvailableBudgetRead>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<AvailableBudgetRead>>(
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

    public AvailableBudgetArray() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AvailableBudgetArray(AvailableBudgetArray availableBudgetArray)
        : base(availableBudgetArray) { }
#pragma warning restore CS8618

    public AvailableBudgetArray(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AvailableBudgetArray(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AvailableBudgetArrayFromRaw.FromRawUnchecked"/>
    public static AvailableBudgetArray FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AvailableBudgetArrayFromRaw : IFromRawJson<AvailableBudgetArray>
{
    /// <inheritdoc/>
    public AvailableBudgetArray FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AvailableBudgetArray.FromRawUnchecked(rawData);
}
