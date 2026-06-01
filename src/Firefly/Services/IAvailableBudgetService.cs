using System;
using System.Threading;
using System.Threading.Tasks;
using Firefly.Core;
using Firefly.Models.AvailableBudgets;

namespace Firefly.Services;

/// <summary>
/// Endpoints to manage the total available amount that the user has made available
/// to themselves. Used in periodic budgeting.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IAvailableBudgetService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAvailableBudgetServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAvailableBudgetService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get a single available budget, by ID.
    /// </summary>
    Task<AvailableBudgetRetrieveResponse> Retrieve(
        AvailableBudgetRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(AvailableBudgetRetrieveParams, CancellationToken)"/>
    Task<AvailableBudgetRetrieveResponse> Retrieve(
        string id,
        AvailableBudgetRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Firefly III calculates the total amount of money budgeted in so-called
    /// "available budgets". This endpoint returns all of these amounts and the periods
    /// for which they are calculated.
    /// </summary>
    Task<AvailableBudgetArray> List(
        AvailableBudgetListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IAvailableBudgetService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAvailableBudgetServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAvailableBudgetServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/available-budgets/{id}</c>, but is otherwise the
    /// same as <see cref="IAvailableBudgetService.Retrieve(AvailableBudgetRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AvailableBudgetRetrieveResponse>> Retrieve(
        AvailableBudgetRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(AvailableBudgetRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<AvailableBudgetRetrieveResponse>> Retrieve(
        string id,
        AvailableBudgetRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/available-budgets</c>, but is otherwise the
    /// same as <see cref="IAvailableBudgetService.List(AvailableBudgetListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AvailableBudgetArray>> List(
        AvailableBudgetListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
