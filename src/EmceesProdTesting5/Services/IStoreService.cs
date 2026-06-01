using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Store;
using EmceesProdTesting5.Services.Store;

namespace EmceesProdTesting5.Services;

/// <summary>
/// Access to Petstore orders
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IStoreService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IStoreServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IStoreService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IOrderService Orders { get; }

    /// <summary>
    /// Returns a map of status codes to quantities
    /// </summary>
    Task<Dictionary<string, int>> ListInventory(
        StoreListInventoryParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IStoreService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IStoreServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IStoreServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IOrderServiceWithRawResponse Orders { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>get /store/inventory</c>, but is otherwise the
    /// same as <see cref="IStoreService.ListInventory(StoreListInventoryParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Dictionary<string, int>>> ListInventory(
        StoreListInventoryParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
