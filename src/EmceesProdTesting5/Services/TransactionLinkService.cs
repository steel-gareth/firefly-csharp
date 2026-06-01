using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Exceptions;
using EmceesProdTesting5.Models.TransactionLinks;

namespace EmceesProdTesting5.Services;

/// <inheritdoc/>
public sealed class TransactionLinkService : ITransactionLinkService
{
    readonly Lazy<ITransactionLinkServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ITransactionLinkServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IEmceesProdTesting5Client _client;

    /// <inheritdoc/>
    public ITransactionLinkService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TransactionLinkService(this._client.WithOptions(modifier));
    }

    public TransactionLinkService(IEmceesProdTesting5Client client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new TransactionLinkServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<TransactionLinkSingle> Create(
        TransactionLinkCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<TransactionLinkSingle> Retrieve(
        TransactionLinkRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<TransactionLinkSingle> Retrieve(
        string id,
        TransactionLinkRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TransactionLinkSingle> Update(
        TransactionLinkUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<TransactionLinkSingle> Update(
        string id,
        TransactionLinkUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TransactionLinkArray> List(
        TransactionLinkListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(
        TransactionLinkDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string id,
        TransactionLinkDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class TransactionLinkServiceWithRawResponse : ITransactionLinkServiceWithRawResponse
{
    readonly IEmceesProdTesting5ClientWithRawResponse _client;

    /// <inheritdoc/>
    public ITransactionLinkServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new TransactionLinkServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public TransactionLinkServiceWithRawResponse(IEmceesProdTesting5ClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TransactionLinkSingle>> Create(
        TransactionLinkCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<TransactionLinkCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var transactionLinkSingle = await response
                    .Deserialize<TransactionLinkSingle>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    transactionLinkSingle.Validate();
                }
                return transactionLinkSingle;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TransactionLinkSingle>> Retrieve(
        TransactionLinkRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new EmceesProdTesting5InvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<TransactionLinkRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var transactionLinkSingle = await response
                    .Deserialize<TransactionLinkSingle>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    transactionLinkSingle.Validate();
                }
                return transactionLinkSingle;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<TransactionLinkSingle>> Retrieve(
        string id,
        TransactionLinkRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TransactionLinkSingle>> Update(
        TransactionLinkUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new EmceesProdTesting5InvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<TransactionLinkUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var transactionLinkSingle = await response
                    .Deserialize<TransactionLinkSingle>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    transactionLinkSingle.Validate();
                }
                return transactionLinkSingle;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<TransactionLinkSingle>> Update(
        string id,
        TransactionLinkUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TransactionLinkArray>> List(
        TransactionLinkListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<TransactionLinkListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var transactionLinkArray = await response
                    .Deserialize<TransactionLinkArray>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    transactionLinkArray.Validate();
                }
                return transactionLinkArray;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        TransactionLinkDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new EmceesProdTesting5InvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<TransactionLinkDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string id,
        TransactionLinkDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { ID = id }, cancellationToken);
    }
}
