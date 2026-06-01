using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Firefly.Core;
using Firefly.Exceptions;
using Firefly.Models.Configuration;

namespace Firefly.Services;

/// <inheritdoc/>
public sealed class ConfigurationService : IConfigurationService
{
    readonly Lazy<IConfigurationServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IConfigurationServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IFireflyClient _client;

    /// <inheritdoc/>
    public IConfigurationService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ConfigurationService(this._client.WithOptions(modifier));
    }

    public ConfigurationService(IFireflyClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new ConfigurationServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<List<ConfigurationConfiguration>> Retrieve(
        ConfigurationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ConfigurationSingle> RetrieveValue(
        ConfigurationRetrieveValueParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveValue(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ConfigurationSingle> RetrieveValue(
        ApiEnum<string, ConfigValueFilter> name,
        ConfigurationRetrieveValueParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveValue(parameters with { Name = name }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ConfigurationSingle> UpdateValue(
        ConfigurationUpdateValueParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.UpdateValue(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ConfigurationSingle> UpdateValue(
        ApiEnum<string, Name> name,
        ConfigurationUpdateValueParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UpdateValue(parameters with { Name = name }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class ConfigurationServiceWithRawResponse : IConfigurationServiceWithRawResponse
{
    readonly IFireflyClientWithRawResponse _client;

    /// <inheritdoc/>
    public IConfigurationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ConfigurationServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ConfigurationServiceWithRawResponse(IFireflyClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<ConfigurationConfiguration>>> Retrieve(
        ConfigurationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ConfigurationRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var configurations = await response
                    .Deserialize<List<ConfigurationConfiguration>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in configurations)
                    {
                        item.Validate();
                    }
                }
                return configurations;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ConfigurationSingle>> RetrieveValue(
        ConfigurationRetrieveValueParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Name == null)
        {
            throw new FireflyInvalidDataException("'parameters.Name' cannot be null");
        }

        HttpRequest<ConfigurationRetrieveValueParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var configurationSingle = await response
                    .Deserialize<ConfigurationSingle>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    configurationSingle.Validate();
                }
                return configurationSingle;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ConfigurationSingle>> RetrieveValue(
        ApiEnum<string, ConfigValueFilter> name,
        ConfigurationRetrieveValueParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveValue(parameters with { Name = name }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ConfigurationSingle>> UpdateValue(
        ConfigurationUpdateValueParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Name == null)
        {
            throw new FireflyInvalidDataException("'parameters.Name' cannot be null");
        }

        HttpRequest<ConfigurationUpdateValueParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var configurationSingle = await response
                    .Deserialize<ConfigurationSingle>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    configurationSingle.Validate();
                }
                return configurationSingle;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ConfigurationSingle>> UpdateValue(
        ApiEnum<string, Name> name,
        ConfigurationUpdateValueParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UpdateValue(parameters with { Name = name }, cancellationToken);
    }
}
