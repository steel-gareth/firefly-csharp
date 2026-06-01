using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Core;

namespace EmceesProdTesting5.Models.Preferences;

[JsonConverter(typeof(JsonModelConverter<PreferenceSingle, PreferenceSingleFromRaw>))]
public sealed record class PreferenceSingle : JsonModel
{
    public required PreferenceRead Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PreferenceRead>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public PreferenceSingle() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PreferenceSingle(PreferenceSingle preferenceSingle)
        : base(preferenceSingle) { }
#pragma warning restore CS8618

    public PreferenceSingle(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PreferenceSingle(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PreferenceSingleFromRaw.FromRawUnchecked"/>
    public static PreferenceSingle FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PreferenceSingle(PreferenceRead data)
        : this()
    {
        this.Data = data;
    }
}

class PreferenceSingleFromRaw : IFromRawJson<PreferenceSingle>
{
    /// <inheritdoc/>
    public PreferenceSingle FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PreferenceSingle.FromRawUnchecked(rawData);
}
