using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Exceptions;
using EmceesProdTesting5.Models.TransactionJournals;
using EmceesProdTesting5.Models.TransactionLinks;

namespace EmceesProdTesting5.Services;

/// <inheritdoc/>
public sealed class TransactionJournalService : ITransactionJournalService
{
    readonly Lazy<ITransactionJournalServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ITransactionJournalServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IEmceesProdTesting5Client _client;

    /// <inheritdoc/>
    public ITransactionJournalService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TransactionJournalService(this._client.WithOptions(modifier));
    }

    public TransactionJournalService(IEmceesProdTesting5Client client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new TransactionJournalServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<TransactionSingle> Retrieve(
        TransactionJournalRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<TransactionSingle> Retrieve(
        string id,
        TransactionJournalRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Delete(
        TransactionJournalDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string id,
        TransactionJournalDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<TransactionLinkArray> ListLinks(
        TransactionJournalListLinksParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListLinks(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<TransactionLinkArray> ListLinks(
        string id,
        TransactionJournalListLinksParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListLinks(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class TransactionJournalServiceWithRawResponse
    : ITransactionJournalServiceWithRawResponse
{
    readonly IEmceesProdTesting5ClientWithRawResponse _client;

    /// <inheritdoc/>
    public ITransactionJournalServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new TransactionJournalServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public TransactionJournalServiceWithRawResponse(IEmceesProdTesting5ClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TransactionSingle>> Retrieve(
        TransactionJournalRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new EmceesProdTesting5InvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<TransactionJournalRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var transactionSingle = await response
                    .Deserialize<TransactionSingle>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    transactionSingle.Validate();
                }
                return transactionSingle;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<TransactionSingle>> Retrieve(
        string id,
        TransactionJournalRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        TransactionJournalDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new EmceesProdTesting5InvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<TransactionJournalDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string id,
        TransactionJournalDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TransactionLinkArray>> ListLinks(
        TransactionJournalListLinksParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new EmceesProdTesting5InvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<TransactionJournalListLinksParams> request = new()
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
    public Task<HttpResponse<TransactionLinkArray>> ListLinks(
        string id,
        TransactionJournalListLinksParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListLinks(parameters with { ID = id }, cancellationToken);
    }
}
