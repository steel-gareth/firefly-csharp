using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Firefly.Core;
using Firefly.Exceptions;
using Firefly.Models.Preferences;

namespace Firefly.Services;

/// <inheritdoc/>
public sealed class PreferenceService : IPreferenceService
{
    readonly Lazy<IPreferenceServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPreferenceServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IFireflyClient _client;

    /// <inheritdoc/>
    public IPreferenceService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PreferenceService(this._client.WithOptions(modifier));
    }

    public PreferenceService(IFireflyClient client)
    {
        _client = client;

        _withRawResponse = new(() => new PreferenceServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<PreferenceSingle> Create(
        PreferenceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<PreferenceSingle> Retrieve(
        PreferenceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PreferenceSingle> Retrieve(
        string name,
        PreferenceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { Name = name }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PreferenceSingle> Update(
        PreferenceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PreferenceSingle> Update(
        string name,
        PreferenceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { Name = name }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PreferenceListResponse> List(
        PreferenceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class PreferenceServiceWithRawResponse : IPreferenceServiceWithRawResponse
{
    readonly IFireflyClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPreferenceServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new PreferenceServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PreferenceServiceWithRawResponse(IFireflyClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PreferenceSingle>> Create(
        PreferenceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<PreferenceCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var preferenceSingle = await response
                    .Deserialize<PreferenceSingle>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    preferenceSingle.Validate();
                }
                return preferenceSingle;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PreferenceSingle>> Retrieve(
        PreferenceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Name == null)
        {
            throw new FireflyInvalidDataException("'parameters.Name' cannot be null");
        }

        HttpRequest<PreferenceRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var preferenceSingle = await response
                    .Deserialize<PreferenceSingle>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    preferenceSingle.Validate();
                }
                return preferenceSingle;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<PreferenceSingle>> Retrieve(
        string name,
        PreferenceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { Name = name }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PreferenceSingle>> Update(
        PreferenceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Name == null)
        {
            throw new FireflyInvalidDataException("'parameters.Name' cannot be null");
        }

        HttpRequest<PreferenceUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var preferenceSingle = await response
                    .Deserialize<PreferenceSingle>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    preferenceSingle.Validate();
                }
                return preferenceSingle;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<PreferenceSingle>> Update(
        string name,
        PreferenceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { Name = name }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PreferenceListResponse>> List(
        PreferenceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<PreferenceListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var preferences = await response
                    .Deserialize<PreferenceListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    preferences.Validate();
                }
                return preferences;
            }
        );
    }
}
