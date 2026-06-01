using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Configuration;

namespace EmceesProdTesting5.Services;

/// <summary>
/// These endpoints allow you to manage and update the Firefly III configuration.
/// You need to have the &amp;quot;owner&amp;quot; role to update configuration.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IConfigurationService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IConfigurationServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IConfigurationService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns all editable and not-editable configuration values for this Firefly III
    /// installation
    /// </summary>
    Task<List<ConfigurationConfiguration>> Retrieve(
        ConfigurationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns one configuration variable for this Firefly III installation
    /// </summary>
    Task<ConfigurationSingle> RetrieveValue(
        ConfigurationRetrieveValueParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveValue(ConfigurationRetrieveValueParams, CancellationToken)"/>
    Task<ConfigurationSingle> RetrieveValue(
        ApiEnum<string, ConfigValueFilter> name,
        ConfigurationRetrieveValueParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Set a single configuration value. Not all configuration values can be updated so
    /// the list of accepted configuration variables is small.
    /// </summary>
    Task<ConfigurationSingle> UpdateValue(
        ConfigurationUpdateValueParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UpdateValue(ConfigurationUpdateValueParams, CancellationToken)"/>
    Task<ConfigurationSingle> UpdateValue(
        ApiEnum<string, Name> name,
        ConfigurationUpdateValueParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IConfigurationService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IConfigurationServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IConfigurationServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/configuration</c>, but is otherwise the
    /// same as <see cref="IConfigurationService.Retrieve(ConfigurationRetrieveParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<ConfigurationConfiguration>>> Retrieve(
        ConfigurationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/configuration/{name}</c>, but is otherwise the
    /// same as <see cref="IConfigurationService.RetrieveValue(ConfigurationRetrieveValueParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ConfigurationSingle>> RetrieveValue(
        ConfigurationRetrieveValueParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveValue(ConfigurationRetrieveValueParams, CancellationToken)"/>
    Task<HttpResponse<ConfigurationSingle>> RetrieveValue(
        ApiEnum<string, ConfigValueFilter> name,
        ConfigurationRetrieveValueParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /v1/configuration/{name}</c>, but is otherwise the
    /// same as <see cref="IConfigurationService.UpdateValue(ConfigurationUpdateValueParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ConfigurationSingle>> UpdateValue(
        ConfigurationUpdateValueParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UpdateValue(ConfigurationUpdateValueParams, CancellationToken)"/>
    Task<HttpResponse<ConfigurationSingle>> UpdateValue(
        ApiEnum<string, Name> name,
        ConfigurationUpdateValueParams parameters,
        CancellationToken cancellationToken = default
    );
}
