using System;
using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Bills;

namespace EmceesProdTesting5.Tests.Models.Bills;

public class BillSingleTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BillSingle
        {
            Data = new()
            {
                ID = "2",
                Attributes = new()
                {
                    Active = true,
                    AmountAvg = "123.45",
                    AmountMax = "123.45",
                    AmountMin = "123.45",
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    CurrencyCode = "EUR",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencyName = "Euro",
                    CurrencySymbol = "$",
                    Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    EndDate = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
                    ExtensionDate = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
                    Name = "Rent",
                    NextExpectedMatch = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    NextExpectedMatchDiff = "today",
                    Notes = "Some example notes",
                    ObjectGroupID = "5",
                    ObjectGroupOrder = 5,
                    ObjectGroupTitle = "Example Group",
                    ObjectHasCurrencySetting = true,
                    Order = 1,
                    PaidDates =
                    [
                        new()
                        {
                            Amount = "123.45",
                            CurrencyCode = "EUR",
                            CurrencyDecimalPlaces = 2,
                            CurrencyID = "5",
                            CurrencyName = "Euro",
                            CurrencySymbol = "$",
                            Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                            ForeignAmount = "123.45",
                            PcAmount = "123.45",
                            PcForeignAmount = "123.45",
                            PrimaryCurrencyCode = "EUR",
                            PrimaryCurrencyDecimalPlaces = 2,
                            PrimaryCurrencyID = "5",
                            PrimaryCurrencyName = "Euro",
                            PrimaryCurrencySymbol = "$",
                            SubscriptionID = "123",
                            TransactionGroupID = "123",
                            TransactionJournalID = "123",
                        },
                    ],
                    PayDates = [DateTimeOffset.Parse("2026-04-01T00:00:00+00:00")],
                    PcAmountAvg = "123.45",
                    PcAmountMax = "123.45",
                    PcAmountMin = "123.45",
                    PrimaryCurrencyCode = "EUR",
                    PrimaryCurrencyDecimalPlaces = 2,
                    PrimaryCurrencyID = "5",
                    PrimaryCurrencyName = "Euro",
                    PrimaryCurrencySymbol = "$",
                    RepeatFreq = BillRepeatFrequency.Monthly,
                    Skip = 0,
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
                Type = "bills",
            },
        };

        BillRead expectedData = new()
        {
            ID = "2",
            Attributes = new()
            {
                Active = true,
                AmountAvg = "123.45",
                AmountMax = "123.45",
                AmountMin = "123.45",
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                CurrencyCode = "EUR",
                CurrencyDecimalPlaces = 2,
                CurrencyID = "5",
                CurrencyName = "Euro",
                CurrencySymbol = "$",
                Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                EndDate = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
                ExtensionDate = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
                Name = "Rent",
                NextExpectedMatch = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                NextExpectedMatchDiff = "today",
                Notes = "Some example notes",
                ObjectGroupID = "5",
                ObjectGroupOrder = 5,
                ObjectGroupTitle = "Example Group",
                ObjectHasCurrencySetting = true,
                Order = 1,
                PaidDates =
                [
                    new()
                    {
                        Amount = "123.45",
                        CurrencyCode = "EUR",
                        CurrencyDecimalPlaces = 2,
                        CurrencyID = "5",
                        CurrencyName = "Euro",
                        CurrencySymbol = "$",
                        Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                        ForeignAmount = "123.45",
                        PcAmount = "123.45",
                        PcForeignAmount = "123.45",
                        PrimaryCurrencyCode = "EUR",
                        PrimaryCurrencyDecimalPlaces = 2,
                        PrimaryCurrencyID = "5",
                        PrimaryCurrencyName = "Euro",
                        PrimaryCurrencySymbol = "$",
                        SubscriptionID = "123",
                        TransactionGroupID = "123",
                        TransactionJournalID = "123",
                    },
                ],
                PayDates = [DateTimeOffset.Parse("2026-04-01T00:00:00+00:00")],
                PcAmountAvg = "123.45",
                PcAmountMax = "123.45",
                PcAmountMin = "123.45",
                PrimaryCurrencyCode = "EUR",
                PrimaryCurrencyDecimalPlaces = 2,
                PrimaryCurrencyID = "5",
                PrimaryCurrencyName = "Euro",
                PrimaryCurrencySymbol = "$",
                RepeatFreq = BillRepeatFrequency.Monthly,
                Skip = 0,
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            },
            Type = "bills",
        };

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BillSingle
        {
            Data = new()
            {
                ID = "2",
                Attributes = new()
                {
                    Active = true,
                    AmountAvg = "123.45",
                    AmountMax = "123.45",
                    AmountMin = "123.45",
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    CurrencyCode = "EUR",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencyName = "Euro",
                    CurrencySymbol = "$",
                    Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    EndDate = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
                    ExtensionDate = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
                    Name = "Rent",
                    NextExpectedMatch = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    NextExpectedMatchDiff = "today",
                    Notes = "Some example notes",
                    ObjectGroupID = "5",
                    ObjectGroupOrder = 5,
                    ObjectGroupTitle = "Example Group",
                    ObjectHasCurrencySetting = true,
                    Order = 1,
                    PaidDates =
                    [
                        new()
                        {
                            Amount = "123.45",
                            CurrencyCode = "EUR",
                            CurrencyDecimalPlaces = 2,
                            CurrencyID = "5",
                            CurrencyName = "Euro",
                            CurrencySymbol = "$",
                            Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                            ForeignAmount = "123.45",
                            PcAmount = "123.45",
                            PcForeignAmount = "123.45",
                            PrimaryCurrencyCode = "EUR",
                            PrimaryCurrencyDecimalPlaces = 2,
                            PrimaryCurrencyID = "5",
                            PrimaryCurrencyName = "Euro",
                            PrimaryCurrencySymbol = "$",
                            SubscriptionID = "123",
                            TransactionGroupID = "123",
                            TransactionJournalID = "123",
                        },
                    ],
                    PayDates = [DateTimeOffset.Parse("2026-04-01T00:00:00+00:00")],
                    PcAmountAvg = "123.45",
                    PcAmountMax = "123.45",
                    PcAmountMin = "123.45",
                    PrimaryCurrencyCode = "EUR",
                    PrimaryCurrencyDecimalPlaces = 2,
                    PrimaryCurrencyID = "5",
                    PrimaryCurrencyName = "Euro",
                    PrimaryCurrencySymbol = "$",
                    RepeatFreq = BillRepeatFrequency.Monthly,
                    Skip = 0,
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
                Type = "bills",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BillSingle>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BillSingle
        {
            Data = new()
            {
                ID = "2",
                Attributes = new()
                {
                    Active = true,
                    AmountAvg = "123.45",
                    AmountMax = "123.45",
                    AmountMin = "123.45",
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    CurrencyCode = "EUR",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencyName = "Euro",
                    CurrencySymbol = "$",
                    Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    EndDate = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
                    ExtensionDate = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
                    Name = "Rent",
                    NextExpectedMatch = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    NextExpectedMatchDiff = "today",
                    Notes = "Some example notes",
                    ObjectGroupID = "5",
                    ObjectGroupOrder = 5,
                    ObjectGroupTitle = "Example Group",
                    ObjectHasCurrencySetting = true,
                    Order = 1,
                    PaidDates =
                    [
                        new()
                        {
                            Amount = "123.45",
                            CurrencyCode = "EUR",
                            CurrencyDecimalPlaces = 2,
                            CurrencyID = "5",
                            CurrencyName = "Euro",
                            CurrencySymbol = "$",
                            Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                            ForeignAmount = "123.45",
                            PcAmount = "123.45",
                            PcForeignAmount = "123.45",
                            PrimaryCurrencyCode = "EUR",
                            PrimaryCurrencyDecimalPlaces = 2,
                            PrimaryCurrencyID = "5",
                            PrimaryCurrencyName = "Euro",
                            PrimaryCurrencySymbol = "$",
                            SubscriptionID = "123",
                            TransactionGroupID = "123",
                            TransactionJournalID = "123",
                        },
                    ],
                    PayDates = [DateTimeOffset.Parse("2026-04-01T00:00:00+00:00")],
                    PcAmountAvg = "123.45",
                    PcAmountMax = "123.45",
                    PcAmountMin = "123.45",
                    PrimaryCurrencyCode = "EUR",
                    PrimaryCurrencyDecimalPlaces = 2,
                    PrimaryCurrencyID = "5",
                    PrimaryCurrencyName = "Euro",
                    PrimaryCurrencySymbol = "$",
                    RepeatFreq = BillRepeatFrequency.Monthly,
                    Skip = 0,
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
                Type = "bills",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BillSingle>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BillRead expectedData = new()
        {
            ID = "2",
            Attributes = new()
            {
                Active = true,
                AmountAvg = "123.45",
                AmountMax = "123.45",
                AmountMin = "123.45",
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                CurrencyCode = "EUR",
                CurrencyDecimalPlaces = 2,
                CurrencyID = "5",
                CurrencyName = "Euro",
                CurrencySymbol = "$",
                Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                EndDate = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
                ExtensionDate = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
                Name = "Rent",
                NextExpectedMatch = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                NextExpectedMatchDiff = "today",
                Notes = "Some example notes",
                ObjectGroupID = "5",
                ObjectGroupOrder = 5,
                ObjectGroupTitle = "Example Group",
                ObjectHasCurrencySetting = true,
                Order = 1,
                PaidDates =
                [
                    new()
                    {
                        Amount = "123.45",
                        CurrencyCode = "EUR",
                        CurrencyDecimalPlaces = 2,
                        CurrencyID = "5",
                        CurrencyName = "Euro",
                        CurrencySymbol = "$",
                        Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                        ForeignAmount = "123.45",
                        PcAmount = "123.45",
                        PcForeignAmount = "123.45",
                        PrimaryCurrencyCode = "EUR",
                        PrimaryCurrencyDecimalPlaces = 2,
                        PrimaryCurrencyID = "5",
                        PrimaryCurrencyName = "Euro",
                        PrimaryCurrencySymbol = "$",
                        SubscriptionID = "123",
                        TransactionGroupID = "123",
                        TransactionJournalID = "123",
                    },
                ],
                PayDates = [DateTimeOffset.Parse("2026-04-01T00:00:00+00:00")],
                PcAmountAvg = "123.45",
                PcAmountMax = "123.45",
                PcAmountMin = "123.45",
                PrimaryCurrencyCode = "EUR",
                PrimaryCurrencyDecimalPlaces = 2,
                PrimaryCurrencyID = "5",
                PrimaryCurrencyName = "Euro",
                PrimaryCurrencySymbol = "$",
                RepeatFreq = BillRepeatFrequency.Monthly,
                Skip = 0,
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            },
            Type = "bills",
        };

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BillSingle
        {
            Data = new()
            {
                ID = "2",
                Attributes = new()
                {
                    Active = true,
                    AmountAvg = "123.45",
                    AmountMax = "123.45",
                    AmountMin = "123.45",
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    CurrencyCode = "EUR",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencyName = "Euro",
                    CurrencySymbol = "$",
                    Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    EndDate = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
                    ExtensionDate = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
                    Name = "Rent",
                    NextExpectedMatch = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    NextExpectedMatchDiff = "today",
                    Notes = "Some example notes",
                    ObjectGroupID = "5",
                    ObjectGroupOrder = 5,
                    ObjectGroupTitle = "Example Group",
                    ObjectHasCurrencySetting = true,
                    Order = 1,
                    PaidDates =
                    [
                        new()
                        {
                            Amount = "123.45",
                            CurrencyCode = "EUR",
                            CurrencyDecimalPlaces = 2,
                            CurrencyID = "5",
                            CurrencyName = "Euro",
                            CurrencySymbol = "$",
                            Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                            ForeignAmount = "123.45",
                            PcAmount = "123.45",
                            PcForeignAmount = "123.45",
                            PrimaryCurrencyCode = "EUR",
                            PrimaryCurrencyDecimalPlaces = 2,
                            PrimaryCurrencyID = "5",
                            PrimaryCurrencyName = "Euro",
                            PrimaryCurrencySymbol = "$",
                            SubscriptionID = "123",
                            TransactionGroupID = "123",
                            TransactionJournalID = "123",
                        },
                    ],
                    PayDates = [DateTimeOffset.Parse("2026-04-01T00:00:00+00:00")],
                    PcAmountAvg = "123.45",
                    PcAmountMax = "123.45",
                    PcAmountMin = "123.45",
                    PrimaryCurrencyCode = "EUR",
                    PrimaryCurrencyDecimalPlaces = 2,
                    PrimaryCurrencyID = "5",
                    PrimaryCurrencyName = "Euro",
                    PrimaryCurrencySymbol = "$",
                    RepeatFreq = BillRepeatFrequency.Monthly,
                    Skip = 0,
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
                Type = "bills",
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BillSingle
        {
            Data = new()
            {
                ID = "2",
                Attributes = new()
                {
                    Active = true,
                    AmountAvg = "123.45",
                    AmountMax = "123.45",
                    AmountMin = "123.45",
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    CurrencyCode = "EUR",
                    CurrencyDecimalPlaces = 2,
                    CurrencyID = "5",
                    CurrencyName = "Euro",
                    CurrencySymbol = "$",
                    Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    EndDate = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
                    ExtensionDate = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
                    Name = "Rent",
                    NextExpectedMatch = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    NextExpectedMatchDiff = "today",
                    Notes = "Some example notes",
                    ObjectGroupID = "5",
                    ObjectGroupOrder = 5,
                    ObjectGroupTitle = "Example Group",
                    ObjectHasCurrencySetting = true,
                    Order = 1,
                    PaidDates =
                    [
                        new()
                        {
                            Amount = "123.45",
                            CurrencyCode = "EUR",
                            CurrencyDecimalPlaces = 2,
                            CurrencyID = "5",
                            CurrencyName = "Euro",
                            CurrencySymbol = "$",
                            Date = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                            ForeignAmount = "123.45",
                            PcAmount = "123.45",
                            PcForeignAmount = "123.45",
                            PrimaryCurrencyCode = "EUR",
                            PrimaryCurrencyDecimalPlaces = 2,
                            PrimaryCurrencyID = "5",
                            PrimaryCurrencyName = "Euro",
                            PrimaryCurrencySymbol = "$",
                            SubscriptionID = "123",
                            TransactionGroupID = "123",
                            TransactionJournalID = "123",
                        },
                    ],
                    PayDates = [DateTimeOffset.Parse("2026-04-01T00:00:00+00:00")],
                    PcAmountAvg = "123.45",
                    PcAmountMax = "123.45",
                    PcAmountMin = "123.45",
                    PrimaryCurrencyCode = "EUR",
                    PrimaryCurrencyDecimalPlaces = 2,
                    PrimaryCurrencyID = "5",
                    PrimaryCurrencyName = "Euro",
                    PrimaryCurrencySymbol = "$",
                    RepeatFreq = BillRepeatFrequency.Monthly,
                    Skip = 0,
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
                Type = "bills",
            },
        };

        BillSingle copied = new(model);

        Assert.Equal(model, copied);
    }
}
