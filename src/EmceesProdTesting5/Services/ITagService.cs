using System;
using System.Threading;
using System.Threading.Tasks;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Accounts;
using EmceesProdTesting5.Models.Tags;

namespace EmceesProdTesting5.Services;

/// <summary>
/// This endpoint manages all of the user&amp;#039;s tags.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ITagService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ITagServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITagService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Creates a new tag. The data required can be submitted as a JSON body or as a
    /// list of parameters.
    /// </summary>
    Task<TagSingle> Create(
        TagCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a single tag.
    /// </summary>
    Task<TagSingle> Retrieve(
        TagRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(TagRetrieveParams, CancellationToken)"/>
    Task<TagSingle> Retrieve(
        string tag,
        TagRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update existing tag.
    /// </summary>
    Task<TagSingle> Update(
        TagUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(TagUpdateParams, CancellationToken)"/>
    Task<TagSingle> Update(
        string tag,
        TagUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List all of the user's tags.
    /// </summary>
    Task<TagListResponse> List(
        TagListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete an tag.
    /// </summary>
    Task Delete(TagDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(TagDeleteParams, CancellationToken)"/>
    Task Delete(
        string tag,
        TagDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Lists all attachments.
    /// </summary>
    Task<AttachmentArray> ListAttachments(
        TagListAttachmentsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListAttachments(TagListAttachmentsParams, CancellationToken)"/>
    Task<AttachmentArray> ListAttachments(
        string tag,
        TagListAttachmentsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List all transactions with this tag.
    /// </summary>
    Task<TransactionArray> ListTransactions(
        TagListTransactionsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListTransactions(TagListTransactionsParams, CancellationToken)"/>
    Task<TransactionArray> ListTransactions(
        string tag,
        TagListTransactionsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ITagService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ITagServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITagServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/tags</c>, but is otherwise the
    /// same as <see cref="ITagService.Create(TagCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TagSingle>> Create(
        TagCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/tags/{tag}</c>, but is otherwise the
    /// same as <see cref="ITagService.Retrieve(TagRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TagSingle>> Retrieve(
        TagRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(TagRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<TagSingle>> Retrieve(
        string tag,
        TagRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /v1/tags/{tag}</c>, but is otherwise the
    /// same as <see cref="ITagService.Update(TagUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TagSingle>> Update(
        TagUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(TagUpdateParams, CancellationToken)"/>
    Task<HttpResponse<TagSingle>> Update(
        string tag,
        TagUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/tags</c>, but is otherwise the
    /// same as <see cref="ITagService.List(TagListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TagListResponse>> List(
        TagListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/tags/{tag}</c>, but is otherwise the
    /// same as <see cref="ITagService.Delete(TagDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        TagDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(TagDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string tag,
        TagDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/tags/{tag}/attachments</c>, but is otherwise the
    /// same as <see cref="ITagService.ListAttachments(TagListAttachmentsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AttachmentArray>> ListAttachments(
        TagListAttachmentsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListAttachments(TagListAttachmentsParams, CancellationToken)"/>
    Task<HttpResponse<AttachmentArray>> ListAttachments(
        string tag,
        TagListAttachmentsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/tags/{tag}/transactions</c>, but is otherwise the
    /// same as <see cref="ITagService.ListTransactions(TagListTransactionsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TransactionArray>> ListTransactions(
        TagListTransactionsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListTransactions(TagListTransactionsParams, CancellationToken)"/>
    Task<HttpResponse<TransactionArray>> ListTransactions(
        string tag,
        TagListTransactionsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
