using System;
using System.Collections.Generic;
using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Attachments;
using EmceesProdTesting5.Models.PiggyBanks;

namespace EmceesProdTesting5.Tests.Models.PiggyBanks;

public class PiggyBankReadTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PiggyBankRead
        {
            ID = "2",
            Attributes = new()
            {
                AccountID = JsonSerializer.Deserialize<JsonElement>("{}"),
                Name = "New digital camera",
                TargetAmount = "123.45",
                Accounts =
                [
                    new()
                    {
                        AccountID = "3",
                        CurrentAmount = "123.45",
                        Name = "Checking account",
                        PcCurrentAmount = "123.45",
                    },
                ],
                Active = true,
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                CurrencyCode = "EUR",
                CurrencyDecimalPlaces = 2,
                CurrencyID = "5",
                CurrencyName = "Euro",
                CurrencySymbol = "$",
                CurrentAmount = "123.45",
                LeftToSave = "700.00",
                Notes = "Some notes",
                ObjectGroupID = "5",
                ObjectGroupOrder = 5,
                ObjectGroupTitle = "Example Group",
                ObjectHasCurrencySetting = true,
                Order = 5,
                PcCurrentAmount = "123.45",
                PcLeftToSave = "700.00",
                PcSavePerMonth = "12.45",
                PcTargetAmount = "123.45",
                Percentage = 12,
                PrimaryCurrencyCode = "EUR",
                PrimaryCurrencyDecimalPlaces = 2,
                PrimaryCurrencyID = "5",
                PrimaryCurrencyName = "Euro",
                PrimaryCurrencySymbol = "$",
                SavePerMonth = "12.45",
                StartDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                TargetDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            },
            Links = new()
            {
                O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
            },
            Type = "piggy_banks",
        };

        string expectedID = "2";
        PiggyBankReadAttributes expectedAttributes = new()
        {
            AccountID = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "New digital camera",
            TargetAmount = "123.45",
            Accounts =
            [
                new()
                {
                    AccountID = "3",
                    CurrentAmount = "123.45",
                    Name = "Checking account",
                    PcCurrentAmount = "123.45",
                },
            ],
            Active = true,
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "5",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            CurrentAmount = "123.45",
            LeftToSave = "700.00",
            Notes = "Some notes",
            ObjectGroupID = "5",
            ObjectGroupOrder = 5,
            ObjectGroupTitle = "Example Group",
            ObjectHasCurrencySetting = true,
            Order = 5,
            PcCurrentAmount = "123.45",
            PcLeftToSave = "700.00",
            PcSavePerMonth = "12.45",
            PcTargetAmount = "123.45",
            Percentage = 12,
            PrimaryCurrencyCode = "EUR",
            PrimaryCurrencyDecimalPlaces = 2,
            PrimaryCurrencyID = "5",
            PrimaryCurrencyName = "Euro",
            PrimaryCurrencySymbol = "$",
            SavePerMonth = "12.45",
            StartDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            TargetDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };
        ObjectLink expectedLinks = new()
        {
            O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
            Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
        };
        string expectedType = "piggy_banks";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAttributes, model.Attributes);
        Assert.Equal(expectedLinks, model.Links);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PiggyBankRead
        {
            ID = "2",
            Attributes = new()
            {
                AccountID = JsonSerializer.Deserialize<JsonElement>("{}"),
                Name = "New digital camera",
                TargetAmount = "123.45",
                Accounts =
                [
                    new()
                    {
                        AccountID = "3",
                        CurrentAmount = "123.45",
                        Name = "Checking account",
                        PcCurrentAmount = "123.45",
                    },
                ],
                Active = true,
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                CurrencyCode = "EUR",
                CurrencyDecimalPlaces = 2,
                CurrencyID = "5",
                CurrencyName = "Euro",
                CurrencySymbol = "$",
                CurrentAmount = "123.45",
                LeftToSave = "700.00",
                Notes = "Some notes",
                ObjectGroupID = "5",
                ObjectGroupOrder = 5,
                ObjectGroupTitle = "Example Group",
                ObjectHasCurrencySetting = true,
                Order = 5,
                PcCurrentAmount = "123.45",
                PcLeftToSave = "700.00",
                PcSavePerMonth = "12.45",
                PcTargetAmount = "123.45",
                Percentage = 12,
                PrimaryCurrencyCode = "EUR",
                PrimaryCurrencyDecimalPlaces = 2,
                PrimaryCurrencyID = "5",
                PrimaryCurrencyName = "Euro",
                PrimaryCurrencySymbol = "$",
                SavePerMonth = "12.45",
                StartDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                TargetDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            },
            Links = new()
            {
                O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
            },
            Type = "piggy_banks",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PiggyBankRead>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PiggyBankRead
        {
            ID = "2",
            Attributes = new()
            {
                AccountID = JsonSerializer.Deserialize<JsonElement>("{}"),
                Name = "New digital camera",
                TargetAmount = "123.45",
                Accounts =
                [
                    new()
                    {
                        AccountID = "3",
                        CurrentAmount = "123.45",
                        Name = "Checking account",
                        PcCurrentAmount = "123.45",
                    },
                ],
                Active = true,
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                CurrencyCode = "EUR",
                CurrencyDecimalPlaces = 2,
                CurrencyID = "5",
                CurrencyName = "Euro",
                CurrencySymbol = "$",
                CurrentAmount = "123.45",
                LeftToSave = "700.00",
                Notes = "Some notes",
                ObjectGroupID = "5",
                ObjectGroupOrder = 5,
                ObjectGroupTitle = "Example Group",
                ObjectHasCurrencySetting = true,
                Order = 5,
                PcCurrentAmount = "123.45",
                PcLeftToSave = "700.00",
                PcSavePerMonth = "12.45",
                PcTargetAmount = "123.45",
                Percentage = 12,
                PrimaryCurrencyCode = "EUR",
                PrimaryCurrencyDecimalPlaces = 2,
                PrimaryCurrencyID = "5",
                PrimaryCurrencyName = "Euro",
                PrimaryCurrencySymbol = "$",
                SavePerMonth = "12.45",
                StartDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                TargetDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            },
            Links = new()
            {
                O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
            },
            Type = "piggy_banks",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PiggyBankRead>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "2";
        PiggyBankReadAttributes expectedAttributes = new()
        {
            AccountID = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "New digital camera",
            TargetAmount = "123.45",
            Accounts =
            [
                new()
                {
                    AccountID = "3",
                    CurrentAmount = "123.45",
                    Name = "Checking account",
                    PcCurrentAmount = "123.45",
                },
            ],
            Active = true,
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "5",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            CurrentAmount = "123.45",
            LeftToSave = "700.00",
            Notes = "Some notes",
            ObjectGroupID = "5",
            ObjectGroupOrder = 5,
            ObjectGroupTitle = "Example Group",
            ObjectHasCurrencySetting = true,
            Order = 5,
            PcCurrentAmount = "123.45",
            PcLeftToSave = "700.00",
            PcSavePerMonth = "12.45",
            PcTargetAmount = "123.45",
            Percentage = 12,
            PrimaryCurrencyCode = "EUR",
            PrimaryCurrencyDecimalPlaces = 2,
            PrimaryCurrencyID = "5",
            PrimaryCurrencyName = "Euro",
            PrimaryCurrencySymbol = "$",
            SavePerMonth = "12.45",
            StartDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            TargetDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };
        ObjectLink expectedLinks = new()
        {
            O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
            Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
        };
        string expectedType = "piggy_banks";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAttributes, deserialized.Attributes);
        Assert.Equal(expectedLinks, deserialized.Links);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PiggyBankRead
        {
            ID = "2",
            Attributes = new()
            {
                AccountID = JsonSerializer.Deserialize<JsonElement>("{}"),
                Name = "New digital camera",
                TargetAmount = "123.45",
                Accounts =
                [
                    new()
                    {
                        AccountID = "3",
                        CurrentAmount = "123.45",
                        Name = "Checking account",
                        PcCurrentAmount = "123.45",
                    },
                ],
                Active = true,
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                CurrencyCode = "EUR",
                CurrencyDecimalPlaces = 2,
                CurrencyID = "5",
                CurrencyName = "Euro",
                CurrencySymbol = "$",
                CurrentAmount = "123.45",
                LeftToSave = "700.00",
                Notes = "Some notes",
                ObjectGroupID = "5",
                ObjectGroupOrder = 5,
                ObjectGroupTitle = "Example Group",
                ObjectHasCurrencySetting = true,
                Order = 5,
                PcCurrentAmount = "123.45",
                PcLeftToSave = "700.00",
                PcSavePerMonth = "12.45",
                PcTargetAmount = "123.45",
                Percentage = 12,
                PrimaryCurrencyCode = "EUR",
                PrimaryCurrencyDecimalPlaces = 2,
                PrimaryCurrencyID = "5",
                PrimaryCurrencyName = "Euro",
                PrimaryCurrencySymbol = "$",
                SavePerMonth = "12.45",
                StartDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                TargetDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            },
            Links = new()
            {
                O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
            },
            Type = "piggy_banks",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PiggyBankRead
        {
            ID = "2",
            Attributes = new()
            {
                AccountID = JsonSerializer.Deserialize<JsonElement>("{}"),
                Name = "New digital camera",
                TargetAmount = "123.45",
                Accounts =
                [
                    new()
                    {
                        AccountID = "3",
                        CurrentAmount = "123.45",
                        Name = "Checking account",
                        PcCurrentAmount = "123.45",
                    },
                ],
                Active = true,
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                CurrencyCode = "EUR",
                CurrencyDecimalPlaces = 2,
                CurrencyID = "5",
                CurrencyName = "Euro",
                CurrencySymbol = "$",
                CurrentAmount = "123.45",
                LeftToSave = "700.00",
                Notes = "Some notes",
                ObjectGroupID = "5",
                ObjectGroupOrder = 5,
                ObjectGroupTitle = "Example Group",
                ObjectHasCurrencySetting = true,
                Order = 5,
                PcCurrentAmount = "123.45",
                PcLeftToSave = "700.00",
                PcSavePerMonth = "12.45",
                PcTargetAmount = "123.45",
                Percentage = 12,
                PrimaryCurrencyCode = "EUR",
                PrimaryCurrencyDecimalPlaces = 2,
                PrimaryCurrencyID = "5",
                PrimaryCurrencyName = "Euro",
                PrimaryCurrencySymbol = "$",
                SavePerMonth = "12.45",
                StartDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                TargetDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            },
            Links = new()
            {
                O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
            },
            Type = "piggy_banks",
        };

        PiggyBankRead copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PiggyBankReadAttributesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PiggyBankReadAttributes
        {
            AccountID = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "New digital camera",
            TargetAmount = "123.45",
            Accounts =
            [
                new()
                {
                    AccountID = "3",
                    CurrentAmount = "123.45",
                    Name = "Checking account",
                    PcCurrentAmount = "123.45",
                },
            ],
            Active = true,
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "5",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            CurrentAmount = "123.45",
            LeftToSave = "700.00",
            Notes = "Some notes",
            ObjectGroupID = "5",
            ObjectGroupOrder = 5,
            ObjectGroupTitle = "Example Group",
            ObjectHasCurrencySetting = true,
            Order = 5,
            PcCurrentAmount = "123.45",
            PcLeftToSave = "700.00",
            PcSavePerMonth = "12.45",
            PcTargetAmount = "123.45",
            Percentage = 12,
            PrimaryCurrencyCode = "EUR",
            PrimaryCurrencyDecimalPlaces = 2,
            PrimaryCurrencyID = "5",
            PrimaryCurrencyName = "Euro",
            PrimaryCurrencySymbol = "$",
            SavePerMonth = "12.45",
            StartDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            TargetDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        JsonElement expectedAccountID = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedName = "New digital camera";
        string expectedTargetAmount = "123.45";
        List<PiggyBankReadAttributesAccount> expectedAccounts =
        [
            new()
            {
                AccountID = "3",
                CurrentAmount = "123.45",
                Name = "Checking account",
                PcCurrentAmount = "123.45",
            },
        ];
        bool expectedActive = true;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        string expectedCurrencyCode = "EUR";
        int expectedCurrencyDecimalPlaces = 2;
        string expectedCurrencyID = "5";
        string expectedCurrencyName = "Euro";
        string expectedCurrencySymbol = "$";
        string expectedCurrentAmount = "123.45";
        string expectedLeftToSave = "700.00";
        string expectedNotes = "Some notes";
        string expectedObjectGroupID = "5";
        int expectedObjectGroupOrder = 5;
        string expectedObjectGroupTitle = "Example Group";
        bool expectedObjectHasCurrencySetting = true;
        int expectedOrder = 5;
        string expectedPcCurrentAmount = "123.45";
        string expectedPcLeftToSave = "700.00";
        string expectedPcSavePerMonth = "12.45";
        string expectedPcTargetAmount = "123.45";
        int expectedPercentage = 12;
        string expectedPrimaryCurrencyCode = "EUR";
        int expectedPrimaryCurrencyDecimalPlaces = 2;
        string expectedPrimaryCurrencyID = "5";
        string expectedPrimaryCurrencyName = "Euro";
        string expectedPrimaryCurrencySymbol = "$";
        string expectedSavePerMonth = "12.45";
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        DateTimeOffset expectedTargetDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");

        Assert.True(JsonElement.DeepEquals(expectedAccountID, model.AccountID));
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedTargetAmount, model.TargetAmount);
        Assert.NotNull(model.Accounts);
        Assert.Equal(expectedAccounts.Count, model.Accounts.Count);
        for (int i = 0; i < expectedAccounts.Count; i++)
        {
            Assert.Equal(expectedAccounts[i], model.Accounts[i]);
        }
        Assert.Equal(expectedActive, model.Active);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCurrencyCode, model.CurrencyCode);
        Assert.Equal(expectedCurrencyDecimalPlaces, model.CurrencyDecimalPlaces);
        Assert.Equal(expectedCurrencyID, model.CurrencyID);
        Assert.Equal(expectedCurrencyName, model.CurrencyName);
        Assert.Equal(expectedCurrencySymbol, model.CurrencySymbol);
        Assert.Equal(expectedCurrentAmount, model.CurrentAmount);
        Assert.Equal(expectedLeftToSave, model.LeftToSave);
        Assert.Equal(expectedNotes, model.Notes);
        Assert.Equal(expectedObjectGroupID, model.ObjectGroupID);
        Assert.Equal(expectedObjectGroupOrder, model.ObjectGroupOrder);
        Assert.Equal(expectedObjectGroupTitle, model.ObjectGroupTitle);
        Assert.Equal(expectedObjectHasCurrencySetting, model.ObjectHasCurrencySetting);
        Assert.Equal(expectedOrder, model.Order);
        Assert.Equal(expectedPcCurrentAmount, model.PcCurrentAmount);
        Assert.Equal(expectedPcLeftToSave, model.PcLeftToSave);
        Assert.Equal(expectedPcSavePerMonth, model.PcSavePerMonth);
        Assert.Equal(expectedPcTargetAmount, model.PcTargetAmount);
        Assert.Equal(expectedPercentage, model.Percentage);
        Assert.Equal(expectedPrimaryCurrencyCode, model.PrimaryCurrencyCode);
        Assert.Equal(expectedPrimaryCurrencyDecimalPlaces, model.PrimaryCurrencyDecimalPlaces);
        Assert.Equal(expectedPrimaryCurrencyID, model.PrimaryCurrencyID);
        Assert.Equal(expectedPrimaryCurrencyName, model.PrimaryCurrencyName);
        Assert.Equal(expectedPrimaryCurrencySymbol, model.PrimaryCurrencySymbol);
        Assert.Equal(expectedSavePerMonth, model.SavePerMonth);
        Assert.Equal(expectedStartDate, model.StartDate);
        Assert.Equal(expectedTargetDate, model.TargetDate);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PiggyBankReadAttributes
        {
            AccountID = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "New digital camera",
            TargetAmount = "123.45",
            Accounts =
            [
                new()
                {
                    AccountID = "3",
                    CurrentAmount = "123.45",
                    Name = "Checking account",
                    PcCurrentAmount = "123.45",
                },
            ],
            Active = true,
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "5",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            CurrentAmount = "123.45",
            LeftToSave = "700.00",
            Notes = "Some notes",
            ObjectGroupID = "5",
            ObjectGroupOrder = 5,
            ObjectGroupTitle = "Example Group",
            ObjectHasCurrencySetting = true,
            Order = 5,
            PcCurrentAmount = "123.45",
            PcLeftToSave = "700.00",
            PcSavePerMonth = "12.45",
            PcTargetAmount = "123.45",
            Percentage = 12,
            PrimaryCurrencyCode = "EUR",
            PrimaryCurrencyDecimalPlaces = 2,
            PrimaryCurrencyID = "5",
            PrimaryCurrencyName = "Euro",
            PrimaryCurrencySymbol = "$",
            SavePerMonth = "12.45",
            StartDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            TargetDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PiggyBankReadAttributes>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PiggyBankReadAttributes
        {
            AccountID = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "New digital camera",
            TargetAmount = "123.45",
            Accounts =
            [
                new()
                {
                    AccountID = "3",
                    CurrentAmount = "123.45",
                    Name = "Checking account",
                    PcCurrentAmount = "123.45",
                },
            ],
            Active = true,
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "5",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            CurrentAmount = "123.45",
            LeftToSave = "700.00",
            Notes = "Some notes",
            ObjectGroupID = "5",
            ObjectGroupOrder = 5,
            ObjectGroupTitle = "Example Group",
            ObjectHasCurrencySetting = true,
            Order = 5,
            PcCurrentAmount = "123.45",
            PcLeftToSave = "700.00",
            PcSavePerMonth = "12.45",
            PcTargetAmount = "123.45",
            Percentage = 12,
            PrimaryCurrencyCode = "EUR",
            PrimaryCurrencyDecimalPlaces = 2,
            PrimaryCurrencyID = "5",
            PrimaryCurrencyName = "Euro",
            PrimaryCurrencySymbol = "$",
            SavePerMonth = "12.45",
            StartDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            TargetDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PiggyBankReadAttributes>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedAccountID = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedName = "New digital camera";
        string expectedTargetAmount = "123.45";
        List<PiggyBankReadAttributesAccount> expectedAccounts =
        [
            new()
            {
                AccountID = "3",
                CurrentAmount = "123.45",
                Name = "Checking account",
                PcCurrentAmount = "123.45",
            },
        ];
        bool expectedActive = true;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        string expectedCurrencyCode = "EUR";
        int expectedCurrencyDecimalPlaces = 2;
        string expectedCurrencyID = "5";
        string expectedCurrencyName = "Euro";
        string expectedCurrencySymbol = "$";
        string expectedCurrentAmount = "123.45";
        string expectedLeftToSave = "700.00";
        string expectedNotes = "Some notes";
        string expectedObjectGroupID = "5";
        int expectedObjectGroupOrder = 5;
        string expectedObjectGroupTitle = "Example Group";
        bool expectedObjectHasCurrencySetting = true;
        int expectedOrder = 5;
        string expectedPcCurrentAmount = "123.45";
        string expectedPcLeftToSave = "700.00";
        string expectedPcSavePerMonth = "12.45";
        string expectedPcTargetAmount = "123.45";
        int expectedPercentage = 12;
        string expectedPrimaryCurrencyCode = "EUR";
        int expectedPrimaryCurrencyDecimalPlaces = 2;
        string expectedPrimaryCurrencyID = "5";
        string expectedPrimaryCurrencyName = "Euro";
        string expectedPrimaryCurrencySymbol = "$";
        string expectedSavePerMonth = "12.45";
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        DateTimeOffset expectedTargetDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");

        Assert.True(JsonElement.DeepEquals(expectedAccountID, deserialized.AccountID));
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedTargetAmount, deserialized.TargetAmount);
        Assert.NotNull(deserialized.Accounts);
        Assert.Equal(expectedAccounts.Count, deserialized.Accounts.Count);
        for (int i = 0; i < expectedAccounts.Count; i++)
        {
            Assert.Equal(expectedAccounts[i], deserialized.Accounts[i]);
        }
        Assert.Equal(expectedActive, deserialized.Active);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCurrencyCode, deserialized.CurrencyCode);
        Assert.Equal(expectedCurrencyDecimalPlaces, deserialized.CurrencyDecimalPlaces);
        Assert.Equal(expectedCurrencyID, deserialized.CurrencyID);
        Assert.Equal(expectedCurrencyName, deserialized.CurrencyName);
        Assert.Equal(expectedCurrencySymbol, deserialized.CurrencySymbol);
        Assert.Equal(expectedCurrentAmount, deserialized.CurrentAmount);
        Assert.Equal(expectedLeftToSave, deserialized.LeftToSave);
        Assert.Equal(expectedNotes, deserialized.Notes);
        Assert.Equal(expectedObjectGroupID, deserialized.ObjectGroupID);
        Assert.Equal(expectedObjectGroupOrder, deserialized.ObjectGroupOrder);
        Assert.Equal(expectedObjectGroupTitle, deserialized.ObjectGroupTitle);
        Assert.Equal(expectedObjectHasCurrencySetting, deserialized.ObjectHasCurrencySetting);
        Assert.Equal(expectedOrder, deserialized.Order);
        Assert.Equal(expectedPcCurrentAmount, deserialized.PcCurrentAmount);
        Assert.Equal(expectedPcLeftToSave, deserialized.PcLeftToSave);
        Assert.Equal(expectedPcSavePerMonth, deserialized.PcSavePerMonth);
        Assert.Equal(expectedPcTargetAmount, deserialized.PcTargetAmount);
        Assert.Equal(expectedPercentage, deserialized.Percentage);
        Assert.Equal(expectedPrimaryCurrencyCode, deserialized.PrimaryCurrencyCode);
        Assert.Equal(
            expectedPrimaryCurrencyDecimalPlaces,
            deserialized.PrimaryCurrencyDecimalPlaces
        );
        Assert.Equal(expectedPrimaryCurrencyID, deserialized.PrimaryCurrencyID);
        Assert.Equal(expectedPrimaryCurrencyName, deserialized.PrimaryCurrencyName);
        Assert.Equal(expectedPrimaryCurrencySymbol, deserialized.PrimaryCurrencySymbol);
        Assert.Equal(expectedSavePerMonth, deserialized.SavePerMonth);
        Assert.Equal(expectedStartDate, deserialized.StartDate);
        Assert.Equal(expectedTargetDate, deserialized.TargetDate);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PiggyBankReadAttributes
        {
            AccountID = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "New digital camera",
            TargetAmount = "123.45",
            Accounts =
            [
                new()
                {
                    AccountID = "3",
                    CurrentAmount = "123.45",
                    Name = "Checking account",
                    PcCurrentAmount = "123.45",
                },
            ],
            Active = true,
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "5",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            CurrentAmount = "123.45",
            LeftToSave = "700.00",
            Notes = "Some notes",
            ObjectGroupID = "5",
            ObjectGroupOrder = 5,
            ObjectGroupTitle = "Example Group",
            ObjectHasCurrencySetting = true,
            Order = 5,
            PcCurrentAmount = "123.45",
            PcLeftToSave = "700.00",
            PcSavePerMonth = "12.45",
            PcTargetAmount = "123.45",
            Percentage = 12,
            PrimaryCurrencyCode = "EUR",
            PrimaryCurrencyDecimalPlaces = 2,
            PrimaryCurrencyID = "5",
            PrimaryCurrencyName = "Euro",
            PrimaryCurrencySymbol = "$",
            SavePerMonth = "12.45",
            StartDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            TargetDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PiggyBankReadAttributes
        {
            AccountID = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "New digital camera",
            TargetAmount = "123.45",
            LeftToSave = "700.00",
            Notes = "Some notes",
            ObjectGroupID = "5",
            ObjectGroupOrder = 5,
            ObjectGroupTitle = "Example Group",
            PcLeftToSave = "700.00",
            PcSavePerMonth = "12.45",
            PcTargetAmount = "123.45",
            Percentage = 12,
            SavePerMonth = "12.45",
            TargetDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        Assert.Null(model.Accounts);
        Assert.False(model.RawData.ContainsKey("accounts"));
        Assert.Null(model.Active);
        Assert.False(model.RawData.ContainsKey("active"));
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
        Assert.Null(model.CurrentAmount);
        Assert.False(model.RawData.ContainsKey("current_amount"));
        Assert.Null(model.ObjectHasCurrencySetting);
        Assert.False(model.RawData.ContainsKey("object_has_currency_setting"));
        Assert.Null(model.Order);
        Assert.False(model.RawData.ContainsKey("order"));
        Assert.Null(model.PcCurrentAmount);
        Assert.False(model.RawData.ContainsKey("pc_current_amount"));
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
        Assert.Null(model.StartDate);
        Assert.False(model.RawData.ContainsKey("start_date"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PiggyBankReadAttributes
        {
            AccountID = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "New digital camera",
            TargetAmount = "123.45",
            LeftToSave = "700.00",
            Notes = "Some notes",
            ObjectGroupID = "5",
            ObjectGroupOrder = 5,
            ObjectGroupTitle = "Example Group",
            PcLeftToSave = "700.00",
            PcSavePerMonth = "12.45",
            PcTargetAmount = "123.45",
            Percentage = 12,
            SavePerMonth = "12.45",
            TargetDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PiggyBankReadAttributes
        {
            AccountID = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "New digital camera",
            TargetAmount = "123.45",
            LeftToSave = "700.00",
            Notes = "Some notes",
            ObjectGroupID = "5",
            ObjectGroupOrder = 5,
            ObjectGroupTitle = "Example Group",
            PcLeftToSave = "700.00",
            PcSavePerMonth = "12.45",
            PcTargetAmount = "123.45",
            Percentage = 12,
            SavePerMonth = "12.45",
            TargetDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),

            // Null should be interpreted as omitted for these properties
            Accounts = null,
            Active = null,
            CreatedAt = null,
            CurrencyCode = null,
            CurrencyDecimalPlaces = null,
            CurrencyID = null,
            CurrencyName = null,
            CurrencySymbol = null,
            CurrentAmount = null,
            ObjectHasCurrencySetting = null,
            Order = null,
            PcCurrentAmount = null,
            PrimaryCurrencyCode = null,
            PrimaryCurrencyDecimalPlaces = null,
            PrimaryCurrencyID = null,
            PrimaryCurrencyName = null,
            PrimaryCurrencySymbol = null,
            StartDate = null,
            UpdatedAt = null,
        };

        Assert.Null(model.Accounts);
        Assert.False(model.RawData.ContainsKey("accounts"));
        Assert.Null(model.Active);
        Assert.False(model.RawData.ContainsKey("active"));
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
        Assert.Null(model.CurrentAmount);
        Assert.False(model.RawData.ContainsKey("current_amount"));
        Assert.Null(model.ObjectHasCurrencySetting);
        Assert.False(model.RawData.ContainsKey("object_has_currency_setting"));
        Assert.Null(model.Order);
        Assert.False(model.RawData.ContainsKey("order"));
        Assert.Null(model.PcCurrentAmount);
        Assert.False(model.RawData.ContainsKey("pc_current_amount"));
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
        Assert.Null(model.StartDate);
        Assert.False(model.RawData.ContainsKey("start_date"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PiggyBankReadAttributes
        {
            AccountID = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "New digital camera",
            TargetAmount = "123.45",
            LeftToSave = "700.00",
            Notes = "Some notes",
            ObjectGroupID = "5",
            ObjectGroupOrder = 5,
            ObjectGroupTitle = "Example Group",
            PcLeftToSave = "700.00",
            PcSavePerMonth = "12.45",
            PcTargetAmount = "123.45",
            Percentage = 12,
            SavePerMonth = "12.45",
            TargetDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),

            // Null should be interpreted as omitted for these properties
            Accounts = null,
            Active = null,
            CreatedAt = null,
            CurrencyCode = null,
            CurrencyDecimalPlaces = null,
            CurrencyID = null,
            CurrencyName = null,
            CurrencySymbol = null,
            CurrentAmount = null,
            ObjectHasCurrencySetting = null,
            Order = null,
            PcCurrentAmount = null,
            PrimaryCurrencyCode = null,
            PrimaryCurrencyDecimalPlaces = null,
            PrimaryCurrencyID = null,
            PrimaryCurrencyName = null,
            PrimaryCurrencySymbol = null,
            StartDate = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PiggyBankReadAttributes
        {
            AccountID = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "New digital camera",
            TargetAmount = "123.45",
            Accounts =
            [
                new()
                {
                    AccountID = "3",
                    CurrentAmount = "123.45",
                    Name = "Checking account",
                    PcCurrentAmount = "123.45",
                },
            ],
            Active = true,
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "5",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            CurrentAmount = "123.45",
            ObjectHasCurrencySetting = true,
            Order = 5,
            PcCurrentAmount = "123.45",
            PrimaryCurrencyCode = "EUR",
            PrimaryCurrencyDecimalPlaces = 2,
            PrimaryCurrencyID = "5",
            PrimaryCurrencyName = "Euro",
            PrimaryCurrencySymbol = "$",
            StartDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        Assert.Null(model.LeftToSave);
        Assert.False(model.RawData.ContainsKey("left_to_save"));
        Assert.Null(model.Notes);
        Assert.False(model.RawData.ContainsKey("notes"));
        Assert.Null(model.ObjectGroupID);
        Assert.False(model.RawData.ContainsKey("object_group_id"));
        Assert.Null(model.ObjectGroupOrder);
        Assert.False(model.RawData.ContainsKey("object_group_order"));
        Assert.Null(model.ObjectGroupTitle);
        Assert.False(model.RawData.ContainsKey("object_group_title"));
        Assert.Null(model.PcLeftToSave);
        Assert.False(model.RawData.ContainsKey("pc_left_to_save"));
        Assert.Null(model.PcSavePerMonth);
        Assert.False(model.RawData.ContainsKey("pc_save_per_month"));
        Assert.Null(model.PcTargetAmount);
        Assert.False(model.RawData.ContainsKey("pc_target_amount"));
        Assert.Null(model.Percentage);
        Assert.False(model.RawData.ContainsKey("percentage"));
        Assert.Null(model.SavePerMonth);
        Assert.False(model.RawData.ContainsKey("save_per_month"));
        Assert.Null(model.TargetDate);
        Assert.False(model.RawData.ContainsKey("target_date"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new PiggyBankReadAttributes
        {
            AccountID = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "New digital camera",
            TargetAmount = "123.45",
            Accounts =
            [
                new()
                {
                    AccountID = "3",
                    CurrentAmount = "123.45",
                    Name = "Checking account",
                    PcCurrentAmount = "123.45",
                },
            ],
            Active = true,
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "5",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            CurrentAmount = "123.45",
            ObjectHasCurrencySetting = true,
            Order = 5,
            PcCurrentAmount = "123.45",
            PrimaryCurrencyCode = "EUR",
            PrimaryCurrencyDecimalPlaces = 2,
            PrimaryCurrencyID = "5",
            PrimaryCurrencyName = "Euro",
            PrimaryCurrencySymbol = "$",
            StartDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new PiggyBankReadAttributes
        {
            AccountID = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "New digital camera",
            TargetAmount = "123.45",
            Accounts =
            [
                new()
                {
                    AccountID = "3",
                    CurrentAmount = "123.45",
                    Name = "Checking account",
                    PcCurrentAmount = "123.45",
                },
            ],
            Active = true,
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "5",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            CurrentAmount = "123.45",
            ObjectHasCurrencySetting = true,
            Order = 5,
            PcCurrentAmount = "123.45",
            PrimaryCurrencyCode = "EUR",
            PrimaryCurrencyDecimalPlaces = 2,
            PrimaryCurrencyID = "5",
            PrimaryCurrencyName = "Euro",
            PrimaryCurrencySymbol = "$",
            StartDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),

            LeftToSave = null,
            Notes = null,
            ObjectGroupID = null,
            ObjectGroupOrder = null,
            ObjectGroupTitle = null,
            PcLeftToSave = null,
            PcSavePerMonth = null,
            PcTargetAmount = null,
            Percentage = null,
            SavePerMonth = null,
            TargetDate = null,
        };

        Assert.Null(model.LeftToSave);
        Assert.True(model.RawData.ContainsKey("left_to_save"));
        Assert.Null(model.Notes);
        Assert.True(model.RawData.ContainsKey("notes"));
        Assert.Null(model.ObjectGroupID);
        Assert.True(model.RawData.ContainsKey("object_group_id"));
        Assert.Null(model.ObjectGroupOrder);
        Assert.True(model.RawData.ContainsKey("object_group_order"));
        Assert.Null(model.ObjectGroupTitle);
        Assert.True(model.RawData.ContainsKey("object_group_title"));
        Assert.Null(model.PcLeftToSave);
        Assert.True(model.RawData.ContainsKey("pc_left_to_save"));
        Assert.Null(model.PcSavePerMonth);
        Assert.True(model.RawData.ContainsKey("pc_save_per_month"));
        Assert.Null(model.PcTargetAmount);
        Assert.True(model.RawData.ContainsKey("pc_target_amount"));
        Assert.Null(model.Percentage);
        Assert.True(model.RawData.ContainsKey("percentage"));
        Assert.Null(model.SavePerMonth);
        Assert.True(model.RawData.ContainsKey("save_per_month"));
        Assert.Null(model.TargetDate);
        Assert.True(model.RawData.ContainsKey("target_date"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PiggyBankReadAttributes
        {
            AccountID = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "New digital camera",
            TargetAmount = "123.45",
            Accounts =
            [
                new()
                {
                    AccountID = "3",
                    CurrentAmount = "123.45",
                    Name = "Checking account",
                    PcCurrentAmount = "123.45",
                },
            ],
            Active = true,
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "5",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            CurrentAmount = "123.45",
            ObjectHasCurrencySetting = true,
            Order = 5,
            PcCurrentAmount = "123.45",
            PrimaryCurrencyCode = "EUR",
            PrimaryCurrencyDecimalPlaces = 2,
            PrimaryCurrencyID = "5",
            PrimaryCurrencyName = "Euro",
            PrimaryCurrencySymbol = "$",
            StartDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),

            LeftToSave = null,
            Notes = null,
            ObjectGroupID = null,
            ObjectGroupOrder = null,
            ObjectGroupTitle = null,
            PcLeftToSave = null,
            PcSavePerMonth = null,
            PcTargetAmount = null,
            Percentage = null,
            SavePerMonth = null,
            TargetDate = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PiggyBankReadAttributes
        {
            AccountID = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "New digital camera",
            TargetAmount = "123.45",
            Accounts =
            [
                new()
                {
                    AccountID = "3",
                    CurrentAmount = "123.45",
                    Name = "Checking account",
                    PcCurrentAmount = "123.45",
                },
            ],
            Active = true,
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            CurrencyCode = "EUR",
            CurrencyDecimalPlaces = 2,
            CurrencyID = "5",
            CurrencyName = "Euro",
            CurrencySymbol = "$",
            CurrentAmount = "123.45",
            LeftToSave = "700.00",
            Notes = "Some notes",
            ObjectGroupID = "5",
            ObjectGroupOrder = 5,
            ObjectGroupTitle = "Example Group",
            ObjectHasCurrencySetting = true,
            Order = 5,
            PcCurrentAmount = "123.45",
            PcLeftToSave = "700.00",
            PcSavePerMonth = "12.45",
            PcTargetAmount = "123.45",
            Percentage = 12,
            PrimaryCurrencyCode = "EUR",
            PrimaryCurrencyDecimalPlaces = 2,
            PrimaryCurrencyID = "5",
            PrimaryCurrencyName = "Euro",
            PrimaryCurrencySymbol = "$",
            SavePerMonth = "12.45",
            StartDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            TargetDate = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        PiggyBankReadAttributes copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PiggyBankReadAttributesAccountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PiggyBankReadAttributesAccount
        {
            AccountID = "3",
            CurrentAmount = "123.45",
            Name = "Checking account",
            PcCurrentAmount = "123.45",
        };

        string expectedAccountID = "3";
        string expectedCurrentAmount = "123.45";
        string expectedName = "Checking account";
        string expectedPcCurrentAmount = "123.45";

        Assert.Equal(expectedAccountID, model.AccountID);
        Assert.Equal(expectedCurrentAmount, model.CurrentAmount);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPcCurrentAmount, model.PcCurrentAmount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PiggyBankReadAttributesAccount
        {
            AccountID = "3",
            CurrentAmount = "123.45",
            Name = "Checking account",
            PcCurrentAmount = "123.45",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PiggyBankReadAttributesAccount>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PiggyBankReadAttributesAccount
        {
            AccountID = "3",
            CurrentAmount = "123.45",
            Name = "Checking account",
            PcCurrentAmount = "123.45",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PiggyBankReadAttributesAccount>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAccountID = "3";
        string expectedCurrentAmount = "123.45";
        string expectedName = "Checking account";
        string expectedPcCurrentAmount = "123.45";

        Assert.Equal(expectedAccountID, deserialized.AccountID);
        Assert.Equal(expectedCurrentAmount, deserialized.CurrentAmount);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPcCurrentAmount, deserialized.PcCurrentAmount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PiggyBankReadAttributesAccount
        {
            AccountID = "3",
            CurrentAmount = "123.45",
            Name = "Checking account",
            PcCurrentAmount = "123.45",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PiggyBankReadAttributesAccount { };

        Assert.Null(model.AccountID);
        Assert.False(model.RawData.ContainsKey("account_id"));
        Assert.Null(model.CurrentAmount);
        Assert.False(model.RawData.ContainsKey("current_amount"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.PcCurrentAmount);
        Assert.False(model.RawData.ContainsKey("pc_current_amount"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PiggyBankReadAttributesAccount { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PiggyBankReadAttributesAccount
        {
            // Null should be interpreted as omitted for these properties
            AccountID = null,
            CurrentAmount = null,
            Name = null,
            PcCurrentAmount = null,
        };

        Assert.Null(model.AccountID);
        Assert.False(model.RawData.ContainsKey("account_id"));
        Assert.Null(model.CurrentAmount);
        Assert.False(model.RawData.ContainsKey("current_amount"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.PcCurrentAmount);
        Assert.False(model.RawData.ContainsKey("pc_current_amount"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PiggyBankReadAttributesAccount
        {
            // Null should be interpreted as omitted for these properties
            AccountID = null,
            CurrentAmount = null,
            Name = null,
            PcCurrentAmount = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PiggyBankReadAttributesAccount
        {
            AccountID = "3",
            CurrentAmount = "123.45",
            Name = "Checking account",
            PcCurrentAmount = "123.45",
        };

        PiggyBankReadAttributesAccount copied = new(model);

        Assert.Equal(model, copied);
    }
}
