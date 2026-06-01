using System;
using System.Net.Http;
using Firefly.Core;
using Firefly.Models.Budgets;

namespace Firefly.Tests.Models.Budgets;

public class BudgetCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BudgetCreateParams
        {
            Name = "Bills",
            Active = false,
            AutoBudgetAmount = "-1012.12",
            AutoBudgetCurrencyCode = "EUR",
            AutoBudgetCurrencyID = "12",
            AutoBudgetPeriod = AutoBudgetPeriod.Monthly,
            AutoBudgetType = AutoBudgetType.Reset,
            FireWebhooks = true,
            Notes = "Some notes",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        string expectedName = "Bills";
        bool expectedActive = false;
        string expectedAutoBudgetAmount = "-1012.12";
        string expectedAutoBudgetCurrencyCode = "EUR";
        string expectedAutoBudgetCurrencyID = "12";
        ApiEnum<string, AutoBudgetPeriod> expectedAutoBudgetPeriod = AutoBudgetPeriod.Monthly;
        ApiEnum<string, AutoBudgetType> expectedAutoBudgetType = AutoBudgetType.Reset;
        bool expectedFireWebhooks = true;
        string expectedNotes = "Some notes";
        string expectedXTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00";

        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedActive, parameters.Active);
        Assert.Equal(expectedAutoBudgetAmount, parameters.AutoBudgetAmount);
        Assert.Equal(expectedAutoBudgetCurrencyCode, parameters.AutoBudgetCurrencyCode);
        Assert.Equal(expectedAutoBudgetCurrencyID, parameters.AutoBudgetCurrencyID);
        Assert.Equal(expectedAutoBudgetPeriod, parameters.AutoBudgetPeriod);
        Assert.Equal(expectedAutoBudgetType, parameters.AutoBudgetType);
        Assert.Equal(expectedFireWebhooks, parameters.FireWebhooks);
        Assert.Equal(expectedNotes, parameters.Notes);
        Assert.Equal(expectedXTraceID, parameters.XTraceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new BudgetCreateParams
        {
            Name = "Bills",
            AutoBudgetAmount = "-1012.12",
            AutoBudgetCurrencyCode = "EUR",
            AutoBudgetCurrencyID = "12",
            AutoBudgetPeriod = AutoBudgetPeriod.Monthly,
            AutoBudgetType = AutoBudgetType.Reset,
            Notes = "Some notes",
        };

        Assert.Null(parameters.Active);
        Assert.False(parameters.RawBodyData.ContainsKey("active"));
        Assert.Null(parameters.FireWebhooks);
        Assert.False(parameters.RawBodyData.ContainsKey("fire_webhooks"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new BudgetCreateParams
        {
            Name = "Bills",
            AutoBudgetAmount = "-1012.12",
            AutoBudgetCurrencyCode = "EUR",
            AutoBudgetCurrencyID = "12",
            AutoBudgetPeriod = AutoBudgetPeriod.Monthly,
            AutoBudgetType = AutoBudgetType.Reset,
            Notes = "Some notes",

            // Null should be interpreted as omitted for these properties
            Active = null,
            FireWebhooks = null,
            XTraceID = null,
        };

        Assert.Null(parameters.Active);
        Assert.False(parameters.RawBodyData.ContainsKey("active"));
        Assert.Null(parameters.FireWebhooks);
        Assert.False(parameters.RawBodyData.ContainsKey("fire_webhooks"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new BudgetCreateParams
        {
            Name = "Bills",
            Active = false,
            FireWebhooks = true,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        Assert.Null(parameters.AutoBudgetAmount);
        Assert.False(parameters.RawBodyData.ContainsKey("auto_budget_amount"));
        Assert.Null(parameters.AutoBudgetCurrencyCode);
        Assert.False(parameters.RawBodyData.ContainsKey("auto_budget_currency_code"));
        Assert.Null(parameters.AutoBudgetCurrencyID);
        Assert.False(parameters.RawBodyData.ContainsKey("auto_budget_currency_id"));
        Assert.Null(parameters.AutoBudgetPeriod);
        Assert.False(parameters.RawBodyData.ContainsKey("auto_budget_period"));
        Assert.Null(parameters.AutoBudgetType);
        Assert.False(parameters.RawBodyData.ContainsKey("auto_budget_type"));
        Assert.Null(parameters.Notes);
        Assert.False(parameters.RawBodyData.ContainsKey("notes"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new BudgetCreateParams
        {
            Name = "Bills",
            Active = false,
            FireWebhooks = true,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",

            AutoBudgetAmount = null,
            AutoBudgetCurrencyCode = null,
            AutoBudgetCurrencyID = null,
            AutoBudgetPeriod = null,
            AutoBudgetType = null,
            Notes = null,
        };

        Assert.Null(parameters.AutoBudgetAmount);
        Assert.True(parameters.RawBodyData.ContainsKey("auto_budget_amount"));
        Assert.Null(parameters.AutoBudgetCurrencyCode);
        Assert.True(parameters.RawBodyData.ContainsKey("auto_budget_currency_code"));
        Assert.Null(parameters.AutoBudgetCurrencyID);
        Assert.True(parameters.RawBodyData.ContainsKey("auto_budget_currency_id"));
        Assert.Null(parameters.AutoBudgetPeriod);
        Assert.True(parameters.RawBodyData.ContainsKey("auto_budget_period"));
        Assert.Null(parameters.AutoBudgetType);
        Assert.True(parameters.RawBodyData.ContainsKey("auto_budget_type"));
        Assert.Null(parameters.Notes);
        Assert.True(parameters.RawBodyData.ContainsKey("notes"));
    }

    [Fact]
    public void Url_Works()
    {
        BudgetCreateParams parameters = new() { Name = "Bills" };

        var url = parameters.Url(new() { });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://demo.firefly-iii.org/api/v1/budgets"), url)
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        BudgetCreateParams parameters = new()
        {
            Name = "Bills",
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
        var parameters = new BudgetCreateParams
        {
            Name = "Bills",
            Active = false,
            AutoBudgetAmount = "-1012.12",
            AutoBudgetCurrencyCode = "EUR",
            AutoBudgetCurrencyID = "12",
            AutoBudgetPeriod = AutoBudgetPeriod.Monthly,
            AutoBudgetType = AutoBudgetType.Reset,
            FireWebhooks = true,
            Notes = "Some notes",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        BudgetCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
