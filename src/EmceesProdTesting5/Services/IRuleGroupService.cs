using System;
using System.Threading;
using System.Threading.Tasks;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Accounts;
using EmceesProdTesting5.Models.Bills;
using EmceesProdTesting5.Models.RuleGroups;

namespace EmceesProdTesting5.Services;

/// <summary>
/// Manage all of the user&amp;#039;s groups of rules and trigger the execution of
/// entire groups.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IRuleGroupService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IRuleGroupServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRuleGroupService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Creates a new rule group. The data required can be submitted as a JSON body or
    /// as a list of parameters.
    /// </summary>
    Task<RuleGroupSingle> Create(
        RuleGroupCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a single rule group. This does not include the rules. For that, see below.
    /// </summary>
    Task<RuleGroupSingle> Retrieve(
        RuleGroupRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(RuleGroupRetrieveParams, CancellationToken)"/>
    Task<RuleGroupSingle> Retrieve(
        string id,
        RuleGroupRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update existing rule group.
    /// </summary>
    Task<RuleGroupSingle> Update(
        RuleGroupUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(RuleGroupUpdateParams, CancellationToken)"/>
    Task<RuleGroupSingle> Update(
        string id,
        RuleGroupUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a rule group.
    /// </summary>
    Task Delete(RuleGroupDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(RuleGroupDeleteParams, CancellationToken)"/>
    Task Delete(
        string id,
        RuleGroupDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List all rule groups.
    /// </summary>
    Task<RuleGroupListAllResponse> ListAll(
        RuleGroupListAllParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List rules in this rule group.
    /// </summary>
    Task<RuleArray> ListRules(
        RuleGroupListRulesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListRules(RuleGroupListRulesParams, CancellationToken)"/>
    Task<RuleArray> ListRules(
        string id,
        RuleGroupListRulesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Test which transactions would be hit by the rule group. No changes will be made.
    /// Limit the result if you want to.
    /// </summary>
    Task<TransactionArray> TestTransactions(
        RuleGroupTestTransactionsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="TestTransactions(RuleGroupTestTransactionsParams, CancellationToken)"/>
    Task<TransactionArray> TestTransactions(
        string id,
        RuleGroupTestTransactionsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Fire the rule group on your transactions. Changes will be made by the rules in
    /// the rule group. Limit the result if you want to.
    /// </summary>
    Task TriggerRules(
        RuleGroupTriggerRulesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="TriggerRules(RuleGroupTriggerRulesParams, CancellationToken)"/>
    Task TriggerRules(
        string id,
        RuleGroupTriggerRulesParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IRuleGroupService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IRuleGroupServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRuleGroupServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/rule-groups</c>, but is otherwise the
    /// same as <see cref="IRuleGroupService.Create(RuleGroupCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RuleGroupSingle>> Create(
        RuleGroupCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/rule-groups/{id}</c>, but is otherwise the
    /// same as <see cref="IRuleGroupService.Retrieve(RuleGroupRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RuleGroupSingle>> Retrieve(
        RuleGroupRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(RuleGroupRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<RuleGroupSingle>> Retrieve(
        string id,
        RuleGroupRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /v1/rule-groups/{id}</c>, but is otherwise the
    /// same as <see cref="IRuleGroupService.Update(RuleGroupUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RuleGroupSingle>> Update(
        RuleGroupUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(RuleGroupUpdateParams, CancellationToken)"/>
    Task<HttpResponse<RuleGroupSingle>> Update(
        string id,
        RuleGroupUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/rule-groups/{id}</c>, but is otherwise the
    /// same as <see cref="IRuleGroupService.Delete(RuleGroupDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        RuleGroupDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(RuleGroupDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string id,
        RuleGroupDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/rule-groups</c>, but is otherwise the
    /// same as <see cref="IRuleGroupService.ListAll(RuleGroupListAllParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RuleGroupListAllResponse>> ListAll(
        RuleGroupListAllParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/rule-groups/{id}/rules</c>, but is otherwise the
    /// same as <see cref="IRuleGroupService.ListRules(RuleGroupListRulesParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RuleArray>> ListRules(
        RuleGroupListRulesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListRules(RuleGroupListRulesParams, CancellationToken)"/>
    Task<HttpResponse<RuleArray>> ListRules(
        string id,
        RuleGroupListRulesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/rule-groups/{id}/test</c>, but is otherwise the
    /// same as <see cref="IRuleGroupService.TestTransactions(RuleGroupTestTransactionsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TransactionArray>> TestTransactions(
        RuleGroupTestTransactionsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="TestTransactions(RuleGroupTestTransactionsParams, CancellationToken)"/>
    Task<HttpResponse<TransactionArray>> TestTransactions(
        string id,
        RuleGroupTestTransactionsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/rule-groups/{id}/trigger</c>, but is otherwise the
    /// same as <see cref="IRuleGroupService.TriggerRules(RuleGroupTriggerRulesParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> TriggerRules(
        RuleGroupTriggerRulesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="TriggerRules(RuleGroupTriggerRulesParams, CancellationToken)"/>
    Task<HttpResponse> TriggerRules(
        string id,
        RuleGroupTriggerRulesParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
