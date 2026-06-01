using System;
using System.Threading;
using System.Threading.Tasks;
using Firefly.Core;
using Firefly.Models.Accounts;
using Firefly.Models.Categories;

namespace Firefly.Services;

/// <summary>
/// Endpoints to manage a user&amp;#039;s categories and get information on transactions
/// and other related objects.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ICategoryService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICategoryServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICategoryService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Creates a new category. The data required can be submitted as a JSON body or as
    /// a list of parameters.
    /// </summary>
    Task<CategorySingle> Create(
        CategoryCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a single category.
    /// </summary>
    Task<CategorySingle> Retrieve(
        CategoryRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(CategoryRetrieveParams, CancellationToken)"/>
    Task<CategorySingle> Retrieve(
        string id,
        CategoryRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update existing category.
    /// </summary>
    Task<CategorySingle> Update(
        CategoryUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(CategoryUpdateParams, CancellationToken)"/>
    Task<CategorySingle> Update(
        string id,
        CategoryUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List all categories.
    /// </summary>
    Task<CategoryListResponse> List(
        CategoryListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a category. Transactions will not be removed.
    /// </summary>
    Task Delete(CategoryDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(CategoryDeleteParams, CancellationToken)"/>
    Task Delete(
        string id,
        CategoryDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Lists all attachments.
    /// </summary>
    Task<AttachmentArray> ListAttachments(
        CategoryListAttachmentsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListAttachments(CategoryListAttachmentsParams, CancellationToken)"/>
    Task<AttachmentArray> ListAttachments(
        string id,
        CategoryListAttachmentsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List all transactions in a category, optionally limited to the date ranges
    /// specified.
    /// </summary>
    Task<TransactionArray> ListTransactions(
        CategoryListTransactionsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListTransactions(CategoryListTransactionsParams, CancellationToken)"/>
    Task<TransactionArray> ListTransactions(
        string id,
        CategoryListTransactionsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ICategoryService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICategoryServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICategoryServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/categories</c>, but is otherwise the
    /// same as <see cref="ICategoryService.Create(CategoryCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CategorySingle>> Create(
        CategoryCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/categories/{id}</c>, but is otherwise the
    /// same as <see cref="ICategoryService.Retrieve(CategoryRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CategorySingle>> Retrieve(
        CategoryRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(CategoryRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<CategorySingle>> Retrieve(
        string id,
        CategoryRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /v1/categories/{id}</c>, but is otherwise the
    /// same as <see cref="ICategoryService.Update(CategoryUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CategorySingle>> Update(
        CategoryUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(CategoryUpdateParams, CancellationToken)"/>
    Task<HttpResponse<CategorySingle>> Update(
        string id,
        CategoryUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/categories</c>, but is otherwise the
    /// same as <see cref="ICategoryService.List(CategoryListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CategoryListResponse>> List(
        CategoryListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/categories/{id}</c>, but is otherwise the
    /// same as <see cref="ICategoryService.Delete(CategoryDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        CategoryDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(CategoryDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string id,
        CategoryDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/categories/{id}/attachments</c>, but is otherwise the
    /// same as <see cref="ICategoryService.ListAttachments(CategoryListAttachmentsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AttachmentArray>> ListAttachments(
        CategoryListAttachmentsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListAttachments(CategoryListAttachmentsParams, CancellationToken)"/>
    Task<HttpResponse<AttachmentArray>> ListAttachments(
        string id,
        CategoryListAttachmentsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/categories/{id}/transactions</c>, but is otherwise the
    /// same as <see cref="ICategoryService.ListTransactions(CategoryListTransactionsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TransactionArray>> ListTransactions(
        CategoryListTransactionsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListTransactions(CategoryListTransactionsParams, CancellationToken)"/>
    Task<HttpResponse<TransactionArray>> ListTransactions(
        string id,
        CategoryListTransactionsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
