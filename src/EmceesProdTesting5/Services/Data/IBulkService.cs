using System;
using System.Threading;
using System.Threading.Tasks;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Data.Bulk;

namespace EmceesProdTesting5.Services.Data;

/// <summary>
/// The &amp;quot;data&amp;quot;-endpoints manage generic Firefly III and user-specific data.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IBulkService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IBulkServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBulkService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Allows you to update transactions in bulk.
    /// </summary>
    Task UpdateTransactions(
        BulkUpdateTransactionsParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IBulkService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IBulkServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBulkServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/data/bulk/transactions</c>, but is otherwise the
    /// same as <see cref="IBulkService.UpdateTransactions(BulkUpdateTransactionsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> UpdateTransactions(
        BulkUpdateTransactionsParams parameters,
        CancellationToken cancellationToken = default
    );
}
