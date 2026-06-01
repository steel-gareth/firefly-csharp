using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Chart.Account;
using EmceesProdTesting5.Models.Chart.Category;

namespace EmceesProdTesting5.Services.Chart;

/// <inheritdoc/>
public sealed class CategoryService : ICategoryService
{
    readonly Lazy<ICategoryServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICategoryServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IEmceesProdTesting5Client _client;

    /// <inheritdoc/>
    public ICategoryService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CategoryService(this._client.WithOptions(modifier));
    }

    public CategoryService(IEmceesProdTesting5Client client)
    {
        _client = client;

        _withRawResponse = new(() => new CategoryServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<List<ChartDataSet>> RetrieveOverview(
        CategoryRetrieveOverviewParams parameters,
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
public sealed class CategoryServiceWithRawResponse : ICategoryServiceWithRawResponse
{
    readonly IEmceesProdTesting5ClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICategoryServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CategoryServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CategoryServiceWithRawResponse(IEmceesProdTesting5ClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<ChartDataSet>>> RetrieveOverview(
        CategoryRetrieveOverviewParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CategoryRetrieveOverviewParams> request = new()
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
