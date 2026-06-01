using System;
using Firefly.Core;
using Chart = Firefly.Services.Chart;

namespace Firefly.Services;

/// <inheritdoc/>
public sealed class ChartService : IChartService
{
    readonly Lazy<IChartServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IChartServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IFireflyClient _client;

    /// <inheritdoc/>
    public IChartService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ChartService(this._client.WithOptions(modifier));
    }

    public ChartService(IFireflyClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ChartServiceWithRawResponse(client.WithRawResponse));
        _account = new(() => new Chart::AccountService(client));
        _balance = new(() => new Chart::BalanceService(client));
        _budget = new(() => new Chart::BudgetService(client));
        _category = new(() => new Chart::CategoryService(client));
    }

    readonly Lazy<Chart::IAccountService> _account;
    public Chart::IAccountService Account
    {
        get { return _account.Value; }
    }

    readonly Lazy<Chart::IBalanceService> _balance;
    public Chart::IBalanceService Balance
    {
        get { return _balance.Value; }
    }

    readonly Lazy<Chart::IBudgetService> _budget;
    public Chart::IBudgetService Budget
    {
        get { return _budget.Value; }
    }

    readonly Lazy<Chart::ICategoryService> _category;
    public Chart::ICategoryService Category
    {
        get { return _category.Value; }
    }
}

/// <inheritdoc/>
public sealed class ChartServiceWithRawResponse : IChartServiceWithRawResponse
{
    readonly IFireflyClientWithRawResponse _client;

    /// <inheritdoc/>
    public IChartServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ChartServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ChartServiceWithRawResponse(IFireflyClientWithRawResponse client)
    {
        _client = client;

        _account = new(() => new Chart::AccountServiceWithRawResponse(client));
        _balance = new(() => new Chart::BalanceServiceWithRawResponse(client));
        _budget = new(() => new Chart::BudgetServiceWithRawResponse(client));
        _category = new(() => new Chart::CategoryServiceWithRawResponse(client));
    }

    readonly Lazy<Chart::IAccountServiceWithRawResponse> _account;
    public Chart::IAccountServiceWithRawResponse Account
    {
        get { return _account.Value; }
    }

    readonly Lazy<Chart::IBalanceServiceWithRawResponse> _balance;
    public Chart::IBalanceServiceWithRawResponse Balance
    {
        get { return _balance.Value; }
    }

    readonly Lazy<Chart::IBudgetServiceWithRawResponse> _budget;
    public Chart::IBudgetServiceWithRawResponse Budget
    {
        get { return _budget.Value; }
    }

    readonly Lazy<Chart::ICategoryServiceWithRawResponse> _category;
    public Chart::ICategoryServiceWithRawResponse Category
    {
        get { return _category.Value; }
    }
}
