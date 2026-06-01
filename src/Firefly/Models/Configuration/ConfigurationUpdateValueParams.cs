using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Firefly.Core;
using Firefly.Exceptions;

namespace Firefly.Models.Configuration;

/// <summary>
/// Set a single configuration value. Not all configuration values can be updated
/// so the list of accepted configuration variables is small.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ConfigurationUpdateValueParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public ApiEnum<string, Name>? Name { get; init; }

    public required PolymorphicProperty Value
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<PolymorphicProperty>("value");
        }
        init { this._rawBodyData.Set("value", value); }
    }

    public string? XTraceID
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableClass<string>("X-Trace-Id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawHeaderData.Set("X-Trace-Id", value);
        }
    }

    public ConfigurationUpdateValueParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConfigurationUpdateValueParams(
        ConfigurationUpdateValueParams configurationUpdateValueParams
    )
        : base(configurationUpdateValueParams)
    {
        this.Name = configurationUpdateValueParams.Name;

        this._rawBodyData = new(configurationUpdateValueParams._rawBodyData);
    }
#pragma warning restore CS8618

    public ConfigurationUpdateValueParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConfigurationUpdateValueParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        ApiEnum<string, Name> name
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.Name = name;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ConfigurationUpdateValueParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        ApiEnum<string, Name> name
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            name
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["Name"] = JsonSerializer.SerializeToElement(this.Name),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(ConfigurationUpdateValueParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.Name?.Equals(other.Name) ?? other.Name == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v1/configuration/{0}", this.Name?.Raw())
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

[JsonConverter(typeof(NameConverter))]
public enum Name
{
    ConfigurationIsDemoSite,
    ConfigurationPermissionUpdateCheck,
    ConfigurationLastUpdateCheck,
    ConfigurationSingleUserMode,
    ConfigurationEnableExchangeRates,
    ConfigurationUseRunningBalance,
    ConfigurationEnableExternalMap,
    ConfigurationEnableExternalRates,
    ConfigurationAllowWebhooks,
    ConfigurationValidUrlProtocols,
}

sealed class NameConverter : JsonConverter<Name>
{
    public override Name Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "configuration.is_demo_site" => Name.ConfigurationIsDemoSite,
            "configuration.permission_update_check" => Name.ConfigurationPermissionUpdateCheck,
            "configuration.last_update_check" => Name.ConfigurationLastUpdateCheck,
            "configuration.single_user_mode" => Name.ConfigurationSingleUserMode,
            "configuration.enable_exchange_rates" => Name.ConfigurationEnableExchangeRates,
            "configuration.use_running_balance" => Name.ConfigurationUseRunningBalance,
            "configuration.enable_external_map" => Name.ConfigurationEnableExternalMap,
            "configuration.enable_external_rates" => Name.ConfigurationEnableExternalRates,
            "configuration.allow_webhooks" => Name.ConfigurationAllowWebhooks,
            "configuration.valid_url_protocols" => Name.ConfigurationValidUrlProtocols,
            _ => (Name)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Name value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Name.ConfigurationIsDemoSite => "configuration.is_demo_site",
                Name.ConfigurationPermissionUpdateCheck => "configuration.permission_update_check",
                Name.ConfigurationLastUpdateCheck => "configuration.last_update_check",
                Name.ConfigurationSingleUserMode => "configuration.single_user_mode",
                Name.ConfigurationEnableExchangeRates => "configuration.enable_exchange_rates",
                Name.ConfigurationUseRunningBalance => "configuration.use_running_balance",
                Name.ConfigurationEnableExternalMap => "configuration.enable_external_map",
                Name.ConfigurationEnableExternalRates => "configuration.enable_external_rates",
                Name.ConfigurationAllowWebhooks => "configuration.allow_webhooks",
                Name.ConfigurationValidUrlProtocols => "configuration.valid_url_protocols",
                _ => throw new FireflyInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
