using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Firefly.Core;
using Rules = Firefly.Models.Rules;

namespace Firefly.Tests.Models.Rules;

public class RuleCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Rules::RuleCreateParams
        {
            Actions =
            [
                new()
                {
                    Type = Rules::RuleActionKeyword.SetCategory,
                    Value = "Daily groceries",
                    Active = true,
                    Order = 5,
                    StopProcessing = false,
                },
            ],
            RuleGroupID = "81",
            Title = "First rule title.",
            Trigger = Rules::RuleTriggerType.StoreJournal,
            Triggers =
            [
                new()
                {
                    Type = Rules::RuleTriggerKeyword.FromAccountStarts,
                    Value = "tag1",
                    Active = true,
                    Order = 5,
                    Prohibited = false,
                    StopProcessing = false,
                },
            ],
            Active = true,
            Description = "First rule description",
            Order = 5,
            RuleGroupTitle = "New rule group",
            StopProcessing = false,
            Strict = true,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        List<Rules::Action> expectedActions =
        [
            new()
            {
                Type = Rules::RuleActionKeyword.SetCategory,
                Value = "Daily groceries",
                Active = true,
                Order = 5,
                StopProcessing = false,
            },
        ];
        string expectedRuleGroupID = "81";
        string expectedTitle = "First rule title.";
        ApiEnum<string, Rules::RuleTriggerType> expectedTrigger =
            Rules::RuleTriggerType.StoreJournal;
        List<Rules::Trigger> expectedTriggers =
        [
            new()
            {
                Type = Rules::RuleTriggerKeyword.FromAccountStarts,
                Value = "tag1",
                Active = true,
                Order = 5,
                Prohibited = false,
                StopProcessing = false,
            },
        ];
        bool expectedActive = true;
        string expectedDescription = "First rule description";
        int expectedOrder = 5;
        string expectedRuleGroupTitle = "New rule group";
        bool expectedStopProcessing = false;
        bool expectedStrict = true;
        string expectedXTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00";

        Assert.Equal(expectedActions.Count, parameters.Actions.Count);
        for (int i = 0; i < expectedActions.Count; i++)
        {
            Assert.Equal(expectedActions[i], parameters.Actions[i]);
        }
        Assert.Equal(expectedRuleGroupID, parameters.RuleGroupID);
        Assert.Equal(expectedTitle, parameters.Title);
        Assert.Equal(expectedTrigger, parameters.Trigger);
        Assert.Equal(expectedTriggers.Count, parameters.Triggers.Count);
        for (int i = 0; i < expectedTriggers.Count; i++)
        {
            Assert.Equal(expectedTriggers[i], parameters.Triggers[i]);
        }
        Assert.Equal(expectedActive, parameters.Active);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedOrder, parameters.Order);
        Assert.Equal(expectedRuleGroupTitle, parameters.RuleGroupTitle);
        Assert.Equal(expectedStopProcessing, parameters.StopProcessing);
        Assert.Equal(expectedStrict, parameters.Strict);
        Assert.Equal(expectedXTraceID, parameters.XTraceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Rules::RuleCreateParams
        {
            Actions =
            [
                new()
                {
                    Type = Rules::RuleActionKeyword.SetCategory,
                    Value = "Daily groceries",
                    Active = true,
                    Order = 5,
                    StopProcessing = false,
                },
            ],
            RuleGroupID = "81",
            Title = "First rule title.",
            Trigger = Rules::RuleTriggerType.StoreJournal,
            Triggers =
            [
                new()
                {
                    Type = Rules::RuleTriggerKeyword.FromAccountStarts,
                    Value = "tag1",
                    Active = true,
                    Order = 5,
                    Prohibited = false,
                    StopProcessing = false,
                },
            ],
        };

        Assert.Null(parameters.Active);
        Assert.False(parameters.RawBodyData.ContainsKey("active"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Order);
        Assert.False(parameters.RawBodyData.ContainsKey("order"));
        Assert.Null(parameters.RuleGroupTitle);
        Assert.False(parameters.RawBodyData.ContainsKey("rule_group_title"));
        Assert.Null(parameters.StopProcessing);
        Assert.False(parameters.RawBodyData.ContainsKey("stop_processing"));
        Assert.Null(parameters.Strict);
        Assert.False(parameters.RawBodyData.ContainsKey("strict"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new Rules::RuleCreateParams
        {
            Actions =
            [
                new()
                {
                    Type = Rules::RuleActionKeyword.SetCategory,
                    Value = "Daily groceries",
                    Active = true,
                    Order = 5,
                    StopProcessing = false,
                },
            ],
            RuleGroupID = "81",
            Title = "First rule title.",
            Trigger = Rules::RuleTriggerType.StoreJournal,
            Triggers =
            [
                new()
                {
                    Type = Rules::RuleTriggerKeyword.FromAccountStarts,
                    Value = "tag1",
                    Active = true,
                    Order = 5,
                    Prohibited = false,
                    StopProcessing = false,
                },
            ],

            // Null should be interpreted as omitted for these properties
            Active = null,
            Description = null,
            Order = null,
            RuleGroupTitle = null,
            StopProcessing = null,
            Strict = null,
            XTraceID = null,
        };

        Assert.Null(parameters.Active);
        Assert.False(parameters.RawBodyData.ContainsKey("active"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Order);
        Assert.False(parameters.RawBodyData.ContainsKey("order"));
        Assert.Null(parameters.RuleGroupTitle);
        Assert.False(parameters.RawBodyData.ContainsKey("rule_group_title"));
        Assert.Null(parameters.StopProcessing);
        Assert.False(parameters.RawBodyData.ContainsKey("stop_processing"));
        Assert.Null(parameters.Strict);
        Assert.False(parameters.RawBodyData.ContainsKey("strict"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void Url_Works()
    {
        Rules::RuleCreateParams parameters = new()
        {
            Actions =
            [
                new()
                {
                    Type = Rules::RuleActionKeyword.SetCategory,
                    Value = "Daily groceries",
                    Active = true,
                    Order = 5,
                    StopProcessing = false,
                },
            ],
            RuleGroupID = "81",
            Title = "First rule title.",
            Trigger = Rules::RuleTriggerType.StoreJournal,
            Triggers =
            [
                new()
                {
                    Type = Rules::RuleTriggerKeyword.FromAccountStarts,
                    Value = "tag1",
                    Active = true,
                    Order = 5,
                    Prohibited = false,
                    StopProcessing = false,
                },
            ],
        };

        var url = parameters.Url(new() { });

        Assert.True(TestBase.UrisEqual(new Uri("https://demo.firefly-iii.org/api/v1/rules"), url));
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        Rules::RuleCreateParams parameters = new()
        {
            Actions =
            [
                new()
                {
                    Type = Rules::RuleActionKeyword.SetCategory,
                    Value = "Daily groceries",
                    Active = true,
                    Order = 5,
                    StopProcessing = false,
                },
            ],
            RuleGroupID = "81",
            Title = "First rule title.",
            Trigger = Rules::RuleTriggerType.StoreJournal,
            Triggers =
            [
                new()
                {
                    Type = Rules::RuleTriggerKeyword.FromAccountStarts,
                    Value = "tag1",
                    Active = true,
                    Order = 5,
                    Prohibited = false,
                    StopProcessing = false,
                },
            ],
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
        var parameters = new Rules::RuleCreateParams
        {
            Actions =
            [
                new()
                {
                    Type = Rules::RuleActionKeyword.SetCategory,
                    Value = "Daily groceries",
                    Active = true,
                    Order = 5,
                    StopProcessing = false,
                },
            ],
            RuleGroupID = "81",
            Title = "First rule title.",
            Trigger = Rules::RuleTriggerType.StoreJournal,
            Triggers =
            [
                new()
                {
                    Type = Rules::RuleTriggerKeyword.FromAccountStarts,
                    Value = "tag1",
                    Active = true,
                    Order = 5,
                    Prohibited = false,
                    StopProcessing = false,
                },
            ],
            Active = true,
            Description = "First rule description",
            Order = 5,
            RuleGroupTitle = "New rule group",
            StopProcessing = false,
            Strict = true,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        Rules::RuleCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ActionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Rules::Action
        {
            Type = Rules::RuleActionKeyword.SetCategory,
            Value = "Daily groceries",
            Active = true,
            Order = 5,
            StopProcessing = false,
        };

        ApiEnum<string, Rules::RuleActionKeyword> expectedType =
            Rules::RuleActionKeyword.SetCategory;
        string expectedValue = "Daily groceries";
        bool expectedActive = true;
        int expectedOrder = 5;
        bool expectedStopProcessing = false;

        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedValue, model.Value);
        Assert.Equal(expectedActive, model.Active);
        Assert.Equal(expectedOrder, model.Order);
        Assert.Equal(expectedStopProcessing, model.StopProcessing);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Rules::Action
        {
            Type = Rules::RuleActionKeyword.SetCategory,
            Value = "Daily groceries",
            Active = true,
            Order = 5,
            StopProcessing = false,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Rules::Action>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Rules::Action
        {
            Type = Rules::RuleActionKeyword.SetCategory,
            Value = "Daily groceries",
            Active = true,
            Order = 5,
            StopProcessing = false,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Rules::Action>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Rules::RuleActionKeyword> expectedType =
            Rules::RuleActionKeyword.SetCategory;
        string expectedValue = "Daily groceries";
        bool expectedActive = true;
        int expectedOrder = 5;
        bool expectedStopProcessing = false;

        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedValue, deserialized.Value);
        Assert.Equal(expectedActive, deserialized.Active);
        Assert.Equal(expectedOrder, deserialized.Order);
        Assert.Equal(expectedStopProcessing, deserialized.StopProcessing);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Rules::Action
        {
            Type = Rules::RuleActionKeyword.SetCategory,
            Value = "Daily groceries",
            Active = true,
            Order = 5,
            StopProcessing = false,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Rules::Action
        {
            Type = Rules::RuleActionKeyword.SetCategory,
            Value = "Daily groceries",
        };

        Assert.Null(model.Active);
        Assert.False(model.RawData.ContainsKey("active"));
        Assert.Null(model.Order);
        Assert.False(model.RawData.ContainsKey("order"));
        Assert.Null(model.StopProcessing);
        Assert.False(model.RawData.ContainsKey("stop_processing"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Rules::Action
        {
            Type = Rules::RuleActionKeyword.SetCategory,
            Value = "Daily groceries",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Rules::Action
        {
            Type = Rules::RuleActionKeyword.SetCategory,
            Value = "Daily groceries",

            // Null should be interpreted as omitted for these properties
            Active = null,
            Order = null,
            StopProcessing = null,
        };

        Assert.Null(model.Active);
        Assert.False(model.RawData.ContainsKey("active"));
        Assert.Null(model.Order);
        Assert.False(model.RawData.ContainsKey("order"));
        Assert.Null(model.StopProcessing);
        Assert.False(model.RawData.ContainsKey("stop_processing"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Rules::Action
        {
            Type = Rules::RuleActionKeyword.SetCategory,
            Value = "Daily groceries",

            // Null should be interpreted as omitted for these properties
            Active = null,
            Order = null,
            StopProcessing = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Rules::Action
        {
            Type = Rules::RuleActionKeyword.SetCategory,
            Value = "Daily groceries",
            Active = true,
            Order = 5,
            StopProcessing = false,
        };

        Rules::Action copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TriggerTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Rules::Trigger
        {
            Type = Rules::RuleTriggerKeyword.FromAccountStarts,
            Value = "tag1",
            Active = true,
            Order = 5,
            Prohibited = false,
            StopProcessing = false,
        };

        ApiEnum<string, Rules::RuleTriggerKeyword> expectedType =
            Rules::RuleTriggerKeyword.FromAccountStarts;
        string expectedValue = "tag1";
        bool expectedActive = true;
        int expectedOrder = 5;
        bool expectedProhibited = false;
        bool expectedStopProcessing = false;

        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedValue, model.Value);
        Assert.Equal(expectedActive, model.Active);
        Assert.Equal(expectedOrder, model.Order);
        Assert.Equal(expectedProhibited, model.Prohibited);
        Assert.Equal(expectedStopProcessing, model.StopProcessing);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Rules::Trigger
        {
            Type = Rules::RuleTriggerKeyword.FromAccountStarts,
            Value = "tag1",
            Active = true,
            Order = 5,
            Prohibited = false,
            StopProcessing = false,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Rules::Trigger>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Rules::Trigger
        {
            Type = Rules::RuleTriggerKeyword.FromAccountStarts,
            Value = "tag1",
            Active = true,
            Order = 5,
            Prohibited = false,
            StopProcessing = false,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Rules::Trigger>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Rules::RuleTriggerKeyword> expectedType =
            Rules::RuleTriggerKeyword.FromAccountStarts;
        string expectedValue = "tag1";
        bool expectedActive = true;
        int expectedOrder = 5;
        bool expectedProhibited = false;
        bool expectedStopProcessing = false;

        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedValue, deserialized.Value);
        Assert.Equal(expectedActive, deserialized.Active);
        Assert.Equal(expectedOrder, deserialized.Order);
        Assert.Equal(expectedProhibited, deserialized.Prohibited);
        Assert.Equal(expectedStopProcessing, deserialized.StopProcessing);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Rules::Trigger
        {
            Type = Rules::RuleTriggerKeyword.FromAccountStarts,
            Value = "tag1",
            Active = true,
            Order = 5,
            Prohibited = false,
            StopProcessing = false,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Rules::Trigger
        {
            Type = Rules::RuleTriggerKeyword.FromAccountStarts,
            Value = "tag1",
        };

        Assert.Null(model.Active);
        Assert.False(model.RawData.ContainsKey("active"));
        Assert.Null(model.Order);
        Assert.False(model.RawData.ContainsKey("order"));
        Assert.Null(model.Prohibited);
        Assert.False(model.RawData.ContainsKey("prohibited"));
        Assert.Null(model.StopProcessing);
        Assert.False(model.RawData.ContainsKey("stop_processing"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Rules::Trigger
        {
            Type = Rules::RuleTriggerKeyword.FromAccountStarts,
            Value = "tag1",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Rules::Trigger
        {
            Type = Rules::RuleTriggerKeyword.FromAccountStarts,
            Value = "tag1",

            // Null should be interpreted as omitted for these properties
            Active = null,
            Order = null,
            Prohibited = null,
            StopProcessing = null,
        };

        Assert.Null(model.Active);
        Assert.False(model.RawData.ContainsKey("active"));
        Assert.Null(model.Order);
        Assert.False(model.RawData.ContainsKey("order"));
        Assert.Null(model.Prohibited);
        Assert.False(model.RawData.ContainsKey("prohibited"));
        Assert.Null(model.StopProcessing);
        Assert.False(model.RawData.ContainsKey("stop_processing"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Rules::Trigger
        {
            Type = Rules::RuleTriggerKeyword.FromAccountStarts,
            Value = "tag1",

            // Null should be interpreted as omitted for these properties
            Active = null,
            Order = null,
            Prohibited = null,
            StopProcessing = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Rules::Trigger
        {
            Type = Rules::RuleTriggerKeyword.FromAccountStarts,
            Value = "tag1",
            Active = true,
            Order = 5,
            Prohibited = false,
            StopProcessing = false,
        };

        Rules::Trigger copied = new(model);

        Assert.Equal(model, copied);
    }
}
