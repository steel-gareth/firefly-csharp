using System;
using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Webhooks.Messages;

namespace EmceesProdTesting5.Tests.Models.Webhooks.Messages;

public class WebhookMessageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebhookMessage
        {
            ID = "2",
            Attributes = new()
            {
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                Errored = false,
                Message = "{some:message}",
                Sent = false,
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                Uuid = "7a344c02-5b52-46b1-90e6-a437431dcf07",
                WebhookID = "5",
            },
            Type = "webhook_messages",
        };

        string expectedID = "2";
        Attributes expectedAttributes = new()
        {
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Errored = false,
            Message = "{some:message}",
            Sent = false,
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Uuid = "7a344c02-5b52-46b1-90e6-a437431dcf07",
            WebhookID = "5",
        };
        string expectedType = "webhook_messages";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAttributes, model.Attributes);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WebhookMessage
        {
            ID = "2",
            Attributes = new()
            {
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                Errored = false,
                Message = "{some:message}",
                Sent = false,
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                Uuid = "7a344c02-5b52-46b1-90e6-a437431dcf07",
                WebhookID = "5",
            },
            Type = "webhook_messages",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookMessage>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebhookMessage
        {
            ID = "2",
            Attributes = new()
            {
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                Errored = false,
                Message = "{some:message}",
                Sent = false,
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                Uuid = "7a344c02-5b52-46b1-90e6-a437431dcf07",
                WebhookID = "5",
            },
            Type = "webhook_messages",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookMessage>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "2";
        Attributes expectedAttributes = new()
        {
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Errored = false,
            Message = "{some:message}",
            Sent = false,
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Uuid = "7a344c02-5b52-46b1-90e6-a437431dcf07",
            WebhookID = "5",
        };
        string expectedType = "webhook_messages";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAttributes, deserialized.Attributes);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WebhookMessage
        {
            ID = "2",
            Attributes = new()
            {
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                Errored = false,
                Message = "{some:message}",
                Sent = false,
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                Uuid = "7a344c02-5b52-46b1-90e6-a437431dcf07",
                WebhookID = "5",
            },
            Type = "webhook_messages",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WebhookMessage
        {
            ID = "2",
            Attributes = new()
            {
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                Errored = false,
                Message = "{some:message}",
                Sent = false,
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                Uuid = "7a344c02-5b52-46b1-90e6-a437431dcf07",
                WebhookID = "5",
            },
            Type = "webhook_messages",
        };

        WebhookMessage copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AttributesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Attributes
        {
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Errored = false,
            Message = "{some:message}",
            Sent = false,
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Uuid = "7a344c02-5b52-46b1-90e6-a437431dcf07",
            WebhookID = "5",
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        bool expectedErrored = false;
        string expectedMessage = "{some:message}";
        bool expectedSent = false;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        string expectedUuid = "7a344c02-5b52-46b1-90e6-a437431dcf07";
        string expectedWebhookID = "5";

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedErrored, model.Errored);
        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedSent, model.Sent);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedUuid, model.Uuid);
        Assert.Equal(expectedWebhookID, model.WebhookID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Attributes
        {
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Errored = false,
            Message = "{some:message}",
            Sent = false,
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Uuid = "7a344c02-5b52-46b1-90e6-a437431dcf07",
            WebhookID = "5",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Attributes>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Attributes
        {
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Errored = false,
            Message = "{some:message}",
            Sent = false,
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Uuid = "7a344c02-5b52-46b1-90e6-a437431dcf07",
            WebhookID = "5",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Attributes>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        bool expectedErrored = false;
        string expectedMessage = "{some:message}";
        bool expectedSent = false;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        string expectedUuid = "7a344c02-5b52-46b1-90e6-a437431dcf07";
        string expectedWebhookID = "5";

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedErrored, deserialized.Errored);
        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedSent, deserialized.Sent);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedUuid, deserialized.Uuid);
        Assert.Equal(expectedWebhookID, deserialized.WebhookID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Attributes
        {
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Errored = false,
            Message = "{some:message}",
            Sent = false,
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Uuid = "7a344c02-5b52-46b1-90e6-a437431dcf07",
            WebhookID = "5",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Attributes { Message = "{some:message}" };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.Errored);
        Assert.False(model.RawData.ContainsKey("errored"));
        Assert.Null(model.Sent);
        Assert.False(model.RawData.ContainsKey("sent"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
        Assert.Null(model.Uuid);
        Assert.False(model.RawData.ContainsKey("uuid"));
        Assert.Null(model.WebhookID);
        Assert.False(model.RawData.ContainsKey("webhook_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Attributes { Message = "{some:message}" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Attributes
        {
            Message = "{some:message}",

            // Null should be interpreted as omitted for these properties
            CreatedAt = null,
            Errored = null,
            Sent = null,
            UpdatedAt = null,
            Uuid = null,
            WebhookID = null,
        };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.Errored);
        Assert.False(model.RawData.ContainsKey("errored"));
        Assert.Null(model.Sent);
        Assert.False(model.RawData.ContainsKey("sent"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
        Assert.Null(model.Uuid);
        Assert.False(model.RawData.ContainsKey("uuid"));
        Assert.Null(model.WebhookID);
        Assert.False(model.RawData.ContainsKey("webhook_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Attributes
        {
            Message = "{some:message}",

            // Null should be interpreted as omitted for these properties
            CreatedAt = null,
            Errored = null,
            Sent = null,
            UpdatedAt = null,
            Uuid = null,
            WebhookID = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Attributes
        {
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Errored = false,
            Sent = false,
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Uuid = "7a344c02-5b52-46b1-90e6-a437431dcf07",
            WebhookID = "5",
        };

        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Attributes
        {
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Errored = false,
            Sent = false,
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Uuid = "7a344c02-5b52-46b1-90e6-a437431dcf07",
            WebhookID = "5",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Attributes
        {
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Errored = false,
            Sent = false,
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Uuid = "7a344c02-5b52-46b1-90e6-a437431dcf07",
            WebhookID = "5",

            Message = null,
        };

        Assert.Null(model.Message);
        Assert.True(model.RawData.ContainsKey("message"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Attributes
        {
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Errored = false,
            Sent = false,
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Uuid = "7a344c02-5b52-46b1-90e6-a437431dcf07",
            WebhookID = "5",

            Message = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Attributes
        {
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Errored = false,
            Message = "{some:message}",
            Sent = false,
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Uuid = "7a344c02-5b52-46b1-90e6-a437431dcf07",
            WebhookID = "5",
        };

        Attributes copied = new(model);

        Assert.Equal(model, copied);
    }
}
