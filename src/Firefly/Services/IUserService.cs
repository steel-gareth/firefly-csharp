using System;
using System.Threading;
using System.Threading.Tasks;
using Firefly.Core;
using Firefly.Models.About;
using Firefly.Models.Users;

namespace Firefly.Services;

/// <summary>
/// Use these endpoints to manage the users registered within Firefly III. You need
/// to have the &amp;quot;owner&amp;quot; role to access these endpoints.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IUserServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUserService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Creates a new user. The data required can be submitted as a JSON body or as a
    /// list of parameters. The user will be given a random password, which they can
    /// reset using the "forgot password" function.
    /// </summary>
    Task<UserSingle> Create(
        UserCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Gets all info of a single user.
    /// </summary>
    Task<UserSingle> Retrieve(
        UserRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(UserRetrieveParams, CancellationToken)"/>
    Task<UserSingle> Retrieve(
        string id,
        UserRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update existing user.
    /// </summary>
    Task<UserSingle> Update(
        UserUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(UserUpdateParams, CancellationToken)"/>
    Task<UserSingle> Update(
        string id,
        UserUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List all the users in this instance of Firefly III.
    /// </summary>
    Task<UserListResponse> List(
        UserListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a user. You cannot delete the user you're authenticated with. This cannot
    /// be undone. Be careful.
    /// </summary>
    Task Delete(UserDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(UserDeleteParams, CancellationToken)"/>
    Task Delete(
        string id,
        UserDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IUserService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IUserServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUserServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/users</c>, but is otherwise the
    /// same as <see cref="IUserService.Create(UserCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UserSingle>> Create(
        UserCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/users/{id}</c>, but is otherwise the
    /// same as <see cref="IUserService.Retrieve(UserRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UserSingle>> Retrieve(
        UserRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(UserRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<UserSingle>> Retrieve(
        string id,
        UserRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /v1/users/{id}</c>, but is otherwise the
    /// same as <see cref="IUserService.Update(UserUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UserSingle>> Update(
        UserUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(UserUpdateParams, CancellationToken)"/>
    Task<HttpResponse<UserSingle>> Update(
        string id,
        UserUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/users</c>, but is otherwise the
    /// same as <see cref="IUserService.List(UserListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UserListResponse>> List(
        UserListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/users/{id}</c>, but is otherwise the
    /// same as <see cref="IUserService.Delete(UserDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        UserDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(UserDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string id,
        UserDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
