using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Chart.Account;
using EmceesProdTesting5.Models.Chart.Category;

namespace EmceesProdTesting5.Services.Chart;

/// <summary>
/// The &amp;quot;charts&amp;quot; endpoints deliver optimised data for charts and graphs.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ICategoryService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICategoryServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICategoryService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// This endpoint returns the data required to generate a chart with basic category
    /// information.
    /// </summary>
    Task<List<ChartDataSet>> RetrieveOverview(
        CategoryRetrieveOverviewParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ICategoryService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICategoryServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICategoryServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/chart/category/overview</c>, but is otherwise the
    /// same as <see cref="ICategoryService.RetrieveOverview(CategoryRetrieveOverviewParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<ChartDataSet>>> RetrieveOverview(
        CategoryRetrieveOverviewParams parameters,
        CancellationToken cancellationToken = default
    );
}
