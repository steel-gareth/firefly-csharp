using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Firefly.Core;
using Firefly.Models.Chart.Account;
using Firefly.Models.Chart.Budget;

namespace Firefly.Services.Chart;

/// <summary>
/// The &amp;quot;charts&amp;quot; endpoints deliver optimised data for charts and graphs.
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

    /// <summary>
    /// This endpoint returns the data required to generate a chart with basic budget
    /// information.
    /// </summary>
    Task<List<ChartDataSet>> RetrieveOverview(
        BudgetRetrieveOverviewParams parameters,
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

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/chart/budget/overview</c>, but is otherwise the
    /// same as <see cref="IBudgetService.RetrieveOverview(BudgetRetrieveOverviewParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<ChartDataSet>>> RetrieveOverview(
        BudgetRetrieveOverviewParams parameters,
        CancellationToken cancellationToken = default
    );
}
