using System;
using System.Threading;
using System.Threading.Tasks;
using Firefly.Core;
using Firefly.Models.Webhooks.Messages.Attempts;

namespace Firefly.Services.Webhooks.Messages;

/// <summary>
/// These endpoints can be used to manage the user&amp;#039;s webhooks and triggers
/// them if necessary.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IAttemptService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAttemptServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAttemptService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// When a webhook message fails to send it will store the failure in an "attempt".
    /// You can view and analyse these. Webhooks messages that receive too many attempts
    /// (failures) will not be fired. You must first clear out old attempts and try
    /// again. This endpoint shows you the details of a single attempt. The ID of the
    /// attempt must match the corresponding webhook and webhook message.
    /// </summary>
    Task<AttemptRetrieveResponse> Retrieve(
        AttemptRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(AttemptRetrieveParams, CancellationToken)"/>
    Task<AttemptRetrieveResponse> Retrieve(
        long attemptID,
        AttemptRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// When a webhook message fails to send it will store the failure in an "attempt".
    /// You can view and analyse these. Webhook messages that receive too many attempts
    /// (failures) will not be sent again. You must first clear out old attempts before
    /// the message can go out again.
    /// </summary>
    Task<AttemptListResponse> List(
        AttemptListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(AttemptListParams, CancellationToken)"/>
    Task<AttemptListResponse> List(
        long messageID,
        AttemptListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a webhook message attempt. If you delete all attempts for a webhook
    /// message, Firefly III will (once again) assume all is well with the webhook
    /// message and will try to send it again.
    /// </summary>
    Task Delete(AttemptDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(AttemptDeleteParams, CancellationToken)"/>
    Task Delete(
        long attemptID,
        AttemptDeleteParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IAttemptService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAttemptServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAttemptServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/webhooks/{id}/messages/{messageId}/attempts/{attemptId}</c>, but is otherwise the
    /// same as <see cref="IAttemptService.Retrieve(AttemptRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AttemptRetrieveResponse>> Retrieve(
        AttemptRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(AttemptRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<AttemptRetrieveResponse>> Retrieve(
        long attemptID,
        AttemptRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/webhooks/{id}/messages/{messageId}/attempts</c>, but is otherwise the
    /// same as <see cref="IAttemptService.List(AttemptListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AttemptListResponse>> List(
        AttemptListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(AttemptListParams, CancellationToken)"/>
    Task<HttpResponse<AttemptListResponse>> List(
        long messageID,
        AttemptListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/webhooks/{id}/messages/{messageId}/attempts/{attemptId}</c>, but is otherwise the
    /// same as <see cref="IAttemptService.Delete(AttemptDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        AttemptDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(AttemptDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        long attemptID,
        AttemptDeleteParams parameters,
        CancellationToken cancellationToken = default
    );
}
