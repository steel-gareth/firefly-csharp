using System;
using System.Threading;
using System.Threading.Tasks;
using Firefly.Core;
using Firefly.Models.Webhooks.Messages;
using Firefly.Services.Webhooks.Messages;

namespace Firefly.Services.Webhooks;

/// <summary>
/// These endpoints can be used to manage the user&amp;#039;s webhooks and triggers
/// them if necessary.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IMessageService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IMessageServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMessageService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IAttemptService Attempts { get; }

    /// <summary>
    /// When a webhook is triggered it will store the actual content of the webhook in a
    /// webhook message. You can view and analyse a single one using this endpoint.
    /// </summary>
    Task<MessageRetrieveResponse> Retrieve(
        MessageRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(MessageRetrieveParams, CancellationToken)"/>
    Task<MessageRetrieveResponse> Retrieve(
        long messageID,
        MessageRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// When a webhook is triggered the actual message that will be send is stored in a
    /// "message". You can view and analyse these messages.
    /// </summary>
    Task<MessageListResponse> List(
        MessageListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(MessageListParams, CancellationToken)"/>
    Task<MessageListResponse> List(
        string id,
        MessageListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a webhook message. Any time a webhook is triggered the message is stored
    /// before it's sent. You can delete them before or after sending.
    /// </summary>
    Task Delete(MessageDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(MessageDeleteParams, CancellationToken)"/>
    Task Delete(
        long messageID,
        MessageDeleteParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IMessageService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IMessageServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMessageServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IAttemptServiceWithRawResponse Attempts { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/webhooks/{id}/messages/{messageId}</c>, but is otherwise the
    /// same as <see cref="IMessageService.Retrieve(MessageRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<MessageRetrieveResponse>> Retrieve(
        MessageRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(MessageRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<MessageRetrieveResponse>> Retrieve(
        long messageID,
        MessageRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/webhooks/{id}/messages</c>, but is otherwise the
    /// same as <see cref="IMessageService.List(MessageListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<MessageListResponse>> List(
        MessageListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(MessageListParams, CancellationToken)"/>
    Task<HttpResponse<MessageListResponse>> List(
        string id,
        MessageListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/webhooks/{id}/messages/{messageId}</c>, but is otherwise the
    /// same as <see cref="IMessageService.Delete(MessageDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        MessageDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(MessageDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        long messageID,
        MessageDeleteParams parameters,
        CancellationToken cancellationToken = default
    );
}
