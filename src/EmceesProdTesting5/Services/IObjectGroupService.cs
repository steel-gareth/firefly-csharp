using System;
using System.Threading;
using System.Threading.Tasks;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Accounts;
using EmceesProdTesting5.Models.Bills;
using EmceesProdTesting5.Models.ObjectGroups;

namespace EmceesProdTesting5.Services;

/// <summary>
/// Endpoints to control and manage all of the user&amp;#039;s object groups. Can
/// only be created in conjunction with another object (for example a piggy bank)
/// and will auto-delete when no other items are linked to it.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IObjectGroupService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IObjectGroupServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IObjectGroupService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get a single object group.
    /// </summary>
    Task<ObjectGroupSingle> Retrieve(
        ObjectGroupRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ObjectGroupRetrieveParams, CancellationToken)"/>
    Task<ObjectGroupSingle> Retrieve(
        string id,
        ObjectGroupRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update existing object group.
    /// </summary>
    Task<ObjectGroupSingle> Update(
        ObjectGroupUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ObjectGroupUpdateParams, CancellationToken)"/>
    Task<ObjectGroupSingle> Update(
        string id,
        ObjectGroupUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List all object groups.
    /// </summary>
    Task<ObjectGroupListResponse> List(
        ObjectGroupListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a object group.
    /// </summary>
    Task Delete(ObjectGroupDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(ObjectGroupDeleteParams, CancellationToken)"/>
    Task Delete(
        string id,
        ObjectGroupDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List all bills with this object group.
    /// </summary>
    Task<BillArray> ListBills(
        ObjectGroupListBillsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListBills(ObjectGroupListBillsParams, CancellationToken)"/>
    Task<BillArray> ListBills(
        string id,
        ObjectGroupListBillsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint returns a list of all the piggy banks connected to the object
    /// group.
    /// </summary>
    Task<PiggyBankArray> ListPiggyBanks(
        ObjectGroupListPiggyBanksParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListPiggyBanks(ObjectGroupListPiggyBanksParams, CancellationToken)"/>
    Task<PiggyBankArray> ListPiggyBanks(
        string id,
        ObjectGroupListPiggyBanksParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IObjectGroupService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IObjectGroupServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IObjectGroupServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/object-groups/{id}</c>, but is otherwise the
    /// same as <see cref="IObjectGroupService.Retrieve(ObjectGroupRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ObjectGroupSingle>> Retrieve(
        ObjectGroupRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ObjectGroupRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<ObjectGroupSingle>> Retrieve(
        string id,
        ObjectGroupRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /v1/object-groups/{id}</c>, but is otherwise the
    /// same as <see cref="IObjectGroupService.Update(ObjectGroupUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ObjectGroupSingle>> Update(
        ObjectGroupUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ObjectGroupUpdateParams, CancellationToken)"/>
    Task<HttpResponse<ObjectGroupSingle>> Update(
        string id,
        ObjectGroupUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/object-groups</c>, but is otherwise the
    /// same as <see cref="IObjectGroupService.List(ObjectGroupListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ObjectGroupListResponse>> List(
        ObjectGroupListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/object-groups/{id}</c>, but is otherwise the
    /// same as <see cref="IObjectGroupService.Delete(ObjectGroupDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        ObjectGroupDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(ObjectGroupDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string id,
        ObjectGroupDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/object-groups/{id}/bills</c>, but is otherwise the
    /// same as <see cref="IObjectGroupService.ListBills(ObjectGroupListBillsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BillArray>> ListBills(
        ObjectGroupListBillsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListBills(ObjectGroupListBillsParams, CancellationToken)"/>
    Task<HttpResponse<BillArray>> ListBills(
        string id,
        ObjectGroupListBillsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/object-groups/{id}/piggy-banks</c>, but is otherwise the
    /// same as <see cref="IObjectGroupService.ListPiggyBanks(ObjectGroupListPiggyBanksParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PiggyBankArray>> ListPiggyBanks(
        ObjectGroupListPiggyBanksParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListPiggyBanks(ObjectGroupListPiggyBanksParams, CancellationToken)"/>
    Task<HttpResponse<PiggyBankArray>> ListPiggyBanks(
        string id,
        ObjectGroupListPiggyBanksParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
