using System;
using System.Threading;
using System.Threading.Tasks;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.UserGroups;

namespace EmceesProdTesting5.Services;

/// <summary>
/// User groups are the objects around which &amp;quot;financial administrations&amp;quot;
/// are built.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IUserGroupService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IUserGroupServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUserGroupService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a single user group by its ID.
    /// </summary>
    Task<UserGroupSingle> Retrieve(
        UserGroupRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(UserGroupRetrieveParams, CancellationToken)"/>
    Task<UserGroupSingle> Retrieve(
        string id,
        UserGroupRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Used to update a single user group. The available fields are still limited.
    /// </summary>
    Task<UserGroupSingle> Update(
        UserGroupUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(UserGroupUpdateParams, CancellationToken)"/>
    Task<UserGroupSingle> Update(
        string id,
        UserGroupUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List all the user groups available to this user. These are essentially the
    /// 'financial administrations' that Firefly III supports.
    /// </summary>
    Task<UserGroupListResponse> List(
        UserGroupListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IUserGroupService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IUserGroupServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUserGroupServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/user-groups/{id}</c>, but is otherwise the
    /// same as <see cref="IUserGroupService.Retrieve(UserGroupRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UserGroupSingle>> Retrieve(
        UserGroupRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(UserGroupRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<UserGroupSingle>> Retrieve(
        string id,
        UserGroupRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /v1/user-groups/{id}</c>, but is otherwise the
    /// same as <see cref="IUserGroupService.Update(UserGroupUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UserGroupSingle>> Update(
        UserGroupUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(UserGroupUpdateParams, CancellationToken)"/>
    Task<HttpResponse<UserGroupSingle>> Update(
        string id,
        UserGroupUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/user-groups</c>, but is otherwise the
    /// same as <see cref="IUserGroupService.List(UserGroupListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UserGroupListResponse>> List(
        UserGroupListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
