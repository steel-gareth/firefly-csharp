using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Exceptions;
using EmceesProdTesting5.Models.Accounts;
using EmceesProdTesting5.Models.Bills;
using EmceesProdTesting5.Models.Rules;

namespace EmceesProdTesting5.Services;

/// <inheritdoc/>
public sealed class RuleService : IRuleService
{
    readonly Lazy<IRuleServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IRuleServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IEmceesProdTesting5Client _client;

    /// <inheritdoc/>
    public IRuleService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RuleService(this._client.WithOptions(modifier));
    }

    public RuleService(IEmceesProdTesting5Client client)
    {
        _client = client;

        _withRawResponse = new(() => new RuleServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<RuleSingle> Create(
        RuleCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<RuleSingle> Retrieve(
        RuleRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<RuleSingle> Retrieve(
        string id,
        RuleRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<RuleSingle> Update(
        RuleUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<RuleSingle> Update(
        string id,
        RuleUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<RuleArray> List(
        RuleListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(RuleDeleteParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string id,
        RuleDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<TransactionArray> Test(
        RuleTestParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Test(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<TransactionArray> Test(
        string id,
        RuleTestParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Test(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Trigger(RuleTriggerParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Trigger(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Trigger(
        string id,
        RuleTriggerParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Trigger(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class RuleServiceWithRawResponse : IRuleServiceWithRawResponse
{
    readonly IEmceesProdTesting5ClientWithRawResponse _client;

    /// <inheritdoc/>
    public IRuleServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RuleServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public RuleServiceWithRawResponse(IEmceesProdTesting5ClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RuleSingle>> Create(
        RuleCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<RuleCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var ruleSingle = await response
                    .Deserialize<RuleSingle>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    ruleSingle.Validate();
                }
                return ruleSingle;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RuleSingle>> Retrieve(
        RuleRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new EmceesProdTesting5InvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<RuleRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var ruleSingle = await response
                    .Deserialize<RuleSingle>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    ruleSingle.Validate();
                }
                return ruleSingle;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<RuleSingle>> Retrieve(
        string id,
        RuleRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RuleSingle>> Update(
        RuleUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new EmceesProdTesting5InvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<RuleUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var ruleSingle = await response
                    .Deserialize<RuleSingle>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    ruleSingle.Validate();
                }
                return ruleSingle;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<RuleSingle>> Update(
        string id,
        RuleUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RuleArray>> List(
        RuleListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<RuleListParams> request = new()
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
    public Task<HttpResponse> Delete(
        RuleDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new EmceesProdTesting5InvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<RuleDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string id,
        RuleDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TransactionArray>> Test(
        RuleTestParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new EmceesProdTesting5InvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<RuleTestParams> request = new()
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
    public Task<HttpResponse<TransactionArray>> Test(
        string id,
        RuleTestParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Test(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Trigger(
        RuleTriggerParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new EmceesProdTesting5InvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<RuleTriggerParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Trigger(
        string id,
        RuleTriggerParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Trigger(parameters with { ID = id }, cancellationToken);
    }
}
