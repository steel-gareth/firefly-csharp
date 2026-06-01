using System;
using System.Threading;
using System.Threading.Tasks;
using Firefly.Core;
using Firefly.Models.Accounts;
using Firefly.Models.Search;

namespace Firefly.Services;

/// <summary>
/// Endpoints that allow you to search through the user&amp;#039;s financial data.
/// Different from the autocomplete endpoints, the search accepts more advanced arguments.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ISearchService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISearchServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISearchService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Search for accounts
    /// </summary>
    Task<AccountArray> Accounts(
        SearchAccountsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Searches through the users transactions.
    /// </summary>
    Task<TransactionArray> Transactions(
        SearchTransactionsParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ISearchService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISearchServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISearchServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/search/accounts</c>, but is otherwise the
    /// same as <see cref="ISearchService.Accounts(SearchAccountsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AccountArray>> Accounts(
        SearchAccountsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/search/transactions</c>, but is otherwise the
    /// same as <see cref="ISearchService.Transactions(SearchTransactionsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TransactionArray>> Transactions(
        SearchTransactionsParams parameters,
        CancellationToken cancellationToken = default
    );
}
