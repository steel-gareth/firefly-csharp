using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Exceptions;
using EmceesProdTesting5.Models.Accounts;
using EmceesProdTesting5.Models.PiggyBanks;

namespace EmceesProdTesting5.Services;

/// <inheritdoc/>
public sealed class PiggyBankService : IPiggyBankService
{
    readonly Lazy<IPiggyBankServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPiggyBankServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IEmceesProdTesting5Client _client;

    /// <inheritdoc/>
    public IPiggyBankService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PiggyBankService(this._client.WithOptions(modifier));
    }

    public PiggyBankService(IEmceesProdTesting5Client client)
    {
        _client = client;

        _withRawResponse = new(() => new PiggyBankServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<PiggyBankSingle> Create(
        PiggyBankCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<PiggyBankSingle> Retrieve(
        PiggyBankRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PiggyBankSingle> Retrieve(
        string id,
        PiggyBankRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PiggyBankSingle> Update(
        PiggyBankUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PiggyBankSingle> Update(
        string id,
        PiggyBankUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PiggyBankArray> List(
        PiggyBankListParams? parameters = null,
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
        PiggyBankDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string id,
        PiggyBankDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<AttachmentArray> ListAttachments(
        PiggyBankListAttachmentsParams parameters,
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
        PiggyBankListAttachmentsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListAttachments(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PiggyBankEventArray> ListEvents(
        PiggyBankListEventsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListEvents(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PiggyBankEventArray> ListEvents(
        string id,
        PiggyBankListEventsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListEvents(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class PiggyBankServiceWithRawResponse : IPiggyBankServiceWithRawResponse
{
    readonly IEmceesProdTesting5ClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPiggyBankServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PiggyBankServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PiggyBankServiceWithRawResponse(IEmceesProdTesting5ClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PiggyBankSingle>> Create(
        PiggyBankCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<PiggyBankCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var piggyBankSingle = await response
                    .Deserialize<PiggyBankSingle>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    piggyBankSingle.Validate();
                }
                return piggyBankSingle;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PiggyBankSingle>> Retrieve(
        PiggyBankRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new EmceesProdTesting5InvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<PiggyBankRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var piggyBankSingle = await response
                    .Deserialize<PiggyBankSingle>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    piggyBankSingle.Validate();
                }
                return piggyBankSingle;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<PiggyBankSingle>> Retrieve(
        string id,
        PiggyBankRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PiggyBankSingle>> Update(
        PiggyBankUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new EmceesProdTesting5InvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<PiggyBankUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var piggyBankSingle = await response
                    .Deserialize<PiggyBankSingle>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    piggyBankSingle.Validate();
                }
                return piggyBankSingle;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<PiggyBankSingle>> Update(
        string id,
        PiggyBankUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PiggyBankArray>> List(
        PiggyBankListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<PiggyBankListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var piggyBankArray = await response
                    .Deserialize<PiggyBankArray>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    piggyBankArray.Validate();
                }
                return piggyBankArray;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        PiggyBankDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new EmceesProdTesting5InvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<PiggyBankDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string id,
        PiggyBankDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AttachmentArray>> ListAttachments(
        PiggyBankListAttachmentsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new EmceesProdTesting5InvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<PiggyBankListAttachmentsParams> request = new()
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
        PiggyBankListAttachmentsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListAttachments(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PiggyBankEventArray>> ListEvents(
        PiggyBankListEventsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new EmceesProdTesting5InvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<PiggyBankListEventsParams> request = new()
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
    public Task<HttpResponse<PiggyBankEventArray>> ListEvents(
        string id,
        PiggyBankListEventsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListEvents(parameters with { ID = id }, cancellationToken);
    }
}
