using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Insight.Expense;

namespace EmceesProdTesting5.Services.Insight;

/// <inheritdoc/>
public sealed class ExpenseService : IExpenseService
{
    readonly Lazy<IExpenseServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IExpenseServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IEmceesProdTesting5Client _client;

    /// <inheritdoc/>
    public IExpenseService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ExpenseService(this._client.WithOptions(modifier));
    }

    public ExpenseService(IEmceesProdTesting5Client client)
    {
        _client = client;

        _withRawResponse = new(() => new ExpenseServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<List<InsightTotalEntry>> GetTotal(
        ExpenseGetTotalParams parameters,
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
        ExpenseListByAssetAccountParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListByAssetAccount(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<List<InsightGroupEntry>> ListByBill(
        ExpenseListByBillParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListByBill(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<List<InsightGroupEntry>> ListByBudget(
        ExpenseListByBudgetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListByBudget(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<List<InsightGroupEntry>> ListByCategory(
        ExpenseListByCategoryParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListByCategory(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<List<InsightGroupEntry>> ListByExpenseAccount(
        ExpenseListByExpenseAccountParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListByExpenseAccount(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<List<InsightGroupEntry>> ListByTag(
        ExpenseListByTagParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListByTag(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<List<InsightTotalEntry>> ListWithoutBill(
        ExpenseListWithoutBillParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListWithoutBill(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<List<InsightTotalEntry>> ListWithoutBudget(
        ExpenseListWithoutBudgetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListWithoutBudget(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<List<InsightTotalEntry>> ListWithoutCategory(
        ExpenseListWithoutCategoryParams parameters,
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
        ExpenseListWithoutTagParams parameters,
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
public sealed class ExpenseServiceWithRawResponse : IExpenseServiceWithRawResponse
{
    readonly IEmceesProdTesting5ClientWithRawResponse _client;

    /// <inheritdoc/>
    public IExpenseServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ExpenseServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ExpenseServiceWithRawResponse(IEmceesProdTesting5ClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<InsightTotalEntry>>> GetTotal(
        ExpenseGetTotalParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ExpenseGetTotalParams> request = new()
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
        ExpenseListByAssetAccountParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ExpenseListByAssetAccountParams> request = new()
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
    public async Task<HttpResponse<List<InsightGroupEntry>>> ListByBill(
        ExpenseListByBillParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ExpenseListByBillParams> request = new()
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
    public async Task<HttpResponse<List<InsightGroupEntry>>> ListByBudget(
        ExpenseListByBudgetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ExpenseListByBudgetParams> request = new()
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
        ExpenseListByCategoryParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ExpenseListByCategoryParams> request = new()
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
    public async Task<HttpResponse<List<InsightGroupEntry>>> ListByExpenseAccount(
        ExpenseListByExpenseAccountParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ExpenseListByExpenseAccountParams> request = new()
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
        ExpenseListByTagParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ExpenseListByTagParams> request = new()
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
    public async Task<HttpResponse<List<InsightTotalEntry>>> ListWithoutBill(
        ExpenseListWithoutBillParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ExpenseListWithoutBillParams> request = new()
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
    public async Task<HttpResponse<List<InsightTotalEntry>>> ListWithoutBudget(
        ExpenseListWithoutBudgetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ExpenseListWithoutBudgetParams> request = new()
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
    public async Task<HttpResponse<List<InsightTotalEntry>>> ListWithoutCategory(
        ExpenseListWithoutCategoryParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ExpenseListWithoutCategoryParams> request = new()
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
        ExpenseListWithoutTagParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ExpenseListWithoutTagParams> request = new()
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
