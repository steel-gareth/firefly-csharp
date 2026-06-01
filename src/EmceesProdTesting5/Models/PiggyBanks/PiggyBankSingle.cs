using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Core;

namespace EmceesProdTesting5.Models.PiggyBanks;

[JsonConverter(typeof(JsonModelConverter<PiggyBankSingle, PiggyBankSingleFromRaw>))]
public sealed record class PiggyBankSingle : JsonModel
{
    public required PiggyBankRead Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PiggyBankRead>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public PiggyBankSingle() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PiggyBankSingle(PiggyBankSingle piggyBankSingle)
        : base(piggyBankSingle) { }
#pragma warning restore CS8618

    public PiggyBankSingle(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PiggyBankSingle(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PiggyBankSingleFromRaw.FromRawUnchecked"/>
    public static PiggyBankSingle FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PiggyBankSingle(PiggyBankRead data)
        : this()
    {
        this.Data = data;
    }
}

class PiggyBankSingleFromRaw : IFromRawJson<PiggyBankSingle>
{
    /// <inheritdoc/>
    public PiggyBankSingle FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PiggyBankSingle.FromRawUnchecked(rawData);
}
