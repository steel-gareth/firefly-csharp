using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Exceptions;
using EmceesProdTesting5.Services;

namespace EmceesProdTesting5;

/// <inheritdoc/>
public sealed class EmceesProdTesting5Client : IEmceesProdTesting5Client
{
    readonly ClientOptions _options;

    /// <inheritdoc/>
    public HttpClient HttpClient
    {
        get { return this._options.HttpClient; }
        init { this._options.HttpClient = value; }
    }

    /// <inheritdoc/>
    public string BaseUrl
    {
        get { return this._options.BaseUrl; }
        init { this._options.BaseUrl = value; }
    }

    /// <inheritdoc/>
    public bool ResponseValidation
    {
        get { return this._options.ResponseValidation; }
        init { this._options.ResponseValidation = value; }
    }

    /// <inheritdoc/>
    public int? MaxRetries
    {
        get { return this._options.MaxRetries; }
        init { this._options.MaxRetries = value; }
    }

    /// <inheritdoc/>
    public TimeSpan? Timeout
    {
        get { return this._options.Timeout; }
        init { this._options.Timeout = value; }
    }

    /// <inheritdoc/>
    public string? BearerToken
    {
        get { return this._options.BearerToken; }
        init { this._options.BearerToken = value; }
    }

    readonly Lazy<IEmceesProdTesting5ClientWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IEmceesProdTesting5ClientWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    /// <inheritdoc/>
    public IEmceesProdTesting5Client WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new EmceesProdTesting5Client(modifier(this._options));
    }

    readonly Lazy<IAutocompleteService> _autocomplete;
    public IAutocompleteService Autocomplete
    {
        get { return _autocomplete.Value; }
    }

    readonly Lazy<IChartService> _chart;
    public IChartService Chart
    {
        get { return _chart.Value; }
    }

    readonly Lazy<IDataService> _data;
    public IDataService Data
    {
        get { return _data.Value; }
    }

    readonly Lazy<IInsightService> _insight;
    public IInsightService Insight
    {
        get { return _insight.Value; }
    }

    readonly Lazy<IAccountService> _accounts;
    public IAccountService Accounts
    {
        get { return _accounts.Value; }
    }

    readonly Lazy<IAttachmentService> _attachments;
    public IAttachmentService Attachments
    {
        get { return _attachments.Value; }
    }

    readonly Lazy<IAvailableBudgetService> _availableBudgets;
    public IAvailableBudgetService AvailableBudgets
    {
        get { return _availableBudgets.Value; }
    }

    readonly Lazy<IBillService> _bills;
    public IBillService Bills
    {
        get { return _bills.Value; }
    }

    readonly Lazy<IBudgetService> _budgets;
    public IBudgetService Budgets
    {
        get { return _budgets.Value; }
    }

    readonly Lazy<ICategoryService> _categories;
    public ICategoryService Categories
    {
        get { return _categories.Value; }
    }

    readonly Lazy<IExchangeRateService> _exchangeRates;
    public IExchangeRateService ExchangeRates
    {
        get { return _exchangeRates.Value; }
    }

    readonly Lazy<ILinkTypeService> _linkTypes;
    public ILinkTypeService LinkTypes
    {
        get { return _linkTypes.Value; }
    }

    readonly Lazy<ITransactionLinkService> _transactionLinks;
    public ITransactionLinkService TransactionLinks
    {
        get { return _transactionLinks.Value; }
    }

    readonly Lazy<IObjectGroupService> _objectGroups;
    public IObjectGroupService ObjectGroups
    {
        get { return _objectGroups.Value; }
    }

    readonly Lazy<IPiggyBankService> _piggyBanks;
    public IPiggyBankService PiggyBanks
    {
        get { return _piggyBanks.Value; }
    }

    readonly Lazy<IRecurrenceService> _recurrences;
    public IRecurrenceService Recurrences
    {
        get { return _recurrences.Value; }
    }

    readonly Lazy<IRuleGroupService> _ruleGroups;
    public IRuleGroupService RuleGroups
    {
        get { return _ruleGroups.Value; }
    }

    readonly Lazy<IRuleService> _rules;
    public IRuleService Rules
    {
        get { return _rules.Value; }
    }

    readonly Lazy<ITagService> _tags;
    public ITagService Tags
    {
        get { return _tags.Value; }
    }

    readonly Lazy<ICurrencyService> _currencies;
    public ICurrencyService Currencies
    {
        get { return _currencies.Value; }
    }

    readonly Lazy<ITransactionJournalService> _transactionJournals;
    public ITransactionJournalService TransactionJournals
    {
        get { return _transactionJournals.Value; }
    }

    readonly Lazy<ITransactionService> _transactions;
    public ITransactionService Transactions
    {
        get { return _transactions.Value; }
    }

    readonly Lazy<IUserGroupService> _userGroups;
    public IUserGroupService UserGroups
    {
        get { return _userGroups.Value; }
    }

    readonly Lazy<ISearchService> _search;
    public ISearchService Search
    {
        get { return _search.Value; }
    }

    readonly Lazy<ISummaryService> _summary;
    public ISummaryService Summary
    {
        get { return _summary.Value; }
    }

    readonly Lazy<IAboutService> _about;
    public IAboutService About
    {
        get { return _about.Value; }
    }

    readonly Lazy<IBatchService> _batch;
    public IBatchService Batch
    {
        get { return _batch.Value; }
    }

    readonly Lazy<IConfigurationService> _configuration;
    public IConfigurationService Configuration
    {
        get { return _configuration.Value; }
    }

    readonly Lazy<ICronService> _cron;
    public ICronService Cron
    {
        get { return _cron.Value; }
    }

    readonly Lazy<IUserService> _users;
    public IUserService Users
    {
        get { return _users.Value; }
    }

    readonly Lazy<IPreferenceService> _preferences;
    public IPreferenceService Preferences
    {
        get { return _preferences.Value; }
    }

    readonly Lazy<IWebhookService> _webhooks;
    public IWebhookService Webhooks
    {
        get { return _webhooks.Value; }
    }

    public void Dispose() => this.HttpClient.Dispose();

    public EmceesProdTesting5Client()
    {
        _options = new();

        _withRawResponse = new(() => new EmceesProdTesting5ClientWithRawResponse(this._options));
        _autocomplete = new(() => new AutocompleteService(this));
        _chart = new(() => new ChartService(this));
        _data = new(() => new DataService(this));
        _insight = new(() => new InsightService(this));
        _accounts = new(() => new AccountService(this));
        _attachments = new(() => new AttachmentService(this));
        _availableBudgets = new(() => new AvailableBudgetService(this));
        _bills = new(() => new BillService(this));
        _budgets = new(() => new BudgetService(this));
        _categories = new(() => new CategoryService(this));
        _exchangeRates = new(() => new ExchangeRateService(this));
        _linkTypes = new(() => new LinkTypeService(this));
        _transactionLinks = new(() => new TransactionLinkService(this));
        _objectGroups = new(() => new ObjectGroupService(this));
        _piggyBanks = new(() => new PiggyBankService(this));
        _recurrences = new(() => new RecurrenceService(this));
        _ruleGroups = new(() => new RuleGroupService(this));
        _rules = new(() => new RuleService(this));
        _tags = new(() => new TagService(this));
        _currencies = new(() => new CurrencyService(this));
        _transactionJournals = new(() => new TransactionJournalService(this));
        _transactions = new(() => new TransactionService(this));
        _userGroups = new(() => new UserGroupService(this));
        _search = new(() => new SearchService(this));
        _summary = new(() => new SummaryService(this));
        _about = new(() => new AboutService(this));
        _batch = new(() => new BatchService(this));
        _configuration = new(() => new ConfigurationService(this));
        _cron = new(() => new CronService(this));
        _users = new(() => new UserService(this));
        _preferences = new(() => new PreferenceService(this));
        _webhooks = new(() => new WebhookService(this));
    }

    public EmceesProdTesting5Client(ClientOptions options)
        : this()
    {
        _options = options;
    }
}

/// <inheritdoc/>
public sealed class EmceesProdTesting5ClientWithRawResponse
    : IEmceesProdTesting5ClientWithRawResponse
{
#if NET
    static readonly Random Random = Random.Shared;
#else
    static readonly ThreadLocal<Random> _threadLocalRandom = new(() => new Random());

    static Random Random
    {
        get { return _threadLocalRandom.Value!; }
    }
#endif

    readonly ClientOptions _options;

    /// <inheritdoc/>
    public HttpClient HttpClient
    {
        get { return this._options.HttpClient; }
        init { this._options.HttpClient = value; }
    }

    /// <inheritdoc/>
    public string BaseUrl
    {
        get { return this._options.BaseUrl; }
        init { this._options.BaseUrl = value; }
    }

    /// <inheritdoc/>
    public bool ResponseValidation
    {
        get { return this._options.ResponseValidation; }
        init { this._options.ResponseValidation = value; }
    }

    /// <inheritdoc/>
    public int? MaxRetries
    {
        get { return this._options.MaxRetries; }
        init { this._options.MaxRetries = value; }
    }

    /// <inheritdoc/>
    public TimeSpan? Timeout
    {
        get { return this._options.Timeout; }
        init { this._options.Timeout = value; }
    }

    /// <inheritdoc/>
    public string? BearerToken
    {
        get { return this._options.BearerToken; }
        init { this._options.BearerToken = value; }
    }

    /// <inheritdoc/>
    public IEmceesProdTesting5ClientWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new EmceesProdTesting5ClientWithRawResponse(modifier(this._options));
    }

    readonly Lazy<IAutocompleteServiceWithRawResponse> _autocomplete;
    public IAutocompleteServiceWithRawResponse Autocomplete
    {
        get { return _autocomplete.Value; }
    }

    readonly Lazy<IChartServiceWithRawResponse> _chart;
    public IChartServiceWithRawResponse Chart
    {
        get { return _chart.Value; }
    }

    readonly Lazy<IDataServiceWithRawResponse> _data;
    public IDataServiceWithRawResponse Data
    {
        get { return _data.Value; }
    }

    readonly Lazy<IInsightServiceWithRawResponse> _insight;
    public IInsightServiceWithRawResponse Insight
    {
        get { return _insight.Value; }
    }

    readonly Lazy<IAccountServiceWithRawResponse> _accounts;
    public IAccountServiceWithRawResponse Accounts
    {
        get { return _accounts.Value; }
    }

    readonly Lazy<IAttachmentServiceWithRawResponse> _attachments;
    public IAttachmentServiceWithRawResponse Attachments
    {
        get { return _attachments.Value; }
    }

    readonly Lazy<IAvailableBudgetServiceWithRawResponse> _availableBudgets;
    public IAvailableBudgetServiceWithRawResponse AvailableBudgets
    {
        get { return _availableBudgets.Value; }
    }

    readonly Lazy<IBillServiceWithRawResponse> _bills;
    public IBillServiceWithRawResponse Bills
    {
        get { return _bills.Value; }
    }

    readonly Lazy<IBudgetServiceWithRawResponse> _budgets;
    public IBudgetServiceWithRawResponse Budgets
    {
        get { return _budgets.Value; }
    }

    readonly Lazy<ICategoryServiceWithRawResponse> _categories;
    public ICategoryServiceWithRawResponse Categories
    {
        get { return _categories.Value; }
    }

    readonly Lazy<IExchangeRateServiceWithRawResponse> _exchangeRates;
    public IExchangeRateServiceWithRawResponse ExchangeRates
    {
        get { return _exchangeRates.Value; }
    }

    readonly Lazy<ILinkTypeServiceWithRawResponse> _linkTypes;
    public ILinkTypeServiceWithRawResponse LinkTypes
    {
        get { return _linkTypes.Value; }
    }

    readonly Lazy<ITransactionLinkServiceWithRawResponse> _transactionLinks;
    public ITransactionLinkServiceWithRawResponse TransactionLinks
    {
        get { return _transactionLinks.Value; }
    }

    readonly Lazy<IObjectGroupServiceWithRawResponse> _objectGroups;
    public IObjectGroupServiceWithRawResponse ObjectGroups
    {
        get { return _objectGroups.Value; }
    }

    readonly Lazy<IPiggyBankServiceWithRawResponse> _piggyBanks;
    public IPiggyBankServiceWithRawResponse PiggyBanks
    {
        get { return _piggyBanks.Value; }
    }

    readonly Lazy<IRecurrenceServiceWithRawResponse> _recurrences;
    public IRecurrenceServiceWithRawResponse Recurrences
    {
        get { return _recurrences.Value; }
    }

    readonly Lazy<IRuleGroupServiceWithRawResponse> _ruleGroups;
    public IRuleGroupServiceWithRawResponse RuleGroups
    {
        get { return _ruleGroups.Value; }
    }

    readonly Lazy<IRuleServiceWithRawResponse> _rules;
    public IRuleServiceWithRawResponse Rules
    {
        get { return _rules.Value; }
    }

    readonly Lazy<ITagServiceWithRawResponse> _tags;
    public ITagServiceWithRawResponse Tags
    {
        get { return _tags.Value; }
    }

    readonly Lazy<ICurrencyServiceWithRawResponse> _currencies;
    public ICurrencyServiceWithRawResponse Currencies
    {
        get { return _currencies.Value; }
    }

    readonly Lazy<ITransactionJournalServiceWithRawResponse> _transactionJournals;
    public ITransactionJournalServiceWithRawResponse TransactionJournals
    {
        get { return _transactionJournals.Value; }
    }

    readonly Lazy<ITransactionServiceWithRawResponse> _transactions;
    public ITransactionServiceWithRawResponse Transactions
    {
        get { return _transactions.Value; }
    }

    readonly Lazy<IUserGroupServiceWithRawResponse> _userGroups;
    public IUserGroupServiceWithRawResponse UserGroups
    {
        get { return _userGroups.Value; }
    }

    readonly Lazy<ISearchServiceWithRawResponse> _search;
    public ISearchServiceWithRawResponse Search
    {
        get { return _search.Value; }
    }

    readonly Lazy<ISummaryServiceWithRawResponse> _summary;
    public ISummaryServiceWithRawResponse Summary
    {
        get { return _summary.Value; }
    }

    readonly Lazy<IAboutServiceWithRawResponse> _about;
    public IAboutServiceWithRawResponse About
    {
        get { return _about.Value; }
    }

    readonly Lazy<IBatchServiceWithRawResponse> _batch;
    public IBatchServiceWithRawResponse Batch
    {
        get { return _batch.Value; }
    }

    readonly Lazy<IConfigurationServiceWithRawResponse> _configuration;
    public IConfigurationServiceWithRawResponse Configuration
    {
        get { return _configuration.Value; }
    }

    readonly Lazy<ICronServiceWithRawResponse> _cron;
    public ICronServiceWithRawResponse Cron
    {
        get { return _cron.Value; }
    }

    readonly Lazy<IUserServiceWithRawResponse> _users;
    public IUserServiceWithRawResponse Users
    {
        get { return _users.Value; }
    }

    readonly Lazy<IPreferenceServiceWithRawResponse> _preferences;
    public IPreferenceServiceWithRawResponse Preferences
    {
        get { return _preferences.Value; }
    }

    readonly Lazy<IWebhookServiceWithRawResponse> _webhooks;
    public IWebhookServiceWithRawResponse Webhooks
    {
        get { return _webhooks.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse> Execute<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase
    {
        var maxRetries = this.MaxRetries ?? ClientOptions.DefaultMaxRetries;
        var retries = 0;
        while (true)
        {
            HttpResponse? response = null;
            try
            {
                response = await ExecuteOnce(request, retries, cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception e)
            {
                if (++retries > maxRetries || !ShouldRetry(e))
                {
                    throw;
                }
            }

            if (response != null && (++retries > maxRetries || !ShouldRetry(response)))
            {
                if (response.IsSuccessStatusCode)
                {
                    return response;
                }

                try
                {
                    throw EmceesProdTesting5ExceptionFactory.CreateApiException(
                        response.StatusCode,
                        await response.ReadAsString(cancellationToken).ConfigureAwait(false)
                    );
                }
                catch (HttpRequestException e)
                {
                    throw new EmceesProdTesting5IOException("I/O Exception", e);
                }
                finally
                {
                    response.Dispose();
                }
            }

            var backoff = ComputeRetryBackoff(retries, response);
            response?.Dispose();
            await Task.Delay(backoff, cancellationToken).ConfigureAwait(false);
        }
    }

    async Task<HttpResponse> ExecuteOnce<T>(
        HttpRequest<T> request,
        int retryCount,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase
    {
        using HttpRequestMessage requestMessage = new(
            request.Method,
            request.Params.Url(this._options)
        )
        {
            Content = request.Params.BodyContent(),
        };
        request.Params.AddHeadersToRequest(requestMessage, this._options);
        if (!requestMessage.Headers.Contains("x-stainless-retry-count"))
        {
            requestMessage.Headers.Add("x-stainless-retry-count", retryCount.ToString());
        }
        using CancellationTokenSource timeoutCts = new(
            this.Timeout ?? ClientOptions.DefaultTimeout
        );
        using var cts = CancellationTokenSource.CreateLinkedTokenSource(
            timeoutCts.Token,
            cancellationToken
        );
        HttpResponseMessage responseMessage;
        try
        {
            responseMessage = await this
                .HttpClient.SendAsync(
                    requestMessage,
                    HttpCompletionOption.ResponseHeadersRead,
                    cts.Token
                )
                .ConfigureAwait(false);
        }
        catch (HttpRequestException e)
        {
            throw new EmceesProdTesting5IOException("I/O exception", e);
        }
        return new() { RawMessage = responseMessage, CancellationToken = cts.Token };
    }

    static TimeSpan ComputeRetryBackoff(int retries, HttpResponse? response)
    {
        TimeSpan? apiBackoff = ParseRetryAfterMsHeader(response) ?? ParseRetryAfterHeader(response);
        if (
            apiBackoff != null
            && apiBackoff > TimeSpan.Zero
            && apiBackoff < TimeSpan.FromMinutes(1)
        )
        {
            // If the API asks us to wait a certain amount of time (and it's a reasonable amount), then just
            // do what it says.
            return (TimeSpan)apiBackoff;
        }

        // Apply exponential backoff, but not more than the max.
        var backoffSeconds = Math.Min(0.5 * Math.Pow(2.0, retries - 1), 8.0);
        var jitter = 1.0 - 0.25 * Random.NextDouble();
        return TimeSpan.FromSeconds(backoffSeconds * jitter);
    }

    static TimeSpan? ParseRetryAfterMsHeader(HttpResponse? response)
    {
        IEnumerable<string>? headerValues = null;
        response?.TryGetHeaderValues("Retry-After-Ms", out headerValues);
        var headerValue = headerValues == null ? null : Enumerable.FirstOrDefault(headerValues);
        if (headerValue == null)
        {
            return null;
        }

        if (float.TryParse(headerValue, out var retryAfterMs))
        {
            return TimeSpan.FromMilliseconds(retryAfterMs);
        }

        return null;
    }

    static TimeSpan? ParseRetryAfterHeader(HttpResponse? response)
    {
        IEnumerable<string>? headerValues = null;
        response?.TryGetHeaderValues("Retry-After", out headerValues);
        var headerValue = headerValues == null ? null : Enumerable.FirstOrDefault(headerValues);
        if (headerValue == null)
        {
            return null;
        }

        if (float.TryParse(headerValue, out var retryAfterSeconds))
        {
            return TimeSpan.FromSeconds(retryAfterSeconds);
        }
        else if (DateTimeOffset.TryParse(headerValue, out var retryAfterDate))
        {
            return retryAfterDate - DateTimeOffset.Now;
        }

        return null;
    }

    static bool ShouldRetry(HttpResponse response)
    {
        if (
            response.TryGetHeaderValues("X-Should-Retry", out var headerValues)
            && bool.TryParse(Enumerable.FirstOrDefault(headerValues), out var shouldRetry)
        )
        {
            // If the server explicitly says whether to retry, then we obey.
            return shouldRetry;
        }

        return (int)response.StatusCode switch
        {
            // Retry on request timeouts
            408
            or
            // Retry on lock timeouts
            409
            or
            // Retry on rate limits
            429
            or
            // Retry internal errors
            >= 500 => true,
            _ => false,
        };
    }

    static bool ShouldRetry(Exception e)
    {
        return e is IOException || e is EmceesProdTesting5IOException;
    }

    public void Dispose() => this.HttpClient.Dispose();

    public EmceesProdTesting5ClientWithRawResponse()
    {
        _options = new();

        _autocomplete = new(() => new AutocompleteServiceWithRawResponse(this));
        _chart = new(() => new ChartServiceWithRawResponse(this));
        _data = new(() => new DataServiceWithRawResponse(this));
        _insight = new(() => new InsightServiceWithRawResponse(this));
        _accounts = new(() => new AccountServiceWithRawResponse(this));
        _attachments = new(() => new AttachmentServiceWithRawResponse(this));
        _availableBudgets = new(() => new AvailableBudgetServiceWithRawResponse(this));
        _bills = new(() => new BillServiceWithRawResponse(this));
        _budgets = new(() => new BudgetServiceWithRawResponse(this));
        _categories = new(() => new CategoryServiceWithRawResponse(this));
        _exchangeRates = new(() => new ExchangeRateServiceWithRawResponse(this));
        _linkTypes = new(() => new LinkTypeServiceWithRawResponse(this));
        _transactionLinks = new(() => new TransactionLinkServiceWithRawResponse(this));
        _objectGroups = new(() => new ObjectGroupServiceWithRawResponse(this));
        _piggyBanks = new(() => new PiggyBankServiceWithRawResponse(this));
        _recurrences = new(() => new RecurrenceServiceWithRawResponse(this));
        _ruleGroups = new(() => new RuleGroupServiceWithRawResponse(this));
        _rules = new(() => new RuleServiceWithRawResponse(this));
        _tags = new(() => new TagServiceWithRawResponse(this));
        _currencies = new(() => new CurrencyServiceWithRawResponse(this));
        _transactionJournals = new(() => new TransactionJournalServiceWithRawResponse(this));
        _transactions = new(() => new TransactionServiceWithRawResponse(this));
        _userGroups = new(() => new UserGroupServiceWithRawResponse(this));
        _search = new(() => new SearchServiceWithRawResponse(this));
        _summary = new(() => new SummaryServiceWithRawResponse(this));
        _about = new(() => new AboutServiceWithRawResponse(this));
        _batch = new(() => new BatchServiceWithRawResponse(this));
        _configuration = new(() => new ConfigurationServiceWithRawResponse(this));
        _cron = new(() => new CronServiceWithRawResponse(this));
        _users = new(() => new UserServiceWithRawResponse(this));
        _preferences = new(() => new PreferenceServiceWithRawResponse(this));
        _webhooks = new(() => new WebhookServiceWithRawResponse(this));
    }

    public EmceesProdTesting5ClientWithRawResponse(ClientOptions options)
        : this()
    {
        _options = options;
    }
}
