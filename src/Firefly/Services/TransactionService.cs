using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Firefly.Core;
using Firefly.Exceptions;
using Firefly.Models.Accounts;
using Firefly.Models.PiggyBanks;
using Firefly.Models.TransactionJournals;
using Firefly.Models.Transactions;

namespace Firefly.Services;

/// <inheritdoc/>
public sealed class TransactionService : ITransactionService
{
    readonly Lazy<ITransactionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ITransactionServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IFireflyClient _client;

    /// <inheritdoc/>
    public ITransactionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TransactionService(this._client.WithOptions(modifier));
    }

    public TransactionService(IFireflyClient client)
    {
        _client = client;

        _withRawResponse = new(() => new TransactionServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<TransactionSingle> Create(
        TransactionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<TransactionSingle> Retrieve(
        TransactionRetrieveParams parameters,
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
        TransactionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TransactionSingle> Update(
        TransactionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<TransactionSingle> Update(
        string id,
        TransactionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TransactionArray> List(
        TransactionListParams? parameters = null,
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
        TransactionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string id,
        TransactionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<AttachmentArray> ListAttachments(
        TransactionListAttachmentsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListAttachments(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AttachmentArray> ListAttachments(
        string id,
        TransactionListAttachmentsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListAttachments(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PiggyBankEventArray> ListPiggyBankEvents(
        TransactionListPiggyBankEventsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListPiggyBankEvents(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PiggyBankEventArray> ListPiggyBankEvents(
        string id,
        TransactionListPiggyBankEventsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListPiggyBankEvents(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class TransactionServiceWithRawResponse : ITransactionServiceWithRawResponse
{
    readonly IFireflyClientWithRawResponse _client;

    /// <inheritdoc/>
    public ITransactionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new TransactionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public TransactionServiceWithRawResponse(IFireflyClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TransactionSingle>> Create(
        TransactionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<TransactionCreateParams> request = new()
        {
            Method = HttpMethod.Post,
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
    public async Task<HttpResponse<TransactionSingle>> Retrieve(
        TransactionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new FireflyInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<TransactionRetrieveParams> request = new()
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
        TransactionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TransactionSingle>> Update(
        TransactionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new FireflyInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<TransactionUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
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
    public Task<HttpResponse<TransactionSingle>> Update(
        string id,
        TransactionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TransactionArray>> List(
        TransactionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<TransactionListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var transactionArray = await response
                    .Deserialize<TransactionArray>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    transactionArray.Validate();
                }
                return transactionArray;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        TransactionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new FireflyInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<TransactionDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string id,
        TransactionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AttachmentArray>> ListAttachments(
        TransactionListAttachmentsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new FireflyInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<TransactionListAttachmentsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var attachmentArray = await response
                    .Deserialize<AttachmentArray>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    attachmentArray.Validate();
                }
                return attachmentArray;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<AttachmentArray>> ListAttachments(
        string id,
        TransactionListAttachmentsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListAttachments(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PiggyBankEventArray>> ListPiggyBankEvents(
        TransactionListPiggyBankEventsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new FireflyInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<TransactionListPiggyBankEventsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var piggyBankEventArray = await response
                    .Deserialize<PiggyBankEventArray>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    piggyBankEventArray.Validate();
                }
                return piggyBankEventArray;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<PiggyBankEventArray>> ListPiggyBankEvents(
        string id,
        TransactionListPiggyBankEventsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListPiggyBankEvents(parameters with { ID = id }, cancellationToken);
    }
}
