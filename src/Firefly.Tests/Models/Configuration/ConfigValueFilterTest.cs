using System.Text.Json;
using Firefly.Core;
using Firefly.Exceptions;
using Firefly.Models.Configuration;

namespace Firefly.Tests.Models.Configuration;

public class ConfigValueFilterTest : TestBase
{
    [Theory]
    [InlineData(ConfigValueFilter.ConfigurationIsDemoSite)]
    [InlineData(ConfigValueFilter.ConfigurationPermissionUpdateCheck)]
    [InlineData(ConfigValueFilter.ConfigurationLastUpdateCheck)]
    [InlineData(ConfigValueFilter.ConfigurationSingleUserMode)]
    [InlineData(ConfigValueFilter.FireflyVersion)]
    [InlineData(ConfigValueFilter.FireflyDefaultLocation)]
    [InlineData(ConfigValueFilter.FireflyAccountToTransaction)]
    [InlineData(ConfigValueFilter.FireflyAllowedOpposingTypes)]
    [InlineData(ConfigValueFilter.FireflyAccountRoles)]
    [InlineData(ConfigValueFilter.FireflyValidLiabilities)]
    [InlineData(ConfigValueFilter.FireflyInterestPeriods)]
    [InlineData(ConfigValueFilter.FireflyEnableExternalMap)]
    [InlineData(ConfigValueFilter.FireflyExpectedSourceTypes)]
    [InlineData(ConfigValueFilter.AppTimezone)]
    [InlineData(ConfigValueFilter.FireflyBillPeriods)]
    [InlineData(ConfigValueFilter.FireflyCreditCardTypes)]
    [InlineData(ConfigValueFilter.FireflyLanguages)]
    [InlineData(ConfigValueFilter.FireflyValidViewRanges)]
    [InlineData(ConfigValueFilter.CerEnabled)]
    [InlineData(ConfigValueFilter.FireflyPreselectedAccounts)]
    [InlineData(ConfigValueFilter.FireflyRuleActions)]
    [InlineData(ConfigValueFilter.FireflyContextRuleActions)]
    [InlineData(ConfigValueFilter.SearchOperators)]
    [InlineData(ConfigValueFilter.WebhookTriggers)]
    [InlineData(ConfigValueFilter.WebhookResponses)]
    [InlineData(ConfigValueFilter.WebhookDeliveries)]
    public void Validation_Works(ConfigValueFilter rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ConfigValueFilter> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ConfigValueFilter>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<FireflyInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ConfigValueFilter.ConfigurationIsDemoSite)]
    [InlineData(ConfigValueFilter.ConfigurationPermissionUpdateCheck)]
    [InlineData(ConfigValueFilter.ConfigurationLastUpdateCheck)]
    [InlineData(ConfigValueFilter.ConfigurationSingleUserMode)]
    [InlineData(ConfigValueFilter.FireflyVersion)]
    [InlineData(ConfigValueFilter.FireflyDefaultLocation)]
    [InlineData(ConfigValueFilter.FireflyAccountToTransaction)]
    [InlineData(ConfigValueFilter.FireflyAllowedOpposingTypes)]
    [InlineData(ConfigValueFilter.FireflyAccountRoles)]
    [InlineData(ConfigValueFilter.FireflyValidLiabilities)]
    [InlineData(ConfigValueFilter.FireflyInterestPeriods)]
    [InlineData(ConfigValueFilter.FireflyEnableExternalMap)]
    [InlineData(ConfigValueFilter.FireflyExpectedSourceTypes)]
    [InlineData(ConfigValueFilter.AppTimezone)]
    [InlineData(ConfigValueFilter.FireflyBillPeriods)]
    [InlineData(ConfigValueFilter.FireflyCreditCardTypes)]
    [InlineData(ConfigValueFilter.FireflyLanguages)]
    [InlineData(ConfigValueFilter.FireflyValidViewRanges)]
    [InlineData(ConfigValueFilter.CerEnabled)]
    [InlineData(ConfigValueFilter.FireflyPreselectedAccounts)]
    [InlineData(ConfigValueFilter.FireflyRuleActions)]
    [InlineData(ConfigValueFilter.FireflyContextRuleActions)]
    [InlineData(ConfigValueFilter.SearchOperators)]
    [InlineData(ConfigValueFilter.WebhookTriggers)]
    [InlineData(ConfigValueFilter.WebhookResponses)]
    [InlineData(ConfigValueFilter.WebhookDeliveries)]
    public void SerializationRoundtrip_Works(ConfigValueFilter rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ConfigValueFilter> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ConfigValueFilter>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ConfigValueFilter>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ConfigValueFilter>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
