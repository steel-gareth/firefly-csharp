using System;
using System.Text.Json;
using Firefly.Core;
using Firefly.Models.PiggyBanks;

namespace Firefly.Tests.Models.PiggyBanks;

public class PiggyBankSingleTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PiggyBankSingle
        {
            Data = new()
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
            },
        };

        PiggyBankRead expectedData = new()
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

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PiggyBankSingle
        {
            Data = new()
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
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PiggyBankSingle>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PiggyBankSingle
        {
            Data = new()
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
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PiggyBankSingle>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        PiggyBankRead expectedData = new()
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

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PiggyBankSingle
        {
            Data = new()
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
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PiggyBankSingle
        {
            Data = new()
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
            },
        };

        PiggyBankSingle copied = new(model);

        Assert.Equal(model, copied);
    }
}
