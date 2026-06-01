using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Firefly.Core;
using Firefly.Models.Chart.Account;
using Firefly.Models.Chart.Budget;

namespace Firefly.Services.Chart;

/// <inheritdoc/>
public sealed class BudgetService : IBudgetService
{
    readonly Lazy<IBudgetServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IBudgetServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IFireflyClient _client;

    /// <inheritdoc/>
    public IBudgetService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BudgetService(this._client.WithOptions(modifier));
    }

    public BudgetService(IFireflyClient client)
    {
        _client = client;

        _withRawResponse = new(() => new BudgetServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<List<ChartDataSet>> RetrieveOverview(
        BudgetRetrieveOverviewParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveOverview(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class BudgetServiceWithRawResponse : IBudgetServiceWithRawResponse
{
    readonly IFireflyClientWithRawResponse _client;

    /// <inheritdoc/>
    public IBudgetServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BudgetServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public BudgetServiceWithRawResponse(IFireflyClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<ChartDataSet>>> RetrieveOverview(
        BudgetRetrieveOverviewParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<BudgetRetrieveOverviewParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var chartDataSets = await response
                    .Deserialize<List<ChartDataSet>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in chartDataSets)
                    {
                        item.Validate();
                    }
                }
                return chartDataSets;
            }
        );
    }
}
