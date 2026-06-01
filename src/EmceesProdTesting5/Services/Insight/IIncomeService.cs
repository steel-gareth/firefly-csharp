using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Insight.Expense;
using EmceesProdTesting5.Models.Insight.Income;

namespace EmceesProdTesting5.Services.Insight;

/// <summary>
/// The &amp;quot;insight&amp;quot; endpoints try to deliver sums, balances and insightful
/// information in the broadest sense of the word.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IIncomeService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IIncomeServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IIncomeService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// This endpoint gives a sum of the total income received by the user.
    /// </summary>
    Task<List<InsightTotalEntry>> GetTotal(
        IncomeGetTotalParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint gives a summary of the income received by the user, grouped by
    /// asset account.
    /// </summary>
    Task<List<InsightGroupEntry>> ListByAssetAccount(
        IncomeListByAssetAccountParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint gives a summary of the income received by the user, grouped by
    /// (any) category.
    /// </summary>
    Task<List<InsightGroupEntry>> ListByCategory(
        IncomeListByCategoryParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint gives a summary of the income received by the user, grouped by
    /// revenue account.
    /// </summary>
    Task<List<InsightGroupEntry>> ListByRevenueAccount(
        IncomeListByRevenueAccountParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint gives a summary of the income received by the user, grouped by
    /// (any) tag.
    /// </summary>
    Task<List<InsightGroupEntry>> ListByTag(
        IncomeListByTagParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint gives a summary of the income received by the user, including only
    /// income with no category.
    /// </summary>
    Task<List<InsightTotalEntry>> ListWithoutCategory(
        IncomeListWithoutCategoryParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint gives a summary of the income received by the user, including only
    /// income with no tag.
    /// </summary>
    Task<List<InsightTotalEntry>> ListWithoutTag(
        IncomeListWithoutTagParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IIncomeService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IIncomeServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IIncomeServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/insight/income/total</c>, but is otherwise the
    /// same as <see cref="IIncomeService.GetTotal(IncomeGetTotalParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<InsightTotalEntry>>> GetTotal(
        IncomeGetTotalParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/insight/income/asset</c>, but is otherwise the
    /// same as <see cref="IIncomeService.ListByAssetAccount(IncomeListByAssetAccountParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<InsightGroupEntry>>> ListByAssetAccount(
        IncomeListByAssetAccountParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/insight/income/category</c>, but is otherwise the
    /// same as <see cref="IIncomeService.ListByCategory(IncomeListByCategoryParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<InsightGroupEntry>>> ListByCategory(
        IncomeListByCategoryParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/insight/income/revenue</c>, but is otherwise the
    /// same as <see cref="IIncomeService.ListByRevenueAccount(IncomeListByRevenueAccountParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<InsightGroupEntry>>> ListByRevenueAccount(
        IncomeListByRevenueAccountParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/insight/income/tag</c>, but is otherwise the
    /// same as <see cref="IIncomeService.ListByTag(IncomeListByTagParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<InsightGroupEntry>>> ListByTag(
        IncomeListByTagParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/insight/income/no-category</c>, but is otherwise the
    /// same as <see cref="IIncomeService.ListWithoutCategory(IncomeListWithoutCategoryParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<InsightTotalEntry>>> ListWithoutCategory(
        IncomeListWithoutCategoryParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/insight/income/no-tag</c>, but is otherwise the
    /// same as <see cref="IIncomeService.ListWithoutTag(IncomeListWithoutTagParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<InsightTotalEntry>>> ListWithoutTag(
        IncomeListWithoutTagParams parameters,
        CancellationToken cancellationToken = default
    );
}
