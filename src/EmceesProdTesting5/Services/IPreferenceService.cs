using System;
using System.Threading;
using System.Threading.Tasks;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Preferences;

namespace EmceesProdTesting5.Services;

/// <summary>
/// These endpoints can be used to manage the user&amp;#039;s preferences, including
/// some hidden ones.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IPreferenceService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPreferenceServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPreferenceService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// This endpoint creates a new preference. The name and data are free-format, and
    /// entirely up to you. If the preference is not used in Firefly III itself it may
    /// not be configurable through the user interface, but you can use this endpoint to
    /// persist custom data for your own app.
    /// </summary>
    Task<PreferenceSingle> Create(
        PreferenceCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Return a single preference and the value.
    /// </summary>
    Task<PreferenceSingle> Retrieve(
        PreferenceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(PreferenceRetrieveParams, CancellationToken)"/>
    Task<PreferenceSingle> Retrieve(
        string name,
        PreferenceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update a user's preference.
    /// </summary>
    Task<PreferenceSingle> Update(
        PreferenceUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(PreferenceUpdateParams, CancellationToken)"/>
    Task<PreferenceSingle> Update(
        string name,
        PreferenceUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List all of the preferences of the user.
    /// </summary>
    Task<PreferenceListResponse> List(
        PreferenceListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IPreferenceService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPreferenceServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPreferenceServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/preferences</c>, but is otherwise the
    /// same as <see cref="IPreferenceService.Create(PreferenceCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PreferenceSingle>> Create(
        PreferenceCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/preferences/{name}</c>, but is otherwise the
    /// same as <see cref="IPreferenceService.Retrieve(PreferenceRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PreferenceSingle>> Retrieve(
        PreferenceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(PreferenceRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<PreferenceSingle>> Retrieve(
        string name,
        PreferenceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /v1/preferences/{name}</c>, but is otherwise the
    /// same as <see cref="IPreferenceService.Update(PreferenceUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PreferenceSingle>> Update(
        PreferenceUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(PreferenceUpdateParams, CancellationToken)"/>
    Task<HttpResponse<PreferenceSingle>> Update(
        string name,
        PreferenceUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/preferences</c>, but is otherwise the
    /// same as <see cref="IPreferenceService.List(PreferenceListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PreferenceListResponse>> List(
        PreferenceListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
