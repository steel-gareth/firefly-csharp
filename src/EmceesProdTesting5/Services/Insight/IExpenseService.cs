using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Insight.Expense;

namespace EmceesProdTesting5.Services.Insight;

/// <summary>
/// The &amp;quot;insight&amp;quot; endpoints try to deliver sums, balances and insightful
/// information in the broadest sense of the word.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IExpenseService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IExpenseServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IExpenseService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// This endpoint gives a sum of the total expenses made by the user.
    /// </summary>
    Task<List<InsightTotalEntry>> GetTotal(
        ExpenseGetTotalParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint gives a summary of the expenses made by the user, grouped by asset
    /// account.
    /// </summary>
    Task<List<InsightGroupEntry>> ListByAssetAccount(
        ExpenseListByAssetAccountParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint gives a summary of the expenses made by the user, grouped by (any)
    /// bill.
    /// </summary>
    Task<List<InsightGroupEntry>> ListByBill(
        ExpenseListByBillParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint gives a summary of the expenses made by the user, grouped by (any)
    /// budget.
    /// </summary>
    Task<List<InsightGroupEntry>> ListByBudget(
        ExpenseListByBudgetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint gives a summary of the expenses made by the user, grouped by (any)
    /// category.
    /// </summary>
    Task<List<InsightGroupEntry>> ListByCategory(
        ExpenseListByCategoryParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint gives a summary of the expenses made by the user, grouped by
    /// expense account.
    /// </summary>
    Task<List<InsightGroupEntry>> ListByExpenseAccount(
        ExpenseListByExpenseAccountParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint gives a summary of the expenses made by the user, grouped by (any)
    /// tag.
    /// </summary>
    Task<List<InsightGroupEntry>> ListByTag(
        ExpenseListByTagParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint gives a summary of the expenses made by the user, including only
    /// expenses with no bill.
    /// </summary>
    Task<List<InsightTotalEntry>> ListWithoutBill(
        ExpenseListWithoutBillParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint gives a summary of the expenses made by the user, including only
    /// expenses with no budget.
    /// </summary>
    Task<List<InsightTotalEntry>> ListWithoutBudget(
        ExpenseListWithoutBudgetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint gives a summary of the expenses made by the user, including only
    /// expenses with no category.
    /// </summary>
    Task<List<InsightTotalEntry>> ListWithoutCategory(
        ExpenseListWithoutCategoryParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint gives a summary of the expenses made by the user, including only
    /// expenses with no tag.
    /// </summary>
    Task<List<InsightTotalEntry>> ListWithoutTag(
        ExpenseListWithoutTagParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IExpenseService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IExpenseServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IExpenseServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/insight/expense/total</c>, but is otherwise the
    /// same as <see cref="IExpenseService.GetTotal(ExpenseGetTotalParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<InsightTotalEntry>>> GetTotal(
        ExpenseGetTotalParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/insight/expense/asset</c>, but is otherwise the
    /// same as <see cref="IExpenseService.ListByAssetAccount(ExpenseListByAssetAccountParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<InsightGroupEntry>>> ListByAssetAccount(
        ExpenseListByAssetAccountParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/insight/expense/bill</c>, but is otherwise the
    /// same as <see cref="IExpenseService.ListByBill(ExpenseListByBillParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<InsightGroupEntry>>> ListByBill(
        ExpenseListByBillParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/insight/expense/budget</c>, but is otherwise the
    /// same as <see cref="IExpenseService.ListByBudget(ExpenseListByBudgetParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<InsightGroupEntry>>> ListByBudget(
        ExpenseListByBudgetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/insight/expense/category</c>, but is otherwise the
    /// same as <see cref="IExpenseService.ListByCategory(ExpenseListByCategoryParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<InsightGroupEntry>>> ListByCategory(
        ExpenseListByCategoryParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/insight/expense/expense</c>, but is otherwise the
    /// same as <see cref="IExpenseService.ListByExpenseAccount(ExpenseListByExpenseAccountParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<InsightGroupEntry>>> ListByExpenseAccount(
        ExpenseListByExpenseAccountParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/insight/expense/tag</c>, but is otherwise the
    /// same as <see cref="IExpenseService.ListByTag(ExpenseListByTagParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<InsightGroupEntry>>> ListByTag(
        ExpenseListByTagParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/insight/expense/no-bill</c>, but is otherwise the
    /// same as <see cref="IExpenseService.ListWithoutBill(ExpenseListWithoutBillParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<InsightTotalEntry>>> ListWithoutBill(
        ExpenseListWithoutBillParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/insight/expense/no-budget</c>, but is otherwise the
    /// same as <see cref="IExpenseService.ListWithoutBudget(ExpenseListWithoutBudgetParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<InsightTotalEntry>>> ListWithoutBudget(
        ExpenseListWithoutBudgetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/insight/expense/no-category</c>, but is otherwise the
    /// same as <see cref="IExpenseService.ListWithoutCategory(ExpenseListWithoutCategoryParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<InsightTotalEntry>>> ListWithoutCategory(
        ExpenseListWithoutCategoryParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/insight/expense/no-tag</c>, but is otherwise the
    /// same as <see cref="IExpenseService.ListWithoutTag(ExpenseListWithoutTagParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<InsightTotalEntry>>> ListWithoutTag(
        ExpenseListWithoutTagParams parameters,
        CancellationToken cancellationToken = default
    );
}
