using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Chart.Account;
using EmceesProdTesting5.Models.Chart.Balance;

namespace EmceesProdTesting5.Services.Chart;

/// <inheritdoc/>
public sealed class BalanceService : IBalanceService
{
    readonly Lazy<IBalanceServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IBalanceServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IEmceesProdTesting5Client _client;

    /// <inheritdoc/>
    public IBalanceService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BalanceService(this._client.WithOptions(modifier));
    }

    public BalanceService(IEmceesProdTesting5Client client)
    {
        _client = client;

        _withRawResponse = new(() => new BalanceServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<List<ChartDataSet>> RetrieveBalance(
        BalanceRetrieveBalanceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveBalance(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class BalanceServiceWithRawResponse : IBalanceServiceWithRawResponse
{
    readonly IEmceesProdTesting5ClientWithRawResponse _client;

    /// <inheritdoc/>
    public IBalanceServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BalanceServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public BalanceServiceWithRawResponse(IEmceesProdTesting5ClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<ChartDataSet>>> RetrieveBalance(
        BalanceRetrieveBalanceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<BalanceRetrieveBalanceParams> request = new()
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
