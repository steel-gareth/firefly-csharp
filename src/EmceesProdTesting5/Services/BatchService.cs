using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Batch;

namespace EmceesProdTesting5.Services;

/// <inheritdoc/>
public sealed class BatchService : IBatchService
{
    readonly Lazy<IBatchServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IBatchServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IEmceesProdTesting5Client _client;

    /// <inheritdoc/>
    public IBatchService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BatchService(this._client.WithOptions(modifier));
    }

    public BatchService(IEmceesProdTesting5Client client)
    {
        _client = client;

        _withRawResponse = new(() => new BatchServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public Task Finish(
        BatchFinishParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Finish(parameters, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class BatchServiceWithRawResponse : IBatchServiceWithRawResponse
{
    readonly IEmceesProdTesting5ClientWithRawResponse _client;

    /// <inheritdoc/>
    public IBatchServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BatchServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public BatchServiceWithRawResponse(IEmceesProdTesting5ClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Finish(
        BatchFinishParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<BatchFinishParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }
}
