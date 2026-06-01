using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Firefly.Core;
using Firefly.Models.Recurrences;

namespace Firefly.Tests.Models.Recurrences;

public class RecurrenceCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RecurrenceCreateParams
        {
            FirstDate = "2026-04-30",
            RepeatUntil = "2026-04-30",
            Repetitions =
            [
                new()
                {
                    Moment = "3",
                    Type = RecurrenceRepetitionType.Weekly,
                    Skip = 0,
                    Weekend = 1,
                },
            ],
            Title = "Rent",
            Transactions =
            [
                new()
                {
                    Amount = "123.45",
                    Description = "Rent for the current month",
                    DestinationID = "258",
                    SourceID = "913",
                    BillID = "123",
                    BudgetID = "4",
                    CategoryID = "211",
                    CurrencyCode = "EUR",
                    CurrencyID = "3",
                    ForeignAmount = "123.45",
                    ForeignCurrencyCode = "GBP",
                    ForeignCurrencyID = "17",
                    PiggyBankID = "123",
                    Tags = ["Barbecue preparation"],
                },
            ],
            Type = RecurrenceTransactionType.Withdrawal,
            Active = true,
            ApplyRules = true,
            Description = "Recurring transaction for the monthly rent",
            Notes = "Some notes",
            NrOfRepetitions = 5,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        string expectedFirstDate = "2026-04-30";
        string expectedRepeatUntil = "2026-04-30";
        List<Repetition> expectedRepetitions =
        [
            new()
            {
                Moment = "3",
                Type = RecurrenceRepetitionType.Weekly,
                Skip = 0,
                Weekend = 1,
            },
        ];
        string expectedTitle = "Rent";
        List<Transaction> expectedTransactions =
        [
            new()
            {
                Amount = "123.45",
                Description = "Rent for the current month",
                DestinationID = "258",
                SourceID = "913",
                BillID = "123",
                BudgetID = "4",
                CategoryID = "211",
                CurrencyCode = "EUR",
                CurrencyID = "3",
                ForeignAmount = "123.45",
                ForeignCurrencyCode = "GBP",
                ForeignCurrencyID = "17",
                PiggyBankID = "123",
                Tags = ["Barbecue preparation"],
            },
        ];
        ApiEnum<string, RecurrenceTransactionType> expectedType =
            RecurrenceTransactionType.Withdrawal;
        bool expectedActive = true;
        bool expectedApplyRules = true;
        string expectedDescription = "Recurring transaction for the monthly rent";
        string expectedNotes = "Some notes";
        int expectedNrOfRepetitions = 5;
        string expectedXTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00";

        Assert.Equal(expectedFirstDate, parameters.FirstDate);
        Assert.Equal(expectedRepeatUntil, parameters.RepeatUntil);
        Assert.Equal(expectedRepetitions.Count, parameters.Repetitions.Count);
        for (int i = 0; i < expectedRepetitions.Count; i++)
        {
            Assert.Equal(expectedRepetitions[i], parameters.Repetitions[i]);
        }
        Assert.Equal(expectedTitle, parameters.Title);
        Assert.Equal(expectedTransactions.Count, parameters.Transactions.Count);
        for (int i = 0; i < expectedTransactions.Count; i++)
        {
            Assert.Equal(expectedTransactions[i], parameters.Transactions[i]);
        }
        Assert.Equal(expectedType, parameters.Type);
        Assert.Equal(expectedActive, parameters.Active);
        Assert.Equal(expectedApplyRules, parameters.ApplyRules);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedNotes, parameters.Notes);
        Assert.Equal(expectedNrOfRepetitions, parameters.NrOfRepetitions);
        Assert.Equal(expectedXTraceID, parameters.XTraceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new RecurrenceCreateParams
        {
            FirstDate = "2026-04-30",
            RepeatUntil = "2026-04-30",
            Repetitions =
            [
                new()
                {
                    Moment = "3",
                    Type = RecurrenceRepetitionType.Weekly,
                    Skip = 0,
                    Weekend = 1,
                },
            ],
            Title = "Rent",
            Transactions =
            [
                new()
                {
                    Amount = "123.45",
                    Description = "Rent for the current month",
                    DestinationID = "258",
                    SourceID = "913",
                    BillID = "123",
                    BudgetID = "4",
                    CategoryID = "211",
                    CurrencyCode = "EUR",
                    CurrencyID = "3",
                    ForeignAmount = "123.45",
                    ForeignCurrencyCode = "GBP",
                    ForeignCurrencyID = "17",
                    PiggyBankID = "123",
                    Tags = ["Barbecue preparation"],
                },
            ],
            Type = RecurrenceTransactionType.Withdrawal,
            Notes = "Some notes",
            NrOfRepetitions = 5,
        };

        Assert.Null(parameters.Active);
        Assert.False(parameters.RawBodyData.ContainsKey("active"));
        Assert.Null(parameters.ApplyRules);
        Assert.False(parameters.RawBodyData.ContainsKey("apply_rules"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new RecurrenceCreateParams
        {
            FirstDate = "2026-04-30",
            RepeatUntil = "2026-04-30",
            Repetitions =
            [
                new()
                {
                    Moment = "3",
                    Type = RecurrenceRepetitionType.Weekly,
                    Skip = 0,
                    Weekend = 1,
                },
            ],
            Title = "Rent",
            Transactions =
            [
                new()
                {
                    Amount = "123.45",
                    Description = "Rent for the current month",
                    DestinationID = "258",
                    SourceID = "913",
                    BillID = "123",
                    BudgetID = "4",
                    CategoryID = "211",
                    CurrencyCode = "EUR",
                    CurrencyID = "3",
                    ForeignAmount = "123.45",
                    ForeignCurrencyCode = "GBP",
                    ForeignCurrencyID = "17",
                    PiggyBankID = "123",
                    Tags = ["Barbecue preparation"],
                },
            ],
            Type = RecurrenceTransactionType.Withdrawal,
            Notes = "Some notes",
            NrOfRepetitions = 5,

            // Null should be interpreted as omitted for these properties
            Active = null,
            ApplyRules = null,
            Description = null,
            XTraceID = null,
        };

        Assert.Null(parameters.Active);
        Assert.False(parameters.RawBodyData.ContainsKey("active"));
        Assert.Null(parameters.ApplyRules);
        Assert.False(parameters.RawBodyData.ContainsKey("apply_rules"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new RecurrenceCreateParams
        {
            FirstDate = "2026-04-30",
            RepeatUntil = "2026-04-30",
            Repetitions =
            [
                new()
                {
                    Moment = "3",
                    Type = RecurrenceRepetitionType.Weekly,
                    Skip = 0,
                    Weekend = 1,
                },
            ],
            Title = "Rent",
            Transactions =
            [
                new()
                {
                    Amount = "123.45",
                    Description = "Rent for the current month",
                    DestinationID = "258",
                    SourceID = "913",
                    BillID = "123",
                    BudgetID = "4",
                    CategoryID = "211",
                    CurrencyCode = "EUR",
                    CurrencyID = "3",
                    ForeignAmount = "123.45",
                    ForeignCurrencyCode = "GBP",
                    ForeignCurrencyID = "17",
                    PiggyBankID = "123",
                    Tags = ["Barbecue preparation"],
                },
            ],
            Type = RecurrenceTransactionType.Withdrawal,
            Active = true,
            ApplyRules = true,
            Description = "Recurring transaction for the monthly rent",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        Assert.Null(parameters.Notes);
        Assert.False(parameters.RawBodyData.ContainsKey("notes"));
        Assert.Null(parameters.NrOfRepetitions);
        Assert.False(parameters.RawBodyData.ContainsKey("nr_of_repetitions"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new RecurrenceCreateParams
        {
            FirstDate = "2026-04-30",
            RepeatUntil = "2026-04-30",
            Repetitions =
            [
                new()
                {
                    Moment = "3",
                    Type = RecurrenceRepetitionType.Weekly,
                    Skip = 0,
                    Weekend = 1,
                },
            ],
            Title = "Rent",
            Transactions =
            [
                new()
                {
                    Amount = "123.45",
                    Description = "Rent for the current month",
                    DestinationID = "258",
                    SourceID = "913",
                    BillID = "123",
                    BudgetID = "4",
                    CategoryID = "211",
                    CurrencyCode = "EUR",
                    CurrencyID = "3",
                    ForeignAmount = "123.45",
                    ForeignCurrencyCode = "GBP",
                    ForeignCurrencyID = "17",
                    PiggyBankID = "123",
                    Tags = ["Barbecue preparation"],
                },
            ],
            Type = RecurrenceTransactionType.Withdrawal,
            Active = true,
            ApplyRules = true,
            Description = "Recurring transaction for the monthly rent",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",

            Notes = null,
            NrOfRepetitions = null,
        };

        Assert.Null(parameters.Notes);
        Assert.True(parameters.RawBodyData.ContainsKey("notes"));
        Assert.Null(parameters.NrOfRepetitions);
        Assert.True(parameters.RawBodyData.ContainsKey("nr_of_repetitions"));
    }

    [Fact]
    public void Url_Works()
    {
        RecurrenceCreateParams parameters = new()
        {
            FirstDate = "2026-04-30",
            RepeatUntil = "2026-04-30",
            Repetitions =
            [
                new()
                {
                    Moment = "3",
                    Type = RecurrenceRepetitionType.Weekly,
                    Skip = 0,
                    Weekend = 1,
                },
            ],
            Title = "Rent",
            Transactions =
            [
                new()
                {
                    Amount = "123.45",
                    Description = "Rent for the current month",
                    DestinationID = "258",
                    SourceID = "913",
                    BillID = "123",
                    BudgetID = "4",
                    CategoryID = "211",
                    CurrencyCode = "EUR",
                    CurrencyID = "3",
                    ForeignAmount = "123.45",
                    ForeignCurrencyCode = "GBP",
                    ForeignCurrencyID = "17",
                    PiggyBankID = "123",
                    Tags = ["Barbecue preparation"],
                },
            ],
            Type = RecurrenceTransactionType.Withdrawal,
        };

        var url = parameters.Url(new() { });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://demo.firefly-iii.org/api/v1/recurrences"), url)
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        RecurrenceCreateParams parameters = new()
        {
            FirstDate = "2026-04-30",
            RepeatUntil = "2026-04-30",
            Repetitions =
            [
                new()
                {
                    Moment = "3",
                    Type = RecurrenceRepetitionType.Weekly,
                    Skip = 0,
                    Weekend = 1,
                },
            ],
            Title = "Rent",
            Transactions =
            [
                new()
                {
                    Amount = "123.45",
                    Description = "Rent for the current month",
                    DestinationID = "258",
                    SourceID = "913",
                    BillID = "123",
                    BudgetID = "4",
                    CategoryID = "211",
                    CurrencyCode = "EUR",
                    CurrencyID = "3",
                    ForeignAmount = "123.45",
                    ForeignCurrencyCode = "GBP",
                    ForeignCurrencyID = "17",
                    PiggyBankID = "123",
                    Tags = ["Barbecue preparation"],
                },
            ],
            Type = RecurrenceTransactionType.Withdrawal,
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
        var parameters = new RecurrenceCreateParams
        {
            FirstDate = "2026-04-30",
            RepeatUntil = "2026-04-30",
            Repetitions =
            [
                new()
                {
                    Moment = "3",
                    Type = RecurrenceRepetitionType.Weekly,
                    Skip = 0,
                    Weekend = 1,
                },
            ],
            Title = "Rent",
            Transactions =
            [
                new()
                {
                    Amount = "123.45",
                    Description = "Rent for the current month",
                    DestinationID = "258",
                    SourceID = "913",
                    BillID = "123",
                    BudgetID = "4",
                    CategoryID = "211",
                    CurrencyCode = "EUR",
                    CurrencyID = "3",
                    ForeignAmount = "123.45",
                    ForeignCurrencyCode = "GBP",
                    ForeignCurrencyID = "17",
                    PiggyBankID = "123",
                    Tags = ["Barbecue preparation"],
                },
            ],
            Type = RecurrenceTransactionType.Withdrawal,
            Active = true,
            ApplyRules = true,
            Description = "Recurring transaction for the monthly rent",
            Notes = "Some notes",
            NrOfRepetitions = 5,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        RecurrenceCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class RepetitionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Repetition
        {
            Moment = "3",
            Type = RecurrenceRepetitionType.Weekly,
            Skip = 0,
            Weekend = 1,
        };

        string expectedMoment = "3";
        ApiEnum<string, RecurrenceRepetitionType> expectedType = RecurrenceRepetitionType.Weekly;
        int expectedSkip = 0;
        int expectedWeekend = 1;

        Assert.Equal(expectedMoment, model.Moment);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedSkip, model.Skip);
        Assert.Equal(expectedWeekend, model.Weekend);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Repetition
        {
            Moment = "3",
            Type = RecurrenceRepetitionType.Weekly,
            Skip = 0,
            Weekend = 1,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Repetition>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Repetition
        {
            Moment = "3",
            Type = RecurrenceRepetitionType.Weekly,
            Skip = 0,
            Weekend = 1,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Repetition>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMoment = "3";
        ApiEnum<string, RecurrenceRepetitionType> expectedType = RecurrenceRepetitionType.Weekly;
        int expectedSkip = 0;
        int expectedWeekend = 1;

        Assert.Equal(expectedMoment, deserialized.Moment);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedSkip, deserialized.Skip);
        Assert.Equal(expectedWeekend, deserialized.Weekend);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Repetition
        {
            Moment = "3",
            Type = RecurrenceRepetitionType.Weekly,
            Skip = 0,
            Weekend = 1,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Repetition { Moment = "3", Type = RecurrenceRepetitionType.Weekly };

        Assert.Null(model.Skip);
        Assert.False(model.RawData.ContainsKey("skip"));
        Assert.Null(model.Weekend);
        Assert.False(model.RawData.ContainsKey("weekend"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Repetition { Moment = "3", Type = RecurrenceRepetitionType.Weekly };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Repetition
        {
            Moment = "3",
            Type = RecurrenceRepetitionType.Weekly,

            // Null should be interpreted as omitted for these properties
            Skip = null,
            Weekend = null,
        };

        Assert.Null(model.Skip);
        Assert.False(model.RawData.ContainsKey("skip"));
        Assert.Null(model.Weekend);
        Assert.False(model.RawData.ContainsKey("weekend"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Repetition
        {
            Moment = "3",
            Type = RecurrenceRepetitionType.Weekly,

            // Null should be interpreted as omitted for these properties
            Skip = null,
            Weekend = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Repetition
        {
            Moment = "3",
            Type = RecurrenceRepetitionType.Weekly,
            Skip = 0,
            Weekend = 1,
        };

        Repetition copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TransactionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Transaction
        {
            Amount = "123.45",
            Description = "Rent for the current month",
            DestinationID = "258",
            SourceID = "913",
            BillID = "123",
            BudgetID = "4",
            CategoryID = "211",
            CurrencyCode = "EUR",
            CurrencyID = "3",
            ForeignAmount = "123.45",
            ForeignCurrencyCode = "GBP",
            ForeignCurrencyID = "17",
            PiggyBankID = "123",
            Tags = ["Barbecue preparation"],
        };

        string expectedAmount = "123.45";
        string expectedDescription = "Rent for the current month";
        string expectedDestinationID = "258";
        string expectedSourceID = "913";
        string expectedBillID = "123";
        string expectedBudgetID = "4";
        string expectedCategoryID = "211";
        string expectedCurrencyCode = "EUR";
        string expectedCurrencyID = "3";
        string expectedForeignAmount = "123.45";
        string expectedForeignCurrencyCode = "GBP";
        string expectedForeignCurrencyID = "17";
        string expectedPiggyBankID = "123";
        List<string> expectedTags = ["Barbecue preparation"];

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedDestinationID, model.DestinationID);
        Assert.Equal(expectedSourceID, model.SourceID);
        Assert.Equal(expectedBillID, model.BillID);
        Assert.Equal(expectedBudgetID, model.BudgetID);
        Assert.Equal(expectedCategoryID, model.CategoryID);
        Assert.Equal(expectedCurrencyCode, model.CurrencyCode);
        Assert.Equal(expectedCurrencyID, model.CurrencyID);
        Assert.Equal(expectedForeignAmount, model.ForeignAmount);
        Assert.Equal(expectedForeignCurrencyCode, model.ForeignCurrencyCode);
        Assert.Equal(expectedForeignCurrencyID, model.ForeignCurrencyID);
        Assert.Equal(expectedPiggyBankID, model.PiggyBankID);
        Assert.NotNull(model.Tags);
        Assert.Equal(expectedTags.Count, model.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], model.Tags[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Transaction
        {
            Amount = "123.45",
            Description = "Rent for the current month",
            DestinationID = "258",
            SourceID = "913",
            BillID = "123",
            BudgetID = "4",
            CategoryID = "211",
            CurrencyCode = "EUR",
            CurrencyID = "3",
            ForeignAmount = "123.45",
            ForeignCurrencyCode = "GBP",
            ForeignCurrencyID = "17",
            PiggyBankID = "123",
            Tags = ["Barbecue preparation"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Transaction>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Transaction
        {
            Amount = "123.45",
            Description = "Rent for the current month",
            DestinationID = "258",
            SourceID = "913",
            BillID = "123",
            BudgetID = "4",
            CategoryID = "211",
            CurrencyCode = "EUR",
            CurrencyID = "3",
            ForeignAmount = "123.45",
            ForeignCurrencyCode = "GBP",
            ForeignCurrencyID = "17",
            PiggyBankID = "123",
            Tags = ["Barbecue preparation"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Transaction>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAmount = "123.45";
        string expectedDescription = "Rent for the current month";
        string expectedDestinationID = "258";
        string expectedSourceID = "913";
        string expectedBillID = "123";
        string expectedBudgetID = "4";
        string expectedCategoryID = "211";
        string expectedCurrencyCode = "EUR";
        string expectedCurrencyID = "3";
        string expectedForeignAmount = "123.45";
        string expectedForeignCurrencyCode = "GBP";
        string expectedForeignCurrencyID = "17";
        string expectedPiggyBankID = "123";
        List<string> expectedTags = ["Barbecue preparation"];

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedDestinationID, deserialized.DestinationID);
        Assert.Equal(expectedSourceID, deserialized.SourceID);
        Assert.Equal(expectedBillID, deserialized.BillID);
        Assert.Equal(expectedBudgetID, deserialized.BudgetID);
        Assert.Equal(expectedCategoryID, deserialized.CategoryID);
        Assert.Equal(expectedCurrencyCode, deserialized.CurrencyCode);
        Assert.Equal(expectedCurrencyID, deserialized.CurrencyID);
        Assert.Equal(expectedForeignAmount, deserialized.ForeignAmount);
        Assert.Equal(expectedForeignCurrencyCode, deserialized.ForeignCurrencyCode);
        Assert.Equal(expectedForeignCurrencyID, deserialized.ForeignCurrencyID);
        Assert.Equal(expectedPiggyBankID, deserialized.PiggyBankID);
        Assert.NotNull(deserialized.Tags);
        Assert.Equal(expectedTags.Count, deserialized.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], deserialized.Tags[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Transaction
        {
            Amount = "123.45",
            Description = "Rent for the current month",
            DestinationID = "258",
            SourceID = "913",
            BillID = "123",
            BudgetID = "4",
            CategoryID = "211",
            CurrencyCode = "EUR",
            CurrencyID = "3",
            ForeignAmount = "123.45",
            ForeignCurrencyCode = "GBP",
            ForeignCurrencyID = "17",
            PiggyBankID = "123",
            Tags = ["Barbecue preparation"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Transaction
        {
            Amount = "123.45",
            Description = "Rent for the current month",
            DestinationID = "258",
            SourceID = "913",
            BillID = "123",
            ForeignAmount = "123.45",
            ForeignCurrencyCode = "GBP",
            ForeignCurrencyID = "17",
            PiggyBankID = "123",
            Tags = ["Barbecue preparation"],
        };

        Assert.Null(model.BudgetID);
        Assert.False(model.RawData.ContainsKey("budget_id"));
        Assert.Null(model.CategoryID);
        Assert.False(model.RawData.ContainsKey("category_id"));
        Assert.Null(model.CurrencyCode);
        Assert.False(model.RawData.ContainsKey("currency_code"));
        Assert.Null(model.CurrencyID);
        Assert.False(model.RawData.ContainsKey("currency_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Transaction
        {
            Amount = "123.45",
            Description = "Rent for the current month",
            DestinationID = "258",
            SourceID = "913",
            BillID = "123",
            ForeignAmount = "123.45",
            ForeignCurrencyCode = "GBP",
            ForeignCurrencyID = "17",
            PiggyBankID = "123",
            Tags = ["Barbecue preparation"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Transaction
        {
            Amount = "123.45",
            Description = "Rent for the current month",
            DestinationID = "258",
            SourceID = "913",
            BillID = "123",
            ForeignAmount = "123.45",
            ForeignCurrencyCode = "GBP",
            ForeignCurrencyID = "17",
            PiggyBankID = "123",
            Tags = ["Barbecue preparation"],

            // Null should be interpreted as omitted for these properties
            BudgetID = null,
            CategoryID = null,
            CurrencyCode = null,
            CurrencyID = null,
        };

        Assert.Null(model.BudgetID);
        Assert.False(model.RawData.ContainsKey("budget_id"));
        Assert.Null(model.CategoryID);
        Assert.False(model.RawData.ContainsKey("category_id"));
        Assert.Null(model.CurrencyCode);
        Assert.False(model.RawData.ContainsKey("currency_code"));
        Assert.Null(model.CurrencyID);
        Assert.False(model.RawData.ContainsKey("currency_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Transaction
        {
            Amount = "123.45",
            Description = "Rent for the current month",
            DestinationID = "258",
            SourceID = "913",
            BillID = "123",
            ForeignAmount = "123.45",
            ForeignCurrencyCode = "GBP",
            ForeignCurrencyID = "17",
            PiggyBankID = "123",
            Tags = ["Barbecue preparation"],

            // Null should be interpreted as omitted for these properties
            BudgetID = null,
            CategoryID = null,
            CurrencyCode = null,
            CurrencyID = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Transaction
        {
            Amount = "123.45",
            Description = "Rent for the current month",
            DestinationID = "258",
            SourceID = "913",
            BudgetID = "4",
            CategoryID = "211",
            CurrencyCode = "EUR",
            CurrencyID = "3",
        };

        Assert.Null(model.BillID);
        Assert.False(model.RawData.ContainsKey("bill_id"));
        Assert.Null(model.ForeignAmount);
        Assert.False(model.RawData.ContainsKey("foreign_amount"));
        Assert.Null(model.ForeignCurrencyCode);
        Assert.False(model.RawData.ContainsKey("foreign_currency_code"));
        Assert.Null(model.ForeignCurrencyID);
        Assert.False(model.RawData.ContainsKey("foreign_currency_id"));
        Assert.Null(model.PiggyBankID);
        Assert.False(model.RawData.ContainsKey("piggy_bank_id"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Transaction
        {
            Amount = "123.45",
            Description = "Rent for the current month",
            DestinationID = "258",
            SourceID = "913",
            BudgetID = "4",
            CategoryID = "211",
            CurrencyCode = "EUR",
            CurrencyID = "3",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Transaction
        {
            Amount = "123.45",
            Description = "Rent for the current month",
            DestinationID = "258",
            SourceID = "913",
            BudgetID = "4",
            CategoryID = "211",
            CurrencyCode = "EUR",
            CurrencyID = "3",

            BillID = null,
            ForeignAmount = null,
            ForeignCurrencyCode = null,
            ForeignCurrencyID = null,
            PiggyBankID = null,
            Tags = null,
        };

        Assert.Null(model.BillID);
        Assert.True(model.RawData.ContainsKey("bill_id"));
        Assert.Null(model.ForeignAmount);
        Assert.True(model.RawData.ContainsKey("foreign_amount"));
        Assert.Null(model.ForeignCurrencyCode);
        Assert.True(model.RawData.ContainsKey("foreign_currency_code"));
        Assert.Null(model.ForeignCurrencyID);
        Assert.True(model.RawData.ContainsKey("foreign_currency_id"));
        Assert.Null(model.PiggyBankID);
        Assert.True(model.RawData.ContainsKey("piggy_bank_id"));
        Assert.Null(model.Tags);
        Assert.True(model.RawData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Transaction
        {
            Amount = "123.45",
            Description = "Rent for the current month",
            DestinationID = "258",
            SourceID = "913",
            BudgetID = "4",
            CategoryID = "211",
            CurrencyCode = "EUR",
            CurrencyID = "3",

            BillID = null,
            ForeignAmount = null,
            ForeignCurrencyCode = null,
            ForeignCurrencyID = null,
            PiggyBankID = null,
            Tags = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Transaction
        {
            Amount = "123.45",
            Description = "Rent for the current month",
            DestinationID = "258",
            SourceID = "913",
            BillID = "123",
            BudgetID = "4",
            CategoryID = "211",
            CurrencyCode = "EUR",
            CurrencyID = "3",
            ForeignAmount = "123.45",
            ForeignCurrencyCode = "GBP",
            ForeignCurrencyID = "17",
            PiggyBankID = "123",
            Tags = ["Barbecue preparation"],
        };

        Transaction copied = new(model);

        Assert.Equal(model, copied);
    }
}
