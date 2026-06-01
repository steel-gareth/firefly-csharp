using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Autocomplete;

namespace EmceesProdTesting5.Services;

/// <inheritdoc/>
public sealed class AutocompleteService : IAutocompleteService
{
    readonly Lazy<IAutocompleteServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAutocompleteServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IEmceesProdTesting5Client _client;

    /// <inheritdoc/>
    public IAutocompleteService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AutocompleteService(this._client.WithOptions(modifier));
    }

    public AutocompleteService(IEmceesProdTesting5Client client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new AutocompleteServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<List<AutocompleteListAccountsResponse>> ListAccounts(
        AutocompleteListAccountsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListAccounts(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<List<AutocompleteBill>> ListBills(
        AutocompleteListBillsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListBills(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<List<AutocompleteListBudgetsResponse>> ListBudgets(
        AutocompleteListBudgetsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListBudgets(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<List<AutocompleteListCategoriesResponse>> ListCategories(
        AutocompleteListCategoriesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListCategories(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<List<AutocompleteListCurrenciesResponse>> ListCurrencies(
        AutocompleteListCurrenciesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListCurrencies(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<List<AutocompleteListCurrenciesWithCodeResponse>> ListCurrenciesWithCode(
        AutocompleteListCurrenciesWithCodeParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListCurrenciesWithCode(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<List<AutocompleteListObjectGroupsResponse>> ListObjectGroups(
        AutocompleteListObjectGroupsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListObjectGroups(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<List<AutocompleteListPiggyBanksResponse>> ListPiggyBanks(
        AutocompleteListPiggyBanksParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListPiggyBanks(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<
        List<AutocompleteListPiggyBanksWithBalanceResponse>
    > ListPiggyBanksWithBalance(
        AutocompleteListPiggyBanksWithBalanceParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListPiggyBanksWithBalance(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<
        List<AutocompleteListRecurringTransactionsResponse>
    > ListRecurringTransactions(
        AutocompleteListRecurringTransactionsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListRecurringTransactions(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<List<AutocompleteListRuleGroupsResponse>> ListRuleGroups(
        AutocompleteListRuleGroupsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListRuleGroups(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<List<AutocompleteListRulesResponse>> ListRules(
        AutocompleteListRulesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListRules(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<List<AutocompleteBill>> ListSubscriptions(
        AutocompleteListSubscriptionsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListSubscriptions(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<List<AutocompleteListTagsResponse>> ListTags(
        AutocompleteListTagsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListTags(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<List<AutocompleteListTransactionTypesResponse>> ListTransactionTypes(
        AutocompleteListTransactionTypesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListTransactionTypes(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<List<AutocompleteListTransactionsResponse>> ListTransactions(
        AutocompleteListTransactionsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListTransactions(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<List<AutocompleteListTransactionsWithIDResponse>> ListTransactionsWithID(
        AutocompleteListTransactionsWithIDParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListTransactionsWithID(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class AutocompleteServiceWithRawResponse : IAutocompleteServiceWithRawResponse
{
    readonly IEmceesProdTesting5ClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAutocompleteServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new AutocompleteServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AutocompleteServiceWithRawResponse(IEmceesProdTesting5ClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<AutocompleteListAccountsResponse>>> ListAccounts(
        AutocompleteListAccountsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AutocompleteListAccountsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<List<AutocompleteListAccountsResponse>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in deserializedResponse)
                    {
                        item.Validate();
                    }
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<AutocompleteBill>>> ListBills(
        AutocompleteListBillsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AutocompleteListBillsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var autocompleteBills = await response
                    .Deserialize<List<AutocompleteBill>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in autocompleteBills)
                    {
                        item.Validate();
                    }
                }
                return autocompleteBills;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<AutocompleteListBudgetsResponse>>> ListBudgets(
        AutocompleteListBudgetsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AutocompleteListBudgetsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<List<AutocompleteListBudgetsResponse>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in deserializedResponse)
                    {
                        item.Validate();
                    }
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<AutocompleteListCategoriesResponse>>> ListCategories(
        AutocompleteListCategoriesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AutocompleteListCategoriesParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<List<AutocompleteListCategoriesResponse>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in deserializedResponse)
                    {
                        item.Validate();
                    }
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<AutocompleteListCurrenciesResponse>>> ListCurrencies(
        AutocompleteListCurrenciesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AutocompleteListCurrenciesParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<List<AutocompleteListCurrenciesResponse>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in deserializedResponse)
                    {
                        item.Validate();
                    }
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<
        HttpResponse<List<AutocompleteListCurrenciesWithCodeResponse>>
    > ListCurrenciesWithCode(
        AutocompleteListCurrenciesWithCodeParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AutocompleteListCurrenciesWithCodeParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<List<AutocompleteListCurrenciesWithCodeResponse>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in deserializedResponse)
                    {
                        item.Validate();
                    }
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<AutocompleteListObjectGroupsResponse>>> ListObjectGroups(
        AutocompleteListObjectGroupsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AutocompleteListObjectGroupsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<List<AutocompleteListObjectGroupsResponse>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in deserializedResponse)
                    {
                        item.Validate();
                    }
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<AutocompleteListPiggyBanksResponse>>> ListPiggyBanks(
        AutocompleteListPiggyBanksParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AutocompleteListPiggyBanksParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<List<AutocompleteListPiggyBanksResponse>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in deserializedResponse)
                    {
                        item.Validate();
                    }
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<
        HttpResponse<List<AutocompleteListPiggyBanksWithBalanceResponse>>
    > ListPiggyBanksWithBalance(
        AutocompleteListPiggyBanksWithBalanceParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AutocompleteListPiggyBanksWithBalanceParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<List<AutocompleteListPiggyBanksWithBalanceResponse>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in deserializedResponse)
                    {
                        item.Validate();
                    }
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<
        HttpResponse<List<AutocompleteListRecurringTransactionsResponse>>
    > ListRecurringTransactions(
        AutocompleteListRecurringTransactionsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AutocompleteListRecurringTransactionsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<List<AutocompleteListRecurringTransactionsResponse>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in deserializedResponse)
                    {
                        item.Validate();
                    }
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<AutocompleteListRuleGroupsResponse>>> ListRuleGroups(
        AutocompleteListRuleGroupsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AutocompleteListRuleGroupsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<List<AutocompleteListRuleGroupsResponse>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in deserializedResponse)
                    {
                        item.Validate();
                    }
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<AutocompleteListRulesResponse>>> ListRules(
        AutocompleteListRulesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AutocompleteListRulesParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<List<AutocompleteListRulesResponse>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in deserializedResponse)
                    {
                        item.Validate();
                    }
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<AutocompleteBill>>> ListSubscriptions(
        AutocompleteListSubscriptionsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AutocompleteListSubscriptionsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var autocompleteBills = await response
                    .Deserialize<List<AutocompleteBill>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in autocompleteBills)
                    {
                        item.Validate();
                    }
                }
                return autocompleteBills;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<AutocompleteListTagsResponse>>> ListTags(
        AutocompleteListTagsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AutocompleteListTagsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<List<AutocompleteListTagsResponse>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in deserializedResponse)
                    {
                        item.Validate();
                    }
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<
        HttpResponse<List<AutocompleteListTransactionTypesResponse>>
    > ListTransactionTypes(
        AutocompleteListTransactionTypesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AutocompleteListTransactionTypesParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<List<AutocompleteListTransactionTypesResponse>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in deserializedResponse)
                    {
                        item.Validate();
                    }
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<AutocompleteListTransactionsResponse>>> ListTransactions(
        AutocompleteListTransactionsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AutocompleteListTransactionsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<List<AutocompleteListTransactionsResponse>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in deserializedResponse)
                    {
                        item.Validate();
                    }
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<
        HttpResponse<List<AutocompleteListTransactionsWithIDResponse>>
    > ListTransactionsWithID(
        AutocompleteListTransactionsWithIDParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AutocompleteListTransactionsWithIDParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<List<AutocompleteListTransactionsWithIDResponse>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in deserializedResponse)
                    {
                        item.Validate();
                    }
                }
                return deserializedResponse;
            }
        );
    }
}
