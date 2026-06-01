using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Configuration;

namespace EmceesProdTesting5.Models.Preferences;

[JsonConverter(typeof(JsonModelConverter<Preference, PreferenceFromRaw>))]
public sealed record class Preference : JsonModel
{
    public required PolymorphicProperty Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PolymorphicProperty>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("created_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    public DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updated_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("updated_at", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
        _ = this.Name;
        _ = this.CreatedAt;
        _ = this.UpdatedAt;
    }

    public Preference() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Preference(Preference preference)
        : base(preference) { }
#pragma warning restore CS8618

    public Preference(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Preference(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PreferenceFromRaw.FromRawUnchecked"/>
    public static Preference FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PreferenceFromRaw : IFromRawJson<Preference>
{
    /// <inheritdoc/>
    public Preference FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Preference.FromRawUnchecked(rawData);
}
