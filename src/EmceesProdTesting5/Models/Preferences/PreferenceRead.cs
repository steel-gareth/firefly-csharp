using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Core;

namespace EmceesProdTesting5.Models.Preferences;

[JsonConverter(typeof(JsonModelConverter<PreferenceRead, PreferenceReadFromRaw>))]
public sealed record class PreferenceRead : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required Preference Attributes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Preference>("attributes");
        }
        init { this._rawData.Set("attributes", value); }
    }

    /// <summary>
    /// Immutable value
    /// </summary>
    public required string Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Attributes.Validate();
        _ = this.Type;
    }

    public PreferenceRead() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PreferenceRead(PreferenceRead preferenceRead)
        : base(preferenceRead) { }
#pragma warning restore CS8618

    public PreferenceRead(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PreferenceRead(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PreferenceReadFromRaw.FromRawUnchecked"/>
    public static PreferenceRead FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PreferenceReadFromRaw : IFromRawJson<PreferenceRead>
{
    /// <inheritdoc/>
    public PreferenceRead FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PreferenceRead.FromRawUnchecked(rawData);
}
