using System;
using System.Text.Json;
using Firefly.Core;
using Firefly.Models.Webhooks;

namespace Firefly.Tests.Models.Webhooks;

public class WebhookSingleTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebhookSingle
        {
            Data = new()
            {
                ID = "2",
                Attributes = new()
                {
                    Delivery = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Response = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Title = "Update magic mirror on new transaction",
                    Trigger = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Url = "https://example.com",
                    Active = false,
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Deliveries = [WebhookDelivery.Json],
                    Responses = [WebhookResponse.Transactions],
                    Secret = "iMLZLtLx2JHWhK9Dtyuoqyir",
                    Triggers = [WebhookTrigger.StoreTransaction, WebhookTrigger.UpdateTransaction],
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
                Links = new()
                {
                    O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                    Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
                },
                Type = "webhooks",
            },
        };

        Webhook expectedData = new()
        {
            ID = "2",
            Attributes = new()
            {
                Delivery = JsonSerializer.Deserialize<JsonElement>("{}"),
                Response = JsonSerializer.Deserialize<JsonElement>("{}"),
                Title = "Update magic mirror on new transaction",
                Trigger = JsonSerializer.Deserialize<JsonElement>("{}"),
                Url = "https://example.com",
                Active = false,
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                Deliveries = [WebhookDelivery.Json],
                Responses = [WebhookResponse.Transactions],
                Secret = "iMLZLtLx2JHWhK9Dtyuoqyir",
                Triggers = [WebhookTrigger.StoreTransaction, WebhookTrigger.UpdateTransaction],
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            },
            Links = new()
            {
                O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
            },
            Type = "webhooks",
        };

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WebhookSingle
        {
            Data = new()
            {
                ID = "2",
                Attributes = new()
                {
                    Delivery = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Response = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Title = "Update magic mirror on new transaction",
                    Trigger = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Url = "https://example.com",
                    Active = false,
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Deliveries = [WebhookDelivery.Json],
                    Responses = [WebhookResponse.Transactions],
                    Secret = "iMLZLtLx2JHWhK9Dtyuoqyir",
                    Triggers = [WebhookTrigger.StoreTransaction, WebhookTrigger.UpdateTransaction],
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
                Links = new()
                {
                    O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                    Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
                },
                Type = "webhooks",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookSingle>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebhookSingle
        {
            Data = new()
            {
                ID = "2",
                Attributes = new()
                {
                    Delivery = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Response = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Title = "Update magic mirror on new transaction",
                    Trigger = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Url = "https://example.com",
                    Active = false,
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Deliveries = [WebhookDelivery.Json],
                    Responses = [WebhookResponse.Transactions],
                    Secret = "iMLZLtLx2JHWhK9Dtyuoqyir",
                    Triggers = [WebhookTrigger.StoreTransaction, WebhookTrigger.UpdateTransaction],
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
                Links = new()
                {
                    O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                    Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
                },
                Type = "webhooks",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookSingle>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Webhook expectedData = new()
        {
            ID = "2",
            Attributes = new()
            {
                Delivery = JsonSerializer.Deserialize<JsonElement>("{}"),
                Response = JsonSerializer.Deserialize<JsonElement>("{}"),
                Title = "Update magic mirror on new transaction",
                Trigger = JsonSerializer.Deserialize<JsonElement>("{}"),
                Url = "https://example.com",
                Active = false,
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                Deliveries = [WebhookDelivery.Json],
                Responses = [WebhookResponse.Transactions],
                Secret = "iMLZLtLx2JHWhK9Dtyuoqyir",
                Triggers = [WebhookTrigger.StoreTransaction, WebhookTrigger.UpdateTransaction],
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            },
            Links = new()
            {
                O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
            },
            Type = "webhooks",
        };

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WebhookSingle
        {
            Data = new()
            {
                ID = "2",
                Attributes = new()
                {
                    Delivery = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Response = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Title = "Update magic mirror on new transaction",
                    Trigger = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Url = "https://example.com",
                    Active = false,
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Deliveries = [WebhookDelivery.Json],
                    Responses = [WebhookResponse.Transactions],
                    Secret = "iMLZLtLx2JHWhK9Dtyuoqyir",
                    Triggers = [WebhookTrigger.StoreTransaction, WebhookTrigger.UpdateTransaction],
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
                Links = new()
                {
                    O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                    Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
                },
                Type = "webhooks",
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WebhookSingle
        {
            Data = new()
            {
                ID = "2",
                Attributes = new()
                {
                    Delivery = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Response = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Title = "Update magic mirror on new transaction",
                    Trigger = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Url = "https://example.com",
                    Active = false,
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Deliveries = [WebhookDelivery.Json],
                    Responses = [WebhookResponse.Transactions],
                    Secret = "iMLZLtLx2JHWhK9Dtyuoqyir",
                    Triggers = [WebhookTrigger.StoreTransaction, WebhookTrigger.UpdateTransaction],
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
                Links = new()
                {
                    O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                    Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
                },
                Type = "webhooks",
            },
        };

        WebhookSingle copied = new(model);

        Assert.Equal(model, copied);
    }
}
