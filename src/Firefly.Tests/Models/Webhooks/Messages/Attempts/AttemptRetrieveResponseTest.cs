using System;
using System.Text.Json;
using Firefly.Core;
using Firefly.Models.Webhooks.Messages.Attempts;

namespace Firefly.Tests.Models.Webhooks.Messages.Attempts;

public class AttemptRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AttemptRetrieveResponse
        {
            Data = new()
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
            },
        };

        WebhookAttempt expectedData = new()
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

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AttemptRetrieveResponse
        {
            Data = new()
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
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AttemptRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AttemptRetrieveResponse
        {
            Data = new()
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
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AttemptRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        WebhookAttempt expectedData = new()
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

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AttemptRetrieveResponse
        {
            Data = new()
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
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AttemptRetrieveResponse
        {
            Data = new()
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
            },
        };

        AttemptRetrieveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
