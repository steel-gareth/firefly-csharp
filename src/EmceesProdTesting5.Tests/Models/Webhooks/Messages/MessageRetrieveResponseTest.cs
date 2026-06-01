using System;
using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Webhooks.Messages;

namespace EmceesProdTesting5.Tests.Models.Webhooks.Messages;

public class MessageRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MessageRetrieveResponse
        {
            Data = new()
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
            },
        };

        WebhookMessage expectedData = new()
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

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MessageRetrieveResponse
        {
            Data = new()
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
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MessageRetrieveResponse
        {
            Data = new()
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
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        WebhookMessage expectedData = new()
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

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MessageRetrieveResponse
        {
            Data = new()
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
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MessageRetrieveResponse
        {
            Data = new()
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
            },
        };

        MessageRetrieveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
