using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Chart.Account;

namespace EmceesProdTesting5.Services.Chart;

/// <summary>
/// The &amp;quot;charts&amp;quot; endpoints deliver optimised data for charts and graphs.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IAccountService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAccountServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAccountService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// This endpoint returns the data required to generate a chart with basic asset
    /// account balance information. This is used on the dashboard.
    /// </summary>
    Task<List<ChartDataSet>> RetrieveOverview(
        AccountRetrieveOverviewParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IAccountService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAccountServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAccountServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/chart/account/overview</c>, but is otherwise the
    /// same as <see cref="IAccountService.RetrieveOverview(AccountRetrieveOverviewParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<ChartDataSet>>> RetrieveOverview(
        AccountRetrieveOverviewParams parameters,
        CancellationToken cancellationToken = default
    );
}
