using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Firefly.Core;
using Firefly.Exceptions;
using Firefly.Models.ExchangeRates;

namespace Firefly.Services;

/// <inheritdoc/>
public sealed class ExchangeRateService : IExchangeRateService
{
    readonly Lazy<IExchangeRateServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IExchangeRateServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IFireflyClient _client;

    /// <inheritdoc/>
    public IExchangeRateService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ExchangeRateService(this._client.WithOptions(modifier));
    }

    public ExchangeRateService(IFireflyClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new ExchangeRateServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<CurrencyExchangeRateSingle> Create(
        ExchangeRateCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CurrencyExchangeRateSingle> Retrieve(
        ExchangeRateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CurrencyExchangeRateSingle> Retrieve(
        string id,
        ExchangeRateRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CurrencyExchangeRateSingle> Update(
        ExchangeRateUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CurrencyExchangeRateSingle> Update(
        string id,
        ExchangeRateUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CurrencyExchangeRateArray> List(
        ExchangeRateListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(
        ExchangeRateDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string id,
        ExchangeRateDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CurrencyExchangeRateArray> CreateByCurrencies(
        ExchangeRateCreateByCurrenciesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.CreateByCurrencies(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CurrencyExchangeRateArray> CreateByCurrencies(
        string to,
        ExchangeRateCreateByCurrenciesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.CreateByCurrencies(parameters with { To = to }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CurrencyExchangeRateArray> CreateByDate(
        ExchangeRateCreateByDateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.CreateByDate(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CurrencyExchangeRateArray> CreateByDate(
        string date,
        ExchangeRateCreateByDateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.CreateByDate(parameters with { Date = date }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task DeleteAllByCurrencies(
        ExchangeRateDeleteAllByCurrenciesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.DeleteAllByCurrencies(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task DeleteAllByCurrencies(
        string to,
        ExchangeRateDeleteAllByCurrenciesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.DeleteAllByCurrencies(parameters with { To = to }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task DeleteByDate(
        ExchangeRateDeleteByDateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.DeleteByDate(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task DeleteByDate(
        string date,
        ExchangeRateDeleteByDateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.DeleteByDate(parameters with { Date = date }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CurrencyExchangeRateArray> ListByCurrencies(
        ExchangeRateListByCurrenciesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListByCurrencies(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CurrencyExchangeRateArray> ListByCurrencies(
        string to,
        ExchangeRateListByCurrenciesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.ListByCurrencies(parameters with { To = to }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CurrencyExchangeRateArray> RetrieveByDate(
        ExchangeRateRetrieveByDateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveByDate(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CurrencyExchangeRateArray> RetrieveByDate(
        string date,
        ExchangeRateRetrieveByDateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.RetrieveByDate(parameters with { Date = date }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CurrencyExchangeRateSingle> UpdateByDate(
        ExchangeRateUpdateByDateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.UpdateByDate(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CurrencyExchangeRateSingle> UpdateByDate(
        string date,
        ExchangeRateUpdateByDateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UpdateByDate(parameters with { Date = date }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class ExchangeRateServiceWithRawResponse : IExchangeRateServiceWithRawResponse
{
    readonly IFireflyClientWithRawResponse _client;

    /// <inheritdoc/>
    public IExchangeRateServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ExchangeRateServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ExchangeRateServiceWithRawResponse(IFireflyClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CurrencyExchangeRateSingle>> Create(
        ExchangeRateCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ExchangeRateCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var currencyExchangeRateSingle = await response
                    .Deserialize<CurrencyExchangeRateSingle>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    currencyExchangeRateSingle.Validate();
                }
                return currencyExchangeRateSingle;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CurrencyExchangeRateSingle>> Retrieve(
        ExchangeRateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new FireflyInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ExchangeRateRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var currencyExchangeRateSingle = await response
                    .Deserialize<CurrencyExchangeRateSingle>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    currencyExchangeRateSingle.Validate();
                }
                return currencyExchangeRateSingle;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CurrencyExchangeRateSingle>> Retrieve(
        string id,
        ExchangeRateRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CurrencyExchangeRateSingle>> Update(
        ExchangeRateUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new FireflyInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ExchangeRateUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var currencyExchangeRateSingle = await response
                    .Deserialize<CurrencyExchangeRateSingle>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    currencyExchangeRateSingle.Validate();
                }
                return currencyExchangeRateSingle;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CurrencyExchangeRateSingle>> Update(
        string id,
        ExchangeRateUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CurrencyExchangeRateArray>> List(
        ExchangeRateListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ExchangeRateListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var currencyExchangeRateArray = await response
                    .Deserialize<CurrencyExchangeRateArray>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    currencyExchangeRateArray.Validate();
                }
                return currencyExchangeRateArray;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        ExchangeRateDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new FireflyInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ExchangeRateDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string id,
        ExchangeRateDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CurrencyExchangeRateArray>> CreateByCurrencies(
        ExchangeRateCreateByCurrenciesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.To == null)
        {
            throw new FireflyInvalidDataException("'parameters.To' cannot be null");
        }

        HttpRequest<ExchangeRateCreateByCurrenciesParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var currencyExchangeRateArray = await response
                    .Deserialize<CurrencyExchangeRateArray>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    currencyExchangeRateArray.Validate();
                }
                return currencyExchangeRateArray;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CurrencyExchangeRateArray>> CreateByCurrencies(
        string to,
        ExchangeRateCreateByCurrenciesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.CreateByCurrencies(parameters with { To = to }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CurrencyExchangeRateArray>> CreateByDate(
        ExchangeRateCreateByDateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Date == null)
        {
            throw new FireflyInvalidDataException("'parameters.Date' cannot be null");
        }

        HttpRequest<ExchangeRateCreateByDateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var currencyExchangeRateArray = await response
                    .Deserialize<CurrencyExchangeRateArray>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    currencyExchangeRateArray.Validate();
                }
                return currencyExchangeRateArray;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CurrencyExchangeRateArray>> CreateByDate(
        string date,
        ExchangeRateCreateByDateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.CreateByDate(parameters with { Date = date }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> DeleteAllByCurrencies(
        ExchangeRateDeleteAllByCurrenciesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.To == null)
        {
            throw new FireflyInvalidDataException("'parameters.To' cannot be null");
        }

        HttpRequest<ExchangeRateDeleteAllByCurrenciesParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> DeleteAllByCurrencies(
        string to,
        ExchangeRateDeleteAllByCurrenciesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.DeleteAllByCurrencies(parameters with { To = to }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> DeleteByDate(
        ExchangeRateDeleteByDateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Date == null)
        {
            throw new FireflyInvalidDataException("'parameters.Date' cannot be null");
        }

        HttpRequest<ExchangeRateDeleteByDateParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> DeleteByDate(
        string date,
        ExchangeRateDeleteByDateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.DeleteByDate(parameters with { Date = date }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CurrencyExchangeRateArray>> ListByCurrencies(
        ExchangeRateListByCurrenciesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.To == null)
        {
            throw new FireflyInvalidDataException("'parameters.To' cannot be null");
        }

        HttpRequest<ExchangeRateListByCurrenciesParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var currencyExchangeRateArray = await response
                    .Deserialize<CurrencyExchangeRateArray>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    currencyExchangeRateArray.Validate();
                }
                return currencyExchangeRateArray;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CurrencyExchangeRateArray>> ListByCurrencies(
        string to,
        ExchangeRateListByCurrenciesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.ListByCurrencies(parameters with { To = to }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CurrencyExchangeRateArray>> RetrieveByDate(
        ExchangeRateRetrieveByDateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Date == null)
        {
            throw new FireflyInvalidDataException("'parameters.Date' cannot be null");
        }

        HttpRequest<ExchangeRateRetrieveByDateParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var currencyExchangeRateArray = await response
                    .Deserialize<CurrencyExchangeRateArray>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    currencyExchangeRateArray.Validate();
                }
                return currencyExchangeRateArray;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CurrencyExchangeRateArray>> RetrieveByDate(
        string date,
        ExchangeRateRetrieveByDateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.RetrieveByDate(parameters with { Date = date }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CurrencyExchangeRateSingle>> UpdateByDate(
        ExchangeRateUpdateByDateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Date == null)
        {
            throw new FireflyInvalidDataException("'parameters.Date' cannot be null");
        }

        HttpRequest<ExchangeRateUpdateByDateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var currencyExchangeRateSingle = await response
                    .Deserialize<CurrencyExchangeRateSingle>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    currencyExchangeRateSingle.Validate();
                }
                return currencyExchangeRateSingle;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CurrencyExchangeRateSingle>> UpdateByDate(
        string date,
        ExchangeRateUpdateByDateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UpdateByDate(parameters with { Date = date }, cancellationToken);
    }
}
