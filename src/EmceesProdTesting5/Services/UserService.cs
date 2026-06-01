using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Exceptions;
using EmceesProdTesting5.Models.Users;

namespace EmceesProdTesting5.Services;

/// <inheritdoc/>
public sealed class UserService : IUserService
{
    readonly Lazy<IUserServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IUserServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IMoreConflictingClient _client;

    /// <inheritdoc/>
    public IUserService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new UserService(this._client.WithOptions(modifier));
    }

    public UserService(IMoreConflictingClient client)
    {
        _client = client;

        _withRawResponse = new(() => new UserServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<User> Create(
        UserCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<User> Retrieve(
        UserRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<User> Retrieve(
        string username,
        UserRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { Username = username }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Update(UserUpdateParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Update(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Update(
        string existingUsername,
        UserUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Update(
                parameters with
                {
                    ExistingUsername = existingUsername,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(UserDeleteParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string username,
        UserDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { Username = username }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<User> CreateWithList(
        UserCreateWithListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.CreateWithList(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<string> Login(
        UserLoginParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Login(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Logout(
        UserLogoutParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Logout(parameters, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class UserServiceWithRawResponse : IUserServiceWithRawResponse
{
    readonly IMoreConflictingClientWithRawResponse _client;

    /// <inheritdoc/>
    public IUserServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new UserServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public UserServiceWithRawResponse(IMoreConflictingClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<User>> Create(
        UserCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<UserCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var user = await response.Deserialize<User>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    user.Validate();
                }
                return user;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<User>> Retrieve(
        UserRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Username == null)
        {
            throw new MoreConflictingInvalidDataException("'parameters.Username' cannot be null");
        }

        HttpRequest<UserRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var user = await response.Deserialize<User>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    user.Validate();
                }
                return user;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<User>> Retrieve(
        string username,
        UserRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { Username = username }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Update(
        UserUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ExistingUsername == null)
        {
            throw new MoreConflictingInvalidDataException(
                "'parameters.ExistingUsername' cannot be null"
            );
        }

        HttpRequest<UserUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Update(
        string existingUsername,
        UserUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(
            parameters with
            {
                ExistingUsername = existingUsername,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        UserDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Username == null)
        {
            throw new MoreConflictingInvalidDataException("'parameters.Username' cannot be null");
        }

        HttpRequest<UserDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string username,
        UserDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { Username = username }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<User>> CreateWithList(
        UserCreateWithListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<UserCreateWithListParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var user = await response.Deserialize<User>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    user.Validate();
                }
                return user;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<string>> Login(
        UserLoginParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<UserLoginParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                return await response.Deserialize<string>(token).ConfigureAwait(false);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Logout(
        UserLogoutParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<UserLogoutParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }
}
