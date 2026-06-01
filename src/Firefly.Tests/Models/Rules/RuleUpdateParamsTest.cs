using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Firefly.Core;
using Firefly.Models.Rules;

namespace Firefly.Tests.Models.Rules;

public class RuleUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RuleUpdateParams
        {
            ID = "123",
            Actions =
            [
                new()
                {
                    Active = true,
                    Order = 5,
                    StopProcessing = false,
                    Type = RuleActionKeyword.SetCategory,
                    Value = "Daily groceries",
                },
            ],
            Active = true,
            Description = "First rule description",
            Order = 5,
            RuleGroupID = "81",
            StopProcessing = false,
            Strict = true,
            Title = "First rule title.",
            Trigger = RuleTriggerType.StoreJournal,
            Triggers =
            [
                new()
                {
                    Active = true,
                    Order = 5,
                    StopProcessing = false,
                    Type = RuleTriggerKeyword.FromAccountStarts,
                    Value = "tag1",
                },
            ],
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        string expectedID = "123";
        List<RuleUpdateParamsAction> expectedActions =
        [
            new()
            {
                Active = true,
                Order = 5,
                StopProcessing = false,
                Type = RuleActionKeyword.SetCategory,
                Value = "Daily groceries",
            },
        ];
        bool expectedActive = true;
        string expectedDescription = "First rule description";
        int expectedOrder = 5;
        string expectedRuleGroupID = "81";
        bool expectedStopProcessing = false;
        bool expectedStrict = true;
        string expectedTitle = "First rule title.";
        ApiEnum<string, RuleTriggerType> expectedTrigger = RuleTriggerType.StoreJournal;
        List<RuleUpdateParamsTrigger> expectedTriggers =
        [
            new()
            {
                Active = true,
                Order = 5,
                StopProcessing = false,
                Type = RuleTriggerKeyword.FromAccountStarts,
                Value = "tag1",
            },
        ];
        string expectedXTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00";

        Assert.Equal(expectedID, parameters.ID);
        Assert.NotNull(parameters.Actions);
        Assert.Equal(expectedActions.Count, parameters.Actions.Count);
        for (int i = 0; i < expectedActions.Count; i++)
        {
            Assert.Equal(expectedActions[i], parameters.Actions[i]);
        }
        Assert.Equal(expectedActive, parameters.Active);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedOrder, parameters.Order);
        Assert.Equal(expectedRuleGroupID, parameters.RuleGroupID);
        Assert.Equal(expectedStopProcessing, parameters.StopProcessing);
        Assert.Equal(expectedStrict, parameters.Strict);
        Assert.Equal(expectedTitle, parameters.Title);
        Assert.Equal(expectedTrigger, parameters.Trigger);
        Assert.NotNull(parameters.Triggers);
        Assert.Equal(expectedTriggers.Count, parameters.Triggers.Count);
        for (int i = 0; i < expectedTriggers.Count; i++)
        {
            Assert.Equal(expectedTriggers[i], parameters.Triggers[i]);
        }
        Assert.Equal(expectedXTraceID, parameters.XTraceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new RuleUpdateParams { ID = "123" };

        Assert.Null(parameters.Actions);
        Assert.False(parameters.RawBodyData.ContainsKey("actions"));
        Assert.Null(parameters.Active);
        Assert.False(parameters.RawBodyData.ContainsKey("active"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Order);
        Assert.False(parameters.RawBodyData.ContainsKey("order"));
        Assert.Null(parameters.RuleGroupID);
        Assert.False(parameters.RawBodyData.ContainsKey("rule_group_id"));
        Assert.Null(parameters.StopProcessing);
        Assert.False(parameters.RawBodyData.ContainsKey("stop_processing"));
        Assert.Null(parameters.Strict);
        Assert.False(parameters.RawBodyData.ContainsKey("strict"));
        Assert.Null(parameters.Title);
        Assert.False(parameters.RawBodyData.ContainsKey("title"));
        Assert.Null(parameters.Trigger);
        Assert.False(parameters.RawBodyData.ContainsKey("trigger"));
        Assert.Null(parameters.Triggers);
        Assert.False(parameters.RawBodyData.ContainsKey("triggers"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new RuleUpdateParams
        {
            ID = "123",

            // Null should be interpreted as omitted for these properties
            Actions = null,
            Active = null,
            Description = null,
            Order = null,
            RuleGroupID = null,
            StopProcessing = null,
            Strict = null,
            Title = null,
            Trigger = null,
            Triggers = null,
            XTraceID = null,
        };

        Assert.Null(parameters.Actions);
        Assert.False(parameters.RawBodyData.ContainsKey("actions"));
        Assert.Null(parameters.Active);
        Assert.False(parameters.RawBodyData.ContainsKey("active"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Order);
        Assert.False(parameters.RawBodyData.ContainsKey("order"));
        Assert.Null(parameters.RuleGroupID);
        Assert.False(parameters.RawBodyData.ContainsKey("rule_group_id"));
        Assert.Null(parameters.StopProcessing);
        Assert.False(parameters.RawBodyData.ContainsKey("stop_processing"));
        Assert.Null(parameters.Strict);
        Assert.False(parameters.RawBodyData.ContainsKey("strict"));
        Assert.Null(parameters.Title);
        Assert.False(parameters.RawBodyData.ContainsKey("title"));
        Assert.Null(parameters.Trigger);
        Assert.False(parameters.RawBodyData.ContainsKey("trigger"));
        Assert.Null(parameters.Triggers);
        Assert.False(parameters.RawBodyData.ContainsKey("triggers"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void Url_Works()
    {
        RuleUpdateParams parameters = new() { ID = "123" };

        var url = parameters.Url(new() { });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://demo.firefly-iii.org/api/v1/rules/123"), url)
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        RuleUpdateParams parameters = new()
        {
            ID = "123",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        parameters.AddHeadersToRequest(requestMessage, new() { });

        Assert.Equal(
            ["40c71bbb-c676-4f24-83cf-cc725d7d7a00"],
            requestMessage.Headers.GetValues("X-Trace-Id")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new RuleUpdateParams
        {
            ID = "123",
            Actions =
            [
                new()
                {
                    Active = true,
                    Order = 5,
                    StopProcessing = false,
                    Type = RuleActionKeyword.SetCategory,
                    Value = "Daily groceries",
                },
            ],
            Active = true,
            Description = "First rule description",
            Order = 5,
            RuleGroupID = "81",
            StopProcessing = false,
            Strict = true,
            Title = "First rule title.",
            Trigger = RuleTriggerType.StoreJournal,
            Triggers =
            [
                new()
                {
                    Active = true,
                    Order = 5,
                    StopProcessing = false,
                    Type = RuleTriggerKeyword.FromAccountStarts,
                    Value = "tag1",
                },
            ],
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        RuleUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class RuleUpdateParamsActionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RuleUpdateParamsAction
        {
            Active = true,
            Order = 5,
            StopProcessing = false,
            Type = RuleActionKeyword.SetCategory,
            Value = "Daily groceries",
        };

        bool expectedActive = true;
        int expectedOrder = 5;
        bool expectedStopProcessing = false;
        ApiEnum<string, RuleActionKeyword> expectedType = RuleActionKeyword.SetCategory;
        string expectedValue = "Daily groceries";

        Assert.Equal(expectedActive, model.Active);
        Assert.Equal(expectedOrder, model.Order);
        Assert.Equal(expectedStopProcessing, model.StopProcessing);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RuleUpdateParamsAction
        {
            Active = true,
            Order = 5,
            StopProcessing = false,
            Type = RuleActionKeyword.SetCategory,
            Value = "Daily groceries",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RuleUpdateParamsAction>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RuleUpdateParamsAction
        {
            Active = true,
            Order = 5,
            StopProcessing = false,
            Type = RuleActionKeyword.SetCategory,
            Value = "Daily groceries",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RuleUpdateParamsAction>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedActive = true;
        int expectedOrder = 5;
        bool expectedStopProcessing = false;
        ApiEnum<string, RuleActionKeyword> expectedType = RuleActionKeyword.SetCategory;
        string expectedValue = "Daily groceries";

        Assert.Equal(expectedActive, deserialized.Active);
        Assert.Equal(expectedOrder, deserialized.Order);
        Assert.Equal(expectedStopProcessing, deserialized.StopProcessing);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RuleUpdateParamsAction
        {
            Active = true,
            Order = 5,
            StopProcessing = false,
            Type = RuleActionKeyword.SetCategory,
            Value = "Daily groceries",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RuleUpdateParamsAction { Value = "Daily groceries" };

        Assert.Null(model.Active);
        Assert.False(model.RawData.ContainsKey("active"));
        Assert.Null(model.Order);
        Assert.False(model.RawData.ContainsKey("order"));
        Assert.Null(model.StopProcessing);
        Assert.False(model.RawData.ContainsKey("stop_processing"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new RuleUpdateParamsAction { Value = "Daily groceries" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new RuleUpdateParamsAction
        {
            Value = "Daily groceries",

            // Null should be interpreted as omitted for these properties
            Active = null,
            Order = null,
            StopProcessing = null,
            Type = null,
        };

        Assert.Null(model.Active);
        Assert.False(model.RawData.ContainsKey("active"));
        Assert.Null(model.Order);
        Assert.False(model.RawData.ContainsKey("order"));
        Assert.Null(model.StopProcessing);
        Assert.False(model.RawData.ContainsKey("stop_processing"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new RuleUpdateParamsAction
        {
            Value = "Daily groceries",

            // Null should be interpreted as omitted for these properties
            Active = null,
            Order = null,
            StopProcessing = null,
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RuleUpdateParamsAction
        {
            Active = true,
            Order = 5,
            StopProcessing = false,
            Type = RuleActionKeyword.SetCategory,
        };

        Assert.Null(model.Value);
        Assert.False(model.RawData.ContainsKey("value"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new RuleUpdateParamsAction
        {
            Active = true,
            Order = 5,
            StopProcessing = false,
            Type = RuleActionKeyword.SetCategory,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new RuleUpdateParamsAction
        {
            Active = true,
            Order = 5,
            StopProcessing = false,
            Type = RuleActionKeyword.SetCategory,

            Value = null,
        };

        Assert.Null(model.Value);
        Assert.True(model.RawData.ContainsKey("value"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new RuleUpdateParamsAction
        {
            Active = true,
            Order = 5,
            StopProcessing = false,
            Type = RuleActionKeyword.SetCategory,

            Value = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RuleUpdateParamsAction
        {
            Active = true,
            Order = 5,
            StopProcessing = false,
            Type = RuleActionKeyword.SetCategory,
            Value = "Daily groceries",
        };

        RuleUpdateParamsAction copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RuleUpdateParamsTriggerTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RuleUpdateParamsTrigger
        {
            Active = true,
            Order = 5,
            StopProcessing = false,
            Type = RuleTriggerKeyword.FromAccountStarts,
            Value = "tag1",
        };

        bool expectedActive = true;
        int expectedOrder = 5;
        bool expectedStopProcessing = false;
        ApiEnum<string, RuleTriggerKeyword> expectedType = RuleTriggerKeyword.FromAccountStarts;
        string expectedValue = "tag1";

        Assert.Equal(expectedActive, model.Active);
        Assert.Equal(expectedOrder, model.Order);
        Assert.Equal(expectedStopProcessing, model.StopProcessing);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RuleUpdateParamsTrigger
        {
            Active = true,
            Order = 5,
            StopProcessing = false,
            Type = RuleTriggerKeyword.FromAccountStarts,
            Value = "tag1",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RuleUpdateParamsTrigger>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RuleUpdateParamsTrigger
        {
            Active = true,
            Order = 5,
            StopProcessing = false,
            Type = RuleTriggerKeyword.FromAccountStarts,
            Value = "tag1",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RuleUpdateParamsTrigger>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedActive = true;
        int expectedOrder = 5;
        bool expectedStopProcessing = false;
        ApiEnum<string, RuleTriggerKeyword> expectedType = RuleTriggerKeyword.FromAccountStarts;
        string expectedValue = "tag1";

        Assert.Equal(expectedActive, deserialized.Active);
        Assert.Equal(expectedOrder, deserialized.Order);
        Assert.Equal(expectedStopProcessing, deserialized.StopProcessing);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RuleUpdateParamsTrigger
        {
            Active = true,
            Order = 5,
            StopProcessing = false,
            Type = RuleTriggerKeyword.FromAccountStarts,
            Value = "tag1",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RuleUpdateParamsTrigger { };

        Assert.Null(model.Active);
        Assert.False(model.RawData.ContainsKey("active"));
        Assert.Null(model.Order);
        Assert.False(model.RawData.ContainsKey("order"));
        Assert.Null(model.StopProcessing);
        Assert.False(model.RawData.ContainsKey("stop_processing"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.Value);
        Assert.False(model.RawData.ContainsKey("value"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new RuleUpdateParamsTrigger { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new RuleUpdateParamsTrigger
        {
            // Null should be interpreted as omitted for these properties
            Active = null,
            Order = null,
            StopProcessing = null,
            Type = null,
            Value = null,
        };

        Assert.Null(model.Active);
        Assert.False(model.RawData.ContainsKey("active"));
        Assert.Null(model.Order);
        Assert.False(model.RawData.ContainsKey("order"));
        Assert.Null(model.StopProcessing);
        Assert.False(model.RawData.ContainsKey("stop_processing"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.Value);
        Assert.False(model.RawData.ContainsKey("value"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new RuleUpdateParamsTrigger
        {
            // Null should be interpreted as omitted for these properties
            Active = null,
            Order = null,
            StopProcessing = null,
            Type = null,
            Value = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RuleUpdateParamsTrigger
        {
            Active = true,
            Order = 5,
            StopProcessing = false,
            Type = RuleTriggerKeyword.FromAccountStarts,
            Value = "tag1",
        };

        RuleUpdateParamsTrigger copied = new(model);

        Assert.Equal(model, copied);
    }
}
