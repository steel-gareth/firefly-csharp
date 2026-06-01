using System;
using System.Threading;
using System.Threading.Tasks;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Data;
using EmceesProdTesting5.Services.Data;

namespace EmceesProdTesting5.Services;

/// <summary>
/// The &amp;quot;data&amp;quot;-endpoints manage generic Firefly III and user-specific data.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IDataService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IDataServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDataService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IBulkService Bulk { get; }

    IExportService Export { get; }

    /// <summary>
    /// A call to this endpoint deletes the requested data type. Use it with care and
    /// always with user permission. The demo user is incapable of using this endpoint.
    /// </summary>
    Task Destroy(DataDestroyParams parameters, CancellationToken cancellationToken = default);

    /// <summary>
    /// A call to this endpoint purges all previously deleted data. Use it with care and
    /// always with user permission. The demo user is incapable of using this endpoint.
    /// </summary>
    Task Purge(DataPurgeParams? parameters = null, CancellationToken cancellationToken = default);
}

/// <summary>
/// A view of <see cref="IDataService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IDataServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDataServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IBulkServiceWithRawResponse Bulk { get; }

    IExportServiceWithRawResponse Export { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/data/destroy</c>, but is otherwise the
    /// same as <see cref="IDataService.Destroy(DataDestroyParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Destroy(
        DataDestroyParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/data/purge</c>, but is otherwise the
    /// same as <see cref="IDataService.Purge(DataPurgeParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Purge(
        DataPurgeParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
