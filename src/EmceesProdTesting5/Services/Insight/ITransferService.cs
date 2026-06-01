using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Insight.Expense;
using EmceesProdTesting5.Models.Insight.Transfer;

namespace EmceesProdTesting5.Services.Insight;

/// <summary>
/// The &amp;quot;insight&amp;quot; endpoints try to deliver sums, balances and insightful
/// information in the broadest sense of the word.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ITransferService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ITransferServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITransferService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// This endpoint gives a sum of the total amount transfers made by the user.
    /// </summary>
    Task<List<InsightTotalEntry>> GetTotal(
        TransferGetTotalParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint gives a summary of the transfers made by the user, grouped by
    /// asset account or lability.
    /// </summary>
    Task<List<TransferListByAssetAccountResponse>> ListByAssetAccount(
        TransferListByAssetAccountParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint gives a summary of the transfers made by the user, grouped by
    /// (any) category.
    /// </summary>
    Task<List<InsightGroupEntry>> ListByCategory(
        TransferListByCategoryParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint gives a summary of the transfers created by the user, grouped by
    /// (any) tag.
    /// </summary>
    Task<List<InsightGroupEntry>> ListByTag(
        TransferListByTagParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint gives a summary of the transfers made by the user, including only
    /// transfers with no category.
    /// </summary>
    Task<List<InsightTotalEntry>> ListWithoutCategory(
        TransferListWithoutCategoryParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint gives a summary of the transfers made by the user, including only
    /// transfers with no tag.
    /// </summary>
    Task<List<InsightTotalEntry>> ListWithoutTag(
        TransferListWithoutTagParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ITransferService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ITransferServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITransferServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/insight/transfer/total</c>, but is otherwise the
    /// same as <see cref="ITransferService.GetTotal(TransferGetTotalParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<InsightTotalEntry>>> GetTotal(
        TransferGetTotalParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/insight/transfer/asset</c>, but is otherwise the
    /// same as <see cref="ITransferService.ListByAssetAccount(TransferListByAssetAccountParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<TransferListByAssetAccountResponse>>> ListByAssetAccount(
        TransferListByAssetAccountParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/insight/transfer/category</c>, but is otherwise the
    /// same as <see cref="ITransferService.ListByCategory(TransferListByCategoryParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<InsightGroupEntry>>> ListByCategory(
        TransferListByCategoryParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/insight/transfer/tag</c>, but is otherwise the
    /// same as <see cref="ITransferService.ListByTag(TransferListByTagParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<InsightGroupEntry>>> ListByTag(
        TransferListByTagParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/insight/transfer/no-category</c>, but is otherwise the
    /// same as <see cref="ITransferService.ListWithoutCategory(TransferListWithoutCategoryParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<InsightTotalEntry>>> ListWithoutCategory(
        TransferListWithoutCategoryParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/insight/transfer/no-tag</c>, but is otherwise the
    /// same as <see cref="ITransferService.ListWithoutTag(TransferListWithoutTagParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<InsightTotalEntry>>> ListWithoutTag(
        TransferListWithoutTagParams parameters,
        CancellationToken cancellationToken = default
    );
}
