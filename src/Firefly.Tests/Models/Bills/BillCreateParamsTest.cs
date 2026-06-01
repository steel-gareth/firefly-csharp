using System;
using System.Net.Http;
using Firefly.Core;
using Firefly.Models.Bills;

namespace Firefly.Tests.Models.Bills;

public class BillCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BillCreateParams
        {
            AmountMax = "123.45",
            AmountMin = "123.45",
            Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Name = "Rent",
            RepeatFreq = BillRepeatFrequency.Monthly,
            Active = true,
            CurrencyCode = "EUR",
            CurrencyID = "5",
            EndDate = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
            ExtensionDate = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
            Notes = "Some example notes",
            ObjectGroupID = "5",
            ObjectGroupTitle = "Example Group",
            Skip = 0,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        string expectedAmountMax = "123.45";
        string expectedAmountMin = "123.45";
        DateTimeOffset expectedDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        string expectedName = "Rent";
        ApiEnum<string, BillRepeatFrequency> expectedRepeatFreq = BillRepeatFrequency.Monthly;
        bool expectedActive = true;
        string expectedCurrencyCode = "EUR";
        string expectedCurrencyID = "5";
        DateTimeOffset expectedEndDate = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00");
        DateTimeOffset expectedExtensionDate = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00");
        string expectedNotes = "Some example notes";
        string expectedObjectGroupID = "5";
        string expectedObjectGroupTitle = "Example Group";
        int expectedSkip = 0;
        string expectedXTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00";

        Assert.Equal(expectedAmountMax, parameters.AmountMax);
        Assert.Equal(expectedAmountMin, parameters.AmountMin);
        Assert.Equal(expectedDate, parameters.Date);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedRepeatFreq, parameters.RepeatFreq);
        Assert.Equal(expectedActive, parameters.Active);
        Assert.Equal(expectedCurrencyCode, parameters.CurrencyCode);
        Assert.Equal(expectedCurrencyID, parameters.CurrencyID);
        Assert.Equal(expectedEndDate, parameters.EndDate);
        Assert.Equal(expectedExtensionDate, parameters.ExtensionDate);
        Assert.Equal(expectedNotes, parameters.Notes);
        Assert.Equal(expectedObjectGroupID, parameters.ObjectGroupID);
        Assert.Equal(expectedObjectGroupTitle, parameters.ObjectGroupTitle);
        Assert.Equal(expectedSkip, parameters.Skip);
        Assert.Equal(expectedXTraceID, parameters.XTraceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new BillCreateParams
        {
            AmountMax = "123.45",
            AmountMin = "123.45",
            Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Name = "Rent",
            RepeatFreq = BillRepeatFrequency.Monthly,
            Notes = "Some example notes",
            ObjectGroupID = "5",
            ObjectGroupTitle = "Example Group",
        };

        Assert.Null(parameters.Active);
        Assert.False(parameters.RawBodyData.ContainsKey("active"));
        Assert.Null(parameters.CurrencyCode);
        Assert.False(parameters.RawBodyData.ContainsKey("currency_code"));
        Assert.Null(parameters.CurrencyID);
        Assert.False(parameters.RawBodyData.ContainsKey("currency_id"));
        Assert.Null(parameters.EndDate);
        Assert.False(parameters.RawBodyData.ContainsKey("end_date"));
        Assert.Null(parameters.ExtensionDate);
        Assert.False(parameters.RawBodyData.ContainsKey("extension_date"));
        Assert.Null(parameters.Skip);
        Assert.False(parameters.RawBodyData.ContainsKey("skip"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new BillCreateParams
        {
            AmountMax = "123.45",
            AmountMin = "123.45",
            Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Name = "Rent",
            RepeatFreq = BillRepeatFrequency.Monthly,
            Notes = "Some example notes",
            ObjectGroupID = "5",
            ObjectGroupTitle = "Example Group",

            // Null should be interpreted as omitted for these properties
            Active = null,
            CurrencyCode = null,
            CurrencyID = null,
            EndDate = null,
            ExtensionDate = null,
            Skip = null,
            XTraceID = null,
        };

        Assert.Null(parameters.Active);
        Assert.False(parameters.RawBodyData.ContainsKey("active"));
        Assert.Null(parameters.CurrencyCode);
        Assert.False(parameters.RawBodyData.ContainsKey("currency_code"));
        Assert.Null(parameters.CurrencyID);
        Assert.False(parameters.RawBodyData.ContainsKey("currency_id"));
        Assert.Null(parameters.EndDate);
        Assert.False(parameters.RawBodyData.ContainsKey("end_date"));
        Assert.Null(parameters.ExtensionDate);
        Assert.False(parameters.RawBodyData.ContainsKey("extension_date"));
        Assert.Null(parameters.Skip);
        Assert.False(parameters.RawBodyData.ContainsKey("skip"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new BillCreateParams
        {
            AmountMax = "123.45",
            AmountMin = "123.45",
            Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Name = "Rent",
            RepeatFreq = BillRepeatFrequency.Monthly,
            Active = true,
            CurrencyCode = "EUR",
            CurrencyID = "5",
            EndDate = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
            ExtensionDate = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
            Skip = 0,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        Assert.Null(parameters.Notes);
        Assert.False(parameters.RawBodyData.ContainsKey("notes"));
        Assert.Null(parameters.ObjectGroupID);
        Assert.False(parameters.RawBodyData.ContainsKey("object_group_id"));
        Assert.Null(parameters.ObjectGroupTitle);
        Assert.False(parameters.RawBodyData.ContainsKey("object_group_title"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new BillCreateParams
        {
            AmountMax = "123.45",
            AmountMin = "123.45",
            Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Name = "Rent",
            RepeatFreq = BillRepeatFrequency.Monthly,
            Active = true,
            CurrencyCode = "EUR",
            CurrencyID = "5",
            EndDate = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
            ExtensionDate = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
            Skip = 0,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",

            Notes = null,
            ObjectGroupID = null,
            ObjectGroupTitle = null,
        };

        Assert.Null(parameters.Notes);
        Assert.True(parameters.RawBodyData.ContainsKey("notes"));
        Assert.Null(parameters.ObjectGroupID);
        Assert.True(parameters.RawBodyData.ContainsKey("object_group_id"));
        Assert.Null(parameters.ObjectGroupTitle);
        Assert.True(parameters.RawBodyData.ContainsKey("object_group_title"));
    }

    [Fact]
    public void Url_Works()
    {
        BillCreateParams parameters = new()
        {
            AmountMax = "123.45",
            AmountMin = "123.45",
            Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Name = "Rent",
            RepeatFreq = BillRepeatFrequency.Monthly,
        };

        var url = parameters.Url(new() { });

        Assert.True(TestBase.UrisEqual(new Uri("https://demo.firefly-iii.org/api/v1/bills"), url));
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        BillCreateParams parameters = new()
        {
            AmountMax = "123.45",
            AmountMin = "123.45",
            Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Name = "Rent",
            RepeatFreq = BillRepeatFrequency.Monthly,
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
        var parameters = new BillCreateParams
        {
            AmountMax = "123.45",
            AmountMin = "123.45",
            Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Name = "Rent",
            RepeatFreq = BillRepeatFrequency.Monthly,
            Active = true,
            CurrencyCode = "EUR",
            CurrencyID = "5",
            EndDate = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
            ExtensionDate = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
            Notes = "Some example notes",
            ObjectGroupID = "5",
            ObjectGroupTitle = "Example Group",
            Skip = 0,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        BillCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
