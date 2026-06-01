using System;
using System.Threading;
using System.Threading.Tasks;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.TransactionLinks;

namespace EmceesProdTesting5.Services;

/// <summary>
/// Endpoints to manage links between transactions, and manage the type of links available.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ITransactionLinkService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ITransactionLinkServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITransactionLinkService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Store a new link between two transactions. For this end point you need the
    /// journal_id from a transaction.
    /// </summary>
    Task<TransactionLinkSingle> Create(
        TransactionLinkCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a single link by its ID.
    /// </summary>
    Task<TransactionLinkSingle> Retrieve(
        TransactionLinkRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(TransactionLinkRetrieveParams, CancellationToken)"/>
    Task<TransactionLinkSingle> Retrieve(
        string id,
        TransactionLinkRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Used to update a single existing link.
    /// </summary>
    Task<TransactionLinkSingle> Update(
        TransactionLinkUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(TransactionLinkUpdateParams, CancellationToken)"/>
    Task<TransactionLinkSingle> Update(
        string id,
        TransactionLinkUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List all the transaction links.
    /// </summary>
    Task<TransactionLinkArray> List(
        TransactionLinkListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Will permanently delete link. Transactions remain.
    /// </summary>
    Task Delete(
        TransactionLinkDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(TransactionLinkDeleteParams, CancellationToken)"/>
    Task Delete(
        string id,
        TransactionLinkDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ITransactionLinkService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ITransactionLinkServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITransactionLinkServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/transaction-links</c>, but is otherwise the
    /// same as <see cref="ITransactionLinkService.Create(TransactionLinkCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TransactionLinkSingle>> Create(
        TransactionLinkCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/transaction-links/{id}</c>, but is otherwise the
    /// same as <see cref="ITransactionLinkService.Retrieve(TransactionLinkRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TransactionLinkSingle>> Retrieve(
        TransactionLinkRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(TransactionLinkRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<TransactionLinkSingle>> Retrieve(
        string id,
        TransactionLinkRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /v1/transaction-links/{id}</c>, but is otherwise the
    /// same as <see cref="ITransactionLinkService.Update(TransactionLinkUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TransactionLinkSingle>> Update(
        TransactionLinkUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(TransactionLinkUpdateParams, CancellationToken)"/>
    Task<HttpResponse<TransactionLinkSingle>> Update(
        string id,
        TransactionLinkUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/transaction-links</c>, but is otherwise the
    /// same as <see cref="ITransactionLinkService.List(TransactionLinkListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TransactionLinkArray>> List(
        TransactionLinkListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/transaction-links/{id}</c>, but is otherwise the
    /// same as <see cref="ITransactionLinkService.Delete(TransactionLinkDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        TransactionLinkDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(TransactionLinkDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string id,
        TransactionLinkDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
