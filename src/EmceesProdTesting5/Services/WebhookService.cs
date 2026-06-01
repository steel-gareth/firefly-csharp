using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Exceptions;
using EmceesProdTesting5.Models.Webhooks;
using EmceesProdTesting5.Services.Webhooks;

namespace EmceesProdTesting5.Services;

/// <inheritdoc/>
public sealed class WebhookService : IWebhookService
{
    readonly Lazy<IWebhookServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IWebhookServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IEmceesProdTesting5Client _client;

    /// <inheritdoc/>
    public IWebhookService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new WebhookService(this._client.WithOptions(modifier));
    }

    public WebhookService(IEmceesProdTesting5Client client)
    {
        _client = client;

        _withRawResponse = new(() => new WebhookServiceWithRawResponse(client.WithRawResponse));
        _messages = new(() => new MessageService(client));
    }

    readonly Lazy<IMessageService> _messages;
    public IMessageService Messages
    {
        get { return _messages.Value; }
    }

    /// <inheritdoc/>
    public async Task<WebhookSingle> Create(
        WebhookCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<WebhookSingle> Retrieve(
        WebhookRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<WebhookSingle> Retrieve(
        string id,
        WebhookRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<WebhookSingle> Update(
        WebhookUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<WebhookSingle> Update(
        string id,
        WebhookUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<WebhookListResponse> List(
        WebhookListParams? parameters = null,
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
        WebhookDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string id,
        WebhookDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Submit(
        WebhookSubmitParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Submit(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Submit(
        string id,
        WebhookSubmitParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Submit(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task TriggerTransaction(
        WebhookTriggerTransactionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.TriggerTransaction(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task TriggerTransaction(
        string transactionID,
        WebhookTriggerTransactionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.TriggerTransaction(
                parameters with
                {
                    TransactionID = transactionID,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class WebhookServiceWithRawResponse : IWebhookServiceWithRawResponse
{
    readonly IEmceesProdTesting5ClientWithRawResponse _client;

    /// <inheritdoc/>
    public IWebhookServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new WebhookServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public WebhookServiceWithRawResponse(IEmceesProdTesting5ClientWithRawResponse client)
    {
        _client = client;

        _messages = new(() => new MessageServiceWithRawResponse(client));
    }

    readonly Lazy<IMessageServiceWithRawResponse> _messages;
    public IMessageServiceWithRawResponse Messages
    {
        get { return _messages.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WebhookSingle>> Create(
        WebhookCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<WebhookCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var webhookSingle = await response
                    .Deserialize<WebhookSingle>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    webhookSingle.Validate();
                }
                return webhookSingle;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WebhookSingle>> Retrieve(
        WebhookRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new EmceesProdTesting5InvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<WebhookRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var webhookSingle = await response
                    .Deserialize<WebhookSingle>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    webhookSingle.Validate();
                }
                return webhookSingle;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<WebhookSingle>> Retrieve(
        string id,
        WebhookRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WebhookSingle>> Update(
        WebhookUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new EmceesProdTesting5InvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<WebhookUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var webhookSingle = await response
                    .Deserialize<WebhookSingle>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    webhookSingle.Validate();
                }
                return webhookSingle;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<WebhookSingle>> Update(
        string id,
        WebhookUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WebhookListResponse>> List(
        WebhookListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<WebhookListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var webhooks = await response
                    .Deserialize<WebhookListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    webhooks.Validate();
                }
                return webhooks;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        WebhookDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new EmceesProdTesting5InvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<WebhookDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string id,
        WebhookDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Submit(
        WebhookSubmitParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new EmceesProdTesting5InvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<WebhookSubmitParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Submit(
        string id,
        WebhookSubmitParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Submit(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> TriggerTransaction(
        WebhookTriggerTransactionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TransactionID == null)
        {
            throw new EmceesProdTesting5InvalidDataException(
                "'parameters.TransactionID' cannot be null"
            );
        }

        HttpRequest<WebhookTriggerTransactionParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> TriggerTransaction(
        string transactionID,
        WebhookTriggerTransactionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.TriggerTransaction(
            parameters with
            {
                TransactionID = transactionID,
            },
            cancellationToken
        );
    }
}
