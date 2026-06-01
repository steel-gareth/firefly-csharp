using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Insight.Expense;
using EmceesProdTesting5.Models.Insight.Income;

namespace EmceesProdTesting5.Services.Insight;

/// <inheritdoc/>
public sealed class IncomeService : IIncomeService
{
    readonly Lazy<IIncomeServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IIncomeServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IEmceesProdTesting5Client _client;

    /// <inheritdoc/>
    public IIncomeService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new IncomeService(this._client.WithOptions(modifier));
    }

    public IncomeService(IEmceesProdTesting5Client client)
    {
        _client = client;

        _withRawResponse = new(() => new IncomeServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<List<InsightTotalEntry>> GetTotal(
        IncomeGetTotalParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetTotal(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<List<InsightGroupEntry>> ListByAssetAccount(
        IncomeListByAssetAccountParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListByAssetAccount(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<List<InsightGroupEntry>> ListByCategory(
        IncomeListByCategoryParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListByCategory(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<List<InsightGroupEntry>> ListByRevenueAccount(
        IncomeListByRevenueAccountParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListByRevenueAccount(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<List<InsightGroupEntry>> ListByTag(
        IncomeListByTagParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListByTag(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<List<InsightTotalEntry>> ListWithoutCategory(
        IncomeListWithoutCategoryParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListWithoutCategory(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<List<InsightTotalEntry>> ListWithoutTag(
        IncomeListWithoutTagParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListWithoutTag(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class IncomeServiceWithRawResponse : IIncomeServiceWithRawResponse
{
    readonly IEmceesProdTesting5ClientWithRawResponse _client;

    /// <inheritdoc/>
    public IIncomeServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new IncomeServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public IncomeServiceWithRawResponse(IEmceesProdTesting5ClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<InsightTotalEntry>>> GetTotal(
        IncomeGetTotalParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<IncomeGetTotalParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var insightTotalEntries = await response
                    .Deserialize<List<InsightTotalEntry>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in insightTotalEntries)
                    {
                        item.Validate();
                    }
                }
                return insightTotalEntries;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<InsightGroupEntry>>> ListByAssetAccount(
        IncomeListByAssetAccountParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<IncomeListByAssetAccountParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var insightGroupEntries = await response
                    .Deserialize<List<InsightGroupEntry>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in insightGroupEntries)
                    {
                        item.Validate();
                    }
                }
                return insightGroupEntries;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<InsightGroupEntry>>> ListByCategory(
        IncomeListByCategoryParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<IncomeListByCategoryParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var insightGroupEntries = await response
                    .Deserialize<List<InsightGroupEntry>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in insightGroupEntries)
                    {
                        item.Validate();
                    }
                }
                return insightGroupEntries;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<InsightGroupEntry>>> ListByRevenueAccount(
        IncomeListByRevenueAccountParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<IncomeListByRevenueAccountParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var insightGroupEntries = await response
                    .Deserialize<List<InsightGroupEntry>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in insightGroupEntries)
                    {
                        item.Validate();
                    }
                }
                return insightGroupEntries;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<InsightGroupEntry>>> ListByTag(
        IncomeListByTagParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<IncomeListByTagParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var insightGroupEntries = await response
                    .Deserialize<List<InsightGroupEntry>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in insightGroupEntries)
                    {
                        item.Validate();
                    }
                }
                return insightGroupEntries;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<InsightTotalEntry>>> ListWithoutCategory(
        IncomeListWithoutCategoryParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<IncomeListWithoutCategoryParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var insightTotalEntries = await response
                    .Deserialize<List<InsightTotalEntry>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in insightTotalEntries)
                    {
                        item.Validate();
                    }
                }
                return insightTotalEntries;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<InsightTotalEntry>>> ListWithoutTag(
        IncomeListWithoutTagParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<IncomeListWithoutTagParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var insightTotalEntries = await response
                    .Deserialize<List<InsightTotalEntry>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in insightTotalEntries)
                    {
                        item.Validate();
                    }
                }
                return insightTotalEntries;
            }
        );
    }
}
