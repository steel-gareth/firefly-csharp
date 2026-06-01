using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Firefly.Core;
using Firefly.Exceptions;
using Firefly.Models.Accounts;
using Firefly.Models.AvailableBudgets;
using Firefly.Models.Bills;
using Firefly.Models.Budgets.Limits;
using Firefly.Models.Currencies;
using Firefly.Models.Recurrences;
using Firefly.Services.Currencies;

namespace Firefly.Services;

/// <inheritdoc/>
public sealed class CurrencyService : ICurrencyService
{
    readonly Lazy<ICurrencyServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICurrencyServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IFireflyClient _client;

    /// <inheritdoc/>
    public ICurrencyService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CurrencyService(this._client.WithOptions(modifier));
    }

    public CurrencyService(IFireflyClient client)
    {
        _client = client;

        _withRawResponse = new(() => new CurrencyServiceWithRawResponse(client.WithRawResponse));
        _primary = new(() => new PrimaryService(client));
    }

    readonly Lazy<IPrimaryService> _primary;
    public IPrimaryService Primary
    {
        get { return _primary.Value; }
    }

    /// <inheritdoc/>
    public async Task<CurrencySingle> Create(
        CurrencyCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CurrencySingle> Retrieve(
        CurrencyRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CurrencySingle> Retrieve(
        string code,
        CurrencyRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { Code = code }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CurrencySingle> Update(
        CurrencyUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CurrencySingle> Update(
        string code,
        CurrencyUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { Code = code }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CurrencyListResponse> List(
        CurrencyListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(
        CurrencyDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string code,
        CurrencyDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { Code = code }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CurrencySingle> Disable(
        CurrencyDisableParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Disable(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CurrencySingle> Disable(
        string code,
        CurrencyDisableParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Disable(parameters with { Code = code }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CurrencySingle> Enable(
        CurrencyEnableParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Enable(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CurrencySingle> Enable(
        string code,
        CurrencyEnableParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Enable(parameters with { Code = code }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AccountArray> ListAccounts(
        CurrencyListAccountsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListAccounts(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AccountArray> ListAccounts(
        string code,
        CurrencyListAccountsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListAccounts(parameters with { Code = code }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AvailableBudgetArray> ListAvailableBudgets(
        CurrencyListAvailableBudgetsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListAvailableBudgets(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AvailableBudgetArray> ListAvailableBudgets(
        string code,
        CurrencyListAvailableBudgetsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListAvailableBudgets(parameters with { Code = code }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BillArray> ListBills(
        CurrencyListBillsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListBills(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BillArray> ListBills(
        string code,
        CurrencyListBillsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListBills(parameters with { Code = code }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BudgetLimitArray> ListBudgetLimits(
        CurrencyListBudgetLimitsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListBudgetLimits(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BudgetLimitArray> ListBudgetLimits(
        string code,
        CurrencyListBudgetLimitsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListBudgetLimits(parameters with { Code = code }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<RecurrenceArray> ListRecurrences(
        CurrencyListRecurrencesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListRecurrences(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<RecurrenceArray> ListRecurrences(
        string code,
        CurrencyListRecurrencesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListRecurrences(parameters with { Code = code }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<RuleArray> ListRules(
        CurrencyListRulesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListRules(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<RuleArray> ListRules(
        string code,
        CurrencyListRulesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListRules(parameters with { Code = code }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TransactionArray> ListTransactions(
        CurrencyListTransactionsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListTransactions(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<TransactionArray> ListTransactions(
        string code,
        CurrencyListTransactionsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListTransactions(parameters with { Code = code }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class CurrencyServiceWithRawResponse : ICurrencyServiceWithRawResponse
{
    readonly IFireflyClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICurrencyServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CurrencyServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CurrencyServiceWithRawResponse(IFireflyClientWithRawResponse client)
    {
        _client = client;

        _primary = new(() => new PrimaryServiceWithRawResponse(client));
    }

    readonly Lazy<IPrimaryServiceWithRawResponse> _primary;
    public IPrimaryServiceWithRawResponse Primary
    {
        get { return _primary.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CurrencySingle>> Create(
        CurrencyCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CurrencyCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var currencySingle = await response
                    .Deserialize<CurrencySingle>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    currencySingle.Validate();
                }
                return currencySingle;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CurrencySingle>> Retrieve(
        CurrencyRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Code == null)
        {
            throw new FireflyInvalidDataException("'parameters.Code' cannot be null");
        }

        HttpRequest<CurrencyRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var currencySingle = await response
                    .Deserialize<CurrencySingle>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    currencySingle.Validate();
                }
                return currencySingle;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CurrencySingle>> Retrieve(
        string code,
        CurrencyRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { Code = code }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CurrencySingle>> Update(
        CurrencyUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Code == null)
        {
            throw new FireflyInvalidDataException("'parameters.Code' cannot be null");
        }

        HttpRequest<CurrencyUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var currencySingle = await response
                    .Deserialize<CurrencySingle>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    currencySingle.Validate();
                }
                return currencySingle;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CurrencySingle>> Update(
        string code,
        CurrencyUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { Code = code }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CurrencyListResponse>> List(
        CurrencyListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<CurrencyListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var currencies = await response
                    .Deserialize<CurrencyListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    currencies.Validate();
                }
                return currencies;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        CurrencyDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Code == null)
        {
            throw new FireflyInvalidDataException("'parameters.Code' cannot be null");
        }

        HttpRequest<CurrencyDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string code,
        CurrencyDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { Code = code }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CurrencySingle>> Disable(
        CurrencyDisableParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Code == null)
        {
            throw new FireflyInvalidDataException("'parameters.Code' cannot be null");
        }

        HttpRequest<CurrencyDisableParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var currencySingle = await response
                    .Deserialize<CurrencySingle>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    currencySingle.Validate();
                }
                return currencySingle;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CurrencySingle>> Disable(
        string code,
        CurrencyDisableParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Disable(parameters with { Code = code }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CurrencySingle>> Enable(
        CurrencyEnableParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Code == null)
        {
            throw new FireflyInvalidDataException("'parameters.Code' cannot be null");
        }

        HttpRequest<CurrencyEnableParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var currencySingle = await response
                    .Deserialize<CurrencySingle>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    currencySingle.Validate();
                }
                return currencySingle;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CurrencySingle>> Enable(
        string code,
        CurrencyEnableParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Enable(parameters with { Code = code }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AccountArray>> ListAccounts(
        CurrencyListAccountsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Code == null)
        {
            throw new FireflyInvalidDataException("'parameters.Code' cannot be null");
        }

        HttpRequest<CurrencyListAccountsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var accountArray = await response
                    .Deserialize<AccountArray>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    accountArray.Validate();
                }
                return accountArray;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<AccountArray>> ListAccounts(
        string code,
        CurrencyListAccountsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListAccounts(parameters with { Code = code }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AvailableBudgetArray>> ListAvailableBudgets(
        CurrencyListAvailableBudgetsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Code == null)
        {
            throw new FireflyInvalidDataException("'parameters.Code' cannot be null");
        }

        HttpRequest<CurrencyListAvailableBudgetsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var availableBudgetArray = await response
                    .Deserialize<AvailableBudgetArray>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    availableBudgetArray.Validate();
                }
                return availableBudgetArray;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<AvailableBudgetArray>> ListAvailableBudgets(
        string code,
        CurrencyListAvailableBudgetsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListAvailableBudgets(parameters with { Code = code }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BillArray>> ListBills(
        CurrencyListBillsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Code == null)
        {
            throw new FireflyInvalidDataException("'parameters.Code' cannot be null");
        }

        HttpRequest<CurrencyListBillsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var billArray = await response.Deserialize<BillArray>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    billArray.Validate();
                }
                return billArray;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BillArray>> ListBills(
        string code,
        CurrencyListBillsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListBills(parameters with { Code = code }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BudgetLimitArray>> ListBudgetLimits(
        CurrencyListBudgetLimitsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Code == null)
        {
            throw new FireflyInvalidDataException("'parameters.Code' cannot be null");
        }

        HttpRequest<CurrencyListBudgetLimitsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var budgetLimitArray = await response
                    .Deserialize<BudgetLimitArray>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    budgetLimitArray.Validate();
                }
                return budgetLimitArray;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BudgetLimitArray>> ListBudgetLimits(
        string code,
        CurrencyListBudgetLimitsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListBudgetLimits(parameters with { Code = code }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RecurrenceArray>> ListRecurrences(
        CurrencyListRecurrencesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Code == null)
        {
            throw new FireflyInvalidDataException("'parameters.Code' cannot be null");
        }

        HttpRequest<CurrencyListRecurrencesParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var recurrenceArray = await response
                    .Deserialize<RecurrenceArray>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    recurrenceArray.Validate();
                }
                return recurrenceArray;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<RecurrenceArray>> ListRecurrences(
        string code,
        CurrencyListRecurrencesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListRecurrences(parameters with { Code = code }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RuleArray>> ListRules(
        CurrencyListRulesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Code == null)
        {
            throw new FireflyInvalidDataException("'parameters.Code' cannot be null");
        }

        HttpRequest<CurrencyListRulesParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var ruleArray = await response.Deserialize<RuleArray>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    ruleArray.Validate();
                }
                return ruleArray;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<RuleArray>> ListRules(
        string code,
        CurrencyListRulesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListRules(parameters with { Code = code }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TransactionArray>> ListTransactions(
        CurrencyListTransactionsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Code == null)
        {
            throw new FireflyInvalidDataException("'parameters.Code' cannot be null");
        }

        HttpRequest<CurrencyListTransactionsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var transactionArray = await response
                    .Deserialize<TransactionArray>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    transactionArray.Validate();
                }
                return transactionArray;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<TransactionArray>> ListTransactions(
        string code,
        CurrencyListTransactionsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListTransactions(parameters with { Code = code }, cancellationToken);
    }
}
