using System;
using System.Threading;
using System.Threading.Tasks;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Cron;

namespace EmceesProdTesting5.Services;

/// <summary>
/// These endpoints deliver general system information, version- and meta information.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ICronService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICronServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICronService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Firefly III has one endpoint for its various cron related tasks. Send a GET to
    /// this endpoint to run the cron. The cron requires the CLI token to be present.
    /// The cron job will fire for all users.
    /// </summary>
    Task<CronRunResponse> Run(
        CronRunParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Run(CronRunParams, CancellationToken)"/>
    Task<CronRunResponse> Run(
        string cliToken,
        CronRunParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ICronService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICronServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICronServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/cron/{cliToken}</c>, but is otherwise the
    /// same as <see cref="ICronService.Run(CronRunParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CronRunResponse>> Run(
        CronRunParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Run(CronRunParams, CancellationToken)"/>
    Task<HttpResponse<CronRunResponse>> Run(
        string cliToken,
        CronRunParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
