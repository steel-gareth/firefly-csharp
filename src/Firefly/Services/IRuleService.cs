using System;
using System.Threading;
using System.Threading.Tasks;
using Firefly.Core;
using Firefly.Models.Accounts;
using Firefly.Models.Bills;
using Firefly.Models.Rules;

namespace Firefly.Services;

/// <summary>
/// These endpoints can be used to manage all of the user&amp;#039;s rules. Also includes
/// triggers to execute or test rules and individual triggers.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IRuleService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IRuleServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRuleService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Creates a new rule. The data required can be submitted as a JSON body or as a
    /// list of parameters.
    /// </summary>
    Task<RuleSingle> Create(
        RuleCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a single rule.
    /// </summary>
    Task<RuleSingle> Retrieve(
        RuleRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(RuleRetrieveParams, CancellationToken)"/>
    Task<RuleSingle> Retrieve(
        string id,
        RuleRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update existing rule.
    /// </summary>
    Task<RuleSingle> Update(
        RuleUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(RuleUpdateParams, CancellationToken)"/>
    Task<RuleSingle> Update(
        string id,
        RuleUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List all rules.
    /// </summary>
    Task<RuleArray> List(
        RuleListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete an rule.
    /// </summary>
    Task Delete(RuleDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(RuleDeleteParams, CancellationToken)"/>
    Task Delete(
        string id,
        RuleDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Test which transactions would be hit by the rule. No changes will be made. Limit
    /// the result if you want to.
    /// </summary>
    Task<TransactionArray> Test(
        RuleTestParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Test(RuleTestParams, CancellationToken)"/>
    Task<TransactionArray> Test(
        string id,
        RuleTestParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Fire the rule group on your transactions. Changes will be made by the rules in
    /// the group. Limit the result if you want to.
    /// </summary>
    Task Trigger(RuleTriggerParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Trigger(RuleTriggerParams, CancellationToken)"/>
    Task Trigger(
        string id,
        RuleTriggerParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IRuleService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IRuleServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRuleServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/rules</c>, but is otherwise the
    /// same as <see cref="IRuleService.Create(RuleCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RuleSingle>> Create(
        RuleCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/rules/{id}</c>, but is otherwise the
    /// same as <see cref="IRuleService.Retrieve(RuleRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RuleSingle>> Retrieve(
        RuleRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(RuleRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<RuleSingle>> Retrieve(
        string id,
        RuleRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /v1/rules/{id}</c>, but is otherwise the
    /// same as <see cref="IRuleService.Update(RuleUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RuleSingle>> Update(
        RuleUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(RuleUpdateParams, CancellationToken)"/>
    Task<HttpResponse<RuleSingle>> Update(
        string id,
        RuleUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/rules</c>, but is otherwise the
    /// same as <see cref="IRuleService.List(RuleListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RuleArray>> List(
        RuleListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/rules/{id}</c>, but is otherwise the
    /// same as <see cref="IRuleService.Delete(RuleDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        RuleDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(RuleDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string id,
        RuleDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/rules/{id}/test</c>, but is otherwise the
    /// same as <see cref="IRuleService.Test(RuleTestParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TransactionArray>> Test(
        RuleTestParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Test(RuleTestParams, CancellationToken)"/>
    Task<HttpResponse<TransactionArray>> Test(
        string id,
        RuleTestParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/rules/{id}/trigger</c>, but is otherwise the
    /// same as <see cref="IRuleService.Trigger(RuleTriggerParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Trigger(
        RuleTriggerParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Trigger(RuleTriggerParams, CancellationToken)"/>
    Task<HttpResponse> Trigger(
        string id,
        RuleTriggerParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
