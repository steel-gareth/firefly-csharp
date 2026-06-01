using System;
using System.Threading;
using System.Threading.Tasks;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Accounts;
using EmceesProdTesting5.Models.AvailableBudgets;
using EmceesProdTesting5.Models.Bills;
using EmceesProdTesting5.Models.Budgets.Limits;
using EmceesProdTesting5.Models.Currencies;
using EmceesProdTesting5.Models.Recurrences;
using EmceesProdTesting5.Services.Currencies;

namespace EmceesProdTesting5.Services;

/// <summary>
/// Endpoints to manage the currencies in Firefly III. Depending on the user&amp;#039;s
/// role you can also disable and enable them, or add new ones.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ICurrencyService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICurrencyServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICurrencyService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IPrimaryService Primary { get; }

    /// <summary>
    /// Creates a new currency. The data required can be submitted as a JSON body or as
    /// a list of parameters.
    /// </summary>
    Task<CurrencySingle> Create(
        CurrencyCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a single currency.
    /// </summary>
    Task<CurrencySingle> Retrieve(
        CurrencyRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(CurrencyRetrieveParams, CancellationToken)"/>
    Task<CurrencySingle> Retrieve(
        string code,
        CurrencyRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update existing currency.
    /// </summary>
    Task<CurrencySingle> Update(
        CurrencyUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(CurrencyUpdateParams, CancellationToken)"/>
    Task<CurrencySingle> Update(
        string code,
        CurrencyUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List all currencies.
    /// </summary>
    Task<CurrencyListResponse> List(
        CurrencyListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a currency.
    /// </summary>
    Task Delete(CurrencyDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(CurrencyDeleteParams, CancellationToken)"/>
    Task Delete(
        string code,
        CurrencyDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Disable a currency.
    /// </summary>
    Task<CurrencySingle> Disable(
        CurrencyDisableParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Disable(CurrencyDisableParams, CancellationToken)"/>
    Task<CurrencySingle> Disable(
        string code,
        CurrencyDisableParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Enable a single currency.
    /// </summary>
    Task<CurrencySingle> Enable(
        CurrencyEnableParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Enable(CurrencyEnableParams, CancellationToken)"/>
    Task<CurrencySingle> Enable(
        string code,
        CurrencyEnableParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List all accounts with this currency.
    /// </summary>
    Task<AccountArray> ListAccounts(
        CurrencyListAccountsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListAccounts(CurrencyListAccountsParams, CancellationToken)"/>
    Task<AccountArray> ListAccounts(
        string code,
        CurrencyListAccountsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List all available budgets with this currency.
    /// </summary>
    Task<AvailableBudgetArray> ListAvailableBudgets(
        CurrencyListAvailableBudgetsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListAvailableBudgets(CurrencyListAvailableBudgetsParams, CancellationToken)"/>
    Task<AvailableBudgetArray> ListAvailableBudgets(
        string code,
        CurrencyListAvailableBudgetsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List all bills with this currency.
    /// </summary>
    Task<BillArray> ListBills(
        CurrencyListBillsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListBills(CurrencyListBillsParams, CancellationToken)"/>
    Task<BillArray> ListBills(
        string code,
        CurrencyListBillsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List all budget limits with this currency
    /// </summary>
    Task<BudgetLimitArray> ListBudgetLimits(
        CurrencyListBudgetLimitsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListBudgetLimits(CurrencyListBudgetLimitsParams, CancellationToken)"/>
    Task<BudgetLimitArray> ListBudgetLimits(
        string code,
        CurrencyListBudgetLimitsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List all recurring transactions with this currency.
    /// </summary>
    Task<RecurrenceArray> ListRecurrences(
        CurrencyListRecurrencesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListRecurrences(CurrencyListRecurrencesParams, CancellationToken)"/>
    Task<RecurrenceArray> ListRecurrences(
        string code,
        CurrencyListRecurrencesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List all rules with this currency.
    /// </summary>
    Task<RuleArray> ListRules(
        CurrencyListRulesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListRules(CurrencyListRulesParams, CancellationToken)"/>
    Task<RuleArray> ListRules(
        string code,
        CurrencyListRulesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List all transactions with this currency.
    /// </summary>
    Task<TransactionArray> ListTransactions(
        CurrencyListTransactionsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListTransactions(CurrencyListTransactionsParams, CancellationToken)"/>
    Task<TransactionArray> ListTransactions(
        string code,
        CurrencyListTransactionsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ICurrencyService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICurrencyServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICurrencyServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IPrimaryServiceWithRawResponse Primary { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/currencies</c>, but is otherwise the
    /// same as <see cref="ICurrencyService.Create(CurrencyCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CurrencySingle>> Create(
        CurrencyCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/currencies/{code}</c>, but is otherwise the
    /// same as <see cref="ICurrencyService.Retrieve(CurrencyRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CurrencySingle>> Retrieve(
        CurrencyRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(CurrencyRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<CurrencySingle>> Retrieve(
        string code,
        CurrencyRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /v1/currencies/{code}</c>, but is otherwise the
    /// same as <see cref="ICurrencyService.Update(CurrencyUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CurrencySingle>> Update(
        CurrencyUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(CurrencyUpdateParams, CancellationToken)"/>
    Task<HttpResponse<CurrencySingle>> Update(
        string code,
        CurrencyUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/currencies</c>, but is otherwise the
    /// same as <see cref="ICurrencyService.List(CurrencyListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CurrencyListResponse>> List(
        CurrencyListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/currencies/{code}</c>, but is otherwise the
    /// same as <see cref="ICurrencyService.Delete(CurrencyDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        CurrencyDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(CurrencyDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string code,
        CurrencyDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/currencies/{code}/disable</c>, but is otherwise the
    /// same as <see cref="ICurrencyService.Disable(CurrencyDisableParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CurrencySingle>> Disable(
        CurrencyDisableParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Disable(CurrencyDisableParams, CancellationToken)"/>
    Task<HttpResponse<CurrencySingle>> Disable(
        string code,
        CurrencyDisableParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/currencies/{code}/enable</c>, but is otherwise the
    /// same as <see cref="ICurrencyService.Enable(CurrencyEnableParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CurrencySingle>> Enable(
        CurrencyEnableParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Enable(CurrencyEnableParams, CancellationToken)"/>
    Task<HttpResponse<CurrencySingle>> Enable(
        string code,
        CurrencyEnableParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/currencies/{code}/accounts</c>, but is otherwise the
    /// same as <see cref="ICurrencyService.ListAccounts(CurrencyListAccountsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AccountArray>> ListAccounts(
        CurrencyListAccountsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListAccounts(CurrencyListAccountsParams, CancellationToken)"/>
    Task<HttpResponse<AccountArray>> ListAccounts(
        string code,
        CurrencyListAccountsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/currencies/{code}/available-budgets</c>, but is otherwise the
    /// same as <see cref="ICurrencyService.ListAvailableBudgets(CurrencyListAvailableBudgetsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AvailableBudgetArray>> ListAvailableBudgets(
        CurrencyListAvailableBudgetsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListAvailableBudgets(CurrencyListAvailableBudgetsParams, CancellationToken)"/>
    Task<HttpResponse<AvailableBudgetArray>> ListAvailableBudgets(
        string code,
        CurrencyListAvailableBudgetsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/currencies/{code}/bills</c>, but is otherwise the
    /// same as <see cref="ICurrencyService.ListBills(CurrencyListBillsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BillArray>> ListBills(
        CurrencyListBillsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListBills(CurrencyListBillsParams, CancellationToken)"/>
    Task<HttpResponse<BillArray>> ListBills(
        string code,
        CurrencyListBillsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/currencies/{code}/budget-limits</c>, but is otherwise the
    /// same as <see cref="ICurrencyService.ListBudgetLimits(CurrencyListBudgetLimitsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BudgetLimitArray>> ListBudgetLimits(
        CurrencyListBudgetLimitsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListBudgetLimits(CurrencyListBudgetLimitsParams, CancellationToken)"/>
    Task<HttpResponse<BudgetLimitArray>> ListBudgetLimits(
        string code,
        CurrencyListBudgetLimitsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/currencies/{code}/recurrences</c>, but is otherwise the
    /// same as <see cref="ICurrencyService.ListRecurrences(CurrencyListRecurrencesParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RecurrenceArray>> ListRecurrences(
        CurrencyListRecurrencesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListRecurrences(CurrencyListRecurrencesParams, CancellationToken)"/>
    Task<HttpResponse<RecurrenceArray>> ListRecurrences(
        string code,
        CurrencyListRecurrencesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/currencies/{code}/rules</c>, but is otherwise the
    /// same as <see cref="ICurrencyService.ListRules(CurrencyListRulesParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RuleArray>> ListRules(
        CurrencyListRulesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListRules(CurrencyListRulesParams, CancellationToken)"/>
    Task<HttpResponse<RuleArray>> ListRules(
        string code,
        CurrencyListRulesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/currencies/{code}/transactions</c>, but is otherwise the
    /// same as <see cref="ICurrencyService.ListTransactions(CurrencyListTransactionsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TransactionArray>> ListTransactions(
        CurrencyListTransactionsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListTransactions(CurrencyListTransactionsParams, CancellationToken)"/>
    Task<HttpResponse<TransactionArray>> ListTransactions(
        string code,
        CurrencyListTransactionsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
