using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Exceptions;
using EmceesProdTesting5.Models.AvailableBudgets;

namespace EmceesProdTesting5.Services;

/// <inheritdoc/>
public sealed class AvailableBudgetService : IAvailableBudgetService
{
    readonly Lazy<IAvailableBudgetServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAvailableBudgetServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IEmceesProdTesting5Client _client;

    /// <inheritdoc/>
    public IAvailableBudgetService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AvailableBudgetService(this._client.WithOptions(modifier));
    }

    public AvailableBudgetService(IEmceesProdTesting5Client client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new AvailableBudgetServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<AvailableBudgetRetrieveResponse> Retrieve(
        AvailableBudgetRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AvailableBudgetRetrieveResponse> Retrieve(
        string id,
        AvailableBudgetRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AvailableBudgetArray> List(
        AvailableBudgetListParams? parameters = null,
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
public sealed class AvailableBudgetServiceWithRawResponse : IAvailableBudgetServiceWithRawResponse
{
    readonly IEmceesProdTesting5ClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAvailableBudgetServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new AvailableBudgetServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AvailableBudgetServiceWithRawResponse(IEmceesProdTesting5ClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AvailableBudgetRetrieveResponse>> Retrieve(
        AvailableBudgetRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new EmceesProdTesting5InvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<AvailableBudgetRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var availableBudget = await response
                    .Deserialize<AvailableBudgetRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    availableBudget.Validate();
                }
                return availableBudget;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<AvailableBudgetRetrieveResponse>> Retrieve(
        string id,
        AvailableBudgetRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AvailableBudgetArray>> List(
        AvailableBudgetListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AvailableBudgetListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var availableBudgetArray = await response
                    .Deserialize<AvailableBudgetArray>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    availableBudgetArray.Validate();
                }
                return availableBudgetArray;
            }
        );
    }
}
