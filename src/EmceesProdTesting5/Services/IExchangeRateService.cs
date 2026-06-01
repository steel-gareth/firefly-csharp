using System;
using System.Threading;
using System.Threading.Tasks;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.ExchangeRates;

namespace EmceesProdTesting5.Services;

/// <summary>
/// All currency exchange rates.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IExchangeRateService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IExchangeRateServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IExchangeRateService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Stores a new exchange rate. The data required can be submitted as a JSON body or
    /// as a list of parameters.
    /// </summary>
    Task<CurrencyExchangeRateSingle> Create(
        ExchangeRateCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List a single specific exchange rate by its ID.
    /// </summary>
    Task<CurrencyExchangeRateSingle> Retrieve(
        ExchangeRateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ExchangeRateRetrieveParams, CancellationToken)"/>
    Task<CurrencyExchangeRateSingle> Retrieve(
        string id,
        ExchangeRateRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Used to update a single currency exchange rate by its ID. Including the from/to
    /// currency is optional.
    /// </summary>
    Task<CurrencyExchangeRateSingle> Update(
        ExchangeRateUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ExchangeRateUpdateParams, CancellationToken)"/>
    Task<CurrencyExchangeRateSingle> Update(
        string id,
        ExchangeRateUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List exchange rates that Firefly III knows.
    /// </summary>
    Task<CurrencyExchangeRateArray> List(
        ExchangeRateListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a specific currency exchange rate by its internal ID.
    /// </summary>
    Task Delete(ExchangeRateDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(ExchangeRateDeleteParams, CancellationToken)"/>
    Task Delete(
        string id,
        ExchangeRateDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Stores a new set of exchange rates for this pair. The date is variable, and the
    /// data required can be submitted as a JSON body.
    /// </summary>
    Task<CurrencyExchangeRateArray> CreateByCurrencies(
        ExchangeRateCreateByCurrenciesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="CreateByCurrencies(ExchangeRateCreateByCurrenciesParams, CancellationToken)"/>
    Task<CurrencyExchangeRateArray> CreateByCurrencies(
        string to,
        ExchangeRateCreateByCurrenciesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Stores a new set of exchange rates. The date is fixed (in the URL parameter) and
    /// the data required can be submitted as a JSON body.
    /// </summary>
    Task<CurrencyExchangeRateArray> CreateByDate(
        ExchangeRateCreateByDateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="CreateByDate(ExchangeRateCreateByDateParams, CancellationToken)"/>
    Task<CurrencyExchangeRateArray> CreateByDate(
        string date,
        ExchangeRateCreateByDateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes ALL currency exchange rates from 'from' to 'to'. It's important to know
    /// that the reverse exchange rates (from 'to' to 'from') will not be deleted and
    /// Firefly III will still be able to infer the correct exchange rate from the
    /// reverse one.
    /// </summary>
    Task DeleteAllByCurrencies(
        ExchangeRateDeleteAllByCurrenciesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="DeleteAllByCurrencies(ExchangeRateDeleteAllByCurrenciesParams, CancellationToken)"/>
    Task DeleteAllByCurrencies(
        string to,
        ExchangeRateDeleteAllByCurrenciesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete the currency exchange rate from 'from' to 'to' on the specified date.  It's
    /// important to know that the reverse exchange rate (from 'to' to 'from') will not be
    /// deleted and Firefly III will still be able to infer the correct exchange rate from
    /// the reverse one.
    /// </summary>
    Task DeleteByDate(
        ExchangeRateDeleteByDateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="DeleteByDate(ExchangeRateDeleteByDateParams, CancellationToken)"/>
    Task DeleteByDate(
        string date,
        ExchangeRateDeleteByDateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List all exchange rates from/to the mentioned currencies.
    /// </summary>
    Task<CurrencyExchangeRateArray> ListByCurrencies(
        ExchangeRateListByCurrenciesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListByCurrencies(ExchangeRateListByCurrenciesParams, CancellationToken)"/>
    Task<CurrencyExchangeRateArray> ListByCurrencies(
        string to,
        ExchangeRateListByCurrenciesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List the exchange rate for the from and to-currency on the requested date.
    /// </summary>
    Task<CurrencyExchangeRateArray> RetrieveByDate(
        ExchangeRateRetrieveByDateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveByDate(ExchangeRateRetrieveByDateParams, CancellationToken)"/>
    Task<CurrencyExchangeRateArray> RetrieveByDate(
        string date,
        ExchangeRateRetrieveByDateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Used to update a single currency exchange rate by its currency codes and date
    /// </summary>
    Task<CurrencyExchangeRateSingle> UpdateByDate(
        ExchangeRateUpdateByDateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UpdateByDate(ExchangeRateUpdateByDateParams, CancellationToken)"/>
    Task<CurrencyExchangeRateSingle> UpdateByDate(
        string date,
        ExchangeRateUpdateByDateParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IExchangeRateService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IExchangeRateServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IExchangeRateServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/exchange-rates</c>, but is otherwise the
    /// same as <see cref="IExchangeRateService.Create(ExchangeRateCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CurrencyExchangeRateSingle>> Create(
        ExchangeRateCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/exchange-rates/{id}</c>, but is otherwise the
    /// same as <see cref="IExchangeRateService.Retrieve(ExchangeRateRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CurrencyExchangeRateSingle>> Retrieve(
        ExchangeRateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ExchangeRateRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<CurrencyExchangeRateSingle>> Retrieve(
        string id,
        ExchangeRateRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /v1/exchange-rates/{id}</c>, but is otherwise the
    /// same as <see cref="IExchangeRateService.Update(ExchangeRateUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CurrencyExchangeRateSingle>> Update(
        ExchangeRateUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ExchangeRateUpdateParams, CancellationToken)"/>
    Task<HttpResponse<CurrencyExchangeRateSingle>> Update(
        string id,
        ExchangeRateUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/exchange-rates</c>, but is otherwise the
    /// same as <see cref="IExchangeRateService.List(ExchangeRateListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CurrencyExchangeRateArray>> List(
        ExchangeRateListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/exchange-rates/{id}</c>, but is otherwise the
    /// same as <see cref="IExchangeRateService.Delete(ExchangeRateDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        ExchangeRateDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(ExchangeRateDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string id,
        ExchangeRateDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/exchange-rates/by-currencies/{from}/{to}</c>, but is otherwise the
    /// same as <see cref="IExchangeRateService.CreateByCurrencies(ExchangeRateCreateByCurrenciesParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CurrencyExchangeRateArray>> CreateByCurrencies(
        ExchangeRateCreateByCurrenciesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="CreateByCurrencies(ExchangeRateCreateByCurrenciesParams, CancellationToken)"/>
    Task<HttpResponse<CurrencyExchangeRateArray>> CreateByCurrencies(
        string to,
        ExchangeRateCreateByCurrenciesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/exchange-rates/by-date/{date}</c>, but is otherwise the
    /// same as <see cref="IExchangeRateService.CreateByDate(ExchangeRateCreateByDateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CurrencyExchangeRateArray>> CreateByDate(
        ExchangeRateCreateByDateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="CreateByDate(ExchangeRateCreateByDateParams, CancellationToken)"/>
    Task<HttpResponse<CurrencyExchangeRateArray>> CreateByDate(
        string date,
        ExchangeRateCreateByDateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/exchange-rates/{from}/{to}</c>, but is otherwise the
    /// same as <see cref="IExchangeRateService.DeleteAllByCurrencies(ExchangeRateDeleteAllByCurrenciesParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> DeleteAllByCurrencies(
        ExchangeRateDeleteAllByCurrenciesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="DeleteAllByCurrencies(ExchangeRateDeleteAllByCurrenciesParams, CancellationToken)"/>
    Task<HttpResponse> DeleteAllByCurrencies(
        string to,
        ExchangeRateDeleteAllByCurrenciesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/exchange-rates/{from}/{to}/{date}</c>, but is otherwise the
    /// same as <see cref="IExchangeRateService.DeleteByDate(ExchangeRateDeleteByDateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> DeleteByDate(
        ExchangeRateDeleteByDateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="DeleteByDate(ExchangeRateDeleteByDateParams, CancellationToken)"/>
    Task<HttpResponse> DeleteByDate(
        string date,
        ExchangeRateDeleteByDateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/exchange-rates/{from}/{to}</c>, but is otherwise the
    /// same as <see cref="IExchangeRateService.ListByCurrencies(ExchangeRateListByCurrenciesParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CurrencyExchangeRateArray>> ListByCurrencies(
        ExchangeRateListByCurrenciesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListByCurrencies(ExchangeRateListByCurrenciesParams, CancellationToken)"/>
    Task<HttpResponse<CurrencyExchangeRateArray>> ListByCurrencies(
        string to,
        ExchangeRateListByCurrenciesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/exchange-rates/{from}/{to}/{date}</c>, but is otherwise the
    /// same as <see cref="IExchangeRateService.RetrieveByDate(ExchangeRateRetrieveByDateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CurrencyExchangeRateArray>> RetrieveByDate(
        ExchangeRateRetrieveByDateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveByDate(ExchangeRateRetrieveByDateParams, CancellationToken)"/>
    Task<HttpResponse<CurrencyExchangeRateArray>> RetrieveByDate(
        string date,
        ExchangeRateRetrieveByDateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /v1/exchange-rates/{from}/{to}/{date}</c>, but is otherwise the
    /// same as <see cref="IExchangeRateService.UpdateByDate(ExchangeRateUpdateByDateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CurrencyExchangeRateSingle>> UpdateByDate(
        ExchangeRateUpdateByDateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UpdateByDate(ExchangeRateUpdateByDateParams, CancellationToken)"/>
    Task<HttpResponse<CurrencyExchangeRateSingle>> UpdateByDate(
        string date,
        ExchangeRateUpdateByDateParams parameters,
        CancellationToken cancellationToken = default
    );
}
