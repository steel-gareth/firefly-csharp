using System;
using System.Threading;
using System.Threading.Tasks;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Accounts;
using EmceesProdTesting5.Models.Budgets.Limits;

namespace EmceesProdTesting5.Services.Budgets;

/// <summary>
/// Endpoints to manage a user&amp;#039;s budgets and get info on the related objects,
/// like limits.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ILimitService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ILimitServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ILimitService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Store a new budget limit under this budget.
    /// </summary>
    Task<BudgetLimitSingle> Create(
        LimitCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(LimitCreateParams, CancellationToken)"/>
    Task<BudgetLimitSingle> Create(
        string id,
        LimitCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get single budget limit.
    /// </summary>
    Task<BudgetLimitSingle> Retrieve(
        LimitRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(LimitRetrieveParams, CancellationToken)"/>
    Task<BudgetLimitSingle> Retrieve(
        long limitID,
        LimitRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update existing budget limit.
    /// </summary>
    Task<BudgetLimitSingle> Update(
        LimitUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(LimitUpdateParams, CancellationToken)"/>
    Task<BudgetLimitSingle> Update(
        string limitID,
        LimitUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a budget limit.
    /// </summary>
    Task Delete(LimitDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(LimitDeleteParams, CancellationToken)"/>
    Task Delete(
        string limitID,
        LimitDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get all budget limits for this budget and the money spent, and money left. You
    /// can limit the list by submitting a date range as well. The "spent" array for
    /// each budget limit is NOT influenced by the start and end date of your query, but
    /// by the start and end date of the budget limit itself.
    /// </summary>
    Task<BudgetLimitArray> List0(
        LimitList0Params parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List0(LimitList0Params, CancellationToken)"/>
    Task<BudgetLimitArray> List0(
        string id,
        LimitList0Params? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get all budget limits for for this date range.
    /// </summary>
    Task<BudgetLimitArray> List1(
        LimitList1Params parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List all the transactions within one budget limit. The start and end date are
    /// dictated by the budget limit.
    /// </summary>
    Task<TransactionArray> ListTransactions(
        LimitListTransactionsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListTransactions(LimitListTransactionsParams, CancellationToken)"/>
    Task<TransactionArray> ListTransactions(
        string limitID,
        LimitListTransactionsParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ILimitService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ILimitServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ILimitServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/budgets/{id}/limits</c>, but is otherwise the
    /// same as <see cref="ILimitService.Create(LimitCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BudgetLimitSingle>> Create(
        LimitCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(LimitCreateParams, CancellationToken)"/>
    Task<HttpResponse<BudgetLimitSingle>> Create(
        string id,
        LimitCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/budgets/{id}/limits/{limitId}</c>, but is otherwise the
    /// same as <see cref="ILimitService.Retrieve(LimitRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BudgetLimitSingle>> Retrieve(
        LimitRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(LimitRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<BudgetLimitSingle>> Retrieve(
        long limitID,
        LimitRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /v1/budgets/{id}/limits/{limitId}</c>, but is otherwise the
    /// same as <see cref="ILimitService.Update(LimitUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BudgetLimitSingle>> Update(
        LimitUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(LimitUpdateParams, CancellationToken)"/>
    Task<HttpResponse<BudgetLimitSingle>> Update(
        string limitID,
        LimitUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/budgets/{id}/limits/{limitId}</c>, but is otherwise the
    /// same as <see cref="ILimitService.Delete(LimitDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        LimitDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(LimitDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string limitID,
        LimitDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/budgets/{id}/limits</c>, but is otherwise the
    /// same as <see cref="ILimitService.List0(LimitList0Params, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BudgetLimitArray>> List0(
        LimitList0Params parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List0(LimitList0Params, CancellationToken)"/>
    Task<HttpResponse<BudgetLimitArray>> List0(
        string id,
        LimitList0Params? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/budget-limits</c>, but is otherwise the
    /// same as <see cref="ILimitService.List1(LimitList1Params, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BudgetLimitArray>> List1(
        LimitList1Params parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/budgets/{id}/limits/{limitId}/transactions</c>, but is otherwise the
    /// same as <see cref="ILimitService.ListTransactions(LimitListTransactionsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TransactionArray>> ListTransactions(
        LimitListTransactionsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListTransactions(LimitListTransactionsParams, CancellationToken)"/>
    Task<HttpResponse<TransactionArray>> ListTransactions(
        string limitID,
        LimitListTransactionsParams parameters,
        CancellationToken cancellationToken = default
    );
}
