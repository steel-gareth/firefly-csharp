using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.About;

namespace EmceesProdTesting5.Services;

/// <inheritdoc/>
public sealed class AboutService : IAboutService
{
    readonly Lazy<IAboutServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAboutServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IEmceesProdTesting5Client _client;

    /// <inheritdoc/>
    public IAboutService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AboutService(this._client.WithOptions(modifier));
    }

    public AboutService(IEmceesProdTesting5Client client)
    {
        _client = client;

        _withRawResponse = new(() => new AboutServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<AboutRetrieveInfoResponse> RetrieveInfo(
        AboutRetrieveInfoParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveInfo(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<UserSingle> RetrieveUser(
        AboutRetrieveUserParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveUser(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class AboutServiceWithRawResponse : IAboutServiceWithRawResponse
{
    readonly IEmceesProdTesting5ClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAboutServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AboutServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AboutServiceWithRawResponse(IEmceesProdTesting5ClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AboutRetrieveInfoResponse>> RetrieveInfo(
        AboutRetrieveInfoParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AboutRetrieveInfoParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<AboutRetrieveInfoResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UserSingle>> RetrieveUser(
        AboutRetrieveUserParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AboutRetrieveUserParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var userSingle = await response
                    .Deserialize<UserSingle>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    userSingle.Validate();
                }
                return userSingle;
            }
        );
    }
}
