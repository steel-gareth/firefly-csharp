using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Exceptions;
using EmceesProdTesting5.Models;
using EmceesProdTesting5.Models.Store.Orders;

namespace EmceesProdTesting5.Services.Store;

/// <inheritdoc/>
public sealed class OrderService : IOrderService
{
    readonly Lazy<IOrderServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IOrderServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IMoreConflictingClient _client;

    /// <inheritdoc/>
    public IOrderService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new OrderService(this._client.WithOptions(modifier));
    }

    public OrderService(IMoreConflictingClient client)
    {
        _client = client;

        _withRawResponse = new(() => new OrderServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<Order> Create(
        OrderCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Order> Retrieve(
        OrderRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Order> Retrieve(
        long orderID,
        OrderRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { OrderID = orderID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Delete(OrderDeleteParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        long orderID,
        OrderDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { OrderID = orderID }, cancellationToken)
            .ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class OrderServiceWithRawResponse : IOrderServiceWithRawResponse
{
    readonly IMoreConflictingClientWithRawResponse _client;

    /// <inheritdoc/>
    public IOrderServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new OrderServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public OrderServiceWithRawResponse(IMoreConflictingClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Order>> Create(
        OrderCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<OrderCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var order = await response.Deserialize<Order>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    order.Validate();
                }
                return order;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Order>> Retrieve(
        OrderRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.OrderID == null)
        {
            throw new MoreConflictingInvalidDataException("'parameters.OrderID' cannot be null");
        }

        HttpRequest<OrderRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var order = await response.Deserialize<Order>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    order.Validate();
                }
                return order;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Order>> Retrieve(
        long orderID,
        OrderRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { OrderID = orderID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        OrderDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.OrderID == null)
        {
            throw new MoreConflictingInvalidDataException("'parameters.OrderID' cannot be null");
        }

        HttpRequest<OrderDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        long orderID,
        OrderDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { OrderID = orderID }, cancellationToken);
    }
}
