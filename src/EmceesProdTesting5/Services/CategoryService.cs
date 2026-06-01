using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Exceptions;
using EmceesProdTesting5.Models.Accounts;
using EmceesProdTesting5.Models.Categories;

namespace EmceesProdTesting5.Services;

/// <inheritdoc/>
public sealed class CategoryService : ICategoryService
{
    readonly Lazy<ICategoryServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICategoryServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IEmceesProdTesting5Client _client;

    /// <inheritdoc/>
    public ICategoryService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CategoryService(this._client.WithOptions(modifier));
    }

    public CategoryService(IEmceesProdTesting5Client client)
    {
        _client = client;

        _withRawResponse = new(() => new CategoryServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<CategorySingle> Create(
        CategoryCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CategorySingle> Retrieve(
        CategoryRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CategorySingle> Retrieve(
        string id,
        CategoryRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CategorySingle> Update(
        CategoryUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CategorySingle> Update(
        string id,
        CategoryUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CategoryListResponse> List(
        CategoryListParams? parameters = null,
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
        CategoryDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string id,
        CategoryDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<AttachmentArray> ListAttachments(
        CategoryListAttachmentsParams parameters,
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
        CategoryListAttachmentsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListAttachments(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TransactionArray> ListTransactions(
        CategoryListTransactionsParams parameters,
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
        CategoryListTransactionsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListTransactions(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class CategoryServiceWithRawResponse : ICategoryServiceWithRawResponse
{
    readonly IEmceesProdTesting5ClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICategoryServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CategoryServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CategoryServiceWithRawResponse(IEmceesProdTesting5ClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CategorySingle>> Create(
        CategoryCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CategoryCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var categorySingle = await response
                    .Deserialize<CategorySingle>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    categorySingle.Validate();
                }
                return categorySingle;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CategorySingle>> Retrieve(
        CategoryRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new EmceesProdTesting5InvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<CategoryRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var categorySingle = await response
                    .Deserialize<CategorySingle>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    categorySingle.Validate();
                }
                return categorySingle;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CategorySingle>> Retrieve(
        string id,
        CategoryRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CategorySingle>> Update(
        CategoryUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new EmceesProdTesting5InvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<CategoryUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var categorySingle = await response
                    .Deserialize<CategorySingle>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    categorySingle.Validate();
                }
                return categorySingle;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CategorySingle>> Update(
        string id,
        CategoryUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CategoryListResponse>> List(
        CategoryListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<CategoryListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var categories = await response
                    .Deserialize<CategoryListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    categories.Validate();
                }
                return categories;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        CategoryDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new EmceesProdTesting5InvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<CategoryDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string id,
        CategoryDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AttachmentArray>> ListAttachments(
        CategoryListAttachmentsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new EmceesProdTesting5InvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<CategoryListAttachmentsParams> request = new()
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
        CategoryListAttachmentsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListAttachments(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TransactionArray>> ListTransactions(
        CategoryListTransactionsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new EmceesProdTesting5InvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<CategoryListTransactionsParams> request = new()
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
        CategoryListTransactionsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListTransactions(parameters with { ID = id }, cancellationToken);
    }
}
