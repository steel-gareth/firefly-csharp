using System;
using System.Collections.Generic;
using System.Text.Json;
using Firefly.Core;
using Firefly.Models.Bills;

namespace Firefly.Tests.Models.Bills;

public class BillReadTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BillRead
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

        string expectedID = "2";
        Attributes expectedAttributes = new()
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
        };
        string expectedType = "bills";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAttributes, model.Attributes);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BillRead
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BillRead>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BillRead
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BillRead>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "2";
        Attributes expectedAttributes = new()
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
        };
        string expectedType = "bills";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAttributes, deserialized.Attributes);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BillRead
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

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BillRead
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

        BillRead copied = new(model);

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
        };

        bool expectedActive = true;
        string expectedAmountAvg = "123.45";
        string expectedAmountMax = "123.45";
        string expectedAmountMin = "123.45";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        string expectedCurrencyCode = "EUR";
        int expectedCurrencyDecimalPlaces = 2;
        string expectedCurrencyID = "5";
        string expectedCurrencyName = "Euro";
        string expectedCurrencySymbol = "$";
        DateTimeOffset expectedDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        DateTimeOffset expectedEndDate = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00");
        DateTimeOffset expectedExtensionDate = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00");
        string expectedName = "Rent";
        DateTimeOffset expectedNextExpectedMatch = DateTimeOffset.Parse(
            "2026-04-01T00:00:00+00:00"
        );
        string expectedNextExpectedMatchDiff = "today";
        string expectedNotes = "Some example notes";
        string expectedObjectGroupID = "5";
        int expectedObjectGroupOrder = 5;
        string expectedObjectGroupTitle = "Example Group";
        bool expectedObjectHasCurrencySetting = true;
        int expectedOrder = 1;
        List<PaidDate> expectedPaidDates =
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
        ];
        List<DateTimeOffset> expectedPayDates = [DateTimeOffset.Parse("2026-04-01T00:00:00+00:00")];
        string expectedPcAmountAvg = "123.45";
        string expectedPcAmountMax = "123.45";
        string expectedPcAmountMin = "123.45";
        string expectedPrimaryCurrencyCode = "EUR";
        int expectedPrimaryCurrencyDecimalPlaces = 2;
        string expectedPrimaryCurrencyID = "5";
        string expectedPrimaryCurrencyName = "Euro";
        string expectedPrimaryCurrencySymbol = "$";
        ApiEnum<string, BillRepeatFrequency> expectedRepeatFreq = BillRepeatFrequency.Monthly;
        int expectedSkip = 0;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");

        Assert.Equal(expectedActive, model.Active);
        Assert.Equal(expectedAmountAvg, model.AmountAvg);
        Assert.Equal(expectedAmountMax, model.AmountMax);
        Assert.Equal(expectedAmountMin, model.AmountMin);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCurrencyCode, model.CurrencyCode);
        Assert.Equal(expectedCurrencyDecimalPlaces, model.CurrencyDecimalPlaces);
        Assert.Equal(expectedCurrencyID, model.CurrencyID);
        Assert.Equal(expectedCurrencyName, model.CurrencyName);
        Assert.Equal(expectedCurrencySymbol, model.CurrencySymbol);
        Assert.Equal(expectedDate, model.Date);
        Assert.Equal(expectedEndDate, model.EndDate);
        Assert.Equal(expectedExtensionDate, model.ExtensionDate);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedNextExpectedMatch, model.NextExpectedMatch);
        Assert.Equal(expectedNextExpectedMatchDiff, model.NextExpectedMatchDiff);
        Assert.Equal(expectedNotes, model.Notes);
        Assert.Equal(expectedObjectGroupID, model.ObjectGroupID);
        Assert.Equal(expectedObjectGroupOrder, model.ObjectGroupOrder);
        Assert.Equal(expectedObjectGroupTitle, model.ObjectGroupTitle);
        Assert.Equal(expectedObjectHasCurrencySetting, model.ObjectHasCurrencySetting);
        Assert.Equal(expectedOrder, model.Order);
        Assert.NotNull(model.PaidDates);
        Assert.Equal(expectedPaidDates.Count, model.PaidDates.Count);
        for (int i = 0; i < expectedPaidDates.Count; i++)
        {
            Assert.Equal(expectedPaidDates[i], model.PaidDates[i]);
        }
        Assert.NotNull(model.PayDates);
        Assert.Equal(expectedPayDates.Count, model.PayDates.Count);
        for (int i = 0; i < expectedPayDates.Count; i++)
        {
            Assert.Equal(expectedPayDates[i], model.PayDates[i]);
        }
        Assert.Equal(expectedPcAmountAvg, model.PcAmountAvg);
        Assert.Equal(expectedPcAmountMax, model.PcAmountMax);
        Assert.Equal(expectedPcAmountMin, model.PcAmountMin);
        Assert.Equal(expectedPrimaryCurrencyCode, model.PrimaryCurrencyCode);
        Assert.Equal(expectedPrimaryCurrencyDecimalPlaces, model.PrimaryCurrencyDecimalPlaces);
        Assert.Equal(expectedPrimaryCurrencyID, model.PrimaryCurrencyID);
        Assert.Equal(expectedPrimaryCurrencyName, model.PrimaryCurrencyName);
        Assert.Equal(expectedPrimaryCurrencySymbol, model.PrimaryCurrencySymbol);
        Assert.Equal(expectedRepeatFreq, model.RepeatFreq);
        Assert.Equal(expectedSkip, model.Skip);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Attributes
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Attributes>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedActive = true;
        string expectedAmountAvg = "123.45";
        string expectedAmountMax = "123.45";
        string expectedAmountMin = "123.45";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        string expectedCurrencyCode = "EUR";
        int expectedCurrencyDecimalPlaces = 2;
        string expectedCurrencyID = "5";
        string expectedCurrencyName = "Euro";
        string expectedCurrencySymbol = "$";
        DateTimeOffset expectedDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        DateTimeOffset expectedEndDate = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00");
        DateTimeOffset expectedExtensionDate = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00");
        string expectedName = "Rent";
        DateTimeOffset expectedNextExpectedMatch = DateTimeOffset.Parse(
            "2026-04-01T00:00:00+00:00"
        );
        string expectedNextExpectedMatchDiff = "today";
        string expectedNotes = "Some example notes";
        string expectedObjectGroupID = "5";
        int expectedObjectGroupOrder = 5;
        string expectedObjectGroupTitle = "Example Group";
        bool expectedObjectHasCurrencySetting = true;
        int expectedOrder = 1;
        List<PaidDate> expectedPaidDates =
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
        ];
        List<DateTimeOffset> expectedPayDates = [DateTimeOffset.Parse("2026-04-01T00:00:00+00:00")];
        string expectedPcAmountAvg = "123.45";
        string expectedPcAmountMax = "123.45";
        string expectedPcAmountMin = "123.45";
        string expectedPrimaryCurrencyCode = "EUR";
        int expectedPrimaryCurrencyDecimalPlaces = 2;
        string expectedPrimaryCurrencyID = "5";
        string expectedPrimaryCurrencyName = "Euro";
        string expectedPrimaryCurrencySymbol = "$";
        ApiEnum<string, BillRepeatFrequency> expectedRepeatFreq = BillRepeatFrequency.Monthly;
        int expectedSkip = 0;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");

        Assert.Equal(expectedActive, deserialized.Active);
        Assert.Equal(expectedAmountAvg, deserialized.AmountAvg);
        Assert.Equal(expectedAmountMax, deserialized.AmountMax);
        Assert.Equal(expectedAmountMin, deserialized.AmountMin);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCurrencyCode, deserialized.CurrencyCode);
        Assert.Equal(expectedCurrencyDecimalPlaces, deserialized.CurrencyDecimalPlaces);
        Assert.Equal(expectedCurrencyID, deserialized.CurrencyID);
        Assert.Equal(expectedCurrencyName, deserialized.CurrencyName);
        Assert.Equal(expectedCurrencySymbol, deserialized.CurrencySymbol);
        Assert.Equal(expectedDate, deserialized.Date);
        Assert.Equal(expectedEndDate, deserialized.EndDate);
        Assert.Equal(expectedExtensionDate, deserialized.ExtensionDate);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedNextExpectedMatch, deserialized.NextExpectedMatch);
        Assert.Equal(expectedNextExpectedMatchDiff, deserialized.NextExpectedMatchDiff);
        Assert.Equal(expectedNotes, deserialized.Notes);
        Assert.Equal(expectedObjectGroupID, deserialized.ObjectGroupID);
        Assert.Equal(expectedObjectGroupOrder, deserialized.ObjectGroupOrder);
        Assert.Equal(expectedObjectGroupTitle, deserialized.ObjectGroupTitle);
        Assert.Equal(expectedObjectHasCurrencySetting, deserialized.ObjectHasCurrencySetting);
        Assert.Equal(expectedOrder, deserialized.Order);
        Assert.NotNull(deserialized.PaidDates);
        Assert.Equal(expectedPaidDates.Count, deserialized.PaidDates.Count);
        for (int i = 0; i < expectedPaidDates.Count; i++)
        {
            Assert.Equal(expectedPaidDates[i], deserialized.PaidDates[i]);
        }
        Assert.NotNull(deserialized.PayDates);
        Assert.Equal(expectedPayDates.Count, deserialized.PayDates.Count);
        for (int i = 0; i < expectedPayDates.Count; i++)
        {
            Assert.Equal(expectedPayDates[i], deserialized.PayDates[i]);
        }
        Assert.Equal(expectedPcAmountAvg, deserialized.PcAmountAvg);
        Assert.Equal(expectedPcAmountMax, deserialized.PcAmountMax);
        Assert.Equal(expectedPcAmountMin, deserialized.PcAmountMin);
        Assert.Equal(expectedPrimaryCurrencyCode, deserialized.PrimaryCurrencyCode);
        Assert.Equal(
            expectedPrimaryCurrencyDecimalPlaces,
            deserialized.PrimaryCurrencyDecimalPlaces
        );
        Assert.Equal(expectedPrimaryCurrencyID, deserialized.PrimaryCurrencyID);
        Assert.Equal(expectedPrimaryCurrencyName, deserialized.PrimaryCurrencyName);
        Assert.Equal(expectedPrimaryCurrencySymbol, deserialized.PrimaryCurrencySymbol);
        Assert.Equal(expectedRepeatFreq, deserialized.RepeatFreq);
        Assert.Equal(expectedSkip, deserialized.Skip);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Attributes
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Attributes
        {
            EndDate = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
            ExtensionDate = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
            NextExpectedMatch = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            NextExpectedMatchDiff = "today",
            Notes = "Some example notes",
            ObjectGroupID = "5",
            ObjectGroupOrder = 5,
            ObjectGroupTitle = "Example Group",
        };

        Assert.Null(model.Active);
        Assert.False(model.RawData.ContainsKey("active"));
        Assert.Null(model.AmountAvg);
        Assert.False(model.RawData.ContainsKey("amount_avg"));
        Assert.Null(model.AmountMax);
        Assert.False(model.RawData.ContainsKey("amount_max"));
        Assert.Null(model.AmountMin);
        Assert.False(model.RawData.ContainsKey("amount_min"));
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
        Assert.Null(model.Date);
        Assert.False(model.RawData.ContainsKey("date"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.ObjectHasCurrencySetting);
        Assert.False(model.RawData.ContainsKey("object_has_currency_setting"));
        Assert.Null(model.Order);
        Assert.False(model.RawData.ContainsKey("order"));
        Assert.Null(model.PaidDates);
        Assert.False(model.RawData.ContainsKey("paid_dates"));
        Assert.Null(model.PayDates);
        Assert.False(model.RawData.ContainsKey("pay_dates"));
        Assert.Null(model.PcAmountAvg);
        Assert.False(model.RawData.ContainsKey("pc_amount_avg"));
        Assert.Null(model.PcAmountMax);
        Assert.False(model.RawData.ContainsKey("pc_amount_max"));
        Assert.Null(model.PcAmountMin);
        Assert.False(model.RawData.ContainsKey("pc_amount_min"));
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
        Assert.Null(model.RepeatFreq);
        Assert.False(model.RawData.ContainsKey("repeat_freq"));
        Assert.Null(model.Skip);
        Assert.False(model.RawData.ContainsKey("skip"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Attributes
        {
            EndDate = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
            ExtensionDate = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
            NextExpectedMatch = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            NextExpectedMatchDiff = "today",
            Notes = "Some example notes",
            ObjectGroupID = "5",
            ObjectGroupOrder = 5,
            ObjectGroupTitle = "Example Group",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Attributes
        {
            EndDate = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
            ExtensionDate = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
            NextExpectedMatch = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            NextExpectedMatchDiff = "today",
            Notes = "Some example notes",
            ObjectGroupID = "5",
            ObjectGroupOrder = 5,
            ObjectGroupTitle = "Example Group",

            // Null should be interpreted as omitted for these properties
            Active = null,
            AmountAvg = null,
            AmountMax = null,
            AmountMin = null,
            CreatedAt = null,
            CurrencyCode = null,
            CurrencyDecimalPlaces = null,
            CurrencyID = null,
            CurrencyName = null,
            CurrencySymbol = null,
            Date = null,
            Name = null,
            ObjectHasCurrencySetting = null,
            Order = null,
            PaidDates = null,
            PayDates = null,
            PcAmountAvg = null,
            PcAmountMax = null,
            PcAmountMin = null,
            PrimaryCurrencyCode = null,
            PrimaryCurrencyDecimalPlaces = null,
            PrimaryCurrencyID = null,
            PrimaryCurrencyName = null,
            PrimaryCurrencySymbol = null,
            RepeatFreq = null,
            Skip = null,
            UpdatedAt = null,
        };

        Assert.Null(model.Active);
        Assert.False(model.RawData.ContainsKey("active"));
        Assert.Null(model.AmountAvg);
        Assert.False(model.RawData.ContainsKey("amount_avg"));
        Assert.Null(model.AmountMax);
        Assert.False(model.RawData.ContainsKey("amount_max"));
        Assert.Null(model.AmountMin);
        Assert.False(model.RawData.ContainsKey("amount_min"));
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
        Assert.Null(model.Date);
        Assert.False(model.RawData.ContainsKey("date"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.ObjectHasCurrencySetting);
        Assert.False(model.RawData.ContainsKey("object_has_currency_setting"));
        Assert.Null(model.Order);
        Assert.False(model.RawData.ContainsKey("order"));
        Assert.Null(model.PaidDates);
        Assert.False(model.RawData.ContainsKey("paid_dates"));
        Assert.Null(model.PayDates);
        Assert.False(model.RawData.ContainsKey("pay_dates"));
        Assert.Null(model.PcAmountAvg);
        Assert.False(model.RawData.ContainsKey("pc_amount_avg"));
        Assert.Null(model.PcAmountMax);
        Assert.False(model.RawData.ContainsKey("pc_amount_max"));
        Assert.Null(model.PcAmountMin);
        Assert.False(model.RawData.ContainsKey("pc_amount_min"));
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
        Assert.Null(model.RepeatFreq);
        Assert.False(model.RawData.ContainsKey("repeat_freq"));
        Assert.Null(model.Skip);
        Assert.False(model.RawData.ContainsKey("skip"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Attributes
        {
            EndDate = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
            ExtensionDate = DateTimeOffset.Parse("2026-04-30T23:59:59+00:00"),
            NextExpectedMatch = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            NextExpectedMatchDiff = "today",
            Notes = "Some example notes",
            ObjectGroupID = "5",
            ObjectGroupOrder = 5,
            ObjectGroupTitle = "Example Group",

            // Null should be interpreted as omitted for these properties
            Active = null,
            AmountAvg = null,
            AmountMax = null,
            AmountMin = null,
            CreatedAt = null,
            CurrencyCode = null,
            CurrencyDecimalPlaces = null,
            CurrencyID = null,
            CurrencyName = null,
            CurrencySymbol = null,
            Date = null,
            Name = null,
            ObjectHasCurrencySetting = null,
            Order = null,
            PaidDates = null,
            PayDates = null,
            PcAmountAvg = null,
            PcAmountMax = null,
            PcAmountMin = null,
            PrimaryCurrencyCode = null,
            PrimaryCurrencyDecimalPlaces = null,
            PrimaryCurrencyID = null,
            PrimaryCurrencyName = null,
            PrimaryCurrencySymbol = null,
            RepeatFreq = null,
            Skip = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Attributes
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
            Name = "Rent",
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
        };

        Assert.Null(model.EndDate);
        Assert.False(model.RawData.ContainsKey("end_date"));
        Assert.Null(model.ExtensionDate);
        Assert.False(model.RawData.ContainsKey("extension_date"));
        Assert.Null(model.NextExpectedMatch);
        Assert.False(model.RawData.ContainsKey("next_expected_match"));
        Assert.Null(model.NextExpectedMatchDiff);
        Assert.False(model.RawData.ContainsKey("next_expected_match_diff"));
        Assert.Null(model.Notes);
        Assert.False(model.RawData.ContainsKey("notes"));
        Assert.Null(model.ObjectGroupID);
        Assert.False(model.RawData.ContainsKey("object_group_id"));
        Assert.Null(model.ObjectGroupOrder);
        Assert.False(model.RawData.ContainsKey("object_group_order"));
        Assert.Null(model.ObjectGroupTitle);
        Assert.False(model.RawData.ContainsKey("object_group_title"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Attributes
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
            Name = "Rent",
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Attributes
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
            Name = "Rent",
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

            EndDate = null,
            ExtensionDate = null,
            NextExpectedMatch = null,
            NextExpectedMatchDiff = null,
            Notes = null,
            ObjectGroupID = null,
            ObjectGroupOrder = null,
            ObjectGroupTitle = null,
        };

        Assert.Null(model.EndDate);
        Assert.True(model.RawData.ContainsKey("end_date"));
        Assert.Null(model.ExtensionDate);
        Assert.True(model.RawData.ContainsKey("extension_date"));
        Assert.Null(model.NextExpectedMatch);
        Assert.True(model.RawData.ContainsKey("next_expected_match"));
        Assert.Null(model.NextExpectedMatchDiff);
        Assert.True(model.RawData.ContainsKey("next_expected_match_diff"));
        Assert.Null(model.Notes);
        Assert.True(model.RawData.ContainsKey("notes"));
        Assert.Null(model.ObjectGroupID);
        Assert.True(model.RawData.ContainsKey("object_group_id"));
        Assert.Null(model.ObjectGroupOrder);
        Assert.True(model.RawData.ContainsKey("object_group_order"));
        Assert.Null(model.ObjectGroupTitle);
        Assert.True(model.RawData.ContainsKey("object_group_title"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Attributes
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
            Name = "Rent",
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

            EndDate = null,
            ExtensionDate = null,
            NextExpectedMatch = null,
            NextExpectedMatchDiff = null,
            Notes = null,
            ObjectGroupID = null,
            ObjectGroupOrder = null,
            ObjectGroupTitle = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Attributes
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
        };

        Attributes copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PaidDateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PaidDate
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
        };

        string expectedAmount = "123.45";
        string expectedCurrencyCode = "EUR";
        int expectedCurrencyDecimalPlaces = 2;
        string expectedCurrencyID = "5";
        string expectedCurrencyName = "Euro";
        string expectedCurrencySymbol = "$";
        DateTimeOffset expectedDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        string expectedForeignAmount = "123.45";
        string expectedPcAmount = "123.45";
        string expectedPcForeignAmount = "123.45";
        string expectedPrimaryCurrencyCode = "EUR";
        int expectedPrimaryCurrencyDecimalPlaces = 2;
        string expectedPrimaryCurrencyID = "5";
        string expectedPrimaryCurrencyName = "Euro";
        string expectedPrimaryCurrencySymbol = "$";
        string expectedSubscriptionID = "123";
        string expectedTransactionGroupID = "123";
        string expectedTransactionJournalID = "123";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrencyCode, model.CurrencyCode);
        Assert.Equal(expectedCurrencyDecimalPlaces, model.CurrencyDecimalPlaces);
        Assert.Equal(expectedCurrencyID, model.CurrencyID);
        Assert.Equal(expectedCurrencyName, model.CurrencyName);
        Assert.Equal(expectedCurrencySymbol, model.CurrencySymbol);
        Assert.Equal(expectedDate, model.Date);
        Assert.Equal(expectedForeignAmount, model.ForeignAmount);
        Assert.Equal(expectedPcAmount, model.PcAmount);
        Assert.Equal(expectedPcForeignAmount, model.PcForeignAmount);
        Assert.Equal(expectedPrimaryCurrencyCode, model.PrimaryCurrencyCode);
        Assert.Equal(expectedPrimaryCurrencyDecimalPlaces, model.PrimaryCurrencyDecimalPlaces);
        Assert.Equal(expectedPrimaryCurrencyID, model.PrimaryCurrencyID);
        Assert.Equal(expectedPrimaryCurrencyName, model.PrimaryCurrencyName);
        Assert.Equal(expectedPrimaryCurrencySymbol, model.PrimaryCurrencySymbol);
        Assert.Equal(expectedSubscriptionID, model.SubscriptionID);
        Assert.Equal(expectedTransactionGroupID, model.TransactionGroupID);
        Assert.Equal(expectedTransactionJournalID, model.TransactionJournalID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PaidDate
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PaidDate>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PaidDate
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PaidDate>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAmount = "123.45";
        string expectedCurrencyCode = "EUR";
        int expectedCurrencyDecimalPlaces = 2;
        string expectedCurrencyID = "5";
        string expectedCurrencyName = "Euro";
        string expectedCurrencySymbol = "$";
        DateTimeOffset expectedDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        string expectedForeignAmount = "123.45";
        string expectedPcAmount = "123.45";
        string expectedPcForeignAmount = "123.45";
        string expectedPrimaryCurrencyCode = "EUR";
        int expectedPrimaryCurrencyDecimalPlaces = 2;
        string expectedPrimaryCurrencyID = "5";
        string expectedPrimaryCurrencyName = "Euro";
        string expectedPrimaryCurrencySymbol = "$";
        string expectedSubscriptionID = "123";
        string expectedTransactionGroupID = "123";
        string expectedTransactionJournalID = "123";

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrencyCode, deserialized.CurrencyCode);
        Assert.Equal(expectedCurrencyDecimalPlaces, deserialized.CurrencyDecimalPlaces);
        Assert.Equal(expectedCurrencyID, deserialized.CurrencyID);
        Assert.Equal(expectedCurrencyName, deserialized.CurrencyName);
        Assert.Equal(expectedCurrencySymbol, deserialized.CurrencySymbol);
        Assert.Equal(expectedDate, deserialized.Date);
        Assert.Equal(expectedForeignAmount, deserialized.ForeignAmount);
        Assert.Equal(expectedPcAmount, deserialized.PcAmount);
        Assert.Equal(expectedPcForeignAmount, deserialized.PcForeignAmount);
        Assert.Equal(expectedPrimaryCurrencyCode, deserialized.PrimaryCurrencyCode);
        Assert.Equal(
            expectedPrimaryCurrencyDecimalPlaces,
            deserialized.PrimaryCurrencyDecimalPlaces
        );
        Assert.Equal(expectedPrimaryCurrencyID, deserialized.PrimaryCurrencyID);
        Assert.Equal(expectedPrimaryCurrencyName, deserialized.PrimaryCurrencyName);
        Assert.Equal(expectedPrimaryCurrencySymbol, deserialized.PrimaryCurrencySymbol);
        Assert.Equal(expectedSubscriptionID, deserialized.SubscriptionID);
        Assert.Equal(expectedTransactionGroupID, deserialized.TransactionGroupID);
        Assert.Equal(expectedTransactionJournalID, deserialized.TransactionJournalID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PaidDate
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PaidDate { };

        Assert.Null(model.Amount);
        Assert.False(model.RawData.ContainsKey("amount"));
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
        Assert.Null(model.Date);
        Assert.False(model.RawData.ContainsKey("date"));
        Assert.Null(model.ForeignAmount);
        Assert.False(model.RawData.ContainsKey("foreign_amount"));
        Assert.Null(model.PcAmount);
        Assert.False(model.RawData.ContainsKey("pc_amount"));
        Assert.Null(model.PcForeignAmount);
        Assert.False(model.RawData.ContainsKey("pc_foreign_amount"));
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
        Assert.Null(model.SubscriptionID);
        Assert.False(model.RawData.ContainsKey("subscription_id"));
        Assert.Null(model.TransactionGroupID);
        Assert.False(model.RawData.ContainsKey("transaction_group_id"));
        Assert.Null(model.TransactionJournalID);
        Assert.False(model.RawData.ContainsKey("transaction_journal_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PaidDate { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PaidDate
        {
            // Null should be interpreted as omitted for these properties
            Amount = null,
            CurrencyCode = null,
            CurrencyDecimalPlaces = null,
            CurrencyID = null,
            CurrencyName = null,
            CurrencySymbol = null,
            Date = null,
            ForeignAmount = null,
            PcAmount = null,
            PcForeignAmount = null,
            PrimaryCurrencyCode = null,
            PrimaryCurrencyDecimalPlaces = null,
            PrimaryCurrencyID = null,
            PrimaryCurrencyName = null,
            PrimaryCurrencySymbol = null,
            SubscriptionID = null,
            TransactionGroupID = null,
            TransactionJournalID = null,
        };

        Assert.Null(model.Amount);
        Assert.False(model.RawData.ContainsKey("amount"));
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
        Assert.Null(model.Date);
        Assert.False(model.RawData.ContainsKey("date"));
        Assert.Null(model.ForeignAmount);
        Assert.False(model.RawData.ContainsKey("foreign_amount"));
        Assert.Null(model.PcAmount);
        Assert.False(model.RawData.ContainsKey("pc_amount"));
        Assert.Null(model.PcForeignAmount);
        Assert.False(model.RawData.ContainsKey("pc_foreign_amount"));
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
        Assert.Null(model.SubscriptionID);
        Assert.False(model.RawData.ContainsKey("subscription_id"));
        Assert.Null(model.TransactionGroupID);
        Assert.False(model.RawData.ContainsKey("transaction_group_id"));
        Assert.Null(model.TransactionJournalID);
        Assert.False(model.RawData.ContainsKey("transaction_journal_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PaidDate
        {
            // Null should be interpreted as omitted for these properties
            Amount = null,
            CurrencyCode = null,
            CurrencyDecimalPlaces = null,
            CurrencyID = null,
            CurrencyName = null,
            CurrencySymbol = null,
            Date = null,
            ForeignAmount = null,
            PcAmount = null,
            PcForeignAmount = null,
            PrimaryCurrencyCode = null,
            PrimaryCurrencyDecimalPlaces = null,
            PrimaryCurrencyID = null,
            PrimaryCurrencyName = null,
            PrimaryCurrencySymbol = null,
            SubscriptionID = null,
            TransactionGroupID = null,
            TransactionJournalID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PaidDate
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
        };

        PaidDate copied = new(model);

        Assert.Equal(model, copied);
    }
}
