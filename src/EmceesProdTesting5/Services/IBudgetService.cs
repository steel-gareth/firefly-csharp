using System;
using System.Threading;
using System.Threading.Tasks;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Accounts;
using EmceesProdTesting5.Models.Budgets;
using EmceesProdTesting5.Services.Budgets;

namespace EmceesProdTesting5.Services;

/// <summary>
/// Endpoints to manage a user&amp;#039;s budgets and get info on the related objects,
/// like limits.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IBudgetService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IBudgetServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBudgetService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ILimitService Limits { get; }

    /// <summary>
    /// Creates a new budget. The data required can be submitted as a JSON body or as a
    /// list of parameters.
    /// </summary>
    Task<BudgetSingle> Create(
        BudgetCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a single budget. If the start date and end date are submitted as well, the
    /// "spent" array will be updated accordingly.
    /// </summary>
    Task<BudgetSingle> Retrieve(
        BudgetRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(BudgetRetrieveParams, CancellationToken)"/>
    Task<BudgetSingle> Retrieve(
        string id,
        BudgetRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update existing budget. This endpoint cannot be used to set budget amount
    /// limits.
    /// </summary>
    Task<BudgetSingle> Update(
        BudgetUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(BudgetUpdateParams, CancellationToken)"/>
    Task<BudgetSingle> Update(
        string id,
        BudgetUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List all the budgets the user has made. If the start date and end date are
    /// submitted as well, the "spent" array will be updated accordingly.
    /// </summary>
    Task<BudgetListResponse> List(
        BudgetListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a budget. Transactions will not be deleted.
    /// </summary>
    Task Delete(BudgetDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(BudgetDeleteParams, CancellationToken)"/>
    Task Delete(
        string id,
        BudgetDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Lists all attachments.
    /// </summary>
    Task<AttachmentArray> ListAttachments(
        BudgetListAttachmentsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListAttachments(BudgetListAttachmentsParams, CancellationToken)"/>
    Task<AttachmentArray> ListAttachments(
        string id,
        BudgetListAttachmentsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get all transactions linked to a budget, possibly limited by start and end
    /// </summary>
    Task<TransactionArray> ListTransactions(
        BudgetListTransactionsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListTransactions(BudgetListTransactionsParams, CancellationToken)"/>
    Task<TransactionArray> ListTransactions(
        string id,
        BudgetListTransactionsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get all transactions NOT linked to a budget, possibly limited by start and end
    /// </summary>
    Task<TransactionArray> ListTransactionsWithoutBudget(
        BudgetListTransactionsWithoutBudgetParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IBudgetService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IBudgetServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBudgetServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ILimitServiceWithRawResponse Limits { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/budgets</c>, but is otherwise the
    /// same as <see cref="IBudgetService.Create(BudgetCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BudgetSingle>> Create(
        BudgetCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/budgets/{id}</c>, but is otherwise the
    /// same as <see cref="IBudgetService.Retrieve(BudgetRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BudgetSingle>> Retrieve(
        BudgetRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(BudgetRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<BudgetSingle>> Retrieve(
        string id,
        BudgetRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /v1/budgets/{id}</c>, but is otherwise the
    /// same as <see cref="IBudgetService.Update(BudgetUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BudgetSingle>> Update(
        BudgetUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(BudgetUpdateParams, CancellationToken)"/>
    Task<HttpResponse<BudgetSingle>> Update(
        string id,
        BudgetUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/budgets</c>, but is otherwise the
    /// same as <see cref="IBudgetService.List(BudgetListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BudgetListResponse>> List(
        BudgetListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/budgets/{id}</c>, but is otherwise the
    /// same as <see cref="IBudgetService.Delete(BudgetDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        BudgetDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(BudgetDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string id,
        BudgetDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/budgets/{id}/attachments</c>, but is otherwise the
    /// same as <see cref="IBudgetService.ListAttachments(BudgetListAttachmentsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AttachmentArray>> ListAttachments(
        BudgetListAttachmentsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListAttachments(BudgetListAttachmentsParams, CancellationToken)"/>
    Task<HttpResponse<AttachmentArray>> ListAttachments(
        string id,
        BudgetListAttachmentsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/budgets/{id}/transactions</c>, but is otherwise the
    /// same as <see cref="IBudgetService.ListTransactions(BudgetListTransactionsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TransactionArray>> ListTransactions(
        BudgetListTransactionsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListTransactions(BudgetListTransactionsParams, CancellationToken)"/>
    Task<HttpResponse<TransactionArray>> ListTransactions(
        string id,
        BudgetListTransactionsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/budgets/transactions-without-budget</c>, but is otherwise the
    /// same as <see cref="IBudgetService.ListTransactionsWithoutBudget(BudgetListTransactionsWithoutBudgetParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TransactionArray>> ListTransactionsWithoutBudget(
        BudgetListTransactionsWithoutBudgetParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
