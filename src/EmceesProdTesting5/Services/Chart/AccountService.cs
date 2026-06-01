using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Chart.Account;

namespace EmceesProdTesting5.Services.Chart;

/// <inheritdoc/>
public sealed class AccountService : IAccountService
{
    readonly Lazy<IAccountServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAccountServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IEmceesProdTesting5Client _client;

    /// <inheritdoc/>
    public IAccountService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AccountService(this._client.WithOptions(modifier));
    }

    public AccountService(IEmceesProdTesting5Client client)
    {
        _client = client;

        _withRawResponse = new(() => new AccountServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<List<ChartDataSet>> RetrieveOverview(
        AccountRetrieveOverviewParams parameters,
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
public sealed class AccountServiceWithRawResponse : IAccountServiceWithRawResponse
{
    readonly IEmceesProdTesting5ClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAccountServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AccountServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AccountServiceWithRawResponse(IEmceesProdTesting5ClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<ChartDataSet>>> RetrieveOverview(
        AccountRetrieveOverviewParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<AccountRetrieveOverviewParams> request = new()
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
