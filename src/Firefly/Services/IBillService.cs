using System;
using System.Threading;
using System.Threading.Tasks;
using Firefly.Core;
using Firefly.Models.Accounts;
using Firefly.Models.Bills;

namespace Firefly.Services;

/// <summary>
/// Endpoints to manage a user&amp;#039;s bills and all related objects.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IBillService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IBillServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBillService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Creates a new bill. The data required can be submitted as a JSON body or as a
    /// list of parameters.
    /// </summary>
    Task<BillSingle> Create(
        BillCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a single bill.
    /// </summary>
    Task<BillSingle> Retrieve(
        BillRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(BillRetrieveParams, CancellationToken)"/>
    Task<BillSingle> Retrieve(
        string id,
        BillRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update existing bill.
    /// </summary>
    Task<BillSingle> Update(
        BillUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(BillUpdateParams, CancellationToken)"/>
    Task<BillSingle> Update(
        string id,
        BillUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint will list all the user's bills.
    /// </summary>
    Task<BillArray> List(
        BillListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a bill. This will not delete any associated rules. Will not remove
    /// associated transactions. WILL remove all associated attachments.
    /// </summary>
    Task Delete(BillDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(BillDeleteParams, CancellationToken)"/>
    Task Delete(
        string id,
        BillDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint will list all attachments linked to the bill.
    /// </summary>
    Task<AttachmentArray> ListAttachments(
        BillListAttachmentsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListAttachments(BillListAttachmentsParams, CancellationToken)"/>
    Task<AttachmentArray> ListAttachments(
        string id,
        BillListAttachmentsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint will list all rules that have an action to set the bill to this
    /// bill.
    /// </summary>
    Task<RuleArray> ListRules(
        BillListRulesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListRules(BillListRulesParams, CancellationToken)"/>
    Task<RuleArray> ListRules(
        string id,
        BillListRulesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint will list all transactions linked to this bill.
    /// </summary>
    Task<TransactionArray> ListTransactions(
        BillListTransactionsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListTransactions(BillListTransactionsParams, CancellationToken)"/>
    Task<TransactionArray> ListTransactions(
        string id,
        BillListTransactionsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IBillService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IBillServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBillServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/bills</c>, but is otherwise the
    /// same as <see cref="IBillService.Create(BillCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BillSingle>> Create(
        BillCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/bills/{id}</c>, but is otherwise the
    /// same as <see cref="IBillService.Retrieve(BillRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BillSingle>> Retrieve(
        BillRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(BillRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<BillSingle>> Retrieve(
        string id,
        BillRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /v1/bills/{id}</c>, but is otherwise the
    /// same as <see cref="IBillService.Update(BillUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BillSingle>> Update(
        BillUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(BillUpdateParams, CancellationToken)"/>
    Task<HttpResponse<BillSingle>> Update(
        string id,
        BillUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/bills</c>, but is otherwise the
    /// same as <see cref="IBillService.List(BillListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BillArray>> List(
        BillListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/bills/{id}</c>, but is otherwise the
    /// same as <see cref="IBillService.Delete(BillDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        BillDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(BillDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string id,
        BillDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/bills/{id}/attachments</c>, but is otherwise the
    /// same as <see cref="IBillService.ListAttachments(BillListAttachmentsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AttachmentArray>> ListAttachments(
        BillListAttachmentsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListAttachments(BillListAttachmentsParams, CancellationToken)"/>
    Task<HttpResponse<AttachmentArray>> ListAttachments(
        string id,
        BillListAttachmentsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/bills/{id}/rules</c>, but is otherwise the
    /// same as <see cref="IBillService.ListRules(BillListRulesParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RuleArray>> ListRules(
        BillListRulesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListRules(BillListRulesParams, CancellationToken)"/>
    Task<HttpResponse<RuleArray>> ListRules(
        string id,
        BillListRulesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/bills/{id}/transactions</c>, but is otherwise the
    /// same as <see cref="IBillService.ListTransactions(BillListTransactionsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TransactionArray>> ListTransactions(
        BillListTransactionsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListTransactions(BillListTransactionsParams, CancellationToken)"/>
    Task<HttpResponse<TransactionArray>> ListTransactions(
        string id,
        BillListTransactionsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
