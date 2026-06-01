using System;
using System.Threading;
using System.Threading.Tasks;
using Firefly.Core;
using Firefly.Models.Currencies;
using Firefly.Models.Currencies.Primary;

namespace Firefly.Services.Currencies;

/// <summary>
/// Endpoints to manage the currencies in Firefly III. Depending on the user&amp;#039;s
/// role you can also disable and enable them, or add new ones.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IPrimaryService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPrimaryServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPrimaryService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get the primary currency of the current administration. This replaces what was
    /// called "the user's default currency" although they are essentially the same.
    /// </summary>
    Task<CurrencySingle> Retrieve(
        PrimaryRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Make this currency the primary currency for the current financial
    /// administration. If the currency is not enabled, it will be enabled as well.
    /// </summary>
    Task<CurrencySingle> MakePrimary(
        PrimaryMakePrimaryParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="MakePrimary(PrimaryMakePrimaryParams, CancellationToken)"/>
    Task<CurrencySingle> MakePrimary(
        string code,
        PrimaryMakePrimaryParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IPrimaryService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPrimaryServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPrimaryServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/currencies/primary</c>, but is otherwise the
    /// same as <see cref="IPrimaryService.Retrieve(PrimaryRetrieveParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CurrencySingle>> Retrieve(
        PrimaryRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/currencies/{code}/primary</c>, but is otherwise the
    /// same as <see cref="IPrimaryService.MakePrimary(PrimaryMakePrimaryParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CurrencySingle>> MakePrimary(
        PrimaryMakePrimaryParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="MakePrimary(PrimaryMakePrimaryParams, CancellationToken)"/>
    Task<HttpResponse<CurrencySingle>> MakePrimary(
        string code,
        PrimaryMakePrimaryParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
