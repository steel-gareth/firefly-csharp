using System;
using System.Threading;
using System.Threading.Tasks;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Accounts;
using EmceesProdTesting5.Models.PiggyBanks;

namespace EmceesProdTesting5.Services;

/// <summary>
/// Endpoints to control and manage all of the user&amp;#039;s piggy banks and related
/// objects and information.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IPiggyBankService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPiggyBankServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPiggyBankService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Creates a new piggy bank. The data required can be submitted as a JSON body or
    /// as a list of parameters.
    /// </summary>
    Task<PiggyBankSingle> Create(
        PiggyBankCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a single piggy bank.
    /// </summary>
    Task<PiggyBankSingle> Retrieve(
        PiggyBankRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(PiggyBankRetrieveParams, CancellationToken)"/>
    Task<PiggyBankSingle> Retrieve(
        string id,
        PiggyBankRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update existing piggy bank.
    /// </summary>
    Task<PiggyBankSingle> Update(
        PiggyBankUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(PiggyBankUpdateParams, CancellationToken)"/>
    Task<PiggyBankSingle> Update(
        string id,
        PiggyBankUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List all piggy banks.
    /// </summary>
    Task<PiggyBankArray> List(
        PiggyBankListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a piggy bank.
    /// </summary>
    Task Delete(PiggyBankDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(PiggyBankDeleteParams, CancellationToken)"/>
    Task Delete(
        string id,
        PiggyBankDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Lists all attachments.
    /// </summary>
    Task<AttachmentArray> ListAttachments(
        PiggyBankListAttachmentsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListAttachments(PiggyBankListAttachmentsParams, CancellationToken)"/>
    Task<AttachmentArray> ListAttachments(
        string id,
        PiggyBankListAttachmentsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List all events linked to a piggy bank (adding and removing money).
    /// </summary>
    Task<PiggyBankEventArray> ListEvents(
        PiggyBankListEventsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListEvents(PiggyBankListEventsParams, CancellationToken)"/>
    Task<PiggyBankEventArray> ListEvents(
        string id,
        PiggyBankListEventsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IPiggyBankService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPiggyBankServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPiggyBankServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/piggy-banks</c>, but is otherwise the
    /// same as <see cref="IPiggyBankService.Create(PiggyBankCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PiggyBankSingle>> Create(
        PiggyBankCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/piggy-banks/{id}</c>, but is otherwise the
    /// same as <see cref="IPiggyBankService.Retrieve(PiggyBankRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PiggyBankSingle>> Retrieve(
        PiggyBankRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(PiggyBankRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<PiggyBankSingle>> Retrieve(
        string id,
        PiggyBankRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /v1/piggy-banks/{id}</c>, but is otherwise the
    /// same as <see cref="IPiggyBankService.Update(PiggyBankUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PiggyBankSingle>> Update(
        PiggyBankUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(PiggyBankUpdateParams, CancellationToken)"/>
    Task<HttpResponse<PiggyBankSingle>> Update(
        string id,
        PiggyBankUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/piggy-banks</c>, but is otherwise the
    /// same as <see cref="IPiggyBankService.List(PiggyBankListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PiggyBankArray>> List(
        PiggyBankListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/piggy-banks/{id}</c>, but is otherwise the
    /// same as <see cref="IPiggyBankService.Delete(PiggyBankDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        PiggyBankDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(PiggyBankDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string id,
        PiggyBankDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/piggy-banks/{id}/attachments</c>, but is otherwise the
    /// same as <see cref="IPiggyBankService.ListAttachments(PiggyBankListAttachmentsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AttachmentArray>> ListAttachments(
        PiggyBankListAttachmentsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListAttachments(PiggyBankListAttachmentsParams, CancellationToken)"/>
    Task<HttpResponse<AttachmentArray>> ListAttachments(
        string id,
        PiggyBankListAttachmentsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/piggy-banks/{id}/events</c>, but is otherwise the
    /// same as <see cref="IPiggyBankService.ListEvents(PiggyBankListEventsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PiggyBankEventArray>> ListEvents(
        PiggyBankListEventsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListEvents(PiggyBankListEventsParams, CancellationToken)"/>
    Task<HttpResponse<PiggyBankEventArray>> ListEvents(
        string id,
        PiggyBankListEventsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
