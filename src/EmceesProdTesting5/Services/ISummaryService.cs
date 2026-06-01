using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Summary;

namespace EmceesProdTesting5.Services;

/// <summary>
/// These endpoints deliver summaries, like sums, lists of numbers and other processed
/// information. Mainly used for the main dashboard and pretty specific for Firefly
/// III itself.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ISummaryService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISummaryServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISummaryService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns basic sums of the users data, like the net worth, spent and earned
    /// amounts. It is multi-currency, and is used in Firefly III to populate the
    /// dashboard.
    /// </summary>
    Task<Dictionary<string, SummaryRetrieveBasicResponse>> RetrieveBasic(
        SummaryRetrieveBasicParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ISummaryService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISummaryServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISummaryServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/summary/basic</c>, but is otherwise the
    /// same as <see cref="ISummaryService.RetrieveBasic(SummaryRetrieveBasicParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Dictionary<string, SummaryRetrieveBasicResponse>>> RetrieveBasic(
        SummaryRetrieveBasicParams parameters,
        CancellationToken cancellationToken = default
    );
}
