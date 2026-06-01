using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Firefly.Core;
using Firefly.Models.Autocomplete;

namespace Firefly.Services;

/// <summary>
/// Auto-complete endpoints show basic information about Firefly III models, like
/// the name and maybe some amounts. They all support a search query and can be used
/// to autocomplete data in forms. Autocomplete return values always have a &amp;quot;name&amp;quot;-field.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IAutocompleteService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAutocompleteServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAutocompleteService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns all accounts of the user returned in a basic auto-complete array.
    /// </summary>
    Task<List<AutocompleteListAccountsResponse>> ListAccounts(
        AutocompleteListAccountsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns all bills of the user returned in a basic auto-complete array.
    /// </summary>
    Task<List<AutocompleteBill>> ListBills(
        AutocompleteListBillsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns all budgets of the user returned in a basic auto-complete array.
    /// </summary>
    Task<List<AutocompleteListBudgetsResponse>> ListBudgets(
        AutocompleteListBudgetsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns all categories of the user returned in a basic auto-complete array.
    /// </summary>
    Task<List<AutocompleteListCategoriesResponse>> ListCategories(
        AutocompleteListCategoriesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns all currencies of the user returned in a basic auto-complete array.
    /// </summary>
    Task<List<AutocompleteListCurrenciesResponse>> ListCurrencies(
        AutocompleteListCurrenciesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns all currencies of the user returned in a basic auto-complete array. This
    /// endpoint is DEPRECATED and I suggest you DO NOT use it.
    /// </summary>
    Task<List<AutocompleteListCurrenciesWithCodeResponse>> ListCurrenciesWithCode(
        AutocompleteListCurrenciesWithCodeParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns all object groups of the user returned in a basic auto-complete array.
    /// </summary>
    Task<List<AutocompleteListObjectGroupsResponse>> ListObjectGroups(
        AutocompleteListObjectGroupsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns all piggy banks of the user returned in a basic auto-complete array.
    /// </summary>
    Task<List<AutocompleteListPiggyBanksResponse>> ListPiggyBanks(
        AutocompleteListPiggyBanksParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns all piggy banks of the user returned in a basic auto-complete array.
    /// </summary>
    Task<List<AutocompleteListPiggyBanksWithBalanceResponse>> ListPiggyBanksWithBalance(
        AutocompleteListPiggyBanksWithBalanceParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns all recurring transactions of the user returned in a basic auto-complete
    /// array.
    /// </summary>
    Task<List<AutocompleteListRecurringTransactionsResponse>> ListRecurringTransactions(
        AutocompleteListRecurringTransactionsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns all rule groups of the user returned in a basic auto-complete array.
    /// </summary>
    Task<List<AutocompleteListRuleGroupsResponse>> ListRuleGroups(
        AutocompleteListRuleGroupsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns all rules of the user returned in a basic auto-complete array.
    /// </summary>
    Task<List<AutocompleteListRulesResponse>> ListRules(
        AutocompleteListRulesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns all subscriptions of the user returned in a basic auto-complete array.
    /// </summary>
    Task<List<AutocompleteBill>> ListSubscriptions(
        AutocompleteListSubscriptionsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns all tags of the user returned in a basic auto-complete array.
    /// </summary>
    Task<List<AutocompleteListTagsResponse>> ListTags(
        AutocompleteListTagsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns all transaction types returned in a basic auto-complete array. English
    /// only.
    /// </summary>
    Task<List<AutocompleteListTransactionTypesResponse>> ListTransactionTypes(
        AutocompleteListTransactionTypesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns all transaction descriptions of the user returned in a basic
    /// auto-complete array.
    /// </summary>
    Task<List<AutocompleteListTransactionsResponse>> ListTransactions(
        AutocompleteListTransactionsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns all transactions, complemented with their ID, of the user returned in a
    /// basic auto-complete array. This endpoint is DEPRECATED and I suggest you DO NOT
    /// use it.
    /// </summary>
    Task<List<AutocompleteListTransactionsWithIDResponse>> ListTransactionsWithID(
        AutocompleteListTransactionsWithIDParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IAutocompleteService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAutocompleteServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAutocompleteServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/autocomplete/accounts</c>, but is otherwise the
    /// same as <see cref="IAutocompleteService.ListAccounts(AutocompleteListAccountsParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<AutocompleteListAccountsResponse>>> ListAccounts(
        AutocompleteListAccountsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/autocomplete/bills</c>, but is otherwise the
    /// same as <see cref="IAutocompleteService.ListBills(AutocompleteListBillsParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<AutocompleteBill>>> ListBills(
        AutocompleteListBillsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/autocomplete/budgets</c>, but is otherwise the
    /// same as <see cref="IAutocompleteService.ListBudgets(AutocompleteListBudgetsParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<AutocompleteListBudgetsResponse>>> ListBudgets(
        AutocompleteListBudgetsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/autocomplete/categories</c>, but is otherwise the
    /// same as <see cref="IAutocompleteService.ListCategories(AutocompleteListCategoriesParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<AutocompleteListCategoriesResponse>>> ListCategories(
        AutocompleteListCategoriesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/autocomplete/currencies</c>, but is otherwise the
    /// same as <see cref="IAutocompleteService.ListCurrencies(AutocompleteListCurrenciesParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<AutocompleteListCurrenciesResponse>>> ListCurrencies(
        AutocompleteListCurrenciesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/autocomplete/currencies-with-code</c>, but is otherwise the
    /// same as <see cref="IAutocompleteService.ListCurrenciesWithCode(AutocompleteListCurrenciesWithCodeParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<AutocompleteListCurrenciesWithCodeResponse>>> ListCurrenciesWithCode(
        AutocompleteListCurrenciesWithCodeParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/autocomplete/object-groups</c>, but is otherwise the
    /// same as <see cref="IAutocompleteService.ListObjectGroups(AutocompleteListObjectGroupsParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<AutocompleteListObjectGroupsResponse>>> ListObjectGroups(
        AutocompleteListObjectGroupsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/autocomplete/piggy-banks</c>, but is otherwise the
    /// same as <see cref="IAutocompleteService.ListPiggyBanks(AutocompleteListPiggyBanksParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<AutocompleteListPiggyBanksResponse>>> ListPiggyBanks(
        AutocompleteListPiggyBanksParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/autocomplete/piggy-banks-with-balance</c>, but is otherwise the
    /// same as <see cref="IAutocompleteService.ListPiggyBanksWithBalance(AutocompleteListPiggyBanksWithBalanceParams?, CancellationToken)"/>.
    /// </summary>
    Task<
        HttpResponse<List<AutocompleteListPiggyBanksWithBalanceResponse>>
    > ListPiggyBanksWithBalance(
        AutocompleteListPiggyBanksWithBalanceParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/autocomplete/recurring</c>, but is otherwise the
    /// same as <see cref="IAutocompleteService.ListRecurringTransactions(AutocompleteListRecurringTransactionsParams?, CancellationToken)"/>.
    /// </summary>
    Task<
        HttpResponse<List<AutocompleteListRecurringTransactionsResponse>>
    > ListRecurringTransactions(
        AutocompleteListRecurringTransactionsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/autocomplete/rule-groups</c>, but is otherwise the
    /// same as <see cref="IAutocompleteService.ListRuleGroups(AutocompleteListRuleGroupsParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<AutocompleteListRuleGroupsResponse>>> ListRuleGroups(
        AutocompleteListRuleGroupsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/autocomplete/rules</c>, but is otherwise the
    /// same as <see cref="IAutocompleteService.ListRules(AutocompleteListRulesParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<AutocompleteListRulesResponse>>> ListRules(
        AutocompleteListRulesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/autocomplete/subscriptions</c>, but is otherwise the
    /// same as <see cref="IAutocompleteService.ListSubscriptions(AutocompleteListSubscriptionsParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<AutocompleteBill>>> ListSubscriptions(
        AutocompleteListSubscriptionsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/autocomplete/tags</c>, but is otherwise the
    /// same as <see cref="IAutocompleteService.ListTags(AutocompleteListTagsParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<AutocompleteListTagsResponse>>> ListTags(
        AutocompleteListTagsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/autocomplete/transaction-types</c>, but is otherwise the
    /// same as <see cref="IAutocompleteService.ListTransactionTypes(AutocompleteListTransactionTypesParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<AutocompleteListTransactionTypesResponse>>> ListTransactionTypes(
        AutocompleteListTransactionTypesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/autocomplete/transactions</c>, but is otherwise the
    /// same as <see cref="IAutocompleteService.ListTransactions(AutocompleteListTransactionsParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<AutocompleteListTransactionsResponse>>> ListTransactions(
        AutocompleteListTransactionsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/autocomplete/transactions-with-id</c>, but is otherwise the
    /// same as <see cref="IAutocompleteService.ListTransactionsWithID(AutocompleteListTransactionsWithIDParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<AutocompleteListTransactionsWithIDResponse>>> ListTransactionsWithID(
        AutocompleteListTransactionsWithIDParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
