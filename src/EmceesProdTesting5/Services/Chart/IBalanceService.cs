using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Chart.Account;
using EmceesProdTesting5.Models.Chart.Balance;

namespace EmceesProdTesting5.Services.Chart;

/// <summary>
/// The &amp;quot;charts&amp;quot; endpoints deliver optimised data for charts and graphs.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IBalanceService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IBalanceServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBalanceService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// This endpoint returns the data required to generate a chart with balance
    /// information.
    /// </summary>
    Task<List<ChartDataSet>> RetrieveBalance(
        BalanceRetrieveBalanceParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IBalanceService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IBalanceServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBalanceServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/chart/balance/balance</c>, but is otherwise the
    /// same as <see cref="IBalanceService.RetrieveBalance(BalanceRetrieveBalanceParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<ChartDataSet>>> RetrieveBalance(
        BalanceRetrieveBalanceParams parameters,
        CancellationToken cancellationToken = default
    );
}
