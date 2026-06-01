using System;
using Firefly.Core;
using Chart = Firefly.Services.Chart;

namespace Firefly.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IChartService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IChartServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IChartService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Chart::IAccountService Account { get; }

    Chart::IBalanceService Balance { get; }

    Chart::IBudgetService Budget { get; }

    Chart::ICategoryService Category { get; }
}

/// <summary>
/// A view of <see cref="IChartService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IChartServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IChartServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Chart::IAccountServiceWithRawResponse Account { get; }

    Chart::IBalanceServiceWithRawResponse Balance { get; }

    Chart::IBudgetServiceWithRawResponse Budget { get; }

    Chart::ICategoryServiceWithRawResponse Category { get; }
}
