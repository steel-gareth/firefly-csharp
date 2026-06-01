using System;
using System.Threading;
using System.Threading.Tasks;
using Firefly.Core;
using Firefly.Models.Webhooks;
using Firefly.Services.Webhooks;

namespace Firefly.Services;

/// <summary>
/// These endpoints can be used to manage the user&amp;#039;s webhooks and triggers
/// them if necessary.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IWebhookService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IWebhookServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWebhookService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IMessageService Messages { get; }

    /// <summary>
    /// Creates a new webhook. The data required can be submitted as a JSON body or as a
    /// list of parameters. The webhook will be given a random secret.
    /// </summary>
    Task<WebhookSingle> Create(
        WebhookCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Gets all info of a single webhook.
    /// </summary>
    Task<WebhookSingle> Retrieve(
        WebhookRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(WebhookRetrieveParams, CancellationToken)"/>
    Task<WebhookSingle> Retrieve(
        string id,
        WebhookRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update an existing webhook's information. If you wish to reset the secret,
    /// submit any value as the "secret". Firefly III will take this as a hint and reset
    /// the secret of the webhook.
    /// </summary>
    Task<WebhookSingle> Update(
        WebhookUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(WebhookUpdateParams, CancellationToken)"/>
    Task<WebhookSingle> Update(
        string id,
        WebhookUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List all the user's webhooks.
    /// </summary>
    Task<WebhookListResponse> List(
        WebhookListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a webhook.
    /// </summary>
    Task Delete(WebhookDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(WebhookDeleteParams, CancellationToken)"/>
    Task Delete(
        string id,
        WebhookDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint will submit any open messages for this webhook. This is an
    /// asynchronous operation, so you can't see the result. Refresh the webhook message
    /// and/or the webhook message attempts to see the results. This may take some time
    /// if the webhook receiver is slow.
    /// </summary>
    Task Submit(WebhookSubmitParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Submit(WebhookSubmitParams, CancellationToken)"/>
    Task Submit(
        string id,
        WebhookSubmitParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint will execute this webhook for a given transaction ID. This is an
    /// asynchronous operation, so you can't see the result. Refresh the webhook message
    /// and/or the webhook message attempts to see the results. This may take some time
    /// if the webhook receiver is slow.
    /// </summary>
    Task TriggerTransaction(
        WebhookTriggerTransactionParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="TriggerTransaction(WebhookTriggerTransactionParams, CancellationToken)"/>
    Task TriggerTransaction(
        string transactionID,
        WebhookTriggerTransactionParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IWebhookService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IWebhookServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWebhookServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IMessageServiceWithRawResponse Messages { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/webhooks</c>, but is otherwise the
    /// same as <see cref="IWebhookService.Create(WebhookCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WebhookSingle>> Create(
        WebhookCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/webhooks/{id}</c>, but is otherwise the
    /// same as <see cref="IWebhookService.Retrieve(WebhookRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WebhookSingle>> Retrieve(
        WebhookRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(WebhookRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<WebhookSingle>> Retrieve(
        string id,
        WebhookRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /v1/webhooks/{id}</c>, but is otherwise the
    /// same as <see cref="IWebhookService.Update(WebhookUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WebhookSingle>> Update(
        WebhookUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(WebhookUpdateParams, CancellationToken)"/>
    Task<HttpResponse<WebhookSingle>> Update(
        string id,
        WebhookUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/webhooks</c>, but is otherwise the
    /// same as <see cref="IWebhookService.List(WebhookListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WebhookListResponse>> List(
        WebhookListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/webhooks/{id}</c>, but is otherwise the
    /// same as <see cref="IWebhookService.Delete(WebhookDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        WebhookDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(WebhookDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string id,
        WebhookDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/webhooks/{id}/submit</c>, but is otherwise the
    /// same as <see cref="IWebhookService.Submit(WebhookSubmitParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Submit(
        WebhookSubmitParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Submit(WebhookSubmitParams, CancellationToken)"/>
    Task<HttpResponse> Submit(
        string id,
        WebhookSubmitParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/webhooks/{id}/trigger-transaction/{transactionId}</c>, but is otherwise the
    /// same as <see cref="IWebhookService.TriggerTransaction(WebhookTriggerTransactionParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> TriggerTransaction(
        WebhookTriggerTransactionParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="TriggerTransaction(WebhookTriggerTransactionParams, CancellationToken)"/>
    Task<HttpResponse> TriggerTransaction(
        string transactionID,
        WebhookTriggerTransactionParams parameters,
        CancellationToken cancellationToken = default
    );
}
