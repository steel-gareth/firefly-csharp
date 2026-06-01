using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Recurrences;

namespace EmceesProdTesting5.Tests.Models.Recurrences;

public class RecurrenceUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RecurrenceUpdateParams
        {
            ID = "123",
            Active = true,
            ApplyRules = true,
            Description = "Recurring transaction for the monthly rent",
            FirstDate = "2026-04-30",
            Notes = "Some notes",
            NrOfRepetitions = 5,
            RepeatUntil = "2026-04-30",
            Repetitions =
            [
                new()
                {
                    Moment = "3",
                    Skip = 0,
                    Type = RecurrenceRepetitionType.Weekly,
                    Weekend = 1,
                },
            ],
            Title = "Rent",
            Transactions =
            [
                new()
                {
                    ID =
                        "ID of the recurring transaction. Not to be confused with the ID of the recurrence itself. Is marked as REQUIRED but can be skipped when there is only ONE transaction.",
                    Amount = "123.45",
                    BillID = "123",
                    BudgetID = "4",
                    CategoryID = "211",
                    CurrencyCode = "EUR",
                    CurrencyID = "3",
                    Description = "Rent for the current month",
                    DestinationID = "258",
                    ForeignAmount = "123.45",
                    ForeignCurrencyID = "17",
                    PiggyBankID = "123",
                    SourceID = "913",
                    Tags = ["Barbecue preparation"],
                },
            ],
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        string expectedID = "123";
        bool expectedActive = true;
        bool expectedApplyRules = true;
        string expectedDescription = "Recurring transaction for the monthly rent";
        string expectedFirstDate = "2026-04-30";
        string expectedNotes = "Some notes";
        int expectedNrOfRepetitions = 5;
        string expectedRepeatUntil = "2026-04-30";
        List<RecurrenceUpdateParamsRepetition> expectedRepetitions =
        [
            new()
            {
                Moment = "3",
                Skip = 0,
                Type = RecurrenceRepetitionType.Weekly,
                Weekend = 1,
            },
        ];
        string expectedTitle = "Rent";
        List<RecurrenceUpdateParamsTransaction> expectedTransactions =
        [
            new()
            {
                ID =
                    "ID of the recurring transaction. Not to be confused with the ID of the recurrence itself. Is marked as REQUIRED but can be skipped when there is only ONE transaction.",
                Amount = "123.45",
                BillID = "123",
                BudgetID = "4",
                CategoryID = "211",
                CurrencyCode = "EUR",
                CurrencyID = "3",
                Description = "Rent for the current month",
                DestinationID = "258",
                ForeignAmount = "123.45",
                ForeignCurrencyID = "17",
                PiggyBankID = "123",
                SourceID = "913",
                Tags = ["Barbecue preparation"],
            },
        ];
        string expectedXTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedActive, parameters.Active);
        Assert.Equal(expectedApplyRules, parameters.ApplyRules);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedFirstDate, parameters.FirstDate);
        Assert.Equal(expectedNotes, parameters.Notes);
        Assert.Equal(expectedNrOfRepetitions, parameters.NrOfRepetitions);
        Assert.Equal(expectedRepeatUntil, parameters.RepeatUntil);
        Assert.NotNull(parameters.Repetitions);
        Assert.Equal(expectedRepetitions.Count, parameters.Repetitions.Count);
        for (int i = 0; i < expectedRepetitions.Count; i++)
        {
            Assert.Equal(expectedRepetitions[i], parameters.Repetitions[i]);
        }
        Assert.Equal(expectedTitle, parameters.Title);
        Assert.NotNull(parameters.Transactions);
        Assert.Equal(expectedTransactions.Count, parameters.Transactions.Count);
        for (int i = 0; i < expectedTransactions.Count; i++)
        {
            Assert.Equal(expectedTransactions[i], parameters.Transactions[i]);
        }
        Assert.Equal(expectedXTraceID, parameters.XTraceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new RecurrenceUpdateParams
        {
            ID = "123",
            Notes = "Some notes",
            NrOfRepetitions = 5,
            RepeatUntil = "2026-04-30",
        };

        Assert.Null(parameters.Active);
        Assert.False(parameters.RawBodyData.ContainsKey("active"));
        Assert.Null(parameters.ApplyRules);
        Assert.False(parameters.RawBodyData.ContainsKey("apply_rules"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.FirstDate);
        Assert.False(parameters.RawBodyData.ContainsKey("first_date"));
        Assert.Null(parameters.Repetitions);
        Assert.False(parameters.RawBodyData.ContainsKey("repetitions"));
        Assert.Null(parameters.Title);
        Assert.False(parameters.RawBodyData.ContainsKey("title"));
        Assert.Null(parameters.Transactions);
        Assert.False(parameters.RawBodyData.ContainsKey("transactions"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new RecurrenceUpdateParams
        {
            ID = "123",
            Notes = "Some notes",
            NrOfRepetitions = 5,
            RepeatUntil = "2026-04-30",

            // Null should be interpreted as omitted for these properties
            Active = null,
            ApplyRules = null,
            Description = null,
            FirstDate = null,
            Repetitions = null,
            Title = null,
            Transactions = null,
            XTraceID = null,
        };

        Assert.Null(parameters.Active);
        Assert.False(parameters.RawBodyData.ContainsKey("active"));
        Assert.Null(parameters.ApplyRules);
        Assert.False(parameters.RawBodyData.ContainsKey("apply_rules"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.FirstDate);
        Assert.False(parameters.RawBodyData.ContainsKey("first_date"));
        Assert.Null(parameters.Repetitions);
        Assert.False(parameters.RawBodyData.ContainsKey("repetitions"));
        Assert.Null(parameters.Title);
        Assert.False(parameters.RawBodyData.ContainsKey("title"));
        Assert.Null(parameters.Transactions);
        Assert.False(parameters.RawBodyData.ContainsKey("transactions"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new RecurrenceUpdateParams
        {
            ID = "123",
            Active = true,
            ApplyRules = true,
            Description = "Recurring transaction for the monthly rent",
            FirstDate = "2026-04-30",
            Repetitions =
            [
                new()
                {
                    Moment = "3",
                    Skip = 0,
                    Type = RecurrenceRepetitionType.Weekly,
                    Weekend = 1,
                },
            ],
            Title = "Rent",
            Transactions =
            [
                new()
                {
                    ID =
                        "ID of the recurring transaction. Not to be confused with the ID of the recurrence itself. Is marked as REQUIRED but can be skipped when there is only ONE transaction.",
                    Amount = "123.45",
                    BillID = "123",
                    BudgetID = "4",
                    CategoryID = "211",
                    CurrencyCode = "EUR",
                    CurrencyID = "3",
                    Description = "Rent for the current month",
                    DestinationID = "258",
                    ForeignAmount = "123.45",
                    ForeignCurrencyID = "17",
                    PiggyBankID = "123",
                    SourceID = "913",
                    Tags = ["Barbecue preparation"],
                },
            ],
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        Assert.Null(parameters.Notes);
        Assert.False(parameters.RawBodyData.ContainsKey("notes"));
        Assert.Null(parameters.NrOfRepetitions);
        Assert.False(parameters.RawBodyData.ContainsKey("nr_of_repetitions"));
        Assert.Null(parameters.RepeatUntil);
        Assert.False(parameters.RawBodyData.ContainsKey("repeat_until"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new RecurrenceUpdateParams
        {
            ID = "123",
            Active = true,
            ApplyRules = true,
            Description = "Recurring transaction for the monthly rent",
            FirstDate = "2026-04-30",
            Repetitions =
            [
                new()
                {
                    Moment = "3",
                    Skip = 0,
                    Type = RecurrenceRepetitionType.Weekly,
                    Weekend = 1,
                },
            ],
            Title = "Rent",
            Transactions =
            [
                new()
                {
                    ID =
                        "ID of the recurring transaction. Not to be confused with the ID of the recurrence itself. Is marked as REQUIRED but can be skipped when there is only ONE transaction.",
                    Amount = "123.45",
                    BillID = "123",
                    BudgetID = "4",
                    CategoryID = "211",
                    CurrencyCode = "EUR",
                    CurrencyID = "3",
                    Description = "Rent for the current month",
                    DestinationID = "258",
                    ForeignAmount = "123.45",
                    ForeignCurrencyID = "17",
                    PiggyBankID = "123",
                    SourceID = "913",
                    Tags = ["Barbecue preparation"],
                },
            ],
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",

            Notes = null,
            NrOfRepetitions = null,
            RepeatUntil = null,
        };

        Assert.Null(parameters.Notes);
        Assert.True(parameters.RawBodyData.ContainsKey("notes"));
        Assert.Null(parameters.NrOfRepetitions);
        Assert.True(parameters.RawBodyData.ContainsKey("nr_of_repetitions"));
        Assert.Null(parameters.RepeatUntil);
        Assert.True(parameters.RawBodyData.ContainsKey("repeat_until"));
    }

    [Fact]
    public void Url_Works()
    {
        RecurrenceUpdateParams parameters = new() { ID = "123" };

        var url = parameters.Url(new() { });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://demo.firefly-iii.org/api/v1/recurrences/123"), url)
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        RecurrenceUpdateParams parameters = new()
        {
            ID = "123",
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
        var parameters = new RecurrenceUpdateParams
        {
            ID = "123",
            Active = true,
            ApplyRules = true,
            Description = "Recurring transaction for the monthly rent",
            FirstDate = "2026-04-30",
            Notes = "Some notes",
            NrOfRepetitions = 5,
            RepeatUntil = "2026-04-30",
            Repetitions =
            [
                new()
                {
                    Moment = "3",
                    Skip = 0,
                    Type = RecurrenceRepetitionType.Weekly,
                    Weekend = 1,
                },
            ],
            Title = "Rent",
            Transactions =
            [
                new()
                {
                    ID =
                        "ID of the recurring transaction. Not to be confused with the ID of the recurrence itself. Is marked as REQUIRED but can be skipped when there is only ONE transaction.",
                    Amount = "123.45",
                    BillID = "123",
                    BudgetID = "4",
                    CategoryID = "211",
                    CurrencyCode = "EUR",
                    CurrencyID = "3",
                    Description = "Rent for the current month",
                    DestinationID = "258",
                    ForeignAmount = "123.45",
                    ForeignCurrencyID = "17",
                    PiggyBankID = "123",
                    SourceID = "913",
                    Tags = ["Barbecue preparation"],
                },
            ],
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        RecurrenceUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class RecurrenceUpdateParamsRepetitionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RecurrenceUpdateParamsRepetition
        {
            Moment = "3",
            Skip = 0,
            Type = RecurrenceRepetitionType.Weekly,
            Weekend = 1,
        };

        string expectedMoment = "3";
        int expectedSkip = 0;
        ApiEnum<string, RecurrenceRepetitionType> expectedType = RecurrenceRepetitionType.Weekly;
        int expectedWeekend = 1;

        Assert.Equal(expectedMoment, model.Moment);
        Assert.Equal(expectedSkip, model.Skip);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedWeekend, model.Weekend);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RecurrenceUpdateParamsRepetition
        {
            Moment = "3",
            Skip = 0,
            Type = RecurrenceRepetitionType.Weekly,
            Weekend = 1,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RecurrenceUpdateParamsRepetition>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RecurrenceUpdateParamsRepetition
        {
            Moment = "3",
            Skip = 0,
            Type = RecurrenceRepetitionType.Weekly,
            Weekend = 1,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RecurrenceUpdateParamsRepetition>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMoment = "3";
        int expectedSkip = 0;
        ApiEnum<string, RecurrenceRepetitionType> expectedType = RecurrenceRepetitionType.Weekly;
        int expectedWeekend = 1;

        Assert.Equal(expectedMoment, deserialized.Moment);
        Assert.Equal(expectedSkip, deserialized.Skip);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedWeekend, deserialized.Weekend);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RecurrenceUpdateParamsRepetition
        {
            Moment = "3",
            Skip = 0,
            Type = RecurrenceRepetitionType.Weekly,
            Weekend = 1,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RecurrenceUpdateParamsRepetition { };

        Assert.Null(model.Moment);
        Assert.False(model.RawData.ContainsKey("moment"));
        Assert.Null(model.Skip);
        Assert.False(model.RawData.ContainsKey("skip"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.Weekend);
        Assert.False(model.RawData.ContainsKey("weekend"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new RecurrenceUpdateParamsRepetition { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new RecurrenceUpdateParamsRepetition
        {
            // Null should be interpreted as omitted for these properties
            Moment = null,
            Skip = null,
            Type = null,
            Weekend = null,
        };

        Assert.Null(model.Moment);
        Assert.False(model.RawData.ContainsKey("moment"));
        Assert.Null(model.Skip);
        Assert.False(model.RawData.ContainsKey("skip"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.Weekend);
        Assert.False(model.RawData.ContainsKey("weekend"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new RecurrenceUpdateParamsRepetition
        {
            // Null should be interpreted as omitted for these properties
            Moment = null,
            Skip = null,
            Type = null,
            Weekend = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RecurrenceUpdateParamsRepetition
        {
            Moment = "3",
            Skip = 0,
            Type = RecurrenceRepetitionType.Weekly,
            Weekend = 1,
        };

        RecurrenceUpdateParamsRepetition copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RecurrenceUpdateParamsTransactionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RecurrenceUpdateParamsTransaction
        {
            ID =
                "ID of the recurring transaction. Not to be confused with the ID of the recurrence itself. Is marked as REQUIRED but can be skipped when there is only ONE transaction.",
            Amount = "123.45",
            BillID = "123",
            BudgetID = "4",
            CategoryID = "211",
            CurrencyCode = "EUR",
            CurrencyID = "3",
            Description = "Rent for the current month",
            DestinationID = "258",
            ForeignAmount = "123.45",
            ForeignCurrencyID = "17",
            PiggyBankID = "123",
            SourceID = "913",
            Tags = ["Barbecue preparation"],
        };

        string expectedID =
            "ID of the recurring transaction. Not to be confused with the ID of the recurrence itself. Is marked as REQUIRED but can be skipped when there is only ONE transaction.";
        string expectedAmount = "123.45";
        string expectedBillID = "123";
        string expectedBudgetID = "4";
        string expectedCategoryID = "211";
        string expectedCurrencyCode = "EUR";
        string expectedCurrencyID = "3";
        string expectedDescription = "Rent for the current month";
        string expectedDestinationID = "258";
        string expectedForeignAmount = "123.45";
        string expectedForeignCurrencyID = "17";
        string expectedPiggyBankID = "123";
        string expectedSourceID = "913";
        List<string> expectedTags = ["Barbecue preparation"];

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedBillID, model.BillID);
        Assert.Equal(expectedBudgetID, model.BudgetID);
        Assert.Equal(expectedCategoryID, model.CategoryID);
        Assert.Equal(expectedCurrencyCode, model.CurrencyCode);
        Assert.Equal(expectedCurrencyID, model.CurrencyID);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedDestinationID, model.DestinationID);
        Assert.Equal(expectedForeignAmount, model.ForeignAmount);
        Assert.Equal(expectedForeignCurrencyID, model.ForeignCurrencyID);
        Assert.Equal(expectedPiggyBankID, model.PiggyBankID);
        Assert.Equal(expectedSourceID, model.SourceID);
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
        var model = new RecurrenceUpdateParamsTransaction
        {
            ID =
                "ID of the recurring transaction. Not to be confused with the ID of the recurrence itself. Is marked as REQUIRED but can be skipped when there is only ONE transaction.",
            Amount = "123.45",
            BillID = "123",
            BudgetID = "4",
            CategoryID = "211",
            CurrencyCode = "EUR",
            CurrencyID = "3",
            Description = "Rent for the current month",
            DestinationID = "258",
            ForeignAmount = "123.45",
            ForeignCurrencyID = "17",
            PiggyBankID = "123",
            SourceID = "913",
            Tags = ["Barbecue preparation"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RecurrenceUpdateParamsTransaction>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RecurrenceUpdateParamsTransaction
        {
            ID =
                "ID of the recurring transaction. Not to be confused with the ID of the recurrence itself. Is marked as REQUIRED but can be skipped when there is only ONE transaction.",
            Amount = "123.45",
            BillID = "123",
            BudgetID = "4",
            CategoryID = "211",
            CurrencyCode = "EUR",
            CurrencyID = "3",
            Description = "Rent for the current month",
            DestinationID = "258",
            ForeignAmount = "123.45",
            ForeignCurrencyID = "17",
            PiggyBankID = "123",
            SourceID = "913",
            Tags = ["Barbecue preparation"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RecurrenceUpdateParamsTransaction>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID =
            "ID of the recurring transaction. Not to be confused with the ID of the recurrence itself. Is marked as REQUIRED but can be skipped when there is only ONE transaction.";
        string expectedAmount = "123.45";
        string expectedBillID = "123";
        string expectedBudgetID = "4";
        string expectedCategoryID = "211";
        string expectedCurrencyCode = "EUR";
        string expectedCurrencyID = "3";
        string expectedDescription = "Rent for the current month";
        string expectedDestinationID = "258";
        string expectedForeignAmount = "123.45";
        string expectedForeignCurrencyID = "17";
        string expectedPiggyBankID = "123";
        string expectedSourceID = "913";
        List<string> expectedTags = ["Barbecue preparation"];

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedBillID, deserialized.BillID);
        Assert.Equal(expectedBudgetID, deserialized.BudgetID);
        Assert.Equal(expectedCategoryID, deserialized.CategoryID);
        Assert.Equal(expectedCurrencyCode, deserialized.CurrencyCode);
        Assert.Equal(expectedCurrencyID, deserialized.CurrencyID);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedDestinationID, deserialized.DestinationID);
        Assert.Equal(expectedForeignAmount, deserialized.ForeignAmount);
        Assert.Equal(expectedForeignCurrencyID, deserialized.ForeignCurrencyID);
        Assert.Equal(expectedPiggyBankID, deserialized.PiggyBankID);
        Assert.Equal(expectedSourceID, deserialized.SourceID);
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
        var model = new RecurrenceUpdateParamsTransaction
        {
            ID =
                "ID of the recurring transaction. Not to be confused with the ID of the recurrence itself. Is marked as REQUIRED but can be skipped when there is only ONE transaction.",
            Amount = "123.45",
            BillID = "123",
            BudgetID = "4",
            CategoryID = "211",
            CurrencyCode = "EUR",
            CurrencyID = "3",
            Description = "Rent for the current month",
            DestinationID = "258",
            ForeignAmount = "123.45",
            ForeignCurrencyID = "17",
            PiggyBankID = "123",
            SourceID = "913",
            Tags = ["Barbecue preparation"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RecurrenceUpdateParamsTransaction
        {
            ID =
                "ID of the recurring transaction. Not to be confused with the ID of the recurrence itself. Is marked as REQUIRED but can be skipped when there is only ONE transaction.",
            BillID = "123",
            ForeignAmount = "123.45",
            ForeignCurrencyID = "17",
            PiggyBankID = "123",
            Tags = ["Barbecue preparation"],
        };

        Assert.Null(model.Amount);
        Assert.False(model.RawData.ContainsKey("amount"));
        Assert.Null(model.BudgetID);
        Assert.False(model.RawData.ContainsKey("budget_id"));
        Assert.Null(model.CategoryID);
        Assert.False(model.RawData.ContainsKey("category_id"));
        Assert.Null(model.CurrencyCode);
        Assert.False(model.RawData.ContainsKey("currency_code"));
        Assert.Null(model.CurrencyID);
        Assert.False(model.RawData.ContainsKey("currency_id"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.DestinationID);
        Assert.False(model.RawData.ContainsKey("destination_id"));
        Assert.Null(model.SourceID);
        Assert.False(model.RawData.ContainsKey("source_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new RecurrenceUpdateParamsTransaction
        {
            ID =
                "ID of the recurring transaction. Not to be confused with the ID of the recurrence itself. Is marked as REQUIRED but can be skipped when there is only ONE transaction.",
            BillID = "123",
            ForeignAmount = "123.45",
            ForeignCurrencyID = "17",
            PiggyBankID = "123",
            Tags = ["Barbecue preparation"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new RecurrenceUpdateParamsTransaction
        {
            ID =
                "ID of the recurring transaction. Not to be confused with the ID of the recurrence itself. Is marked as REQUIRED but can be skipped when there is only ONE transaction.",
            BillID = "123",
            ForeignAmount = "123.45",
            ForeignCurrencyID = "17",
            PiggyBankID = "123",
            Tags = ["Barbecue preparation"],

            // Null should be interpreted as omitted for these properties
            Amount = null,
            BudgetID = null,
            CategoryID = null,
            CurrencyCode = null,
            CurrencyID = null,
            Description = null,
            DestinationID = null,
            SourceID = null,
        };

        Assert.Null(model.Amount);
        Assert.False(model.RawData.ContainsKey("amount"));
        Assert.Null(model.BudgetID);
        Assert.False(model.RawData.ContainsKey("budget_id"));
        Assert.Null(model.CategoryID);
        Assert.False(model.RawData.ContainsKey("category_id"));
        Assert.Null(model.CurrencyCode);
        Assert.False(model.RawData.ContainsKey("currency_code"));
        Assert.Null(model.CurrencyID);
        Assert.False(model.RawData.ContainsKey("currency_id"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.DestinationID);
        Assert.False(model.RawData.ContainsKey("destination_id"));
        Assert.Null(model.SourceID);
        Assert.False(model.RawData.ContainsKey("source_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new RecurrenceUpdateParamsTransaction
        {
            ID =
                "ID of the recurring transaction. Not to be confused with the ID of the recurrence itself. Is marked as REQUIRED but can be skipped when there is only ONE transaction.",
            BillID = "123",
            ForeignAmount = "123.45",
            ForeignCurrencyID = "17",
            PiggyBankID = "123",
            Tags = ["Barbecue preparation"],

            // Null should be interpreted as omitted for these properties
            Amount = null,
            BudgetID = null,
            CategoryID = null,
            CurrencyCode = null,
            CurrencyID = null,
            Description = null,
            DestinationID = null,
            SourceID = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RecurrenceUpdateParamsTransaction
        {
            ID =
                "ID of the recurring transaction. Not to be confused with the ID of the recurrence itself. Is marked as REQUIRED but can be skipped when there is only ONE transaction.",
            Amount = "123.45",
            BudgetID = "4",
            CategoryID = "211",
            CurrencyCode = "EUR",
            CurrencyID = "3",
            Description = "Rent for the current month",
            DestinationID = "258",
            SourceID = "913",
        };

        Assert.Null(model.BillID);
        Assert.False(model.RawData.ContainsKey("bill_id"));
        Assert.Null(model.ForeignAmount);
        Assert.False(model.RawData.ContainsKey("foreign_amount"));
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
        var model = new RecurrenceUpdateParamsTransaction
        {
            ID =
                "ID of the recurring transaction. Not to be confused with the ID of the recurrence itself. Is marked as REQUIRED but can be skipped when there is only ONE transaction.",
            Amount = "123.45",
            BudgetID = "4",
            CategoryID = "211",
            CurrencyCode = "EUR",
            CurrencyID = "3",
            Description = "Rent for the current month",
            DestinationID = "258",
            SourceID = "913",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new RecurrenceUpdateParamsTransaction
        {
            ID =
                "ID of the recurring transaction. Not to be confused with the ID of the recurrence itself. Is marked as REQUIRED but can be skipped when there is only ONE transaction.",
            Amount = "123.45",
            BudgetID = "4",
            CategoryID = "211",
            CurrencyCode = "EUR",
            CurrencyID = "3",
            Description = "Rent for the current month",
            DestinationID = "258",
            SourceID = "913",

            BillID = null,
            ForeignAmount = null,
            ForeignCurrencyID = null,
            PiggyBankID = null,
            Tags = null,
        };

        Assert.Null(model.BillID);
        Assert.True(model.RawData.ContainsKey("bill_id"));
        Assert.Null(model.ForeignAmount);
        Assert.True(model.RawData.ContainsKey("foreign_amount"));
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
        var model = new RecurrenceUpdateParamsTransaction
        {
            ID =
                "ID of the recurring transaction. Not to be confused with the ID of the recurrence itself. Is marked as REQUIRED but can be skipped when there is only ONE transaction.",
            Amount = "123.45",
            BudgetID = "4",
            CategoryID = "211",
            CurrencyCode = "EUR",
            CurrencyID = "3",
            Description = "Rent for the current month",
            DestinationID = "258",
            SourceID = "913",

            BillID = null,
            ForeignAmount = null,
            ForeignCurrencyID = null,
            PiggyBankID = null,
            Tags = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RecurrenceUpdateParamsTransaction
        {
            ID =
                "ID of the recurring transaction. Not to be confused with the ID of the recurrence itself. Is marked as REQUIRED but can be skipped when there is only ONE transaction.",
            Amount = "123.45",
            BillID = "123",
            BudgetID = "4",
            CategoryID = "211",
            CurrencyCode = "EUR",
            CurrencyID = "3",
            Description = "Rent for the current month",
            DestinationID = "258",
            ForeignAmount = "123.45",
            ForeignCurrencyID = "17",
            PiggyBankID = "123",
            SourceID = "913",
            Tags = ["Barbecue preparation"],
        };

        RecurrenceUpdateParamsTransaction copied = new(model);

        Assert.Equal(model, copied);
    }
}
