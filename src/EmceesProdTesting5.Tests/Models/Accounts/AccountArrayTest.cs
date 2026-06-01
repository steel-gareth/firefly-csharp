using System;
using System.Collections.Generic;
using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Accounts;

namespace EmceesProdTesting5.Tests.Models.Accounts;

public class AccountArrayTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AccountArray
        {
            Data =
            [
                new()
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
                },
            ],
            Meta = new()
            {
                Pagination = new()
                {
                    Count = 20,
                    CurrentPage = 1,
                    PerPage = 100,
                    Total = 3,
                    TotalPages = 1,
                },
            },
        };

        List<AccountRead> expectedData =
        [
            new()
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
            },
        ];
        Meta expectedMeta = new()
        {
            Pagination = new()
            {
                Count = 20,
                CurrentPage = 1,
                PerPage = 100,
                Total = 3,
                TotalPages = 1,
            },
        };

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedMeta, model.Meta);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AccountArray
        {
            Data =
            [
                new()
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
                },
            ],
            Meta = new()
            {
                Pagination = new()
                {
                    Count = 20,
                    CurrentPage = 1,
                    PerPage = 100,
                    Total = 3,
                    TotalPages = 1,
                },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountArray>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AccountArray
        {
            Data =
            [
                new()
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
                },
            ],
            Meta = new()
            {
                Pagination = new()
                {
                    Count = 20,
                    CurrentPage = 1,
                    PerPage = 100,
                    Total = 3,
                    TotalPages = 1,
                },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountArray>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<AccountRead> expectedData =
        [
            new()
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
            },
        ];
        Meta expectedMeta = new()
        {
            Pagination = new()
            {
                Count = 20,
                CurrentPage = 1,
                PerPage = 100,
                Total = 3,
                TotalPages = 1,
            },
        };

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedMeta, deserialized.Meta);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AccountArray
        {
            Data =
            [
                new()
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
                },
            ],
            Meta = new()
            {
                Pagination = new()
                {
                    Count = 20,
                    CurrentPage = 1,
                    PerPage = 100,
                    Total = 3,
                    TotalPages = 1,
                },
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AccountArray
        {
            Data =
            [
                new()
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
                },
            ],
            Meta = new()
            {
                Pagination = new()
                {
                    Count = 20,
                    CurrentPage = 1,
                    PerPage = 100,
                    Total = 3,
                    TotalPages = 1,
                },
            },
        };

        AccountArray copied = new(model);

        Assert.Equal(model, copied);
    }
}
