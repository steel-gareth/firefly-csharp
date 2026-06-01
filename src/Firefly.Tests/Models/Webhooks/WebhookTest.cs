using System;
using System.Collections.Generic;
using System.Text.Json;
using Firefly.Core;
using Firefly.Models.Webhooks;
using Attachments = Firefly.Models.Attachments;

namespace Firefly.Tests.Models.Webhooks;

public class WebhookTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Webhook
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

        string expectedID = "2";
        Attributes expectedAttributes = new()
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
        };
        Attachments::ObjectLink expectedLinks = new()
        {
            O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
            Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
        };
        string expectedType = "webhooks";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAttributes, model.Attributes);
        Assert.Equal(expectedLinks, model.Links);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Webhook
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Webhook>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Webhook
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Webhook>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "2";
        Attributes expectedAttributes = new()
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
        };
        Attachments::ObjectLink expectedLinks = new()
        {
            O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
            Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
        };
        string expectedType = "webhooks";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAttributes, deserialized.Attributes);
        Assert.Equal(expectedLinks, deserialized.Links);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Webhook
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

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Webhook
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

        Webhook copied = new(model);

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
        };

        JsonElement expectedDelivery = JsonSerializer.Deserialize<JsonElement>("{}");
        JsonElement expectedResponse = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedTitle = "Update magic mirror on new transaction";
        JsonElement expectedTrigger = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedUrl = "https://example.com";
        bool expectedActive = false;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        List<ApiEnum<string, WebhookDelivery>> expectedDeliveries = [WebhookDelivery.Json];
        List<ApiEnum<string, WebhookResponse>> expectedResponses = [WebhookResponse.Transactions];
        string expectedSecret = "iMLZLtLx2JHWhK9Dtyuoqyir";
        List<ApiEnum<string, WebhookTrigger>> expectedTriggers =
        [
            WebhookTrigger.StoreTransaction,
            WebhookTrigger.UpdateTransaction,
        ];
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");

        Assert.True(JsonElement.DeepEquals(expectedDelivery, model.Delivery));
        Assert.True(JsonElement.DeepEquals(expectedResponse, model.Response));
        Assert.Equal(expectedTitle, model.Title);
        Assert.True(JsonElement.DeepEquals(expectedTrigger, model.Trigger));
        Assert.Equal(expectedUrl, model.Url);
        Assert.Equal(expectedActive, model.Active);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.NotNull(model.Deliveries);
        Assert.Equal(expectedDeliveries.Count, model.Deliveries.Count);
        for (int i = 0; i < expectedDeliveries.Count; i++)
        {
            Assert.Equal(expectedDeliveries[i], model.Deliveries[i]);
        }
        Assert.NotNull(model.Responses);
        Assert.Equal(expectedResponses.Count, model.Responses.Count);
        for (int i = 0; i < expectedResponses.Count; i++)
        {
            Assert.Equal(expectedResponses[i], model.Responses[i]);
        }
        Assert.Equal(expectedSecret, model.Secret);
        Assert.NotNull(model.Triggers);
        Assert.Equal(expectedTriggers.Count, model.Triggers.Count);
        for (int i = 0; i < expectedTriggers.Count; i++)
        {
            Assert.Equal(expectedTriggers[i], model.Triggers[i]);
        }
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Attributes
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Attributes>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedDelivery = JsonSerializer.Deserialize<JsonElement>("{}");
        JsonElement expectedResponse = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedTitle = "Update magic mirror on new transaction";
        JsonElement expectedTrigger = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedUrl = "https://example.com";
        bool expectedActive = false;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        List<ApiEnum<string, WebhookDelivery>> expectedDeliveries = [WebhookDelivery.Json];
        List<ApiEnum<string, WebhookResponse>> expectedResponses = [WebhookResponse.Transactions];
        string expectedSecret = "iMLZLtLx2JHWhK9Dtyuoqyir";
        List<ApiEnum<string, WebhookTrigger>> expectedTriggers =
        [
            WebhookTrigger.StoreTransaction,
            WebhookTrigger.UpdateTransaction,
        ];
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");

        Assert.True(JsonElement.DeepEquals(expectedDelivery, deserialized.Delivery));
        Assert.True(JsonElement.DeepEquals(expectedResponse, deserialized.Response));
        Assert.Equal(expectedTitle, deserialized.Title);
        Assert.True(JsonElement.DeepEquals(expectedTrigger, deserialized.Trigger));
        Assert.Equal(expectedUrl, deserialized.Url);
        Assert.Equal(expectedActive, deserialized.Active);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.NotNull(deserialized.Deliveries);
        Assert.Equal(expectedDeliveries.Count, deserialized.Deliveries.Count);
        for (int i = 0; i < expectedDeliveries.Count; i++)
        {
            Assert.Equal(expectedDeliveries[i], deserialized.Deliveries[i]);
        }
        Assert.NotNull(deserialized.Responses);
        Assert.Equal(expectedResponses.Count, deserialized.Responses.Count);
        for (int i = 0; i < expectedResponses.Count; i++)
        {
            Assert.Equal(expectedResponses[i], deserialized.Responses[i]);
        }
        Assert.Equal(expectedSecret, deserialized.Secret);
        Assert.NotNull(deserialized.Triggers);
        Assert.Equal(expectedTriggers.Count, deserialized.Triggers.Count);
        for (int i = 0; i < expectedTriggers.Count; i++)
        {
            Assert.Equal(expectedTriggers[i], deserialized.Triggers[i]);
        }
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Attributes
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Attributes
        {
            Delivery = JsonSerializer.Deserialize<JsonElement>("{}"),
            Response = JsonSerializer.Deserialize<JsonElement>("{}"),
            Title = "Update magic mirror on new transaction",
            Trigger = JsonSerializer.Deserialize<JsonElement>("{}"),
            Url = "https://example.com",
        };

        Assert.Null(model.Active);
        Assert.False(model.RawData.ContainsKey("active"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.Deliveries);
        Assert.False(model.RawData.ContainsKey("deliveries"));
        Assert.Null(model.Responses);
        Assert.False(model.RawData.ContainsKey("responses"));
        Assert.Null(model.Secret);
        Assert.False(model.RawData.ContainsKey("secret"));
        Assert.Null(model.Triggers);
        Assert.False(model.RawData.ContainsKey("triggers"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Attributes
        {
            Delivery = JsonSerializer.Deserialize<JsonElement>("{}"),
            Response = JsonSerializer.Deserialize<JsonElement>("{}"),
            Title = "Update magic mirror on new transaction",
            Trigger = JsonSerializer.Deserialize<JsonElement>("{}"),
            Url = "https://example.com",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Attributes
        {
            Delivery = JsonSerializer.Deserialize<JsonElement>("{}"),
            Response = JsonSerializer.Deserialize<JsonElement>("{}"),
            Title = "Update magic mirror on new transaction",
            Trigger = JsonSerializer.Deserialize<JsonElement>("{}"),
            Url = "https://example.com",

            // Null should be interpreted as omitted for these properties
            Active = null,
            CreatedAt = null,
            Deliveries = null,
            Responses = null,
            Secret = null,
            Triggers = null,
            UpdatedAt = null,
        };

        Assert.Null(model.Active);
        Assert.False(model.RawData.ContainsKey("active"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.Deliveries);
        Assert.False(model.RawData.ContainsKey("deliveries"));
        Assert.Null(model.Responses);
        Assert.False(model.RawData.ContainsKey("responses"));
        Assert.Null(model.Secret);
        Assert.False(model.RawData.ContainsKey("secret"));
        Assert.Null(model.Triggers);
        Assert.False(model.RawData.ContainsKey("triggers"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Attributes
        {
            Delivery = JsonSerializer.Deserialize<JsonElement>("{}"),
            Response = JsonSerializer.Deserialize<JsonElement>("{}"),
            Title = "Update magic mirror on new transaction",
            Trigger = JsonSerializer.Deserialize<JsonElement>("{}"),
            Url = "https://example.com",

            // Null should be interpreted as omitted for these properties
            Active = null,
            CreatedAt = null,
            Deliveries = null,
            Responses = null,
            Secret = null,
            Triggers = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Attributes
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
        };

        Attributes copied = new(model);

        Assert.Equal(model, copied);
    }
}
