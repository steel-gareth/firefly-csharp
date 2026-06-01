using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Firefly.Core;
using Firefly.Models.Data;
using Firefly.Services.Data;

namespace Firefly.Services;

/// <inheritdoc/>
public sealed class DataService : IDataService
{
    readonly Lazy<IDataServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IDataServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IFireflyClient _client;

    /// <inheritdoc/>
    public IDataService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DataService(this._client.WithOptions(modifier));
    }

    public DataService(IFireflyClient client)
    {
        _client = client;

        _withRawResponse = new(() => new DataServiceWithRawResponse(client.WithRawResponse));
        _bulk = new(() => new BulkService(client));
        _export = new(() => new ExportService(client));
    }

    readonly Lazy<IBulkService> _bulk;
    public IBulkService Bulk
    {
        get { return _bulk.Value; }
    }

    readonly Lazy<IExportService> _export;
    public IExportService Export
    {
        get { return _export.Value; }
    }

    /// <inheritdoc/>
    public Task Destroy(DataDestroyParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Destroy(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Purge(
        DataPurgeParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Purge(parameters, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class DataServiceWithRawResponse : IDataServiceWithRawResponse
{
    readonly IFireflyClientWithRawResponse _client;

    /// <inheritdoc/>
    public IDataServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DataServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public DataServiceWithRawResponse(IFireflyClientWithRawResponse client)
    {
        _client = client;

        _bulk = new(() => new BulkServiceWithRawResponse(client));
        _export = new(() => new ExportServiceWithRawResponse(client));
    }

    readonly Lazy<IBulkServiceWithRawResponse> _bulk;
    public IBulkServiceWithRawResponse Bulk
    {
        get { return _bulk.Value; }
    }

    readonly Lazy<IExportServiceWithRawResponse> _export;
    public IExportServiceWithRawResponse Export
    {
        get { return _export.Value; }
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Destroy(
        DataDestroyParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<DataDestroyParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Purge(
        DataPurgeParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<DataPurgeParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }
}
