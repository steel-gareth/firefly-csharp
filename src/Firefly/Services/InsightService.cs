using System;
using Firefly.Core;
using Firefly.Services.Insight;

namespace Firefly.Services;

/// <inheritdoc/>
public sealed class InsightService : IInsightService
{
    readonly Lazy<IInsightServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IInsightServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IFireflyClient _client;

    /// <inheritdoc/>
    public IInsightService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new InsightService(this._client.WithOptions(modifier));
    }

    public InsightService(IFireflyClient client)
    {
        _client = client;

        _withRawResponse = new(() => new InsightServiceWithRawResponse(client.WithRawResponse));
        _expense = new(() => new ExpenseService(client));
        _income = new(() => new IncomeService(client));
        _transfer = new(() => new TransferService(client));
    }

    readonly Lazy<IExpenseService> _expense;
    public IExpenseService Expense
    {
        get { return _expense.Value; }
    }

    readonly Lazy<IIncomeService> _income;
    public IIncomeService Income
    {
        get { return _income.Value; }
    }

    readonly Lazy<ITransferService> _transfer;
    public ITransferService Transfer
    {
        get { return _transfer.Value; }
    }
}

/// <inheritdoc/>
public sealed class InsightServiceWithRawResponse : IInsightServiceWithRawResponse
{
    readonly IFireflyClientWithRawResponse _client;

    /// <inheritdoc/>
    public IInsightServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new InsightServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public InsightServiceWithRawResponse(IFireflyClientWithRawResponse client)
    {
        _client = client;

        _expense = new(() => new ExpenseServiceWithRawResponse(client));
        _income = new(() => new IncomeServiceWithRawResponse(client));
        _transfer = new(() => new TransferServiceWithRawResponse(client));
    }

    readonly Lazy<IExpenseServiceWithRawResponse> _expense;
    public IExpenseServiceWithRawResponse Expense
    {
        get { return _expense.Value; }
    }

    readonly Lazy<IIncomeServiceWithRawResponse> _income;
    public IIncomeServiceWithRawResponse Income
    {
        get { return _income.Value; }
    }

    readonly Lazy<ITransferServiceWithRawResponse> _transfer;
    public ITransferServiceWithRawResponse Transfer
    {
        get { return _transfer.Value; }
    }
}
