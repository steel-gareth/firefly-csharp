using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmceesProdTesting5.Exceptions;

namespace EmceesProdTesting5.Models.Configuration;

/// <summary>
/// Title of the configuration value.
/// </summary>
[JsonConverter(typeof(ConfigValueFilterConverter))]
public enum ConfigValueFilter
{
    ConfigurationIsDemoSite,
    ConfigurationPermissionUpdateCheck,
    ConfigurationLastUpdateCheck,
    ConfigurationSingleUserMode,
    FireflyVersion,
    FireflyDefaultLocation,
    FireflyAccountToTransaction,
    FireflyAllowedOpposingTypes,
    FireflyAccountRoles,
    FireflyValidLiabilities,
    FireflyInterestPeriods,
    FireflyEnableExternalMap,
    FireflyExpectedSourceTypes,
    AppTimezone,
    FireflyBillPeriods,
    FireflyCreditCardTypes,
    FireflyLanguages,
    FireflyValidViewRanges,
    CerEnabled,
    FireflyPreselectedAccounts,
    FireflyRuleActions,
    FireflyContextRuleActions,
    SearchOperators,
    WebhookTriggers,
    WebhookResponses,
    WebhookDeliveries,
}

sealed class ConfigValueFilterConverter : JsonConverter<ConfigValueFilter>
{
    public override ConfigValueFilter Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "configuration.is_demo_site" => ConfigValueFilter.ConfigurationIsDemoSite,
            "configuration.permission_update_check" =>
                ConfigValueFilter.ConfigurationPermissionUpdateCheck,
            "configuration.last_update_check" => ConfigValueFilter.ConfigurationLastUpdateCheck,
            "configuration.single_user_mode" => ConfigValueFilter.ConfigurationSingleUserMode,
            "firefly.version" => ConfigValueFilter.FireflyVersion,
            "firefly.default_location" => ConfigValueFilter.FireflyDefaultLocation,
            "firefly.account_to_transaction" => ConfigValueFilter.FireflyAccountToTransaction,
            "firefly.allowed_opposing_types" => ConfigValueFilter.FireflyAllowedOpposingTypes,
            "firefly.accountRoles" => ConfigValueFilter.FireflyAccountRoles,
            "firefly.valid_liabilities" => ConfigValueFilter.FireflyValidLiabilities,
            "firefly.interest_periods" => ConfigValueFilter.FireflyInterestPeriods,
            "firefly.enable_external_map" => ConfigValueFilter.FireflyEnableExternalMap,
            "firefly.expected_source_types" => ConfigValueFilter.FireflyExpectedSourceTypes,
            "app.timezone" => ConfigValueFilter.AppTimezone,
            "firefly.bill_periods" => ConfigValueFilter.FireflyBillPeriods,
            "firefly.credit_card_types" => ConfigValueFilter.FireflyCreditCardTypes,
            "firefly.languages" => ConfigValueFilter.FireflyLanguages,
            "firefly.valid_view_ranges" => ConfigValueFilter.FireflyValidViewRanges,
            "cer.enabled" => ConfigValueFilter.CerEnabled,
            "firefly.preselected_accounts" => ConfigValueFilter.FireflyPreselectedAccounts,
            "firefly.rule-actions" => ConfigValueFilter.FireflyRuleActions,
            "firefly.context-rule-actions" => ConfigValueFilter.FireflyContextRuleActions,
            "search.operators" => ConfigValueFilter.SearchOperators,
            "webhook.triggers" => ConfigValueFilter.WebhookTriggers,
            "webhook.responses" => ConfigValueFilter.WebhookResponses,
            "webhook.deliveries" => ConfigValueFilter.WebhookDeliveries,
            _ => (ConfigValueFilter)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConfigValueFilter value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ConfigValueFilter.ConfigurationIsDemoSite => "configuration.is_demo_site",
                ConfigValueFilter.ConfigurationPermissionUpdateCheck =>
                    "configuration.permission_update_check",
                ConfigValueFilter.ConfigurationLastUpdateCheck => "configuration.last_update_check",
                ConfigValueFilter.ConfigurationSingleUserMode => "configuration.single_user_mode",
                ConfigValueFilter.FireflyVersion => "firefly.version",
                ConfigValueFilter.FireflyDefaultLocation => "firefly.default_location",
                ConfigValueFilter.FireflyAccountToTransaction => "firefly.account_to_transaction",
                ConfigValueFilter.FireflyAllowedOpposingTypes => "firefly.allowed_opposing_types",
                ConfigValueFilter.FireflyAccountRoles => "firefly.accountRoles",
                ConfigValueFilter.FireflyValidLiabilities => "firefly.valid_liabilities",
                ConfigValueFilter.FireflyInterestPeriods => "firefly.interest_periods",
                ConfigValueFilter.FireflyEnableExternalMap => "firefly.enable_external_map",
                ConfigValueFilter.FireflyExpectedSourceTypes => "firefly.expected_source_types",
                ConfigValueFilter.AppTimezone => "app.timezone",
                ConfigValueFilter.FireflyBillPeriods => "firefly.bill_periods",
                ConfigValueFilter.FireflyCreditCardTypes => "firefly.credit_card_types",
                ConfigValueFilter.FireflyLanguages => "firefly.languages",
                ConfigValueFilter.FireflyValidViewRanges => "firefly.valid_view_ranges",
                ConfigValueFilter.CerEnabled => "cer.enabled",
                ConfigValueFilter.FireflyPreselectedAccounts => "firefly.preselected_accounts",
                ConfigValueFilter.FireflyRuleActions => "firefly.rule-actions",
                ConfigValueFilter.FireflyContextRuleActions => "firefly.context-rule-actions",
                ConfigValueFilter.SearchOperators => "search.operators",
                ConfigValueFilter.WebhookTriggers => "webhook.triggers",
                ConfigValueFilter.WebhookResponses => "webhook.responses",
                ConfigValueFilter.WebhookDeliveries => "webhook.deliveries",
                _ => throw new EmceesProdTesting5InvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
