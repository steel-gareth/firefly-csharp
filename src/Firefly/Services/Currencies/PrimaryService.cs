using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Firefly.Core;
using Firefly.Exceptions;
using Firefly.Models.Currencies;
using Firefly.Models.Currencies.Primary;

namespace Firefly.Services.Currencies;

/// <inheritdoc/>
public sealed class PrimaryService : IPrimaryService
{
    readonly Lazy<IPrimaryServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPrimaryServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IFireflyClient _client;

    /// <inheritdoc/>
    public IPrimaryService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PrimaryService(this._client.WithOptions(modifier));
    }

    public PrimaryService(IFireflyClient client)
    {
        _client = client;

        _withRawResponse = new(() => new PrimaryServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<CurrencySingle> Retrieve(
        PrimaryRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CurrencySingle> MakePrimary(
        PrimaryMakePrimaryParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.MakePrimary(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CurrencySingle> MakePrimary(
        string code,
        PrimaryMakePrimaryParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.MakePrimary(parameters with { Code = code }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class PrimaryServiceWithRawResponse : IPrimaryServiceWithRawResponse
{
    readonly IFireflyClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPrimaryServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PrimaryServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PrimaryServiceWithRawResponse(IFireflyClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CurrencySingle>> Retrieve(
        PrimaryRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<PrimaryRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var currencySingle = await response
                    .Deserialize<CurrencySingle>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    currencySingle.Validate();
                }
                return currencySingle;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CurrencySingle>> MakePrimary(
        PrimaryMakePrimaryParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Code == null)
        {
            throw new FireflyInvalidDataException("'parameters.Code' cannot be null");
        }

        HttpRequest<PrimaryMakePrimaryParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var currencySingle = await response
                    .Deserialize<CurrencySingle>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    currencySingle.Validate();
                }
                return currencySingle;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CurrencySingle>> MakePrimary(
        string code,
        PrimaryMakePrimaryParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.MakePrimary(parameters with { Code = code }, cancellationToken);
    }
}
