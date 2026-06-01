using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Accounts;
using EmceesProdTesting5.Models.Search;

namespace EmceesProdTesting5.Services;

/// <inheritdoc/>
public sealed class SearchService : ISearchService
{
    readonly Lazy<ISearchServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISearchServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IEmceesProdTesting5Client _client;

    /// <inheritdoc/>
    public ISearchService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SearchService(this._client.WithOptions(modifier));
    }

    public SearchService(IEmceesProdTesting5Client client)
    {
        _client = client;

        _withRawResponse = new(() => new SearchServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<AccountArray> Accounts(
        SearchAccountsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Accounts(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<TransactionArray> Transactions(
        SearchTransactionsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Transactions(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class SearchServiceWithRawResponse : ISearchServiceWithRawResponse
{
    readonly IEmceesProdTesting5ClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISearchServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SearchServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SearchServiceWithRawResponse(IEmceesProdTesting5ClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AccountArray>> Accounts(
        SearchAccountsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SearchAccountsParams> request = new()
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
    public async Task<HttpResponse<TransactionArray>> Transactions(
        SearchTransactionsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SearchTransactionsParams> request = new()
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
}
