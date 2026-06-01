using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Exceptions;
using EmceesProdTesting5.Models.Accounts;
using EmceesProdTesting5.Models.Bills;

namespace EmceesProdTesting5.Services;

/// <inheritdoc/>
public sealed class BillService : IBillService
{
    readonly Lazy<IBillServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IBillServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IEmceesProdTesting5Client _client;

    /// <inheritdoc/>
    public IBillService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BillService(this._client.WithOptions(modifier));
    }

    public BillService(IEmceesProdTesting5Client client)
    {
        _client = client;

        _withRawResponse = new(() => new BillServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<BillSingle> Create(
        BillCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BillSingle> Retrieve(
        BillRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BillSingle> Retrieve(
        string id,
        BillRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BillSingle> Update(
        BillUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BillSingle> Update(
        string id,
        BillUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BillArray> List(
        BillListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(BillDeleteParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string id,
        BillDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<AttachmentArray> ListAttachments(
        BillListAttachmentsParams parameters,
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
        BillListAttachmentsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListAttachments(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<RuleArray> ListRules(
        BillListRulesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListRules(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<RuleArray> ListRules(
        string id,
        BillListRulesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListRules(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TransactionArray> ListTransactions(
        BillListTransactionsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListTransactions(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<TransactionArray> ListTransactions(
        string id,
        BillListTransactionsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListTransactions(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class BillServiceWithRawResponse : IBillServiceWithRawResponse
{
    readonly IEmceesProdTesting5ClientWithRawResponse _client;

    /// <inheritdoc/>
    public IBillServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BillServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public BillServiceWithRawResponse(IEmceesProdTesting5ClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BillSingle>> Create(
        BillCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<BillCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var billSingle = await response
                    .Deserialize<BillSingle>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    billSingle.Validate();
                }
                return billSingle;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BillSingle>> Retrieve(
        BillRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new EmceesProdTesting5InvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<BillRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var billSingle = await response
                    .Deserialize<BillSingle>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    billSingle.Validate();
                }
                return billSingle;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BillSingle>> Retrieve(
        string id,
        BillRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BillSingle>> Update(
        BillUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new EmceesProdTesting5InvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<BillUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var billSingle = await response
                    .Deserialize<BillSingle>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    billSingle.Validate();
                }
                return billSingle;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BillSingle>> Update(
        string id,
        BillUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BillArray>> List(
        BillListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<BillListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var billArray = await response.Deserialize<BillArray>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    billArray.Validate();
                }
                return billArray;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        BillDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new EmceesProdTesting5InvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<BillDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string id,
        BillDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AttachmentArray>> ListAttachments(
        BillListAttachmentsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new EmceesProdTesting5InvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<BillListAttachmentsParams> request = new()
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
        BillListAttachmentsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListAttachments(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RuleArray>> ListRules(
        BillListRulesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new EmceesProdTesting5InvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<BillListRulesParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var ruleArray = await response.Deserialize<RuleArray>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    ruleArray.Validate();
                }
                return ruleArray;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<RuleArray>> ListRules(
        string id,
        BillListRulesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListRules(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TransactionArray>> ListTransactions(
        BillListTransactionsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new EmceesProdTesting5InvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<BillListTransactionsParams> request = new()
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
    public Task<HttpResponse<TransactionArray>> ListTransactions(
        string id,
        BillListTransactionsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListTransactions(parameters with { ID = id }, cancellationToken);
    }
}
