using System;
using System.Threading;
using System.Threading.Tasks;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Data.Export;

namespace EmceesProdTesting5.Services.Data;

/// <summary>
/// The &amp;quot;data&amp;quot;-endpoints manage generic Firefly III and user-specific data.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IExportService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IExportServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IExportService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// This endpoint allows you to export your accounts from Firefly III into a file.
    /// Currently supports CSV exports only.
    ///
    /// <para>It's the caller's responsibility to dispose the returned response.</para>
    /// </summary>
    Task<HttpResponse> ExportAccounts(
        ExportExportAccountsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint allows you to export your bills from Firefly III into a file.
    /// Currently supports CSV exports only.
    ///
    /// <para>It's the caller's responsibility to dispose the returned response.</para>
    /// </summary>
    Task<HttpResponse> ExportBills(
        ExportExportBillsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint allows you to export your budgets and associated budget data from
    /// Firefly III into a file. Currently supports CSV exports only.
    ///
    /// <para>It's the caller's responsibility to dispose the returned response.</para>
    /// </summary>
    Task<HttpResponse> ExportBudgets(
        ExportExportBudgetsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint allows you to export your categories from Firefly III into a file.
    /// Currently supports CSV exports only.
    ///
    /// <para>It's the caller's responsibility to dispose the returned response.</para>
    /// </summary>
    Task<HttpResponse> ExportCategories(
        ExportExportCategoriesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint allows you to export your piggy banks from Firefly III into a
    /// file. Currently supports CSV exports only.
    ///
    /// <para>It's the caller's responsibility to dispose the returned response.</para>
    /// </summary>
    Task<HttpResponse> ExportPiggyBanks(
        ExportExportPiggyBanksParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint allows you to export your recurring transactions from Firefly III
    /// into a file. Currently supports CSV exports only.
    ///
    /// <para>It's the caller's responsibility to dispose the returned response.</para>
    /// </summary>
    Task<HttpResponse> ExportRecurring(
        ExportExportRecurringParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint allows you to export your rules and rule groups from Firefly III
    /// into a file. Currently supports CSV exports only.
    ///
    /// <para>It's the caller's responsibility to dispose the returned response.</para>
    /// </summary>
    Task<HttpResponse> ExportRules(
        ExportExportRulesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint allows you to export your tags from Firefly III into a file.
    /// Currently supports CSV exports only.
    ///
    /// <para>It's the caller's responsibility to dispose the returned response.</para>
    /// </summary>
    Task<HttpResponse> ExportTags(
        ExportExportTagsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint allows you to export transactions from Firefly III into a file.
    /// Currently supports CSV exports only.
    ///
    /// <para>It's the caller's responsibility to dispose the returned response.</para>
    /// </summary>
    Task<HttpResponse> ExportTransactions(
        ExportExportTransactionsParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IExportService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IExportServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IExportServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/data/export/accounts</c>, but is otherwise the
    /// same as <see cref="IExportService.ExportAccounts(ExportExportAccountsParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> ExportAccounts(
        ExportExportAccountsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/data/export/bills</c>, but is otherwise the
    /// same as <see cref="IExportService.ExportBills(ExportExportBillsParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> ExportBills(
        ExportExportBillsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/data/export/budgets</c>, but is otherwise the
    /// same as <see cref="IExportService.ExportBudgets(ExportExportBudgetsParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> ExportBudgets(
        ExportExportBudgetsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/data/export/categories</c>, but is otherwise the
    /// same as <see cref="IExportService.ExportCategories(ExportExportCategoriesParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> ExportCategories(
        ExportExportCategoriesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/data/export/piggy-banks</c>, but is otherwise the
    /// same as <see cref="IExportService.ExportPiggyBanks(ExportExportPiggyBanksParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> ExportPiggyBanks(
        ExportExportPiggyBanksParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/data/export/recurring</c>, but is otherwise the
    /// same as <see cref="IExportService.ExportRecurring(ExportExportRecurringParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> ExportRecurring(
        ExportExportRecurringParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/data/export/rules</c>, but is otherwise the
    /// same as <see cref="IExportService.ExportRules(ExportExportRulesParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> ExportRules(
        ExportExportRulesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/data/export/tags</c>, but is otherwise the
    /// same as <see cref="IExportService.ExportTags(ExportExportTagsParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> ExportTags(
        ExportExportTagsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/data/export/transactions</c>, but is otherwise the
    /// same as <see cref="IExportService.ExportTransactions(ExportExportTransactionsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> ExportTransactions(
        ExportExportTransactionsParams parameters,
        CancellationToken cancellationToken = default
    );
}
