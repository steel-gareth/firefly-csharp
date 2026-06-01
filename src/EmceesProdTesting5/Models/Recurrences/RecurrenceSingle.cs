using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Core;

namespace EmceesProdTesting5.Models.Recurrences;

[JsonConverter(typeof(JsonModelConverter<RecurrenceSingle, RecurrenceSingleFromRaw>))]
public sealed record class RecurrenceSingle : JsonModel
{
    public required RecurrenceRead Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<RecurrenceRead>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public RecurrenceSingle() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RecurrenceSingle(RecurrenceSingle recurrenceSingle)
        : base(recurrenceSingle) { }
#pragma warning restore CS8618

    public RecurrenceSingle(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RecurrenceSingle(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RecurrenceSingleFromRaw.FromRawUnchecked"/>
    public static RecurrenceSingle FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public RecurrenceSingle(RecurrenceRead data)
        : this()
    {
        this.Data = data;
    }
}

class RecurrenceSingleFromRaw : IFromRawJson<RecurrenceSingle>
{
    /// <inheritdoc/>
    public RecurrenceSingle FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        RecurrenceSingle.FromRawUnchecked(rawData);
}
