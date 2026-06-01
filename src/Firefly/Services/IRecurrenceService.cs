using System;
using System.Threading;
using System.Threading.Tasks;
using Firefly.Core;
using Firefly.Models.Accounts;
using Firefly.Models.Recurrences;

namespace Firefly.Services;

/// <summary>
/// Use these endpoints to manage the user&amp;#039;s recurring transactions, trigger
/// the creation of transactions and manage the settings.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IRecurrenceService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IRecurrenceServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRecurrenceService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Creates a new recurring transaction. The data required can be submitted as a
    /// JSON body or as a list of parameters.
    /// </summary>
    Task<RecurrenceSingle> Create(
        RecurrenceCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a single recurring transaction.
    /// </summary>
    Task<RecurrenceSingle> Retrieve(
        RecurrenceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(RecurrenceRetrieveParams, CancellationToken)"/>
    Task<RecurrenceSingle> Retrieve(
        string id,
        RecurrenceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update existing recurring transaction.
    /// </summary>
    Task<RecurrenceSingle> Update(
        RecurrenceUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(RecurrenceUpdateParams, CancellationToken)"/>
    Task<RecurrenceSingle> Update(
        string id,
        RecurrenceUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List all recurring transactions.
    /// </summary>
    Task<RecurrenceArray> List(
        RecurrenceListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a recurring transaction. Transactions created by the recurring
    /// transaction will not be deleted.
    /// </summary>
    Task Delete(RecurrenceDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(RecurrenceDeleteParams, CancellationToken)"/>
    Task Delete(
        string id,
        RecurrenceDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List all transactions created by a recurring transaction, optionally limited to
    /// the date ranges specified.
    /// </summary>
    Task<TransactionArray> ListTransactions(
        RecurrenceListTransactionsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListTransactions(RecurrenceListTransactionsParams, CancellationToken)"/>
    Task<TransactionArray> ListTransactions(
        string id,
        RecurrenceListTransactionsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Trigger the creation of a transaction for a specific recurring transaction. All
    /// recurrences have a set of future occurrences. For those moments, you can trigger
    /// the creation of the transaction. That means the transaction will be created NOW,
    /// instead of on the indicated date. The transaction will be dated to _today_.
    ///
    /// <para>So, if you recurring transaction that occurs every Monday, you can trigger
    /// the creation of a transaction for Monday in two weeks, today. On that Monday two
    /// weeks from now, no transaction will be created. Instead, the transaction is
    /// created right now, and dated _today_. </para>
    /// </summary>
    Task<TransactionArray> TriggerTransaction(
        RecurrenceTriggerTransactionParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="TriggerTransaction(RecurrenceTriggerTransactionParams, CancellationToken)"/>
    Task<TransactionArray> TriggerTransaction(
        string id,
        RecurrenceTriggerTransactionParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IRecurrenceService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IRecurrenceServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRecurrenceServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/recurrences</c>, but is otherwise the
    /// same as <see cref="IRecurrenceService.Create(RecurrenceCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RecurrenceSingle>> Create(
        RecurrenceCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/recurrences/{id}</c>, but is otherwise the
    /// same as <see cref="IRecurrenceService.Retrieve(RecurrenceRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RecurrenceSingle>> Retrieve(
        RecurrenceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(RecurrenceRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<RecurrenceSingle>> Retrieve(
        string id,
        RecurrenceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /v1/recurrences/{id}</c>, but is otherwise the
    /// same as <see cref="IRecurrenceService.Update(RecurrenceUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RecurrenceSingle>> Update(
        RecurrenceUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(RecurrenceUpdateParams, CancellationToken)"/>
    Task<HttpResponse<RecurrenceSingle>> Update(
        string id,
        RecurrenceUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/recurrences</c>, but is otherwise the
    /// same as <see cref="IRecurrenceService.List(RecurrenceListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RecurrenceArray>> List(
        RecurrenceListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/recurrences/{id}</c>, but is otherwise the
    /// same as <see cref="IRecurrenceService.Delete(RecurrenceDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        RecurrenceDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(RecurrenceDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string id,
        RecurrenceDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/recurrences/{id}/transactions</c>, but is otherwise the
    /// same as <see cref="IRecurrenceService.ListTransactions(RecurrenceListTransactionsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TransactionArray>> ListTransactions(
        RecurrenceListTransactionsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListTransactions(RecurrenceListTransactionsParams, CancellationToken)"/>
    Task<HttpResponse<TransactionArray>> ListTransactions(
        string id,
        RecurrenceListTransactionsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/recurrences/{id}/trigger</c>, but is otherwise the
    /// same as <see cref="IRecurrenceService.TriggerTransaction(RecurrenceTriggerTransactionParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TransactionArray>> TriggerTransaction(
        RecurrenceTriggerTransactionParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="TriggerTransaction(RecurrenceTriggerTransactionParams, CancellationToken)"/>
    Task<HttpResponse<TransactionArray>> TriggerTransaction(
        string id,
        RecurrenceTriggerTransactionParams parameters,
        CancellationToken cancellationToken = default
    );
}
