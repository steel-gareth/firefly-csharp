using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Webhooks;

namespace EmceesProdTesting5.Tests.Models.Webhooks;

public class WebhookCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WebhookCreateParams
        {
            Delivery = JsonSerializer.Deserialize<JsonElement>("{}"),
            Response = JsonSerializer.Deserialize<JsonElement>("{}"),
            Title = "Update magic mirror on new transaction",
            Trigger = JsonSerializer.Deserialize<JsonElement>("{}"),
            UrlValue = "https://example.com",
            Active = false,
            Deliveries = [WebhookDelivery.Json],
            Responses = [WebhookResponse.Transactions],
            Triggers = [WebhookTrigger.StoreTransaction, WebhookTrigger.UpdateTransaction],
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        JsonElement expectedDelivery = JsonSerializer.Deserialize<JsonElement>("{}");
        JsonElement expectedResponse = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedTitle = "Update magic mirror on new transaction";
        JsonElement expectedTrigger = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedUrlValue = "https://example.com";
        bool expectedActive = false;
        List<ApiEnum<string, WebhookDelivery>> expectedDeliveries = [WebhookDelivery.Json];
        List<ApiEnum<string, WebhookResponse>> expectedResponses = [WebhookResponse.Transactions];
        List<ApiEnum<string, WebhookTrigger>> expectedTriggers =
        [
            WebhookTrigger.StoreTransaction,
            WebhookTrigger.UpdateTransaction,
        ];
        string expectedXTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00";

        Assert.True(JsonElement.DeepEquals(expectedDelivery, parameters.Delivery));
        Assert.True(JsonElement.DeepEquals(expectedResponse, parameters.Response));
        Assert.Equal(expectedTitle, parameters.Title);
        Assert.True(JsonElement.DeepEquals(expectedTrigger, parameters.Trigger));
        Assert.Equal(expectedUrlValue, parameters.UrlValue);
        Assert.Equal(expectedActive, parameters.Active);
        Assert.NotNull(parameters.Deliveries);
        Assert.Equal(expectedDeliveries.Count, parameters.Deliveries.Count);
        for (int i = 0; i < expectedDeliveries.Count; i++)
        {
            Assert.Equal(expectedDeliveries[i], parameters.Deliveries[i]);
        }
        Assert.NotNull(parameters.Responses);
        Assert.Equal(expectedResponses.Count, parameters.Responses.Count);
        for (int i = 0; i < expectedResponses.Count; i++)
        {
            Assert.Equal(expectedResponses[i], parameters.Responses[i]);
        }
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
        var parameters = new WebhookCreateParams
        {
            Delivery = JsonSerializer.Deserialize<JsonElement>("{}"),
            Response = JsonSerializer.Deserialize<JsonElement>("{}"),
            Title = "Update magic mirror on new transaction",
            Trigger = JsonSerializer.Deserialize<JsonElement>("{}"),
            UrlValue = "https://example.com",
        };

        Assert.Null(parameters.Active);
        Assert.False(parameters.RawBodyData.ContainsKey("active"));
        Assert.Null(parameters.Deliveries);
        Assert.False(parameters.RawBodyData.ContainsKey("deliveries"));
        Assert.Null(parameters.Responses);
        Assert.False(parameters.RawBodyData.ContainsKey("responses"));
        Assert.Null(parameters.Triggers);
        Assert.False(parameters.RawBodyData.ContainsKey("triggers"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new WebhookCreateParams
        {
            Delivery = JsonSerializer.Deserialize<JsonElement>("{}"),
            Response = JsonSerializer.Deserialize<JsonElement>("{}"),
            Title = "Update magic mirror on new transaction",
            Trigger = JsonSerializer.Deserialize<JsonElement>("{}"),
            UrlValue = "https://example.com",

            // Null should be interpreted as omitted for these properties
            Active = null,
            Deliveries = null,
            Responses = null,
            Triggers = null,
            XTraceID = null,
        };

        Assert.Null(parameters.Active);
        Assert.False(parameters.RawBodyData.ContainsKey("active"));
        Assert.Null(parameters.Deliveries);
        Assert.False(parameters.RawBodyData.ContainsKey("deliveries"));
        Assert.Null(parameters.Responses);
        Assert.False(parameters.RawBodyData.ContainsKey("responses"));
        Assert.Null(parameters.Triggers);
        Assert.False(parameters.RawBodyData.ContainsKey("triggers"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void Url_Works()
    {
        WebhookCreateParams parameters = new()
        {
            Delivery = JsonSerializer.Deserialize<JsonElement>("{}"),
            Response = JsonSerializer.Deserialize<JsonElement>("{}"),
            Title = "Update magic mirror on new transaction",
            Trigger = JsonSerializer.Deserialize<JsonElement>("{}"),
            UrlValue = "https://example.com",
        };

        var url = parameters.Url(new() { });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://demo.firefly-iii.org/api/v1/webhooks"), url)
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        WebhookCreateParams parameters = new()
        {
            Delivery = JsonSerializer.Deserialize<JsonElement>("{}"),
            Response = JsonSerializer.Deserialize<JsonElement>("{}"),
            Title = "Update magic mirror on new transaction",
            Trigger = JsonSerializer.Deserialize<JsonElement>("{}"),
            UrlValue = "https://example.com",
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
        var parameters = new WebhookCreateParams
        {
            Delivery = JsonSerializer.Deserialize<JsonElement>("{}"),
            Response = JsonSerializer.Deserialize<JsonElement>("{}"),
            Title = "Update magic mirror on new transaction",
            Trigger = JsonSerializer.Deserialize<JsonElement>("{}"),
            UrlValue = "https://example.com",
            Active = false,
            Deliveries = [WebhookDelivery.Json],
            Responses = [WebhookResponse.Transactions],
            Triggers = [WebhookTrigger.StoreTransaction, WebhookTrigger.UpdateTransaction],
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        WebhookCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
