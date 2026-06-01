using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Data.Bulk;

namespace EmceesProdTesting5.Services.Data;

/// <inheritdoc/>
public sealed class BulkService : IBulkService
{
    readonly Lazy<IBulkServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IBulkServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IEmceesProdTesting5Client _client;

    /// <inheritdoc/>
    public IBulkService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BulkService(this._client.WithOptions(modifier));
    }

    public BulkService(IEmceesProdTesting5Client client)
    {
        _client = client;

        _withRawResponse = new(() => new BulkServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public Task UpdateTransactions(
        BulkUpdateTransactionsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.UpdateTransactions(parameters, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class BulkServiceWithRawResponse : IBulkServiceWithRawResponse
{
    readonly IEmceesProdTesting5ClientWithRawResponse _client;

    /// <inheritdoc/>
    public IBulkServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BulkServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public BulkServiceWithRawResponse(IEmceesProdTesting5ClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public Task<HttpResponse> UpdateTransactions(
        BulkUpdateTransactionsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<BulkUpdateTransactionsParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }
}
