using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Firefly.Core;
using Firefly.Exceptions;
using Firefly.Models.Accounts;
using Firefly.Models.LinkTypes;

namespace Firefly.Services;

/// <inheritdoc/>
public sealed class LinkTypeService : ILinkTypeService
{
    readonly Lazy<ILinkTypeServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ILinkTypeServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IFireflyClient _client;

    /// <inheritdoc/>
    public ILinkTypeService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new LinkTypeService(this._client.WithOptions(modifier));
    }

    public LinkTypeService(IFireflyClient client)
    {
        _client = client;

        _withRawResponse = new(() => new LinkTypeServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<LinkTypeSingle> Create(
        LinkTypeCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<LinkTypeSingle> Retrieve(
        LinkTypeRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<LinkTypeSingle> Retrieve(
        string id,
        LinkTypeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<LinkTypeSingle> Update(
        LinkTypeUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<LinkTypeSingle> Update(
        string id,
        LinkTypeUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<LinkTypeListResponse> List(
        LinkTypeListParams? parameters = null,
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
        LinkTypeDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string id,
        LinkTypeDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<TransactionArray> ListTransactions(
        LinkTypeListTransactionsParams parameters,
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
        LinkTypeListTransactionsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListTransactions(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class LinkTypeServiceWithRawResponse : ILinkTypeServiceWithRawResponse
{
    readonly IFireflyClientWithRawResponse _client;

    /// <inheritdoc/>
    public ILinkTypeServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new LinkTypeServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public LinkTypeServiceWithRawResponse(IFireflyClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<LinkTypeSingle>> Create(
        LinkTypeCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<LinkTypeCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var linkTypeSingle = await response
                    .Deserialize<LinkTypeSingle>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    linkTypeSingle.Validate();
                }
                return linkTypeSingle;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<LinkTypeSingle>> Retrieve(
        LinkTypeRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new FireflyInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<LinkTypeRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var linkTypeSingle = await response
                    .Deserialize<LinkTypeSingle>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    linkTypeSingle.Validate();
                }
                return linkTypeSingle;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<LinkTypeSingle>> Retrieve(
        string id,
        LinkTypeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<LinkTypeSingle>> Update(
        LinkTypeUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new FireflyInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<LinkTypeUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var linkTypeSingle = await response
                    .Deserialize<LinkTypeSingle>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    linkTypeSingle.Validate();
                }
                return linkTypeSingle;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<LinkTypeSingle>> Update(
        string id,
        LinkTypeUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<LinkTypeListResponse>> List(
        LinkTypeListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<LinkTypeListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var linkTypes = await response
                    .Deserialize<LinkTypeListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    linkTypes.Validate();
                }
                return linkTypes;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        LinkTypeDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new FireflyInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<LinkTypeDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string id,
        LinkTypeDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TransactionArray>> ListTransactions(
        LinkTypeListTransactionsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new FireflyInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<LinkTypeListTransactionsParams> request = new()
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
        LinkTypeListTransactionsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListTransactions(parameters with { ID = id }, cancellationToken);
    }
}
