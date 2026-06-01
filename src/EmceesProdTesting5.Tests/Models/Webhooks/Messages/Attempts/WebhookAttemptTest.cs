using System;
using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Webhooks.Messages.Attempts;

namespace EmceesProdTesting5.Tests.Models.Webhooks.Messages.Attempts;

public class WebhookAttemptTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebhookAttempt
        {
            ID = "2",
            Attributes = new()
            {
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                Logs = "Page not found",
                Response = "Page not found",
                StatusCode = 404,
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                WebhookMessageID = "5",
            },
            Type = "webhook_attempts",
        };

        string expectedID = "2";
        Attributes expectedAttributes = new()
        {
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Logs = "Page not found",
            Response = "Page not found",
            StatusCode = 404,
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            WebhookMessageID = "5",
        };
        string expectedType = "webhook_attempts";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAttributes, model.Attributes);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WebhookAttempt
        {
            ID = "2",
            Attributes = new()
            {
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                Logs = "Page not found",
                Response = "Page not found",
                StatusCode = 404,
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                WebhookMessageID = "5",
            },
            Type = "webhook_attempts",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookAttempt>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebhookAttempt
        {
            ID = "2",
            Attributes = new()
            {
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                Logs = "Page not found",
                Response = "Page not found",
                StatusCode = 404,
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                WebhookMessageID = "5",
            },
            Type = "webhook_attempts",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookAttempt>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "2";
        Attributes expectedAttributes = new()
        {
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Logs = "Page not found",
            Response = "Page not found",
            StatusCode = 404,
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            WebhookMessageID = "5",
        };
        string expectedType = "webhook_attempts";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAttributes, deserialized.Attributes);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WebhookAttempt
        {
            ID = "2",
            Attributes = new()
            {
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                Logs = "Page not found",
                Response = "Page not found",
                StatusCode = 404,
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                WebhookMessageID = "5",
            },
            Type = "webhook_attempts",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WebhookAttempt
        {
            ID = "2",
            Attributes = new()
            {
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                Logs = "Page not found",
                Response = "Page not found",
                StatusCode = 404,
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                WebhookMessageID = "5",
            },
            Type = "webhook_attempts",
        };

        WebhookAttempt copied = new(model);

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
            Logs = "Page not found",
            Response = "Page not found",
            StatusCode = 404,
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            WebhookMessageID = "5",
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        string expectedLogs = "Page not found";
        string expectedResponse = "Page not found";
        int expectedStatusCode = 404;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        string expectedWebhookMessageID = "5";

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedLogs, model.Logs);
        Assert.Equal(expectedResponse, model.Response);
        Assert.Equal(expectedStatusCode, model.StatusCode);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedWebhookMessageID, model.WebhookMessageID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Attributes
        {
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Logs = "Page not found",
            Response = "Page not found",
            StatusCode = 404,
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            WebhookMessageID = "5",
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
            Logs = "Page not found",
            Response = "Page not found",
            StatusCode = 404,
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            WebhookMessageID = "5",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Attributes>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        string expectedLogs = "Page not found";
        string expectedResponse = "Page not found";
        int expectedStatusCode = 404;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        string expectedWebhookMessageID = "5";

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedLogs, deserialized.Logs);
        Assert.Equal(expectedResponse, deserialized.Response);
        Assert.Equal(expectedStatusCode, deserialized.StatusCode);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedWebhookMessageID, deserialized.WebhookMessageID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Attributes
        {
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Logs = "Page not found",
            Response = "Page not found",
            StatusCode = 404,
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            WebhookMessageID = "5",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Attributes
        {
            Logs = "Page not found",
            Response = "Page not found",
            StatusCode = 404,
        };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
        Assert.Null(model.WebhookMessageID);
        Assert.False(model.RawData.ContainsKey("webhook_message_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Attributes
        {
            Logs = "Page not found",
            Response = "Page not found",
            StatusCode = 404,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Attributes
        {
            Logs = "Page not found",
            Response = "Page not found",
            StatusCode = 404,

            // Null should be interpreted as omitted for these properties
            CreatedAt = null,
            UpdatedAt = null,
            WebhookMessageID = null,
        };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
        Assert.Null(model.WebhookMessageID);
        Assert.False(model.RawData.ContainsKey("webhook_message_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Attributes
        {
            Logs = "Page not found",
            Response = "Page not found",
            StatusCode = 404,

            // Null should be interpreted as omitted for these properties
            CreatedAt = null,
            UpdatedAt = null,
            WebhookMessageID = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Attributes
        {
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            WebhookMessageID = "5",
        };

        Assert.Null(model.Logs);
        Assert.False(model.RawData.ContainsKey("logs"));
        Assert.Null(model.Response);
        Assert.False(model.RawData.ContainsKey("response"));
        Assert.Null(model.StatusCode);
        Assert.False(model.RawData.ContainsKey("status_code"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Attributes
        {
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            WebhookMessageID = "5",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Attributes
        {
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            WebhookMessageID = "5",

            Logs = null,
            Response = null,
            StatusCode = null,
        };

        Assert.Null(model.Logs);
        Assert.True(model.RawData.ContainsKey("logs"));
        Assert.Null(model.Response);
        Assert.True(model.RawData.ContainsKey("response"));
        Assert.Null(model.StatusCode);
        Assert.True(model.RawData.ContainsKey("status_code"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Attributes
        {
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            WebhookMessageID = "5",

            Logs = null,
            Response = null,
            StatusCode = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Attributes
        {
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Logs = "Page not found",
            Response = "Page not found",
            StatusCode = 404,
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            WebhookMessageID = "5",
        };

        Attributes copied = new(model);

        Assert.Equal(model, copied);
    }
}
