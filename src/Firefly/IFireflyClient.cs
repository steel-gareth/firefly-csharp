using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Firefly.Core;
using Firefly.Services;

namespace Firefly;

/// <summary>
/// A client for interacting with the Firefly REST API.
///
/// <para>This client performs best when you create a single instance and reuse it
/// for all interactions with the REST API. This is because each client holds its
/// own connection pool and thread pools. Reusing connections and threads reduces
/// latency and saves memory.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IFireflyClient : IDisposable
{
    /// <inheritdoc cref="ClientOptions.HttpClient" />
    HttpClient HttpClient { get; init; }

    /// <inheritdoc cref="ClientOptions.BaseUrl" />
    string BaseUrl { get; init; }

    /// <inheritdoc cref="ClientOptions.ResponseValidation" />
    bool ResponseValidation { get; init; }

    /// <inheritdoc cref="ClientOptions.MaxRetries" />
    int? MaxRetries { get; init; }

    /// <inheritdoc cref="ClientOptions.Timeout" />
    TimeSpan? Timeout { get; init; }

    /// <summary>
    /// Optional Bearer token flow
    /// </summary>
    string? BearerToken { get; init; }

    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IFireflyClientWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFireflyClient WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IAutocompleteService Autocomplete { get; }

    IChartService Chart { get; }

    IDataService Data { get; }

    IInsightService Insight { get; }

    IAccountService Accounts { get; }

    IAttachmentService Attachments { get; }

    IAvailableBudgetService AvailableBudgets { get; }

    IBillService Bills { get; }

    IBudgetService Budgets { get; }

    ICategoryService Categories { get; }

    IExchangeRateService ExchangeRates { get; }

    ILinkTypeService LinkTypes { get; }

    ITransactionLinkService TransactionLinks { get; }

    IObjectGroupService ObjectGroups { get; }

    IPiggyBankService PiggyBanks { get; }

    IRecurrenceService Recurrences { get; }

    IRuleGroupService RuleGroups { get; }

    IRuleService Rules { get; }

    ITagService Tags { get; }

    ICurrencyService Currencies { get; }

    ITransactionJournalService TransactionJournals { get; }

    ITransactionService Transactions { get; }

    IUserGroupService UserGroups { get; }

    ISearchService Search { get; }

    ISummaryService Summary { get; }

    IAboutService About { get; }

    IBatchService Batch { get; }

    IConfigurationService Configuration { get; }

    ICronService Cron { get; }

    IUserService Users { get; }

    IPreferenceService Preferences { get; }

    IWebhookService Webhooks { get; }
}

/// <summary>
/// A view of <see cref="IFireflyClient"/> that provides access to raw HTTP responses for each method.
/// </summary>
public interface IFireflyClientWithRawResponse : IDisposable
{
    /// <inheritdoc cref="ClientOptions.HttpClient" />
    HttpClient HttpClient { get; init; }

    /// <inheritdoc cref="ClientOptions.BaseUrl" />
    string BaseUrl { get; init; }

    /// <inheritdoc cref="ClientOptions.ResponseValidation" />
    bool ResponseValidation { get; init; }

    /// <inheritdoc cref="ClientOptions.MaxRetries" />
    int? MaxRetries { get; init; }

    /// <inheritdoc cref="ClientOptions.Timeout" />
    TimeSpan? Timeout { get; init; }

    /// <summary>
    /// Optional Bearer token flow
    /// </summary>
    string? BearerToken { get; init; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFireflyClientWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IAutocompleteServiceWithRawResponse Autocomplete { get; }

    IChartServiceWithRawResponse Chart { get; }

    IDataServiceWithRawResponse Data { get; }

    IInsightServiceWithRawResponse Insight { get; }

    IAccountServiceWithRawResponse Accounts { get; }

    IAttachmentServiceWithRawResponse Attachments { get; }

    IAvailableBudgetServiceWithRawResponse AvailableBudgets { get; }

    IBillServiceWithRawResponse Bills { get; }

    IBudgetServiceWithRawResponse Budgets { get; }

    ICategoryServiceWithRawResponse Categories { get; }

    IExchangeRateServiceWithRawResponse ExchangeRates { get; }

    ILinkTypeServiceWithRawResponse LinkTypes { get; }

    ITransactionLinkServiceWithRawResponse TransactionLinks { get; }

    IObjectGroupServiceWithRawResponse ObjectGroups { get; }

    IPiggyBankServiceWithRawResponse PiggyBanks { get; }

    IRecurrenceServiceWithRawResponse Recurrences { get; }

    IRuleGroupServiceWithRawResponse RuleGroups { get; }

    IRuleServiceWithRawResponse Rules { get; }

    ITagServiceWithRawResponse Tags { get; }

    ICurrencyServiceWithRawResponse Currencies { get; }

    ITransactionJournalServiceWithRawResponse TransactionJournals { get; }

    ITransactionServiceWithRawResponse Transactions { get; }

    IUserGroupServiceWithRawResponse UserGroups { get; }

    ISearchServiceWithRawResponse Search { get; }

    ISummaryServiceWithRawResponse Summary { get; }

    IAboutServiceWithRawResponse About { get; }

    IBatchServiceWithRawResponse Batch { get; }

    IConfigurationServiceWithRawResponse Configuration { get; }

    ICronServiceWithRawResponse Cron { get; }

    IUserServiceWithRawResponse Users { get; }

    IPreferenceServiceWithRawResponse Preferences { get; }

    IWebhookServiceWithRawResponse Webhooks { get; }

    /// <summary>
    /// Sends a request to the Firefly REST API.
    /// </summary>
    Task<HttpResponse> Execute<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase;
}
