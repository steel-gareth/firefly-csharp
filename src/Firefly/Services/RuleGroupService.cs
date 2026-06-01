using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Firefly.Core;
using Firefly.Exceptions;
using Firefly.Models.Accounts;
using Firefly.Models.Bills;
using Firefly.Models.RuleGroups;

namespace Firefly.Services;

/// <inheritdoc/>
public sealed class RuleGroupService : IRuleGroupService
{
    readonly Lazy<IRuleGroupServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IRuleGroupServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IFireflyClient _client;

    /// <inheritdoc/>
    public IRuleGroupService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RuleGroupService(this._client.WithOptions(modifier));
    }

    public RuleGroupService(IFireflyClient client)
    {
        _client = client;

        _withRawResponse = new(() => new RuleGroupServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<RuleGroupSingle> Create(
        RuleGroupCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<RuleGroupSingle> Retrieve(
        RuleGroupRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<RuleGroupSingle> Retrieve(
        string id,
        RuleGroupRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<RuleGroupSingle> Update(
        RuleGroupUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<RuleGroupSingle> Update(
        string id,
        RuleGroupUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Delete(
        RuleGroupDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string id,
        RuleGroupDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<RuleGroupListAllResponse> ListAll(
        RuleGroupListAllParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListAll(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<RuleArray> ListRules(
        RuleGroupListRulesParams parameters,
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
        string id,
        RuleGroupListRulesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListRules(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TransactionArray> TestTransactions(
        RuleGroupTestTransactionsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.TestTransactions(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<TransactionArray> TestTransactions(
        string id,
        RuleGroupTestTransactionsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.TestTransactions(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task TriggerRules(
        RuleGroupTriggerRulesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.TriggerRules(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task TriggerRules(
        string id,
        RuleGroupTriggerRulesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.TriggerRules(parameters with { ID = id }, cancellationToken)
            .ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class RuleGroupServiceWithRawResponse : IRuleGroupServiceWithRawResponse
{
    readonly IFireflyClientWithRawResponse _client;

    /// <inheritdoc/>
    public IRuleGroupServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RuleGroupServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public RuleGroupServiceWithRawResponse(IFireflyClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RuleGroupSingle>> Create(
        RuleGroupCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<RuleGroupCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var ruleGroupSingle = await response
                    .Deserialize<RuleGroupSingle>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    ruleGroupSingle.Validate();
                }
                return ruleGroupSingle;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RuleGroupSingle>> Retrieve(
        RuleGroupRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new FireflyInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<RuleGroupRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var ruleGroupSingle = await response
                    .Deserialize<RuleGroupSingle>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    ruleGroupSingle.Validate();
                }
                return ruleGroupSingle;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<RuleGroupSingle>> Retrieve(
        string id,
        RuleGroupRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RuleGroupSingle>> Update(
        RuleGroupUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new FireflyInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<RuleGroupUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var ruleGroupSingle = await response
                    .Deserialize<RuleGroupSingle>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    ruleGroupSingle.Validate();
                }
                return ruleGroupSingle;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<RuleGroupSingle>> Update(
        string id,
        RuleGroupUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        RuleGroupDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new FireflyInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<RuleGroupDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string id,
        RuleGroupDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RuleGroupListAllResponse>> ListAll(
        RuleGroupListAllParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<RuleGroupListAllParams> request = new()
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
                    .Deserialize<RuleGroupListAllResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RuleArray>> ListRules(
        RuleGroupListRulesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new FireflyInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<RuleGroupListRulesParams> request = new()
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
        string id,
        RuleGroupListRulesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListRules(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TransactionArray>> TestTransactions(
        RuleGroupTestTransactionsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new FireflyInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<RuleGroupTestTransactionsParams> request = new()
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
    public Task<HttpResponse<TransactionArray>> TestTransactions(
        string id,
        RuleGroupTestTransactionsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.TestTransactions(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> TriggerRules(
        RuleGroupTriggerRulesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new FireflyInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<RuleGroupTriggerRulesParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> TriggerRules(
        string id,
        RuleGroupTriggerRulesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.TriggerRules(parameters with { ID = id }, cancellationToken);
    }
}
