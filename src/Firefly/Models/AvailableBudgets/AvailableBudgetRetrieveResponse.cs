using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Firefly.Core;

namespace Firefly.Models.AvailableBudgets;

[JsonConverter(
    typeof(JsonModelConverter<
        AvailableBudgetRetrieveResponse,
        AvailableBudgetRetrieveResponseFromRaw
    >)
)]
public sealed record class AvailableBudgetRetrieveResponse : JsonModel
{
    public required AvailableBudgetRead Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AvailableBudgetRead>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public AvailableBudgetRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AvailableBudgetRetrieveResponse(
        AvailableBudgetRetrieveResponse availableBudgetRetrieveResponse
    )
        : base(availableBudgetRetrieveResponse) { }
#pragma warning restore CS8618

    public AvailableBudgetRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AvailableBudgetRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AvailableBudgetRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static AvailableBudgetRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AvailableBudgetRetrieveResponse(AvailableBudgetRead data)
        : this()
    {
        this.Data = data;
    }
}

class AvailableBudgetRetrieveResponseFromRaw : IFromRawJson<AvailableBudgetRetrieveResponse>
{
    /// <inheritdoc/>
    public AvailableBudgetRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AvailableBudgetRetrieveResponse.FromRawUnchecked(rawData);
}
