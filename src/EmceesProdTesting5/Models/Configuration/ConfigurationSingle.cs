using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Core;

namespace EmceesProdTesting5.Models.Configuration;

[JsonConverter(typeof(JsonModelConverter<ConfigurationSingle, ConfigurationSingleFromRaw>))]
public sealed record class ConfigurationSingle : JsonModel
{
    public required ConfigurationConfiguration Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ConfigurationConfiguration>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
    }

    public ConfigurationSingle() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConfigurationSingle(ConfigurationSingle configurationSingle)
        : base(configurationSingle) { }
#pragma warning restore CS8618

    public ConfigurationSingle(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConfigurationSingle(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConfigurationSingleFromRaw.FromRawUnchecked"/>
    public static ConfigurationSingle FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ConfigurationSingle(ConfigurationConfiguration data)
        : this()
    {
        this.Data = data;
    }
}

class ConfigurationSingleFromRaw : IFromRawJson<ConfigurationSingle>
{
    /// <inheritdoc/>
    public ConfigurationSingle FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ConfigurationSingle.FromRawUnchecked(rawData);
}
