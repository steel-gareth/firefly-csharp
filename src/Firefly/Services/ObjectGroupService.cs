using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Firefly.Core;
using Firefly.Exceptions;
using Firefly.Models.Accounts;
using Firefly.Models.Bills;
using Firefly.Models.ObjectGroups;

namespace Firefly.Services;

/// <inheritdoc/>
public sealed class ObjectGroupService : IObjectGroupService
{
    readonly Lazy<IObjectGroupServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IObjectGroupServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IFireflyClient _client;

    /// <inheritdoc/>
    public IObjectGroupService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ObjectGroupService(this._client.WithOptions(modifier));
    }

    public ObjectGroupService(IFireflyClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ObjectGroupServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<ObjectGroupSingle> Retrieve(
        ObjectGroupRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ObjectGroupSingle> Retrieve(
        string id,
        ObjectGroupRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ObjectGroupSingle> Update(
        ObjectGroupUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ObjectGroupSingle> Update(
        string id,
        ObjectGroupUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ObjectGroupListResponse> List(
        ObjectGroupListParams? parameters = null,
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
        ObjectGroupDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string id,
        ObjectGroupDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BillArray> ListBills(
        ObjectGroupListBillsParams parameters,
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
        string id,
        ObjectGroupListBillsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListBills(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PiggyBankArray> ListPiggyBanks(
        ObjectGroupListPiggyBanksParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListPiggyBanks(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PiggyBankArray> ListPiggyBanks(
        string id,
        ObjectGroupListPiggyBanksParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListPiggyBanks(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class ObjectGroupServiceWithRawResponse : IObjectGroupServiceWithRawResponse
{
    readonly IFireflyClientWithRawResponse _client;

    /// <inheritdoc/>
    public IObjectGroupServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ObjectGroupServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ObjectGroupServiceWithRawResponse(IFireflyClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ObjectGroupSingle>> Retrieve(
        ObjectGroupRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new FireflyInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ObjectGroupRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var objectGroupSingle = await response
                    .Deserialize<ObjectGroupSingle>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    objectGroupSingle.Validate();
                }
                return objectGroupSingle;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ObjectGroupSingle>> Retrieve(
        string id,
        ObjectGroupRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ObjectGroupSingle>> Update(
        ObjectGroupUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new FireflyInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ObjectGroupUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var objectGroupSingle = await response
                    .Deserialize<ObjectGroupSingle>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    objectGroupSingle.Validate();
                }
                return objectGroupSingle;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ObjectGroupSingle>> Update(
        string id,
        ObjectGroupUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ObjectGroupListResponse>> List(
        ObjectGroupListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ObjectGroupListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var objectGroups = await response
                    .Deserialize<ObjectGroupListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    objectGroups.Validate();
                }
                return objectGroups;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        ObjectGroupDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new FireflyInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ObjectGroupDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string id,
        ObjectGroupDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BillArray>> ListBills(
        ObjectGroupListBillsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new FireflyInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ObjectGroupListBillsParams> request = new()
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
        string id,
        ObjectGroupListBillsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListBills(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PiggyBankArray>> ListPiggyBanks(
        ObjectGroupListPiggyBanksParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new FireflyInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ObjectGroupListPiggyBanksParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var piggyBankArray = await response
                    .Deserialize<PiggyBankArray>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    piggyBankArray.Validate();
                }
                return piggyBankArray;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<PiggyBankArray>> ListPiggyBanks(
        string id,
        ObjectGroupListPiggyBanksParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListPiggyBanks(parameters with { ID = id }, cancellationToken);
    }
}
