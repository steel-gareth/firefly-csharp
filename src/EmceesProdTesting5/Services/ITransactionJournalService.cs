using System;
using System.Threading;
using System.Threading.Tasks;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.TransactionJournals;
using EmceesProdTesting5.Models.TransactionLinks;

namespace EmceesProdTesting5.Services;

/// <summary>
/// The most-used endpoints in Firefly III, these endpoints are used to manage the
/// user&amp;#039;s transactions.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ITransactionJournalService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ITransactionJournalServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITransactionJournalService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get a single transaction by underlying journal (split).
    /// </summary>
    Task<TransactionSingle> Retrieve(
        TransactionJournalRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(TransactionJournalRetrieveParams, CancellationToken)"/>
    Task<TransactionSingle> Retrieve(
        string id,
        TransactionJournalRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete an individual journal (split) from a transaction.
    /// </summary>
    Task Delete(
        TransactionJournalDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(TransactionJournalDeleteParams, CancellationToken)"/>
    Task Delete(
        string id,
        TransactionJournalDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Lists all the transaction links for an individual journal (a split). Don't use
    /// the group ID, you need the actual underlying journal (the split).
    /// </summary>
    Task<TransactionLinkArray> ListLinks(
        TransactionJournalListLinksParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListLinks(TransactionJournalListLinksParams, CancellationToken)"/>
    Task<TransactionLinkArray> ListLinks(
        string id,
        TransactionJournalListLinksParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ITransactionJournalService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ITransactionJournalServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITransactionJournalServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/transaction-journals/{id}</c>, but is otherwise the
    /// same as <see cref="ITransactionJournalService.Retrieve(TransactionJournalRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TransactionSingle>> Retrieve(
        TransactionJournalRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(TransactionJournalRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<TransactionSingle>> Retrieve(
        string id,
        TransactionJournalRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/transaction-journals/{id}</c>, but is otherwise the
    /// same as <see cref="ITransactionJournalService.Delete(TransactionJournalDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        TransactionJournalDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(TransactionJournalDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string id,
        TransactionJournalDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/transaction-journals/{id}/links</c>, but is otherwise the
    /// same as <see cref="ITransactionJournalService.ListLinks(TransactionJournalListLinksParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TransactionLinkArray>> ListLinks(
        TransactionJournalListLinksParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListLinks(TransactionJournalListLinksParams, CancellationToken)"/>
    Task<HttpResponse<TransactionLinkArray>> ListLinks(
        string id,
        TransactionJournalListLinksParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
