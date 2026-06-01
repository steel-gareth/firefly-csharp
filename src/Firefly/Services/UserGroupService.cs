using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Firefly.Core;
using Firefly.Exceptions;
using Firefly.Models.UserGroups;

namespace Firefly.Services;

/// <inheritdoc/>
public sealed class UserGroupService : IUserGroupService
{
    readonly Lazy<IUserGroupServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IUserGroupServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IFireflyClient _client;

    /// <inheritdoc/>
    public IUserGroupService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new UserGroupService(this._client.WithOptions(modifier));
    }

    public UserGroupService(IFireflyClient client)
    {
        _client = client;

        _withRawResponse = new(() => new UserGroupServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<UserGroupSingle> Retrieve(
        UserGroupRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<UserGroupSingle> Retrieve(
        string id,
        UserGroupRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<UserGroupSingle> Update(
        UserGroupUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<UserGroupSingle> Update(
        string id,
        UserGroupUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<UserGroupListResponse> List(
        UserGroupListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class UserGroupServiceWithRawResponse : IUserGroupServiceWithRawResponse
{
    readonly IFireflyClientWithRawResponse _client;

    /// <inheritdoc/>
    public IUserGroupServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new UserGroupServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public UserGroupServiceWithRawResponse(IFireflyClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UserGroupSingle>> Retrieve(
        UserGroupRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new FireflyInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<UserGroupRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var userGroupSingle = await response
                    .Deserialize<UserGroupSingle>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    userGroupSingle.Validate();
                }
                return userGroupSingle;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<UserGroupSingle>> Retrieve(
        string id,
        UserGroupRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UserGroupSingle>> Update(
        UserGroupUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new FireflyInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<UserGroupUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var userGroupSingle = await response
                    .Deserialize<UserGroupSingle>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    userGroupSingle.Validate();
                }
                return userGroupSingle;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<UserGroupSingle>> Update(
        string id,
        UserGroupUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UserGroupListResponse>> List(
        UserGroupListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<UserGroupListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var userGroups = await response
                    .Deserialize<UserGroupListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    userGroups.Validate();
                }
                return userGroups;
            }
        );
    }
}
