using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Exceptions;
using EmceesProdTesting5.Models.Accounts;
using EmceesProdTesting5.Models.Tags;

namespace EmceesProdTesting5.Services;

/// <inheritdoc/>
public sealed class TagService : ITagService
{
    readonly Lazy<ITagServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ITagServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IEmceesProdTesting5Client _client;

    /// <inheritdoc/>
    public ITagService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TagService(this._client.WithOptions(modifier));
    }

    public TagService(IEmceesProdTesting5Client client)
    {
        _client = client;

        _withRawResponse = new(() => new TagServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<TagSingle> Create(
        TagCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<TagSingle> Retrieve(
        TagRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<TagSingle> Retrieve(
        string tag,
        TagRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { Tag = tag }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TagSingle> Update(
        TagUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<TagSingle> Update(
        string tag,
        TagUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { Tag = tag }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TagListResponse> List(
        TagListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(TagDeleteParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string tag,
        TagDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { Tag = tag }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<AttachmentArray> ListAttachments(
        TagListAttachmentsParams parameters,
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
        string tag,
        TagListAttachmentsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListAttachments(parameters with { Tag = tag }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TransactionArray> ListTransactions(
        TagListTransactionsParams parameters,
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
        string tag,
        TagListTransactionsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListTransactions(parameters with { Tag = tag }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class TagServiceWithRawResponse : ITagServiceWithRawResponse
{
    readonly IEmceesProdTesting5ClientWithRawResponse _client;

    /// <inheritdoc/>
    public ITagServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TagServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public TagServiceWithRawResponse(IEmceesProdTesting5ClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TagSingle>> Create(
        TagCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<TagCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var tagSingle = await response.Deserialize<TagSingle>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    tagSingle.Validate();
                }
                return tagSingle;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TagSingle>> Retrieve(
        TagRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Tag == null)
        {
            throw new EmceesProdTesting5InvalidDataException("'parameters.Tag' cannot be null");
        }

        HttpRequest<TagRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var tagSingle = await response.Deserialize<TagSingle>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    tagSingle.Validate();
                }
                return tagSingle;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<TagSingle>> Retrieve(
        string tag,
        TagRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { Tag = tag }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TagSingle>> Update(
        TagUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Tag == null)
        {
            throw new EmceesProdTesting5InvalidDataException("'parameters.Tag' cannot be null");
        }

        HttpRequest<TagUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var tagSingle = await response.Deserialize<TagSingle>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    tagSingle.Validate();
                }
                return tagSingle;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<TagSingle>> Update(
        string tag,
        TagUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { Tag = tag }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TagListResponse>> List(
        TagListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<TagListParams> request = new() { Method = HttpMethod.Get, Params = parameters };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var tags = await response.Deserialize<TagListResponse>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    tags.Validate();
                }
                return tags;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        TagDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Tag == null)
        {
            throw new EmceesProdTesting5InvalidDataException("'parameters.Tag' cannot be null");
        }

        HttpRequest<TagDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string tag,
        TagDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { Tag = tag }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AttachmentArray>> ListAttachments(
        TagListAttachmentsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Tag == null)
        {
            throw new EmceesProdTesting5InvalidDataException("'parameters.Tag' cannot be null");
        }

        HttpRequest<TagListAttachmentsParams> request = new()
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
        string tag,
        TagListAttachmentsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListAttachments(parameters with { Tag = tag }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TransactionArray>> ListTransactions(
        TagListTransactionsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Tag == null)
        {
            throw new EmceesProdTesting5InvalidDataException("'parameters.Tag' cannot be null");
        }

        HttpRequest<TagListTransactionsParams> request = new()
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
        string tag,
        TagListTransactionsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListTransactions(parameters with { Tag = tag }, cancellationToken);
    }
}
