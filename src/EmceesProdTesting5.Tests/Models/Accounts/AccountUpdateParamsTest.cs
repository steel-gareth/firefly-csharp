using System;
using System.Net.Http;
using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Accounts;

namespace EmceesProdTesting5.Tests.Models.Accounts;

public class AccountUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AccountUpdateParams
        {
            ID = "123",
            Name = "My checking account",
            Type = JsonSerializer.Deserialize<JsonElement>("{}"),
            AccountNumber = "7009312345678",
            AccountRole = AccountRoleProperty.DefaultAsset,
            Active = false,
            Bic = "BOFAUS3N",
            CreditCardType = CreditCardTypeProperty.MonthlyFull,
            CurrencyCode = "EUR",
            CurrencyID = "12",
            Iban = "GB98MIDL07009312345678",
            IncludeNetWorth = true,
            Interest = "5.3",
            InterestPeriod = InterestPeriodProperty.Monthly,
            Latitude = 51.983333,
            LiabilityType = LiabilityTypeProperty.Loan,
            Longitude = 5.916667,
            MonthlyPaymentDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Notes = "Some example notes",
            OpeningBalance = "-1012.12",
            OpeningBalanceDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Order = 1,
            VirtualBalance = "123.45",
            ZoomLevel = 6,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        string expectedID = "123";
        string expectedName = "My checking account";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedAccountNumber = "7009312345678";
        ApiEnum<string, AccountRoleProperty> expectedAccountRole = AccountRoleProperty.DefaultAsset;
        bool expectedActive = false;
        string expectedBic = "BOFAUS3N";
        ApiEnum<string, CreditCardTypeProperty> expectedCreditCardType =
            CreditCardTypeProperty.MonthlyFull;
        string expectedCurrencyCode = "EUR";
        string expectedCurrencyID = "12";
        string expectedIban = "GB98MIDL07009312345678";
        bool expectedIncludeNetWorth = true;
        string expectedInterest = "5.3";
        ApiEnum<string, InterestPeriodProperty> expectedInterestPeriod =
            InterestPeriodProperty.Monthly;
        double expectedLatitude = 51.983333;
        ApiEnum<string, LiabilityTypeProperty> expectedLiabilityType = LiabilityTypeProperty.Loan;
        double expectedLongitude = 5.916667;
        DateTimeOffset expectedMonthlyPaymentDate = DateTimeOffset.Parse(
            "2026-04-01T00:00:00+00:00"
        );
        string expectedNotes = "Some example notes";
        string expectedOpeningBalance = "-1012.12";
        DateTimeOffset expectedOpeningBalanceDate = DateTimeOffset.Parse(
            "2026-04-01T00:00:00+00:00"
        );
        int expectedOrder = 1;
        string expectedVirtualBalance = "123.45";
        int expectedZoomLevel = 6;
        string expectedXTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedName, parameters.Name);
        Assert.True(JsonElement.DeepEquals(expectedType, parameters.Type));
        Assert.Equal(expectedAccountNumber, parameters.AccountNumber);
        Assert.Equal(expectedAccountRole, parameters.AccountRole);
        Assert.Equal(expectedActive, parameters.Active);
        Assert.Equal(expectedBic, parameters.Bic);
        Assert.Equal(expectedCreditCardType, parameters.CreditCardType);
        Assert.Equal(expectedCurrencyCode, parameters.CurrencyCode);
        Assert.Equal(expectedCurrencyID, parameters.CurrencyID);
        Assert.Equal(expectedIban, parameters.Iban);
        Assert.Equal(expectedIncludeNetWorth, parameters.IncludeNetWorth);
        Assert.Equal(expectedInterest, parameters.Interest);
        Assert.Equal(expectedInterestPeriod, parameters.InterestPeriod);
        Assert.Equal(expectedLatitude, parameters.Latitude);
        Assert.Equal(expectedLiabilityType, parameters.LiabilityType);
        Assert.Equal(expectedLongitude, parameters.Longitude);
        Assert.Equal(expectedMonthlyPaymentDate, parameters.MonthlyPaymentDate);
        Assert.Equal(expectedNotes, parameters.Notes);
        Assert.Equal(expectedOpeningBalance, parameters.OpeningBalance);
        Assert.Equal(expectedOpeningBalanceDate, parameters.OpeningBalanceDate);
        Assert.Equal(expectedOrder, parameters.Order);
        Assert.Equal(expectedVirtualBalance, parameters.VirtualBalance);
        Assert.Equal(expectedZoomLevel, parameters.ZoomLevel);
        Assert.Equal(expectedXTraceID, parameters.XTraceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AccountUpdateParams
        {
            ID = "123",
            Name = "My checking account",
            Type = JsonSerializer.Deserialize<JsonElement>("{}"),
            AccountNumber = "7009312345678",
            AccountRole = AccountRoleProperty.DefaultAsset,
            Bic = "BOFAUS3N",
            CreditCardType = CreditCardTypeProperty.MonthlyFull,
            Iban = "GB98MIDL07009312345678",
            Interest = "5.3",
            InterestPeriod = InterestPeriodProperty.Monthly,
            Latitude = 51.983333,
            LiabilityType = LiabilityTypeProperty.Loan,
            Longitude = 5.916667,
            MonthlyPaymentDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Notes = "Some example notes",
            OpeningBalanceDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            ZoomLevel = 6,
        };

        Assert.Null(parameters.Active);
        Assert.False(parameters.RawBodyData.ContainsKey("active"));
        Assert.Null(parameters.CurrencyCode);
        Assert.False(parameters.RawBodyData.ContainsKey("currency_code"));
        Assert.Null(parameters.CurrencyID);
        Assert.False(parameters.RawBodyData.ContainsKey("currency_id"));
        Assert.Null(parameters.IncludeNetWorth);
        Assert.False(parameters.RawBodyData.ContainsKey("include_net_worth"));
        Assert.Null(parameters.OpeningBalance);
        Assert.False(parameters.RawBodyData.ContainsKey("opening_balance"));
        Assert.Null(parameters.Order);
        Assert.False(parameters.RawBodyData.ContainsKey("order"));
        Assert.Null(parameters.VirtualBalance);
        Assert.False(parameters.RawBodyData.ContainsKey("virtual_balance"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new AccountUpdateParams
        {
            ID = "123",
            Name = "My checking account",
            Type = JsonSerializer.Deserialize<JsonElement>("{}"),
            AccountNumber = "7009312345678",
            AccountRole = AccountRoleProperty.DefaultAsset,
            Bic = "BOFAUS3N",
            CreditCardType = CreditCardTypeProperty.MonthlyFull,
            Iban = "GB98MIDL07009312345678",
            Interest = "5.3",
            InterestPeriod = InterestPeriodProperty.Monthly,
            Latitude = 51.983333,
            LiabilityType = LiabilityTypeProperty.Loan,
            Longitude = 5.916667,
            MonthlyPaymentDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Notes = "Some example notes",
            OpeningBalanceDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            ZoomLevel = 6,

            // Null should be interpreted as omitted for these properties
            Active = null,
            CurrencyCode = null,
            CurrencyID = null,
            IncludeNetWorth = null,
            OpeningBalance = null,
            Order = null,
            VirtualBalance = null,
            XTraceID = null,
        };

        Assert.Null(parameters.Active);
        Assert.False(parameters.RawBodyData.ContainsKey("active"));
        Assert.Null(parameters.CurrencyCode);
        Assert.False(parameters.RawBodyData.ContainsKey("currency_code"));
        Assert.Null(parameters.CurrencyID);
        Assert.False(parameters.RawBodyData.ContainsKey("currency_id"));
        Assert.Null(parameters.IncludeNetWorth);
        Assert.False(parameters.RawBodyData.ContainsKey("include_net_worth"));
        Assert.Null(parameters.OpeningBalance);
        Assert.False(parameters.RawBodyData.ContainsKey("opening_balance"));
        Assert.Null(parameters.Order);
        Assert.False(parameters.RawBodyData.ContainsKey("order"));
        Assert.Null(parameters.VirtualBalance);
        Assert.False(parameters.RawBodyData.ContainsKey("virtual_balance"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AccountUpdateParams
        {
            ID = "123",
            Name = "My checking account",
            Type = JsonSerializer.Deserialize<JsonElement>("{}"),
            Active = false,
            CurrencyCode = "EUR",
            CurrencyID = "12",
            IncludeNetWorth = true,
            OpeningBalance = "-1012.12",
            Order = 1,
            VirtualBalance = "123.45",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        Assert.Null(parameters.AccountNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("account_number"));
        Assert.Null(parameters.AccountRole);
        Assert.False(parameters.RawBodyData.ContainsKey("account_role"));
        Assert.Null(parameters.Bic);
        Assert.False(parameters.RawBodyData.ContainsKey("bic"));
        Assert.Null(parameters.CreditCardType);
        Assert.False(parameters.RawBodyData.ContainsKey("credit_card_type"));
        Assert.Null(parameters.Iban);
        Assert.False(parameters.RawBodyData.ContainsKey("iban"));
        Assert.Null(parameters.Interest);
        Assert.False(parameters.RawBodyData.ContainsKey("interest"));
        Assert.Null(parameters.InterestPeriod);
        Assert.False(parameters.RawBodyData.ContainsKey("interest_period"));
        Assert.Null(parameters.Latitude);
        Assert.False(parameters.RawBodyData.ContainsKey("latitude"));
        Assert.Null(parameters.LiabilityType);
        Assert.False(parameters.RawBodyData.ContainsKey("liability_type"));
        Assert.Null(parameters.Longitude);
        Assert.False(parameters.RawBodyData.ContainsKey("longitude"));
        Assert.Null(parameters.MonthlyPaymentDate);
        Assert.False(parameters.RawBodyData.ContainsKey("monthly_payment_date"));
        Assert.Null(parameters.Notes);
        Assert.False(parameters.RawBodyData.ContainsKey("notes"));
        Assert.Null(parameters.OpeningBalanceDate);
        Assert.False(parameters.RawBodyData.ContainsKey("opening_balance_date"));
        Assert.Null(parameters.ZoomLevel);
        Assert.False(parameters.RawBodyData.ContainsKey("zoom_level"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new AccountUpdateParams
        {
            ID = "123",
            Name = "My checking account",
            Type = JsonSerializer.Deserialize<JsonElement>("{}"),
            Active = false,
            CurrencyCode = "EUR",
            CurrencyID = "12",
            IncludeNetWorth = true,
            OpeningBalance = "-1012.12",
            Order = 1,
            VirtualBalance = "123.45",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",

            AccountNumber = null,
            AccountRole = null,
            Bic = null,
            CreditCardType = null,
            Iban = null,
            Interest = null,
            InterestPeriod = null,
            Latitude = null,
            LiabilityType = null,
            Longitude = null,
            MonthlyPaymentDate = null,
            Notes = null,
            OpeningBalanceDate = null,
            ZoomLevel = null,
        };

        Assert.Null(parameters.AccountNumber);
        Assert.True(parameters.RawBodyData.ContainsKey("account_number"));
        Assert.Null(parameters.AccountRole);
        Assert.True(parameters.RawBodyData.ContainsKey("account_role"));
        Assert.Null(parameters.Bic);
        Assert.True(parameters.RawBodyData.ContainsKey("bic"));
        Assert.Null(parameters.CreditCardType);
        Assert.True(parameters.RawBodyData.ContainsKey("credit_card_type"));
        Assert.Null(parameters.Iban);
        Assert.True(parameters.RawBodyData.ContainsKey("iban"));
        Assert.Null(parameters.Interest);
        Assert.True(parameters.RawBodyData.ContainsKey("interest"));
        Assert.Null(parameters.InterestPeriod);
        Assert.True(parameters.RawBodyData.ContainsKey("interest_period"));
        Assert.Null(parameters.Latitude);
        Assert.True(parameters.RawBodyData.ContainsKey("latitude"));
        Assert.Null(parameters.LiabilityType);
        Assert.True(parameters.RawBodyData.ContainsKey("liability_type"));
        Assert.Null(parameters.Longitude);
        Assert.True(parameters.RawBodyData.ContainsKey("longitude"));
        Assert.Null(parameters.MonthlyPaymentDate);
        Assert.True(parameters.RawBodyData.ContainsKey("monthly_payment_date"));
        Assert.Null(parameters.Notes);
        Assert.True(parameters.RawBodyData.ContainsKey("notes"));
        Assert.Null(parameters.OpeningBalanceDate);
        Assert.True(parameters.RawBodyData.ContainsKey("opening_balance_date"));
        Assert.Null(parameters.ZoomLevel);
        Assert.True(parameters.RawBodyData.ContainsKey("zoom_level"));
    }

    [Fact]
    public void Url_Works()
    {
        AccountUpdateParams parameters = new()
        {
            ID = "123",
            Name = "My checking account",
            Type = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        var url = parameters.Url(new() { });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://demo.firefly-iii.org/api/v1/accounts/123"), url)
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        AccountUpdateParams parameters = new()
        {
            ID = "123",
            Name = "My checking account",
            Type = JsonSerializer.Deserialize<JsonElement>("{}"),
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
        var parameters = new AccountUpdateParams
        {
            ID = "123",
            Name = "My checking account",
            Type = JsonSerializer.Deserialize<JsonElement>("{}"),
            AccountNumber = "7009312345678",
            AccountRole = AccountRoleProperty.DefaultAsset,
            Active = false,
            Bic = "BOFAUS3N",
            CreditCardType = CreditCardTypeProperty.MonthlyFull,
            CurrencyCode = "EUR",
            CurrencyID = "12",
            Iban = "GB98MIDL07009312345678",
            IncludeNetWorth = true,
            Interest = "5.3",
            InterestPeriod = InterestPeriodProperty.Monthly,
            Latitude = 51.983333,
            LiabilityType = LiabilityTypeProperty.Loan,
            Longitude = 5.916667,
            MonthlyPaymentDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Notes = "Some example notes",
            OpeningBalance = "-1012.12",
            OpeningBalanceDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Order = 1,
            VirtualBalance = "123.45",
            ZoomLevel = 6,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        AccountUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
