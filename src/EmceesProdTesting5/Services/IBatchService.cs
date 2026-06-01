using System;
using System.Threading;
using System.Threading.Tasks;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Batch;

namespace EmceesProdTesting5.Services;

/// <summary>
/// These endpoints deliver general system information, version- and meta information.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IBatchService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IBatchServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBatchService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// summary: Finish a batch of unprocessed transactions.
    /// </summary>
    Task Finish(
        BatchFinishParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IBatchService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IBatchServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBatchServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/batch/finish</c>, but is otherwise the
    /// same as <see cref="IBatchService.Finish(BatchFinishParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Finish(
        BatchFinishParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
