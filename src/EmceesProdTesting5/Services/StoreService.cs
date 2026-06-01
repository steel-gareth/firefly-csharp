using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Store;
using EmceesProdTesting5.Services.Store;

namespace EmceesProdTesting5.Services;

/// <inheritdoc/>
public sealed class StoreService : IStoreService
{
    readonly Lazy<IStoreServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IStoreServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IMoreConflictingClient _client;

    /// <inheritdoc/>
    public IStoreService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new StoreService(this._client.WithOptions(modifier));
    }

    public StoreService(IMoreConflictingClient client)
    {
        _client = client;

        _withRawResponse = new(() => new StoreServiceWithRawResponse(client.WithRawResponse));
        _orders = new(() => new OrderService(client));
    }

    readonly Lazy<IOrderService> _orders;
    public IOrderService Orders
    {
        get { return _orders.Value; }
    }

    /// <inheritdoc/>
    public async Task<Dictionary<string, int>> ListInventory(
        StoreListInventoryParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListInventory(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class StoreServiceWithRawResponse : IStoreServiceWithRawResponse
{
    readonly IMoreConflictingClientWithRawResponse _client;

    /// <inheritdoc/>
    public IStoreServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new StoreServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public StoreServiceWithRawResponse(IMoreConflictingClientWithRawResponse client)
    {
        _client = client;

        _orders = new(() => new OrderServiceWithRawResponse(client));
    }

    readonly Lazy<IOrderServiceWithRawResponse> _orders;
    public IOrderServiceWithRawResponse Orders
    {
        get { return _orders.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Dictionary<string, int>>> ListInventory(
        StoreListInventoryParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<StoreListInventoryParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                return await response
                    .Deserialize<Dictionary<string, int>>(token)
                    .ConfigureAwait(false);
            }
        );
    }
}
