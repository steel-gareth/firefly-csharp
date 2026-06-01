using System;
using Firefly.Core;
using Firefly.Services.Insight;

namespace Firefly.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IInsightService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IInsightServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInsightService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IExpenseService Expense { get; }

    IIncomeService Income { get; }

    ITransferService Transfer { get; }
}

/// <summary>
/// A view of <see cref="IInsightService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IInsightServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInsightServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IExpenseServiceWithRawResponse Expense { get; }

    IIncomeServiceWithRawResponse Income { get; }

    ITransferServiceWithRawResponse Transfer { get; }
}
