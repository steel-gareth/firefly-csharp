using System;
using System.Collections.Generic;
using System.Net.Http;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Webhooks;

namespace EmceesProdTesting5.Tests.Models.Webhooks;

public class WebhookUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WebhookUpdateParams
        {
            ID = "123",
            Active = false,
            Deliveries = [WebhookDelivery.Json],
            Responses = [WebhookResponse.Transactions],
            Secret = "iMLZLtLx2JHWhK9Dtyuoqyir",
            Title = "Update magic mirror on new transaction",
            Triggers = [WebhookTrigger.StoreTransaction, WebhookTrigger.UpdateTransaction],
            UrlValue = "https://example.com",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        string expectedID = "123";
        bool expectedActive = false;
        List<ApiEnum<string, WebhookDelivery>> expectedDeliveries = [WebhookDelivery.Json];
        List<ApiEnum<string, WebhookResponse>> expectedResponses = [WebhookResponse.Transactions];
        string expectedSecret = "iMLZLtLx2JHWhK9Dtyuoqyir";
        string expectedTitle = "Update magic mirror on new transaction";
        List<ApiEnum<string, WebhookTrigger>> expectedTriggers =
        [
            WebhookTrigger.StoreTransaction,
            WebhookTrigger.UpdateTransaction,
        ];
        string expectedUrlValue = "https://example.com";
        string expectedXTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00";

        Assert.Equal(expectedID, parameters.ID);
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
        Assert.Equal(expectedSecret, parameters.Secret);
        Assert.Equal(expectedTitle, parameters.Title);
        Assert.NotNull(parameters.Triggers);
        Assert.Equal(expectedTriggers.Count, parameters.Triggers.Count);
        for (int i = 0; i < expectedTriggers.Count; i++)
        {
            Assert.Equal(expectedTriggers[i], parameters.Triggers[i]);
        }
        Assert.Equal(expectedUrlValue, parameters.UrlValue);
        Assert.Equal(expectedXTraceID, parameters.XTraceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new WebhookUpdateParams { ID = "123" };

        Assert.Null(parameters.Active);
        Assert.False(parameters.RawBodyData.ContainsKey("active"));
        Assert.Null(parameters.Deliveries);
        Assert.False(parameters.RawBodyData.ContainsKey("deliveries"));
        Assert.Null(parameters.Responses);
        Assert.False(parameters.RawBodyData.ContainsKey("responses"));
        Assert.Null(parameters.Secret);
        Assert.False(parameters.RawBodyData.ContainsKey("secret"));
        Assert.Null(parameters.Title);
        Assert.False(parameters.RawBodyData.ContainsKey("title"));
        Assert.Null(parameters.Triggers);
        Assert.False(parameters.RawBodyData.ContainsKey("triggers"));
        Assert.Null(parameters.UrlValue);
        Assert.False(parameters.RawBodyData.ContainsKey("url"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new WebhookUpdateParams
        {
            ID = "123",

            // Null should be interpreted as omitted for these properties
            Active = null,
            Deliveries = null,
            Responses = null,
            Secret = null,
            Title = null,
            Triggers = null,
            UrlValue = null,
            XTraceID = null,
        };

        Assert.Null(parameters.Active);
        Assert.False(parameters.RawBodyData.ContainsKey("active"));
        Assert.Null(parameters.Deliveries);
        Assert.False(parameters.RawBodyData.ContainsKey("deliveries"));
        Assert.Null(parameters.Responses);
        Assert.False(parameters.RawBodyData.ContainsKey("responses"));
        Assert.Null(parameters.Secret);
        Assert.False(parameters.RawBodyData.ContainsKey("secret"));
        Assert.Null(parameters.Title);
        Assert.False(parameters.RawBodyData.ContainsKey("title"));
        Assert.Null(parameters.Triggers);
        Assert.False(parameters.RawBodyData.ContainsKey("triggers"));
        Assert.Null(parameters.UrlValue);
        Assert.False(parameters.RawBodyData.ContainsKey("url"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void Url_Works()
    {
        WebhookUpdateParams parameters = new() { ID = "123" };

        var url = parameters.Url(new() { });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://demo.firefly-iii.org/api/v1/webhooks/123"), url)
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        WebhookUpdateParams parameters = new()
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
        var parameters = new WebhookUpdateParams
        {
            ID = "123",
            Active = false,
            Deliveries = [WebhookDelivery.Json],
            Responses = [WebhookResponse.Transactions],
            Secret = "iMLZLtLx2JHWhK9Dtyuoqyir",
            Title = "Update magic mirror on new transaction",
            Triggers = [WebhookTrigger.StoreTransaction, WebhookTrigger.UpdateTransaction],
            UrlValue = "https://example.com",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        WebhookUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
