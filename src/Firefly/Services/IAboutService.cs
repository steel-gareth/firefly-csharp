using System;
using System.Threading;
using System.Threading.Tasks;
using Firefly.Core;
using Firefly.Models.About;

namespace Firefly.Services;

/// <summary>
/// These endpoints deliver general system information, version- and meta information.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IAboutService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAboutServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAboutService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns general system information and versions of the (supporting) software.
    /// </summary>
    Task<AboutRetrieveInfoResponse> RetrieveInfo(
        AboutRetrieveInfoParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns the currently authenticated user.
    /// </summary>
    Task<UserSingle> RetrieveUser(
        AboutRetrieveUserParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IAboutService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAboutServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAboutServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/about</c>, but is otherwise the
    /// same as <see cref="IAboutService.RetrieveInfo(AboutRetrieveInfoParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AboutRetrieveInfoResponse>> RetrieveInfo(
        AboutRetrieveInfoParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/about/user</c>, but is otherwise the
    /// same as <see cref="IAboutService.RetrieveUser(AboutRetrieveUserParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UserSingle>> RetrieveUser(
        AboutRetrieveUserParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
