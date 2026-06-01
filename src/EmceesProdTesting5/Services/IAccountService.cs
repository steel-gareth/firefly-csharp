using System;
using System.Threading;
using System.Threading.Tasks;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Accounts;

namespace EmceesProdTesting5.Services;

/// <summary>
/// Endpoints that deliver all of the user&amp;#039;s asset, expense and other accounts
/// (and the metadata) together with related transactions, piggy banks and other objects.
/// Also delivers endpoints for CRUD operations for accounts.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IAccountService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAccountServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAccountService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Creates a new account. The data required can be submitted as a JSON body or as a
    /// list of parameters (in key=value pairs, like a webform).
    /// </summary>
    Task<AccountSingle> Create(
        AccountCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a single account by its ID.
    /// </summary>
    Task<AccountSingle> Retrieve(
        AccountRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(AccountRetrieveParams, CancellationToken)"/>
    Task<AccountSingle> Retrieve(
        string id,
        AccountRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Used to update a single account. All fields that are not submitted will be
    /// cleared (set to NULL). The model will tell you which fields are mandatory.
    /// </summary>
    Task<AccountSingle> Update(
        AccountUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(AccountUpdateParams, CancellationToken)"/>
    Task<AccountSingle> Update(
        string id,
        AccountUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint returns a list of all the accounts owned by the authenticated
    /// user.
    /// </summary>
    Task<AccountArray> List(
        AccountListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Will permanently delete an account. Any associated transactions and piggy banks
    /// are ALSO deleted. Cannot be recovered from.
    /// </summary>
    Task Delete(AccountDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(AccountDeleteParams, CancellationToken)"/>
    Task Delete(
        string id,
        AccountDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Lists all attachments.
    /// </summary>
    Task<AttachmentArray> ListAttachments(
        AccountListAttachmentsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListAttachments(AccountListAttachmentsParams, CancellationToken)"/>
    Task<AttachmentArray> ListAttachments(
        string id,
        AccountListAttachmentsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint returns a list of all the piggy banks connected to the account.
    /// </summary>
    Task<PiggyBankArray> ListPiggyBanks(
        AccountListPiggyBanksParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListPiggyBanks(AccountListPiggyBanksParams, CancellationToken)"/>
    Task<PiggyBankArray> ListPiggyBanks(
        string id,
        AccountListPiggyBanksParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint returns a list of all the transactions connected to the account.
    /// </summary>
    Task<TransactionArray> ListTransactions(
        AccountListTransactionsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListTransactions(AccountListTransactionsParams, CancellationToken)"/>
    Task<TransactionArray> ListTransactions(
        string id,
        AccountListTransactionsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IAccountService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAccountServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAccountServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/accounts</c>, but is otherwise the
    /// same as <see cref="IAccountService.Create(AccountCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AccountSingle>> Create(
        AccountCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/accounts/{id}</c>, but is otherwise the
    /// same as <see cref="IAccountService.Retrieve(AccountRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AccountSingle>> Retrieve(
        AccountRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(AccountRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<AccountSingle>> Retrieve(
        string id,
        AccountRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /v1/accounts/{id}</c>, but is otherwise the
    /// same as <see cref="IAccountService.Update(AccountUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AccountSingle>> Update(
        AccountUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(AccountUpdateParams, CancellationToken)"/>
    Task<HttpResponse<AccountSingle>> Update(
        string id,
        AccountUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/accounts</c>, but is otherwise the
    /// same as <see cref="IAccountService.List(AccountListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AccountArray>> List(
        AccountListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/accounts/{id}</c>, but is otherwise the
    /// same as <see cref="IAccountService.Delete(AccountDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        AccountDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(AccountDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string id,
        AccountDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/accounts/{id}/attachments</c>, but is otherwise the
    /// same as <see cref="IAccountService.ListAttachments(AccountListAttachmentsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AttachmentArray>> ListAttachments(
        AccountListAttachmentsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListAttachments(AccountListAttachmentsParams, CancellationToken)"/>
    Task<HttpResponse<AttachmentArray>> ListAttachments(
        string id,
        AccountListAttachmentsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/accounts/{id}/piggy-banks</c>, but is otherwise the
    /// same as <see cref="IAccountService.ListPiggyBanks(AccountListPiggyBanksParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PiggyBankArray>> ListPiggyBanks(
        AccountListPiggyBanksParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListPiggyBanks(AccountListPiggyBanksParams, CancellationToken)"/>
    Task<HttpResponse<PiggyBankArray>> ListPiggyBanks(
        string id,
        AccountListPiggyBanksParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/accounts/{id}/transactions</c>, but is otherwise the
    /// same as <see cref="IAccountService.ListTransactions(AccountListTransactionsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TransactionArray>> ListTransactions(
        AccountListTransactionsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListTransactions(AccountListTransactionsParams, CancellationToken)"/>
    Task<HttpResponse<TransactionArray>> ListTransactions(
        string id,
        AccountListTransactionsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
