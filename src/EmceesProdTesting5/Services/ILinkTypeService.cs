using System;
using System.Threading;
using System.Threading.Tasks;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Accounts;
using EmceesProdTesting5.Models.LinkTypes;

namespace EmceesProdTesting5.Services;

/// <summary>
/// Endpoints to manage links between transactions, and manage the type of links available.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ILinkTypeService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ILinkTypeServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ILinkTypeService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Creates a new link type. The data required can be submitted as a JSON body or as
    /// a list of parameters (in key=value pairs, like a webform).
    /// </summary>
    Task<LinkTypeSingle> Create(
        LinkTypeCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a single link type by its ID.
    /// </summary>
    Task<LinkTypeSingle> Retrieve(
        LinkTypeRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(LinkTypeRetrieveParams, CancellationToken)"/>
    Task<LinkTypeSingle> Retrieve(
        string id,
        LinkTypeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Used to update a single link type. All fields that are not submitted will be
    /// cleared (set to NULL). The model will tell you which fields are mandatory. You
    /// cannot update some of the system provided link types, indicated by the
    /// editable=false flag when you list it.
    /// </summary>
    Task<LinkTypeSingle> Update(
        LinkTypeUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(LinkTypeUpdateParams, CancellationToken)"/>
    Task<LinkTypeSingle> Update(
        string id,
        LinkTypeUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List all the link types the system has. These include the default ones as well
    /// as any new ones.
    /// </summary>
    Task<LinkTypeListResponse> List(
        LinkTypeListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Will permanently delete a link type. The links between transactions will be
    /// removed. The transactions themselves remain. You cannot delete some of the
    /// system provided link types, indicated by the editable=false flag when you list
    /// it.
    /// </summary>
    Task Delete(LinkTypeDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(LinkTypeDeleteParams, CancellationToken)"/>
    Task Delete(
        string id,
        LinkTypeDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List all transactions under this link type, both the inward and outward
    /// transactions.
    /// </summary>
    Task<TransactionArray> ListTransactions(
        LinkTypeListTransactionsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListTransactions(LinkTypeListTransactionsParams, CancellationToken)"/>
    Task<TransactionArray> ListTransactions(
        string id,
        LinkTypeListTransactionsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ILinkTypeService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ILinkTypeServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ILinkTypeServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/link-types</c>, but is otherwise the
    /// same as <see cref="ILinkTypeService.Create(LinkTypeCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<LinkTypeSingle>> Create(
        LinkTypeCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/link-types/{id}</c>, but is otherwise the
    /// same as <see cref="ILinkTypeService.Retrieve(LinkTypeRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<LinkTypeSingle>> Retrieve(
        LinkTypeRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(LinkTypeRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<LinkTypeSingle>> Retrieve(
        string id,
        LinkTypeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /v1/link-types/{id}</c>, but is otherwise the
    /// same as <see cref="ILinkTypeService.Update(LinkTypeUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<LinkTypeSingle>> Update(
        LinkTypeUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(LinkTypeUpdateParams, CancellationToken)"/>
    Task<HttpResponse<LinkTypeSingle>> Update(
        string id,
        LinkTypeUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/link-types</c>, but is otherwise the
    /// same as <see cref="ILinkTypeService.List(LinkTypeListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<LinkTypeListResponse>> List(
        LinkTypeListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/link-types/{id}</c>, but is otherwise the
    /// same as <see cref="ILinkTypeService.Delete(LinkTypeDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        LinkTypeDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(LinkTypeDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string id,
        LinkTypeDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/link-types/{id}/transactions</c>, but is otherwise the
    /// same as <see cref="ILinkTypeService.ListTransactions(LinkTypeListTransactionsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TransactionArray>> ListTransactions(
        LinkTypeListTransactionsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListTransactions(LinkTypeListTransactionsParams, CancellationToken)"/>
    Task<HttpResponse<TransactionArray>> ListTransactions(
        string id,
        LinkTypeListTransactionsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
