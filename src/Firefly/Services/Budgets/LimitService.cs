using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Firefly.Core;
using Firefly.Exceptions;
using Firefly.Models.Accounts;
using Firefly.Models.Budgets.Limits;

namespace Firefly.Services.Budgets;

/// <inheritdoc/>
public sealed class LimitService : ILimitService
{
    readonly Lazy<ILimitServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ILimitServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IFireflyClient _client;

    /// <inheritdoc/>
    public ILimitService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new LimitService(this._client.WithOptions(modifier));
    }

    public LimitService(IFireflyClient client)
    {
        _client = client;

        _withRawResponse = new(() => new LimitServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<BudgetLimitSingle> Create(
        LimitCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BudgetLimitSingle> Create(
        string id,
        LimitCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BudgetLimitSingle> Retrieve(
        LimitRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BudgetLimitSingle> Retrieve(
        long limitID,
        LimitRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { LimitID = limitID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BudgetLimitSingle> Update(
        LimitUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BudgetLimitSingle> Update(
        string limitID,
        LimitUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { LimitID = limitID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Delete(LimitDeleteParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string limitID,
        LimitDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Delete(parameters with { LimitID = limitID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BudgetLimitArray> List0(
        LimitList0Params parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List0(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BudgetLimitArray> List0(
        string id,
        LimitList0Params? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List0(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BudgetLimitArray> List1(
        LimitList1Params parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List1(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<TransactionArray> ListTransactions(
        LimitListTransactionsParams parameters,
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
        string limitID,
        LimitListTransactionsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.ListTransactions(parameters with { LimitID = limitID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class LimitServiceWithRawResponse : ILimitServiceWithRawResponse
{
    readonly IFireflyClientWithRawResponse _client;

    /// <inheritdoc/>
    public ILimitServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new LimitServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public LimitServiceWithRawResponse(IFireflyClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BudgetLimitSingle>> Create(
        LimitCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new FireflyInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<LimitCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var budgetLimitSingle = await response
                    .Deserialize<BudgetLimitSingle>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    budgetLimitSingle.Validate();
                }
                return budgetLimitSingle;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BudgetLimitSingle>> Create(
        string id,
        LimitCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BudgetLimitSingle>> Retrieve(
        LimitRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.LimitID == null)
        {
            throw new FireflyInvalidDataException("'parameters.LimitID' cannot be null");
        }

        HttpRequest<LimitRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var budgetLimitSingle = await response
                    .Deserialize<BudgetLimitSingle>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    budgetLimitSingle.Validate();
                }
                return budgetLimitSingle;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BudgetLimitSingle>> Retrieve(
        long limitID,
        LimitRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { LimitID = limitID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BudgetLimitSingle>> Update(
        LimitUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.LimitID == null)
        {
            throw new FireflyInvalidDataException("'parameters.LimitID' cannot be null");
        }

        HttpRequest<LimitUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var budgetLimitSingle = await response
                    .Deserialize<BudgetLimitSingle>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    budgetLimitSingle.Validate();
                }
                return budgetLimitSingle;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BudgetLimitSingle>> Update(
        string limitID,
        LimitUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { LimitID = limitID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        LimitDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.LimitID == null)
        {
            throw new FireflyInvalidDataException("'parameters.LimitID' cannot be null");
        }

        HttpRequest<LimitDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string limitID,
        LimitDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with { LimitID = limitID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BudgetLimitArray>> List0(
        LimitList0Params parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new FireflyInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<LimitList0Params> request = new()
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
    public Task<HttpResponse<BudgetLimitArray>> List0(
        string id,
        LimitList0Params? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List0(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BudgetLimitArray>> List1(
        LimitList1Params parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<LimitList1Params> request = new()
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
    public async Task<HttpResponse<TransactionArray>> ListTransactions(
        LimitListTransactionsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.LimitID == null)
        {
            throw new FireflyInvalidDataException("'parameters.LimitID' cannot be null");
        }

        HttpRequest<LimitListTransactionsParams> request = new()
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
        string limitID,
        LimitListTransactionsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.ListTransactions(parameters with { LimitID = limitID }, cancellationToken);
    }
}
