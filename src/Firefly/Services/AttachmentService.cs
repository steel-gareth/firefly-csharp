using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Firefly.Core;
using Firefly.Exceptions;
using Firefly.Models.Accounts;
using Firefly.Models.Attachments;

namespace Firefly.Services;

/// <inheritdoc/>
public sealed class AttachmentService : IAttachmentService
{
    readonly Lazy<IAttachmentServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAttachmentServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IFireflyClient _client;

    /// <inheritdoc/>
    public IAttachmentService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AttachmentService(this._client.WithOptions(modifier));
    }

    public AttachmentService(IFireflyClient client)
    {
        _client = client;

        _withRawResponse = new(() => new AttachmentServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<AttachmentSingle> Create(
        AttachmentCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<AttachmentSingle> Retrieve(
        AttachmentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AttachmentSingle> Retrieve(
        string id,
        AttachmentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AttachmentSingle> Update(
        AttachmentUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AttachmentSingle> Update(
        string id,
        AttachmentUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AttachmentArray> List(
        AttachmentListParams? parameters = null,
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
        AttachmentDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string id,
        AttachmentDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Download(
        AttachmentDownloadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Download(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Download(
        string id,
        AttachmentDownloadParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Download(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Upload(
        AttachmentUploadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Upload(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Upload(
        string id,
        BinaryContent body,
        AttachmentUploadParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Upload(parameters with { ID = id, Body = body }, cancellationToken)
            .ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class AttachmentServiceWithRawResponse : IAttachmentServiceWithRawResponse
{
    readonly IFireflyClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAttachmentServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new AttachmentServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AttachmentServiceWithRawResponse(IFireflyClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AttachmentSingle>> Create(
        AttachmentCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<AttachmentCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var attachmentSingle = await response
                    .Deserialize<AttachmentSingle>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    attachmentSingle.Validate();
                }
                return attachmentSingle;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AttachmentSingle>> Retrieve(
        AttachmentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new FireflyInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<AttachmentRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var attachmentSingle = await response
                    .Deserialize<AttachmentSingle>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    attachmentSingle.Validate();
                }
                return attachmentSingle;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<AttachmentSingle>> Retrieve(
        string id,
        AttachmentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AttachmentSingle>> Update(
        AttachmentUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new FireflyInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<AttachmentUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var attachmentSingle = await response
                    .Deserialize<AttachmentSingle>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    attachmentSingle.Validate();
                }
                return attachmentSingle;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<AttachmentSingle>> Update(
        string id,
        AttachmentUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AttachmentArray>> List(
        AttachmentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AttachmentListParams> request = new()
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
    public Task<HttpResponse> Delete(
        AttachmentDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new FireflyInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<AttachmentDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string id,
        AttachmentDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Download(
        AttachmentDownloadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new FireflyInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<AttachmentDownloadParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Download(
        string id,
        AttachmentDownloadParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Download(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Upload(
        AttachmentUploadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new FireflyInvalidDataException("'parameters.ID' cannot be null");
        }
        if (parameters.Body == null)
        {
            throw new FireflyInvalidDataException("'parameters.Body' cannot be null");
        }

        HttpRequest<AttachmentUploadParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Upload(
        string id,
        BinaryContent body,
        AttachmentUploadParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Upload(parameters with { ID = id, Body = body }, cancellationToken);
    }
}
