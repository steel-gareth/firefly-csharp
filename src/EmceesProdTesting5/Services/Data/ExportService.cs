using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Data.Export;

namespace EmceesProdTesting5.Services.Data;

/// <inheritdoc/>
public sealed class ExportService : IExportService
{
    readonly Lazy<IExportServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IExportServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IEmceesProdTesting5Client _client;

    /// <inheritdoc/>
    public IExportService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ExportService(this._client.WithOptions(modifier));
    }

    public ExportService(IEmceesProdTesting5Client client)
    {
        _client = client;

        _withRawResponse = new(() => new ExportServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public Task<HttpResponse> ExportAccounts(
        ExportExportAccountsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.ExportAccounts(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> ExportBills(
        ExportExportBillsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.ExportBills(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> ExportBudgets(
        ExportExportBudgetsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.ExportBudgets(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> ExportCategories(
        ExportExportCategoriesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.ExportCategories(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> ExportPiggyBanks(
        ExportExportPiggyBanksParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.ExportPiggyBanks(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> ExportRecurring(
        ExportExportRecurringParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.ExportRecurring(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> ExportRules(
        ExportExportRulesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.ExportRules(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> ExportTags(
        ExportExportTagsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.ExportTags(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> ExportTransactions(
        ExportExportTransactionsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.ExportTransactions(parameters, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class ExportServiceWithRawResponse : IExportServiceWithRawResponse
{
    readonly IEmceesProdTesting5ClientWithRawResponse _client;

    /// <inheritdoc/>
    public IExportServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ExportServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ExportServiceWithRawResponse(IEmceesProdTesting5ClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public Task<HttpResponse> ExportAccounts(
        ExportExportAccountsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ExportExportAccountsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> ExportBills(
        ExportExportBillsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ExportExportBillsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> ExportBudgets(
        ExportExportBudgetsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ExportExportBudgetsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> ExportCategories(
        ExportExportCategoriesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ExportExportCategoriesParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> ExportPiggyBanks(
        ExportExportPiggyBanksParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ExportExportPiggyBanksParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> ExportRecurring(
        ExportExportRecurringParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ExportExportRecurringParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> ExportRules(
        ExportExportRulesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ExportExportRulesParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> ExportTags(
        ExportExportTagsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ExportExportTagsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> ExportTransactions(
        ExportExportTransactionsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ExportExportTransactionsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }
}
