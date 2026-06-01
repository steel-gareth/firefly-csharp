using System;
using System.Threading;
using System.Threading.Tasks;
using Firefly.Core;
using Firefly.Models.Accounts;
using Firefly.Models.PiggyBanks;
using Firefly.Models.TransactionJournals;
using Firefly.Models.Transactions;

namespace Firefly.Services;

/// <summary>
/// The most-used endpoints in Firefly III, these endpoints are used to manage the
/// user&amp;#039;s transactions.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ITransactionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ITransactionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITransactionService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Creates a new transaction. The data required can be submitted as a JSON body or
    /// as a list of parameters.
    /// </summary>
    Task<TransactionSingle> Create(
        TransactionCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a single transaction.
    /// </summary>
    Task<TransactionSingle> Retrieve(
        TransactionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(TransactionRetrieveParams, CancellationToken)"/>
    Task<TransactionSingle> Retrieve(
        string id,
        TransactionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update an existing transaction.
    /// </summary>
    Task<TransactionSingle> Update(
        TransactionUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(TransactionUpdateParams, CancellationToken)"/>
    Task<TransactionSingle> Update(
        string id,
        TransactionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List all the user's transactions.
    /// </summary>
    Task<TransactionArray> List(
        TransactionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a transaction.
    /// </summary>
    Task Delete(TransactionDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(TransactionDeleteParams, CancellationToken)"/>
    Task Delete(
        string id,
        TransactionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Lists all attachments.
    /// </summary>
    Task<AttachmentArray> ListAttachments(
        TransactionListAttachmentsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListAttachments(TransactionListAttachmentsParams, CancellationToken)"/>
    Task<AttachmentArray> ListAttachments(
        string id,
        TransactionListAttachmentsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Lists all piggy bank events.
    /// </summary>
    Task<PiggyBankEventArray> ListPiggyBankEvents(
        TransactionListPiggyBankEventsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListPiggyBankEvents(TransactionListPiggyBankEventsParams, CancellationToken)"/>
    Task<PiggyBankEventArray> ListPiggyBankEvents(
        string id,
        TransactionListPiggyBankEventsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ITransactionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ITransactionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITransactionServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/transactions</c>, but is otherwise the
    /// same as <see cref="ITransactionService.Create(TransactionCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TransactionSingle>> Create(
        TransactionCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/transactions/{id}</c>, but is otherwise the
    /// same as <see cref="ITransactionService.Retrieve(TransactionRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TransactionSingle>> Retrieve(
        TransactionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(TransactionRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<TransactionSingle>> Retrieve(
        string id,
        TransactionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /v1/transactions/{id}</c>, but is otherwise the
    /// same as <see cref="ITransactionService.Update(TransactionUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TransactionSingle>> Update(
        TransactionUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(TransactionUpdateParams, CancellationToken)"/>
    Task<HttpResponse<TransactionSingle>> Update(
        string id,
        TransactionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/transactions</c>, but is otherwise the
    /// same as <see cref="ITransactionService.List(TransactionListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TransactionArray>> List(
        TransactionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/transactions/{id}</c>, but is otherwise the
    /// same as <see cref="ITransactionService.Delete(TransactionDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        TransactionDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(TransactionDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string id,
        TransactionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/transactions/{id}/attachments</c>, but is otherwise the
    /// same as <see cref="ITransactionService.ListAttachments(TransactionListAttachmentsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AttachmentArray>> ListAttachments(
        TransactionListAttachmentsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListAttachments(TransactionListAttachmentsParams, CancellationToken)"/>
    Task<HttpResponse<AttachmentArray>> ListAttachments(
        string id,
        TransactionListAttachmentsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/transactions/{id}/piggy-bank-events</c>, but is otherwise the
    /// same as <see cref="ITransactionService.ListPiggyBankEvents(TransactionListPiggyBankEventsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PiggyBankEventArray>> ListPiggyBankEvents(
        TransactionListPiggyBankEventsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListPiggyBankEvents(TransactionListPiggyBankEventsParams, CancellationToken)"/>
    Task<HttpResponse<PiggyBankEventArray>> ListPiggyBankEvents(
        string id,
        TransactionListPiggyBankEventsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
