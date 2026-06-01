using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Firefly.Core;

namespace Firefly.Models.Configuration;

[JsonConverter(
    typeof(JsonModelConverter<ConfigurationConfiguration, ConfigurationConfigurationFromRaw>)
)]
public sealed record class ConfigurationConfiguration : JsonModel
{
    /// <summary>
    /// If this config variable can be edited by the user
    /// </summary>
    public required bool Editable
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("editable");
        }
        init { this._rawData.Set("editable", value); }
    }

    /// <summary>
    /// Title of the configuration value.
    /// </summary>
    public required ApiEnum<string, ConfigValueFilter> Title
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ConfigValueFilter>>("title");
        }
        init { this._rawData.Set("title", value); }
    }

    public required PolymorphicProperty Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PolymorphicProperty>("value");
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Editable;
        this.Title.Validate();
        this.Value.Validate();
    }

    public ConfigurationConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConfigurationConfiguration(ConfigurationConfiguration configurationConfiguration)
        : base(configurationConfiguration) { }
#pragma warning restore CS8618

    public ConfigurationConfiguration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConfigurationConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConfigurationConfigurationFromRaw.FromRawUnchecked"/>
    public static ConfigurationConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConfigurationConfigurationFromRaw : IFromRawJson<ConfigurationConfiguration>
{
    /// <inheritdoc/>
    public ConfigurationConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConfigurationConfiguration.FromRawUnchecked(rawData);
}
