using System;
using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Accounts;

namespace EmceesProdTesting5.Tests.Models.Accounts;

public class AccountReadTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AccountRead
        {
            ID = "2",
            Attributes = new()
            {
                Name = "My checking account",
                Type = ShortAccountTypeProperty.Asset,
                AccountNumber = "7009312345678",
                AccountRole = AccountRoleProperty.DefaultAsset,
                Active = false,
                BalanceDifference = "123.45",
                Bic = "BOFAUS3N",
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                CreditCardType = CreditCardTypeProperty.MonthlyFull,
                CurrencyCode = "EUR",
                CurrencyDecimalPlaces = 2,
                CurrencyID = "5",
                CurrencyName = "Euro",
                CurrencySymbol = "$",
                CurrentBalance = "123.45",
                CurrentBalanceDate = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
                DebtAmount = "1012.12",
                Iban = "GB98MIDL07009312345678",
                IncludeNetWorth = true,
                Interest = "5.3",
                InterestPeriod = InterestPeriodProperty.Monthly,
                LastActivity = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                Latitude = 51.983333,
                LiabilityDirection = LiabilityDirectionProperty.Credit,
                LiabilityType = LiabilityTypeProperty.Loan,
                Longitude = 5.916667,
                MonthlyPaymentDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                Notes = "Some example notes",
                ObjectGroupID = "5",
                ObjectGroupOrder = 5,
                ObjectGroupTitle = "Example Group",
                ObjectHasCurrencySetting = true,
                OpeningBalance = "-1012.12",
                OpeningBalanceDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                Order = 1,
                PcBalanceDifference = "123.45",
                PcCurrentBalance = "123.45",
                PcDebtAmount = "1012.12",
                PcOpeningBalance = "-1012.12",
                PcVirtualBalance = "123.45",
                PrimaryCurrencyCode = "EUR",
                PrimaryCurrencyDecimalPlaces = 2,
                PrimaryCurrencyID = "5",
                PrimaryCurrencyName = "Euro",
                PrimaryCurrencySymbol = "$",
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                VirtualBalance = "123.45",
                ZoomLevel = 6,
            },
            Type = "accounts",
        };

        string expectedID = "2";
        Attributes expectedAttributes = new()
        {
            Name = "My checking account",
            Type = ShortAccountTypeProperty.Asset,
            AccountNumber = "7009312345678",
            AccountRole = AccountRoleProperty.DefaultAsset,
            Active = false,
            BalanceDifference = "123.45",
            Bic = "BOFAUS3N",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            CreditCardType = CreditCardTypeProperty.MonthlyFull,
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "5",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            CurrentBalance = "123.45",
            CurrentBalanceDate = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
            DebtAmount = "1012.12",
            Iban = "GB98MIDL07009312345678",
            IncludeNetWorth = true,
            Interest = "5.3",
            InterestPeriod = InterestPeriodProperty.Monthly,
            LastActivity = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Latitude = 51.983333,
            LiabilityDirection = LiabilityDirectionProperty.Credit,
            LiabilityType = LiabilityTypeProperty.Loan,
            Longitude = 5.916667,
            MonthlyPaymentDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Notes = "Some example notes",
            ObjectGroupID = "5",
            ObjectGroupOrder = 5,
            ObjectGroupTitle = "Example Group",
            ObjectHasCurrencySetting = true,
            OpeningBalance = "-1012.12",
            OpeningBalanceDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Order = 1,
            PcBalanceDifference = "123.45",
            PcCurrentBalance = "123.45",
            PcDebtAmount = "1012.12",
            PcOpeningBalance = "-1012.12",
            PcVirtualBalance = "123.45",
            PrimaryCurrencyCode = "EUR",
            PrimaryCurrencyDecimalPlaces = 2,
            PrimaryCurrencyID = "5",
            PrimaryCurrencyName = "Euro",
            PrimaryCurrencySymbol = "$",
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            VirtualBalance = "123.45",
            ZoomLevel = 6,
        };
        string expectedType = "accounts";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAttributes, model.Attributes);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AccountRead
        {
            ID = "2",
            Attributes = new()
            {
                Name = "My checking account",
                Type = ShortAccountTypeProperty.Asset,
                AccountNumber = "7009312345678",
                AccountRole = AccountRoleProperty.DefaultAsset,
                Active = false,
                BalanceDifference = "123.45",
                Bic = "BOFAUS3N",
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                CreditCardType = CreditCardTypeProperty.MonthlyFull,
                CurrencyCode = "EUR",
                CurrencyDecimalPlaces = 2,
                CurrencyID = "5",
                CurrencyName = "Euro",
                CurrencySymbol = "$",
                CurrentBalance = "123.45",
                CurrentBalanceDate = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
                DebtAmount = "1012.12",
                Iban = "GB98MIDL07009312345678",
                IncludeNetWorth = true,
                Interest = "5.3",
                InterestPeriod = InterestPeriodProperty.Monthly,
                LastActivity = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                Latitude = 51.983333,
                LiabilityDirection = LiabilityDirectionProperty.Credit,
                LiabilityType = LiabilityTypeProperty.Loan,
                Longitude = 5.916667,
                MonthlyPaymentDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                Notes = "Some example notes",
                ObjectGroupID = "5",
                ObjectGroupOrder = 5,
                ObjectGroupTitle = "Example Group",
                ObjectHasCurrencySetting = true,
                OpeningBalance = "-1012.12",
                OpeningBalanceDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                Order = 1,
                PcBalanceDifference = "123.45",
                PcCurrentBalance = "123.45",
                PcDebtAmount = "1012.12",
                PcOpeningBalance = "-1012.12",
                PcVirtualBalance = "123.45",
                PrimaryCurrencyCode = "EUR",
                PrimaryCurrencyDecimalPlaces = 2,
                PrimaryCurrencyID = "5",
                PrimaryCurrencyName = "Euro",
                PrimaryCurrencySymbol = "$",
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                VirtualBalance = "123.45",
                ZoomLevel = 6,
            },
            Type = "accounts",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountRead>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AccountRead
        {
            ID = "2",
            Attributes = new()
            {
                Name = "My checking account",
                Type = ShortAccountTypeProperty.Asset,
                AccountNumber = "7009312345678",
                AccountRole = AccountRoleProperty.DefaultAsset,
                Active = false,
                BalanceDifference = "123.45",
                Bic = "BOFAUS3N",
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                CreditCardType = CreditCardTypeProperty.MonthlyFull,
                CurrencyCode = "EUR",
                CurrencyDecimalPlaces = 2,
                CurrencyID = "5",
                CurrencyName = "Euro",
                CurrencySymbol = "$",
                CurrentBalance = "123.45",
                CurrentBalanceDate = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
                DebtAmount = "1012.12",
                Iban = "GB98MIDL07009312345678",
                IncludeNetWorth = true,
                Interest = "5.3",
                InterestPeriod = InterestPeriodProperty.Monthly,
                LastActivity = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                Latitude = 51.983333,
                LiabilityDirection = LiabilityDirectionProperty.Credit,
                LiabilityType = LiabilityTypeProperty.Loan,
                Longitude = 5.916667,
                MonthlyPaymentDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                Notes = "Some example notes",
                ObjectGroupID = "5",
                ObjectGroupOrder = 5,
                ObjectGroupTitle = "Example Group",
                ObjectHasCurrencySetting = true,
                OpeningBalance = "-1012.12",
                OpeningBalanceDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                Order = 1,
                PcBalanceDifference = "123.45",
                PcCurrentBalance = "123.45",
                PcDebtAmount = "1012.12",
                PcOpeningBalance = "-1012.12",
                PcVirtualBalance = "123.45",
                PrimaryCurrencyCode = "EUR",
                PrimaryCurrencyDecimalPlaces = 2,
                PrimaryCurrencyID = "5",
                PrimaryCurrencyName = "Euro",
                PrimaryCurrencySymbol = "$",
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                VirtualBalance = "123.45",
                ZoomLevel = 6,
            },
            Type = "accounts",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountRead>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "2";
        Attributes expectedAttributes = new()
        {
            Name = "My checking account",
            Type = ShortAccountTypeProperty.Asset,
            AccountNumber = "7009312345678",
            AccountRole = AccountRoleProperty.DefaultAsset,
            Active = false,
            BalanceDifference = "123.45",
            Bic = "BOFAUS3N",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            CreditCardType = CreditCardTypeProperty.MonthlyFull,
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "5",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            CurrentBalance = "123.45",
            CurrentBalanceDate = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
            DebtAmount = "1012.12",
            Iban = "GB98MIDL07009312345678",
            IncludeNetWorth = true,
            Interest = "5.3",
            InterestPeriod = InterestPeriodProperty.Monthly,
            LastActivity = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Latitude = 51.983333,
            LiabilityDirection = LiabilityDirectionProperty.Credit,
            LiabilityType = LiabilityTypeProperty.Loan,
            Longitude = 5.916667,
            MonthlyPaymentDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Notes = "Some example notes",
            ObjectGroupID = "5",
            ObjectGroupOrder = 5,
            ObjectGroupTitle = "Example Group",
            ObjectHasCurrencySetting = true,
            OpeningBalance = "-1012.12",
            OpeningBalanceDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Order = 1,
            PcBalanceDifference = "123.45",
            PcCurrentBalance = "123.45",
            PcDebtAmount = "1012.12",
            PcOpeningBalance = "-1012.12",
            PcVirtualBalance = "123.45",
            PrimaryCurrencyCode = "EUR",
            PrimaryCurrencyDecimalPlaces = 2,
            PrimaryCurrencyID = "5",
            PrimaryCurrencyName = "Euro",
            PrimaryCurrencySymbol = "$",
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            VirtualBalance = "123.45",
            ZoomLevel = 6,
        };
        string expectedType = "accounts";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAttributes, deserialized.Attributes);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AccountRead
        {
            ID = "2",
            Attributes = new()
            {
                Name = "My checking account",
                Type = ShortAccountTypeProperty.Asset,
                AccountNumber = "7009312345678",
                AccountRole = AccountRoleProperty.DefaultAsset,
                Active = false,
                BalanceDifference = "123.45",
                Bic = "BOFAUS3N",
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                CreditCardType = CreditCardTypeProperty.MonthlyFull,
                CurrencyCode = "EUR",
                CurrencyDecimalPlaces = 2,
                CurrencyID = "5",
                CurrencyName = "Euro",
                CurrencySymbol = "$",
                CurrentBalance = "123.45",
                CurrentBalanceDate = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
                DebtAmount = "1012.12",
                Iban = "GB98MIDL07009312345678",
                IncludeNetWorth = true,
                Interest = "5.3",
                InterestPeriod = InterestPeriodProperty.Monthly,
                LastActivity = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                Latitude = 51.983333,
                LiabilityDirection = LiabilityDirectionProperty.Credit,
                LiabilityType = LiabilityTypeProperty.Loan,
                Longitude = 5.916667,
                MonthlyPaymentDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                Notes = "Some example notes",
                ObjectGroupID = "5",
                ObjectGroupOrder = 5,
                ObjectGroupTitle = "Example Group",
                ObjectHasCurrencySetting = true,
                OpeningBalance = "-1012.12",
                OpeningBalanceDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                Order = 1,
                PcBalanceDifference = "123.45",
                PcCurrentBalance = "123.45",
                PcDebtAmount = "1012.12",
                PcOpeningBalance = "-1012.12",
                PcVirtualBalance = "123.45",
                PrimaryCurrencyCode = "EUR",
                PrimaryCurrencyDecimalPlaces = 2,
                PrimaryCurrencyID = "5",
                PrimaryCurrencyName = "Euro",
                PrimaryCurrencySymbol = "$",
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                VirtualBalance = "123.45",
                ZoomLevel = 6,
            },
            Type = "accounts",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AccountRead
        {
            ID = "2",
            Attributes = new()
            {
                Name = "My checking account",
                Type = ShortAccountTypeProperty.Asset,
                AccountNumber = "7009312345678",
                AccountRole = AccountRoleProperty.DefaultAsset,
                Active = false,
                BalanceDifference = "123.45",
                Bic = "BOFAUS3N",
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                CreditCardType = CreditCardTypeProperty.MonthlyFull,
                CurrencyCode = "EUR",
                CurrencyDecimalPlaces = 2,
                CurrencyID = "5",
                CurrencyName = "Euro",
                CurrencySymbol = "$",
                CurrentBalance = "123.45",
                CurrentBalanceDate = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
                DebtAmount = "1012.12",
                Iban = "GB98MIDL07009312345678",
                IncludeNetWorth = true,
                Interest = "5.3",
                InterestPeriod = InterestPeriodProperty.Monthly,
                LastActivity = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                Latitude = 51.983333,
                LiabilityDirection = LiabilityDirectionProperty.Credit,
                LiabilityType = LiabilityTypeProperty.Loan,
                Longitude = 5.916667,
                MonthlyPaymentDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                Notes = "Some example notes",
                ObjectGroupID = "5",
                ObjectGroupOrder = 5,
                ObjectGroupTitle = "Example Group",
                ObjectHasCurrencySetting = true,
                OpeningBalance = "-1012.12",
                OpeningBalanceDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                Order = 1,
                PcBalanceDifference = "123.45",
                PcCurrentBalance = "123.45",
                PcDebtAmount = "1012.12",
                PcOpeningBalance = "-1012.12",
                PcVirtualBalance = "123.45",
                PrimaryCurrencyCode = "EUR",
                PrimaryCurrencyDecimalPlaces = 2,
                PrimaryCurrencyID = "5",
                PrimaryCurrencyName = "Euro",
                PrimaryCurrencySymbol = "$",
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                VirtualBalance = "123.45",
                ZoomLevel = 6,
            },
            Type = "accounts",
        };

        AccountRead copied = new(model);

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
            Name = "My checking account",
            Type = ShortAccountTypeProperty.Asset,
            AccountNumber = "7009312345678",
            AccountRole = AccountRoleProperty.DefaultAsset,
            Active = false,
            BalanceDifference = "123.45",
            Bic = "BOFAUS3N",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            CreditCardType = CreditCardTypeProperty.MonthlyFull,
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "5",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            CurrentBalance = "123.45",
            CurrentBalanceDate = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
            DebtAmount = "1012.12",
            Iban = "GB98MIDL07009312345678",
            IncludeNetWorth = true,
            Interest = "5.3",
            InterestPeriod = InterestPeriodProperty.Monthly,
            LastActivity = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Latitude = 51.983333,
            LiabilityDirection = LiabilityDirectionProperty.Credit,
            LiabilityType = LiabilityTypeProperty.Loan,
            Longitude = 5.916667,
            MonthlyPaymentDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Notes = "Some example notes",
            ObjectGroupID = "5",
            ObjectGroupOrder = 5,
            ObjectGroupTitle = "Example Group",
            ObjectHasCurrencySetting = true,
            OpeningBalance = "-1012.12",
            OpeningBalanceDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Order = 1,
            PcBalanceDifference = "123.45",
            PcCurrentBalance = "123.45",
            PcDebtAmount = "1012.12",
            PcOpeningBalance = "-1012.12",
            PcVirtualBalance = "123.45",
            PrimaryCurrencyCode = "EUR",
            PrimaryCurrencyDecimalPlaces = 2,
            PrimaryCurrencyID = "5",
            PrimaryCurrencyName = "Euro",
            PrimaryCurrencySymbol = "$",
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            VirtualBalance = "123.45",
            ZoomLevel = 6,
        };

        string expectedName = "My checking account";
        ApiEnum<string, ShortAccountTypeProperty> expectedType = ShortAccountTypeProperty.Asset;
        string expectedAccountNumber = "7009312345678";
        ApiEnum<string, AccountRoleProperty> expectedAccountRole = AccountRoleProperty.DefaultAsset;
        bool expectedActive = false;
        string expectedBalanceDifference = "123.45";
        string expectedBic = "BOFAUS3N";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        ApiEnum<string, CreditCardTypeProperty> expectedCreditCardType =
            CreditCardTypeProperty.MonthlyFull;
        string expectedCurrencyCode = "EUR";
        int expectedCurrencyDecimalPlaces = 2;
        string expectedCurrencyID = "5";
        string expectedCurrencyName = "Euro";
        string expectedCurrencySymbol = "$";
        string expectedCurrentBalance = "123.45";
        DateTimeOffset expectedCurrentBalanceDate = DateTimeOffset.Parse(
            "2026-04-30T23:59:59+00:00"
        );
        string expectedDebtAmount = "1012.12";
        string expectedIban = "GB98MIDL07009312345678";
        bool expectedIncludeNetWorth = true;
        string expectedInterest = "5.3";
        ApiEnum<string, InterestPeriodProperty> expectedInterestPeriod =
            InterestPeriodProperty.Monthly;
        DateTimeOffset expectedLastActivity = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        double expectedLatitude = 51.983333;
        ApiEnum<string, LiabilityDirectionProperty> expectedLiabilityDirection =
            LiabilityDirectionProperty.Credit;
        ApiEnum<string, LiabilityTypeProperty> expectedLiabilityType = LiabilityTypeProperty.Loan;
        double expectedLongitude = 5.916667;
        DateTimeOffset expectedMonthlyPaymentDate = DateTimeOffset.Parse(
            "2026-04-01T00:00:00+00:00"
        );
        string expectedNotes = "Some example notes";
        string expectedObjectGroupID = "5";
        int expectedObjectGroupOrder = 5;
        string expectedObjectGroupTitle = "Example Group";
        bool expectedObjectHasCurrencySetting = true;
        string expectedOpeningBalance = "-1012.12";
        DateTimeOffset expectedOpeningBalanceDate = DateTimeOffset.Parse(
            "2026-04-01T00:00:00+00:00"
        );
        int expectedOrder = 1;
        string expectedPcBalanceDifference = "123.45";
        string expectedPcCurrentBalance = "123.45";
        string expectedPcDebtAmount = "1012.12";
        string expectedPcOpeningBalance = "-1012.12";
        string expectedPcVirtualBalance = "123.45";
        string expectedPrimaryCurrencyCode = "EUR";
        int expectedPrimaryCurrencyDecimalPlaces = 2;
        string expectedPrimaryCurrencyID = "5";
        string expectedPrimaryCurrencyName = "Euro";
        string expectedPrimaryCurrencySymbol = "$";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        string expectedVirtualBalance = "123.45";
        int expectedZoomLevel = 6;

        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedAccountNumber, model.AccountNumber);
        Assert.Equal(expectedAccountRole, model.AccountRole);
        Assert.Equal(expectedActive, model.Active);
        Assert.Equal(expectedBalanceDifference, model.BalanceDifference);
        Assert.Equal(expectedBic, model.Bic);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreditCardType, model.CreditCardType);
        Assert.Equal(expectedCurrencyCode, model.CurrencyCode);
        Assert.Equal(expectedCurrencyDecimalPlaces, model.CurrencyDecimalPlaces);
        Assert.Equal(expectedCurrencyID, model.CurrencyID);
        Assert.Equal(expectedCurrencyName, model.CurrencyName);
        Assert.Equal(expectedCurrencySymbol, model.CurrencySymbol);
        Assert.Equal(expectedCurrentBalance, model.CurrentBalance);
        Assert.Equal(expectedCurrentBalanceDate, model.CurrentBalanceDate);
        Assert.Equal(expectedDebtAmount, model.DebtAmount);
        Assert.Equal(expectedIban, model.Iban);
        Assert.Equal(expectedIncludeNetWorth, model.IncludeNetWorth);
        Assert.Equal(expectedInterest, model.Interest);
        Assert.Equal(expectedInterestPeriod, model.InterestPeriod);
        Assert.Equal(expectedLastActivity, model.LastActivity);
        Assert.Equal(expectedLatitude, model.Latitude);
        Assert.Equal(expectedLiabilityDirection, model.LiabilityDirection);
        Assert.Equal(expectedLiabilityType, model.LiabilityType);
        Assert.Equal(expectedLongitude, model.Longitude);
        Assert.Equal(expectedMonthlyPaymentDate, model.MonthlyPaymentDate);
        Assert.Equal(expectedNotes, model.Notes);
        Assert.Equal(expectedObjectGroupID, model.ObjectGroupID);
        Assert.Equal(expectedObjectGroupOrder, model.ObjectGroupOrder);
        Assert.Equal(expectedObjectGroupTitle, model.ObjectGroupTitle);
        Assert.Equal(expectedObjectHasCurrencySetting, model.ObjectHasCurrencySetting);
        Assert.Equal(expectedOpeningBalance, model.OpeningBalance);
        Assert.Equal(expectedOpeningBalanceDate, model.OpeningBalanceDate);
        Assert.Equal(expectedOrder, model.Order);
        Assert.Equal(expectedPcBalanceDifference, model.PcBalanceDifference);
        Assert.Equal(expectedPcCurrentBalance, model.PcCurrentBalance);
        Assert.Equal(expectedPcDebtAmount, model.PcDebtAmount);
        Assert.Equal(expectedPcOpeningBalance, model.PcOpeningBalance);
        Assert.Equal(expectedPcVirtualBalance, model.PcVirtualBalance);
        Assert.Equal(expectedPrimaryCurrencyCode, model.PrimaryCurrencyCode);
        Assert.Equal(expectedPrimaryCurrencyDecimalPlaces, model.PrimaryCurrencyDecimalPlaces);
        Assert.Equal(expectedPrimaryCurrencyID, model.PrimaryCurrencyID);
        Assert.Equal(expectedPrimaryCurrencyName, model.PrimaryCurrencyName);
        Assert.Equal(expectedPrimaryCurrencySymbol, model.PrimaryCurrencySymbol);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedVirtualBalance, model.VirtualBalance);
        Assert.Equal(expectedZoomLevel, model.ZoomLevel);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Attributes
        {
            Name = "My checking account",
            Type = ShortAccountTypeProperty.Asset,
            AccountNumber = "7009312345678",
            AccountRole = AccountRoleProperty.DefaultAsset,
            Active = false,
            BalanceDifference = "123.45",
            Bic = "BOFAUS3N",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            CreditCardType = CreditCardTypeProperty.MonthlyFull,
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "5",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            CurrentBalance = "123.45",
            CurrentBalanceDate = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
            DebtAmount = "1012.12",
            Iban = "GB98MIDL07009312345678",
            IncludeNetWorth = true,
            Interest = "5.3",
            InterestPeriod = InterestPeriodProperty.Monthly,
            LastActivity = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Latitude = 51.983333,
            LiabilityDirection = LiabilityDirectionProperty.Credit,
            LiabilityType = LiabilityTypeProperty.Loan,
            Longitude = 5.916667,
            MonthlyPaymentDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Notes = "Some example notes",
            ObjectGroupID = "5",
            ObjectGroupOrder = 5,
            ObjectGroupTitle = "Example Group",
            ObjectHasCurrencySetting = true,
            OpeningBalance = "-1012.12",
            OpeningBalanceDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Order = 1,
            PcBalanceDifference = "123.45",
            PcCurrentBalance = "123.45",
            PcDebtAmount = "1012.12",
            PcOpeningBalance = "-1012.12",
            PcVirtualBalance = "123.45",
            PrimaryCurrencyCode = "EUR",
            PrimaryCurrencyDecimalPlaces = 2,
            PrimaryCurrencyID = "5",
            PrimaryCurrencyName = "Euro",
            PrimaryCurrencySymbol = "$",
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            VirtualBalance = "123.45",
            ZoomLevel = 6,
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
            Name = "My checking account",
            Type = ShortAccountTypeProperty.Asset,
            AccountNumber = "7009312345678",
            AccountRole = AccountRoleProperty.DefaultAsset,
            Active = false,
            BalanceDifference = "123.45",
            Bic = "BOFAUS3N",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            CreditCardType = CreditCardTypeProperty.MonthlyFull,
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "5",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            CurrentBalance = "123.45",
            CurrentBalanceDate = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
            DebtAmount = "1012.12",
            Iban = "GB98MIDL07009312345678",
            IncludeNetWorth = true,
            Interest = "5.3",
            InterestPeriod = InterestPeriodProperty.Monthly,
            LastActivity = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Latitude = 51.983333,
            LiabilityDirection = LiabilityDirectionProperty.Credit,
            LiabilityType = LiabilityTypeProperty.Loan,
            Longitude = 5.916667,
            MonthlyPaymentDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Notes = "Some example notes",
            ObjectGroupID = "5",
            ObjectGroupOrder = 5,
            ObjectGroupTitle = "Example Group",
            ObjectHasCurrencySetting = true,
            OpeningBalance = "-1012.12",
            OpeningBalanceDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Order = 1,
            PcBalanceDifference = "123.45",
            PcCurrentBalance = "123.45",
            PcDebtAmount = "1012.12",
            PcOpeningBalance = "-1012.12",
            PcVirtualBalance = "123.45",
            PrimaryCurrencyCode = "EUR",
            PrimaryCurrencyDecimalPlaces = 2,
            PrimaryCurrencyID = "5",
            PrimaryCurrencyName = "Euro",
            PrimaryCurrencySymbol = "$",
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            VirtualBalance = "123.45",
            ZoomLevel = 6,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Attributes>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "My checking account";
        ApiEnum<string, ShortAccountTypeProperty> expectedType = ShortAccountTypeProperty.Asset;
        string expectedAccountNumber = "7009312345678";
        ApiEnum<string, AccountRoleProperty> expectedAccountRole = AccountRoleProperty.DefaultAsset;
        bool expectedActive = false;
        string expectedBalanceDifference = "123.45";
        string expectedBic = "BOFAUS3N";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        ApiEnum<string, CreditCardTypeProperty> expectedCreditCardType =
            CreditCardTypeProperty.MonthlyFull;
        string expectedCurrencyCode = "EUR";
        int expectedCurrencyDecimalPlaces = 2;
        string expectedCurrencyID = "5";
        string expectedCurrencyName = "Euro";
        string expectedCurrencySymbol = "$";
        string expectedCurrentBalance = "123.45";
        DateTimeOffset expectedCurrentBalanceDate = DateTimeOffset.Parse(
            "2026-04-30T23:59:59+00:00"
        );
        string expectedDebtAmount = "1012.12";
        string expectedIban = "GB98MIDL07009312345678";
        bool expectedIncludeNetWorth = true;
        string expectedInterest = "5.3";
        ApiEnum<string, InterestPeriodProperty> expectedInterestPeriod =
            InterestPeriodProperty.Monthly;
        DateTimeOffset expectedLastActivity = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        double expectedLatitude = 51.983333;
        ApiEnum<string, LiabilityDirectionProperty> expectedLiabilityDirection =
            LiabilityDirectionProperty.Credit;
        ApiEnum<string, LiabilityTypeProperty> expectedLiabilityType = LiabilityTypeProperty.Loan;
        double expectedLongitude = 5.916667;
        DateTimeOffset expectedMonthlyPaymentDate = DateTimeOffset.Parse(
            "2026-04-01T00:00:00+00:00"
        );
        string expectedNotes = "Some example notes";
        string expectedObjectGroupID = "5";
        int expectedObjectGroupOrder = 5;
        string expectedObjectGroupTitle = "Example Group";
        bool expectedObjectHasCurrencySetting = true;
        string expectedOpeningBalance = "-1012.12";
        DateTimeOffset expectedOpeningBalanceDate = DateTimeOffset.Parse(
            "2026-04-01T00:00:00+00:00"
        );
        int expectedOrder = 1;
        string expectedPcBalanceDifference = "123.45";
        string expectedPcCurrentBalance = "123.45";
        string expectedPcDebtAmount = "1012.12";
        string expectedPcOpeningBalance = "-1012.12";
        string expectedPcVirtualBalance = "123.45";
        string expectedPrimaryCurrencyCode = "EUR";
        int expectedPrimaryCurrencyDecimalPlaces = 2;
        string expectedPrimaryCurrencyID = "5";
        string expectedPrimaryCurrencyName = "Euro";
        string expectedPrimaryCurrencySymbol = "$";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        string expectedVirtualBalance = "123.45";
        int expectedZoomLevel = 6;

        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedAccountNumber, deserialized.AccountNumber);
        Assert.Equal(expectedAccountRole, deserialized.AccountRole);
        Assert.Equal(expectedActive, deserialized.Active);
        Assert.Equal(expectedBalanceDifference, deserialized.BalanceDifference);
        Assert.Equal(expectedBic, deserialized.Bic);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCreditCardType, deserialized.CreditCardType);
        Assert.Equal(expectedCurrencyCode, deserialized.CurrencyCode);
        Assert.Equal(expectedCurrencyDecimalPlaces, deserialized.CurrencyDecimalPlaces);
        Assert.Equal(expectedCurrencyID, deserialized.CurrencyID);
        Assert.Equal(expectedCurrencyName, deserialized.CurrencyName);
        Assert.Equal(expectedCurrencySymbol, deserialized.CurrencySymbol);
        Assert.Equal(expectedCurrentBalance, deserialized.CurrentBalance);
        Assert.Equal(expectedCurrentBalanceDate, deserialized.CurrentBalanceDate);
        Assert.Equal(expectedDebtAmount, deserialized.DebtAmount);
        Assert.Equal(expectedIban, deserialized.Iban);
        Assert.Equal(expectedIncludeNetWorth, deserialized.IncludeNetWorth);
        Assert.Equal(expectedInterest, deserialized.Interest);
        Assert.Equal(expectedInterestPeriod, deserialized.InterestPeriod);
        Assert.Equal(expectedLastActivity, deserialized.LastActivity);
        Assert.Equal(expectedLatitude, deserialized.Latitude);
        Assert.Equal(expectedLiabilityDirection, deserialized.LiabilityDirection);
        Assert.Equal(expectedLiabilityType, deserialized.LiabilityType);
        Assert.Equal(expectedLongitude, deserialized.Longitude);
        Assert.Equal(expectedMonthlyPaymentDate, deserialized.MonthlyPaymentDate);
        Assert.Equal(expectedNotes, deserialized.Notes);
        Assert.Equal(expectedObjectGroupID, deserialized.ObjectGroupID);
        Assert.Equal(expectedObjectGroupOrder, deserialized.ObjectGroupOrder);
        Assert.Equal(expectedObjectGroupTitle, deserialized.ObjectGroupTitle);
        Assert.Equal(expectedObjectHasCurrencySetting, deserialized.ObjectHasCurrencySetting);
        Assert.Equal(expectedOpeningBalance, deserialized.OpeningBalance);
        Assert.Equal(expectedOpeningBalanceDate, deserialized.OpeningBalanceDate);
        Assert.Equal(expectedOrder, deserialized.Order);
        Assert.Equal(expectedPcBalanceDifference, deserialized.PcBalanceDifference);
        Assert.Equal(expectedPcCurrentBalance, deserialized.PcCurrentBalance);
        Assert.Equal(expectedPcDebtAmount, deserialized.PcDebtAmount);
        Assert.Equal(expectedPcOpeningBalance, deserialized.PcOpeningBalance);
        Assert.Equal(expectedPcVirtualBalance, deserialized.PcVirtualBalance);
        Assert.Equal(expectedPrimaryCurrencyCode, deserialized.PrimaryCurrencyCode);
        Assert.Equal(
            expectedPrimaryCurrencyDecimalPlaces,
            deserialized.PrimaryCurrencyDecimalPlaces
        );
        Assert.Equal(expectedPrimaryCurrencyID, deserialized.PrimaryCurrencyID);
        Assert.Equal(expectedPrimaryCurrencyName, deserialized.PrimaryCurrencyName);
        Assert.Equal(expectedPrimaryCurrencySymbol, deserialized.PrimaryCurrencySymbol);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedVirtualBalance, deserialized.VirtualBalance);
        Assert.Equal(expectedZoomLevel, deserialized.ZoomLevel);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Attributes
        {
            Name = "My checking account",
            Type = ShortAccountTypeProperty.Asset,
            AccountNumber = "7009312345678",
            AccountRole = AccountRoleProperty.DefaultAsset,
            Active = false,
            BalanceDifference = "123.45",
            Bic = "BOFAUS3N",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            CreditCardType = CreditCardTypeProperty.MonthlyFull,
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "5",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            CurrentBalance = "123.45",
            CurrentBalanceDate = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
            DebtAmount = "1012.12",
            Iban = "GB98MIDL07009312345678",
            IncludeNetWorth = true,
            Interest = "5.3",
            InterestPeriod = InterestPeriodProperty.Monthly,
            LastActivity = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Latitude = 51.983333,
            LiabilityDirection = LiabilityDirectionProperty.Credit,
            LiabilityType = LiabilityTypeProperty.Loan,
            Longitude = 5.916667,
            MonthlyPaymentDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Notes = "Some example notes",
            ObjectGroupID = "5",
            ObjectGroupOrder = 5,
            ObjectGroupTitle = "Example Group",
            ObjectHasCurrencySetting = true,
            OpeningBalance = "-1012.12",
            OpeningBalanceDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Order = 1,
            PcBalanceDifference = "123.45",
            PcCurrentBalance = "123.45",
            PcDebtAmount = "1012.12",
            PcOpeningBalance = "-1012.12",
            PcVirtualBalance = "123.45",
            PrimaryCurrencyCode = "EUR",
            PrimaryCurrencyDecimalPlaces = 2,
            PrimaryCurrencyID = "5",
            PrimaryCurrencyName = "Euro",
            PrimaryCurrencySymbol = "$",
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            VirtualBalance = "123.45",
            ZoomLevel = 6,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Attributes
        {
            Name = "My checking account",
            Type = ShortAccountTypeProperty.Asset,
            AccountNumber = "7009312345678",
            AccountRole = AccountRoleProperty.DefaultAsset,
            Bic = "BOFAUS3N",
            CreditCardType = CreditCardTypeProperty.MonthlyFull,
            DebtAmount = "1012.12",
            Iban = "GB98MIDL07009312345678",
            Interest = "5.3",
            InterestPeriod = InterestPeriodProperty.Monthly,
            LastActivity = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Latitude = 51.983333,
            LiabilityDirection = LiabilityDirectionProperty.Credit,
            LiabilityType = LiabilityTypeProperty.Loan,
            Longitude = 5.916667,
            MonthlyPaymentDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Notes = "Some example notes",
            ObjectGroupID = "5",
            ObjectGroupOrder = 5,
            ObjectGroupTitle = "Example Group",
            OpeningBalanceDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Order = 1,
            PcBalanceDifference = "123.45",
            PcCurrentBalance = "123.45",
            PcDebtAmount = "1012.12",
            ZoomLevel = 6,
        };

        Assert.Null(model.Active);
        Assert.False(model.RawData.ContainsKey("active"));
        Assert.Null(model.BalanceDifference);
        Assert.False(model.RawData.ContainsKey("balance_difference"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.CurrencyCode);
        Assert.False(model.RawData.ContainsKey("currency_code"));
        Assert.Null(model.CurrencyDecimalPlaces);
        Assert.False(model.RawData.ContainsKey("currency_decimal_places"));
        Assert.Null(model.CurrencyID);
        Assert.False(model.RawData.ContainsKey("currency_id"));
        Assert.Null(model.CurrencyName);
        Assert.False(model.RawData.ContainsKey("currency_name"));
        Assert.Null(model.CurrencySymbol);
        Assert.False(model.RawData.ContainsKey("currency_symbol"));
        Assert.Null(model.CurrentBalance);
        Assert.False(model.RawData.ContainsKey("current_balance"));
        Assert.Null(model.CurrentBalanceDate);
        Assert.False(model.RawData.ContainsKey("current_balance_date"));
        Assert.Null(model.IncludeNetWorth);
        Assert.False(model.RawData.ContainsKey("include_net_worth"));
        Assert.Null(model.ObjectHasCurrencySetting);
        Assert.False(model.RawData.ContainsKey("object_has_currency_setting"));
        Assert.Null(model.OpeningBalance);
        Assert.False(model.RawData.ContainsKey("opening_balance"));
        Assert.Null(model.PcOpeningBalance);
        Assert.False(model.RawData.ContainsKey("pc_opening_balance"));
        Assert.Null(model.PcVirtualBalance);
        Assert.False(model.RawData.ContainsKey("pc_virtual_balance"));
        Assert.Null(model.PrimaryCurrencyCode);
        Assert.False(model.RawData.ContainsKey("primary_currency_code"));
        Assert.Null(model.PrimaryCurrencyDecimalPlaces);
        Assert.False(model.RawData.ContainsKey("primary_currency_decimal_places"));
        Assert.Null(model.PrimaryCurrencyID);
        Assert.False(model.RawData.ContainsKey("primary_currency_id"));
        Assert.Null(model.PrimaryCurrencyName);
        Assert.False(model.RawData.ContainsKey("primary_currency_name"));
        Assert.Null(model.PrimaryCurrencySymbol);
        Assert.False(model.RawData.ContainsKey("primary_currency_symbol"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
        Assert.Null(model.VirtualBalance);
        Assert.False(model.RawData.ContainsKey("virtual_balance"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Attributes
        {
            Name = "My checking account",
            Type = ShortAccountTypeProperty.Asset,
            AccountNumber = "7009312345678",
            AccountRole = AccountRoleProperty.DefaultAsset,
            Bic = "BOFAUS3N",
            CreditCardType = CreditCardTypeProperty.MonthlyFull,
            DebtAmount = "1012.12",
            Iban = "GB98MIDL07009312345678",
            Interest = "5.3",
            InterestPeriod = InterestPeriodProperty.Monthly,
            LastActivity = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Latitude = 51.983333,
            LiabilityDirection = LiabilityDirectionProperty.Credit,
            LiabilityType = LiabilityTypeProperty.Loan,
            Longitude = 5.916667,
            MonthlyPaymentDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Notes = "Some example notes",
            ObjectGroupID = "5",
            ObjectGroupOrder = 5,
            ObjectGroupTitle = "Example Group",
            OpeningBalanceDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Order = 1,
            PcBalanceDifference = "123.45",
            PcCurrentBalance = "123.45",
            PcDebtAmount = "1012.12",
            ZoomLevel = 6,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Attributes
        {
            Name = "My checking account",
            Type = ShortAccountTypeProperty.Asset,
            AccountNumber = "7009312345678",
            AccountRole = AccountRoleProperty.DefaultAsset,
            Bic = "BOFAUS3N",
            CreditCardType = CreditCardTypeProperty.MonthlyFull,
            DebtAmount = "1012.12",
            Iban = "GB98MIDL07009312345678",
            Interest = "5.3",
            InterestPeriod = InterestPeriodProperty.Monthly,
            LastActivity = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Latitude = 51.983333,
            LiabilityDirection = LiabilityDirectionProperty.Credit,
            LiabilityType = LiabilityTypeProperty.Loan,
            Longitude = 5.916667,
            MonthlyPaymentDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Notes = "Some example notes",
            ObjectGroupID = "5",
            ObjectGroupOrder = 5,
            ObjectGroupTitle = "Example Group",
            OpeningBalanceDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Order = 1,
            PcBalanceDifference = "123.45",
            PcCurrentBalance = "123.45",
            PcDebtAmount = "1012.12",
            ZoomLevel = 6,

            // Null should be interpreted as omitted for these properties
            Active = null,
            BalanceDifference = null,
            CreatedAt = null,
            CurrencyCode = null,
            CurrencyDecimalPlaces = null,
            CurrencyID = null,
            CurrencyName = null,
            CurrencySymbol = null,
            CurrentBalance = null,
            CurrentBalanceDate = null,
            IncludeNetWorth = null,
            ObjectHasCurrencySetting = null,
            OpeningBalance = null,
            PcOpeningBalance = null,
            PcVirtualBalance = null,
            PrimaryCurrencyCode = null,
            PrimaryCurrencyDecimalPlaces = null,
            PrimaryCurrencyID = null,
            PrimaryCurrencyName = null,
            PrimaryCurrencySymbol = null,
            UpdatedAt = null,
            VirtualBalance = null,
        };

        Assert.Null(model.Active);
        Assert.False(model.RawData.ContainsKey("active"));
        Assert.Null(model.BalanceDifference);
        Assert.False(model.RawData.ContainsKey("balance_difference"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.CurrencyCode);
        Assert.False(model.RawData.ContainsKey("currency_code"));
        Assert.Null(model.CurrencyDecimalPlaces);
        Assert.False(model.RawData.ContainsKey("currency_decimal_places"));
        Assert.Null(model.CurrencyID);
        Assert.False(model.RawData.ContainsKey("currency_id"));
        Assert.Null(model.CurrencyName);
        Assert.False(model.RawData.ContainsKey("currency_name"));
        Assert.Null(model.CurrencySymbol);
        Assert.False(model.RawData.ContainsKey("currency_symbol"));
        Assert.Null(model.CurrentBalance);
        Assert.False(model.RawData.ContainsKey("current_balance"));
        Assert.Null(model.CurrentBalanceDate);
        Assert.False(model.RawData.ContainsKey("current_balance_date"));
        Assert.Null(model.IncludeNetWorth);
        Assert.False(model.RawData.ContainsKey("include_net_worth"));
        Assert.Null(model.ObjectHasCurrencySetting);
        Assert.False(model.RawData.ContainsKey("object_has_currency_setting"));
        Assert.Null(model.OpeningBalance);
        Assert.False(model.RawData.ContainsKey("opening_balance"));
        Assert.Null(model.PcOpeningBalance);
        Assert.False(model.RawData.ContainsKey("pc_opening_balance"));
        Assert.Null(model.PcVirtualBalance);
        Assert.False(model.RawData.ContainsKey("pc_virtual_balance"));
        Assert.Null(model.PrimaryCurrencyCode);
        Assert.False(model.RawData.ContainsKey("primary_currency_code"));
        Assert.Null(model.PrimaryCurrencyDecimalPlaces);
        Assert.False(model.RawData.ContainsKey("primary_currency_decimal_places"));
        Assert.Null(model.PrimaryCurrencyID);
        Assert.False(model.RawData.ContainsKey("primary_currency_id"));
        Assert.Null(model.PrimaryCurrencyName);
        Assert.False(model.RawData.ContainsKey("primary_currency_name"));
        Assert.Null(model.PrimaryCurrencySymbol);
        Assert.False(model.RawData.ContainsKey("primary_currency_symbol"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
        Assert.Null(model.VirtualBalance);
        Assert.False(model.RawData.ContainsKey("virtual_balance"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Attributes
        {
            Name = "My checking account",
            Type = ShortAccountTypeProperty.Asset,
            AccountNumber = "7009312345678",
            AccountRole = AccountRoleProperty.DefaultAsset,
            Bic = "BOFAUS3N",
            CreditCardType = CreditCardTypeProperty.MonthlyFull,
            DebtAmount = "1012.12",
            Iban = "GB98MIDL07009312345678",
            Interest = "5.3",
            InterestPeriod = InterestPeriodProperty.Monthly,
            LastActivity = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Latitude = 51.983333,
            LiabilityDirection = LiabilityDirectionProperty.Credit,
            LiabilityType = LiabilityTypeProperty.Loan,
            Longitude = 5.916667,
            MonthlyPaymentDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Notes = "Some example notes",
            ObjectGroupID = "5",
            ObjectGroupOrder = 5,
            ObjectGroupTitle = "Example Group",
            OpeningBalanceDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Order = 1,
            PcBalanceDifference = "123.45",
            PcCurrentBalance = "123.45",
            PcDebtAmount = "1012.12",
            ZoomLevel = 6,

            // Null should be interpreted as omitted for these properties
            Active = null,
            BalanceDifference = null,
            CreatedAt = null,
            CurrencyCode = null,
            CurrencyDecimalPlaces = null,
            CurrencyID = null,
            CurrencyName = null,
            CurrencySymbol = null,
            CurrentBalance = null,
            CurrentBalanceDate = null,
            IncludeNetWorth = null,
            ObjectHasCurrencySetting = null,
            OpeningBalance = null,
            PcOpeningBalance = null,
            PcVirtualBalance = null,
            PrimaryCurrencyCode = null,
            PrimaryCurrencyDecimalPlaces = null,
            PrimaryCurrencyID = null,
            PrimaryCurrencyName = null,
            PrimaryCurrencySymbol = null,
            UpdatedAt = null,
            VirtualBalance = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Attributes
        {
            Name = "My checking account",
            Type = ShortAccountTypeProperty.Asset,
            Active = false,
            BalanceDifference = "123.45",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "5",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            CurrentBalance = "123.45",
            CurrentBalanceDate = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
            IncludeNetWorth = true,
            ObjectHasCurrencySetting = true,
            OpeningBalance = "-1012.12",
            PcOpeningBalance = "-1012.12",
            PcVirtualBalance = "123.45",
            PrimaryCurrencyCode = "EUR",
            PrimaryCurrencyDecimalPlaces = 2,
            PrimaryCurrencyID = "5",
            PrimaryCurrencyName = "Euro",
            PrimaryCurrencySymbol = "$",
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            VirtualBalance = "123.45",
        };

        Assert.Null(model.AccountNumber);
        Assert.False(model.RawData.ContainsKey("account_number"));
        Assert.Null(model.AccountRole);
        Assert.False(model.RawData.ContainsKey("account_role"));
        Assert.Null(model.Bic);
        Assert.False(model.RawData.ContainsKey("bic"));
        Assert.Null(model.CreditCardType);
        Assert.False(model.RawData.ContainsKey("credit_card_type"));
        Assert.Null(model.DebtAmount);
        Assert.False(model.RawData.ContainsKey("debt_amount"));
        Assert.Null(model.Iban);
        Assert.False(model.RawData.ContainsKey("iban"));
        Assert.Null(model.Interest);
        Assert.False(model.RawData.ContainsKey("interest"));
        Assert.Null(model.InterestPeriod);
        Assert.False(model.RawData.ContainsKey("interest_period"));
        Assert.Null(model.LastActivity);
        Assert.False(model.RawData.ContainsKey("last_activity"));
        Assert.Null(model.Latitude);
        Assert.False(model.RawData.ContainsKey("latitude"));
        Assert.Null(model.LiabilityDirection);
        Assert.False(model.RawData.ContainsKey("liability_direction"));
        Assert.Null(model.LiabilityType);
        Assert.False(model.RawData.ContainsKey("liability_type"));
        Assert.Null(model.Longitude);
        Assert.False(model.RawData.ContainsKey("longitude"));
        Assert.Null(model.MonthlyPaymentDate);
        Assert.False(model.RawData.ContainsKey("monthly_payment_date"));
        Assert.Null(model.Notes);
        Assert.False(model.RawData.ContainsKey("notes"));
        Assert.Null(model.ObjectGroupID);
        Assert.False(model.RawData.ContainsKey("object_group_id"));
        Assert.Null(model.ObjectGroupOrder);
        Assert.False(model.RawData.ContainsKey("object_group_order"));
        Assert.Null(model.ObjectGroupTitle);
        Assert.False(model.RawData.ContainsKey("object_group_title"));
        Assert.Null(model.OpeningBalanceDate);
        Assert.False(model.RawData.ContainsKey("opening_balance_date"));
        Assert.Null(model.Order);
        Assert.False(model.RawData.ContainsKey("order"));
        Assert.Null(model.PcBalanceDifference);
        Assert.False(model.RawData.ContainsKey("pc_balance_difference"));
        Assert.Null(model.PcCurrentBalance);
        Assert.False(model.RawData.ContainsKey("pc_current_balance"));
        Assert.Null(model.PcDebtAmount);
        Assert.False(model.RawData.ContainsKey("pc_debt_amount"));
        Assert.Null(model.ZoomLevel);
        Assert.False(model.RawData.ContainsKey("zoom_level"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Attributes
        {
            Name = "My checking account",
            Type = ShortAccountTypeProperty.Asset,
            Active = false,
            BalanceDifference = "123.45",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "5",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            CurrentBalance = "123.45",
            CurrentBalanceDate = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
            IncludeNetWorth = true,
            ObjectHasCurrencySetting = true,
            OpeningBalance = "-1012.12",
            PcOpeningBalance = "-1012.12",
            PcVirtualBalance = "123.45",
            PrimaryCurrencyCode = "EUR",
            PrimaryCurrencyDecimalPlaces = 2,
            PrimaryCurrencyID = "5",
            PrimaryCurrencyName = "Euro",
            PrimaryCurrencySymbol = "$",
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            VirtualBalance = "123.45",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Attributes
        {
            Name = "My checking account",
            Type = ShortAccountTypeProperty.Asset,
            Active = false,
            BalanceDifference = "123.45",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "5",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            CurrentBalance = "123.45",
            CurrentBalanceDate = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
            IncludeNetWorth = true,
            ObjectHasCurrencySetting = true,
            OpeningBalance = "-1012.12",
            PcOpeningBalance = "-1012.12",
            PcVirtualBalance = "123.45",
            PrimaryCurrencyCode = "EUR",
            PrimaryCurrencyDecimalPlaces = 2,
            PrimaryCurrencyID = "5",
            PrimaryCurrencyName = "Euro",
            PrimaryCurrencySymbol = "$",
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            VirtualBalance = "123.45",

            AccountNumber = null,
            AccountRole = null,
            Bic = null,
            CreditCardType = null,
            DebtAmount = null,
            Iban = null,
            Interest = null,
            InterestPeriod = null,
            LastActivity = null,
            Latitude = null,
            LiabilityDirection = null,
            LiabilityType = null,
            Longitude = null,
            MonthlyPaymentDate = null,
            Notes = null,
            ObjectGroupID = null,
            ObjectGroupOrder = null,
            ObjectGroupTitle = null,
            OpeningBalanceDate = null,
            Order = null,
            PcBalanceDifference = null,
            PcCurrentBalance = null,
            PcDebtAmount = null,
            ZoomLevel = null,
        };

        Assert.Null(model.AccountNumber);
        Assert.True(model.RawData.ContainsKey("account_number"));
        Assert.Null(model.AccountRole);
        Assert.True(model.RawData.ContainsKey("account_role"));
        Assert.Null(model.Bic);
        Assert.True(model.RawData.ContainsKey("bic"));
        Assert.Null(model.CreditCardType);
        Assert.True(model.RawData.ContainsKey("credit_card_type"));
        Assert.Null(model.DebtAmount);
        Assert.True(model.RawData.ContainsKey("debt_amount"));
        Assert.Null(model.Iban);
        Assert.True(model.RawData.ContainsKey("iban"));
        Assert.Null(model.Interest);
        Assert.True(model.RawData.ContainsKey("interest"));
        Assert.Null(model.InterestPeriod);
        Assert.True(model.RawData.ContainsKey("interest_period"));
        Assert.Null(model.LastActivity);
        Assert.True(model.RawData.ContainsKey("last_activity"));
        Assert.Null(model.Latitude);
        Assert.True(model.RawData.ContainsKey("latitude"));
        Assert.Null(model.LiabilityDirection);
        Assert.True(model.RawData.ContainsKey("liability_direction"));
        Assert.Null(model.LiabilityType);
        Assert.True(model.RawData.ContainsKey("liability_type"));
        Assert.Null(model.Longitude);
        Assert.True(model.RawData.ContainsKey("longitude"));
        Assert.Null(model.MonthlyPaymentDate);
        Assert.True(model.RawData.ContainsKey("monthly_payment_date"));
        Assert.Null(model.Notes);
        Assert.True(model.RawData.ContainsKey("notes"));
        Assert.Null(model.ObjectGroupID);
        Assert.True(model.RawData.ContainsKey("object_group_id"));
        Assert.Null(model.ObjectGroupOrder);
        Assert.True(model.RawData.ContainsKey("object_group_order"));
        Assert.Null(model.ObjectGroupTitle);
        Assert.True(model.RawData.ContainsKey("object_group_title"));
        Assert.Null(model.OpeningBalanceDate);
        Assert.True(model.RawData.ContainsKey("opening_balance_date"));
        Assert.Null(model.Order);
        Assert.True(model.RawData.ContainsKey("order"));
        Assert.Null(model.PcBalanceDifference);
        Assert.True(model.RawData.ContainsKey("pc_balance_difference"));
        Assert.Null(model.PcCurrentBalance);
        Assert.True(model.RawData.ContainsKey("pc_current_balance"));
        Assert.Null(model.PcDebtAmount);
        Assert.True(model.RawData.ContainsKey("pc_debt_amount"));
        Assert.Null(model.ZoomLevel);
        Assert.True(model.RawData.ContainsKey("zoom_level"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Attributes
        {
            Name = "My checking account",
            Type = ShortAccountTypeProperty.Asset,
            Active = false,
            BalanceDifference = "123.45",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "5",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            CurrentBalance = "123.45",
            CurrentBalanceDate = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
            IncludeNetWorth = true,
            ObjectHasCurrencySetting = true,
            OpeningBalance = "-1012.12",
            PcOpeningBalance = "-1012.12",
            PcVirtualBalance = "123.45",
            PrimaryCurrencyCode = "EUR",
            PrimaryCurrencyDecimalPlaces = 2,
            PrimaryCurrencyID = "5",
            PrimaryCurrencyName = "Euro",
            PrimaryCurrencySymbol = "$",
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            VirtualBalance = "123.45",

            AccountNumber = null,
            AccountRole = null,
            Bic = null,
            CreditCardType = null,
            DebtAmount = null,
            Iban = null,
            Interest = null,
            InterestPeriod = null,
            LastActivity = null,
            Latitude = null,
            LiabilityDirection = null,
            LiabilityType = null,
            Longitude = null,
            MonthlyPaymentDate = null,
            Notes = null,
            ObjectGroupID = null,
            ObjectGroupOrder = null,
            ObjectGroupTitle = null,
            OpeningBalanceDate = null,
            Order = null,
            PcBalanceDifference = null,
            PcCurrentBalance = null,
            PcDebtAmount = null,
            ZoomLevel = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Attributes
        {
            Name = "My checking account",
            Type = ShortAccountTypeProperty.Asset,
            AccountNumber = "7009312345678",
            AccountRole = AccountRoleProperty.DefaultAsset,
            Active = false,
            BalanceDifference = "123.45",
            Bic = "BOFAUS3N",
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            CreditCardType = CreditCardTypeProperty.MonthlyFull,
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "5",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            CurrentBalance = "123.45",
            CurrentBalanceDate = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
            DebtAmount = "1012.12",
            Iban = "GB98MIDL07009312345678",
            IncludeNetWorth = true,
            Interest = "5.3",
            InterestPeriod = InterestPeriodProperty.Monthly,
            LastActivity = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Latitude = 51.983333,
            LiabilityDirection = LiabilityDirectionProperty.Credit,
            LiabilityType = LiabilityTypeProperty.Loan,
            Longitude = 5.916667,
            MonthlyPaymentDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Notes = "Some example notes",
            ObjectGroupID = "5",
            ObjectGroupOrder = 5,
            ObjectGroupTitle = "Example Group",
            ObjectHasCurrencySetting = true,
            OpeningBalance = "-1012.12",
            OpeningBalanceDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Order = 1,
            PcBalanceDifference = "123.45",
            PcCurrentBalance = "123.45",
            PcDebtAmount = "1012.12",
            PcOpeningBalance = "-1012.12",
            PcVirtualBalance = "123.45",
            PrimaryCurrencyCode = "EUR",
            PrimaryCurrencyDecimalPlaces = 2,
            PrimaryCurrencyID = "5",
            PrimaryCurrencyName = "Euro",
            PrimaryCurrencySymbol = "$",
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            VirtualBalance = "123.45",
            ZoomLevel = 6,
        };

        Attributes copied = new(model);

        Assert.Equal(model, copied);
    }
}
