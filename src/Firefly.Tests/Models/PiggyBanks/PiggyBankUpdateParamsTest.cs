using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Firefly.Core;
using Firefly.Models.PiggyBanks;

namespace Firefly.Tests.Models.PiggyBanks;

public class PiggyBankUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PiggyBankUpdateParams
        {
            ID = "123",
            Accounts =
            [
                new()
                {
                    ID = JsonSerializer.Deserialize<JsonElement>("{}"),
                    AccountID = "3",
                    CurrentAmount = "123.45",
                    Name = "Checking account",
                },
            ],
            Name = "New digital camera",
            Notes = "Some notes",
            ObjectGroupID = "5",
            ObjectGroupTitle = "Example Group",
            Order = 5,
            StartDate = "2026-04-01",
            TargetAmount = "123.45",
            TargetDate = "2026-04-30",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        string expectedID = "123";
        List<PiggyBankUpdateParamsAccount> expectedAccounts =
        [
            new()
            {
                ID = JsonSerializer.Deserialize<JsonElement>("{}"),
                AccountID = "3",
                CurrentAmount = "123.45",
                Name = "Checking account",
            },
        ];
        string expectedName = "New digital camera";
        string expectedNotes = "Some notes";
        string expectedObjectGroupID = "5";
        string expectedObjectGroupTitle = "Example Group";
        int expectedOrder = 5;
        string expectedStartDate = "2026-04-01";
        string expectedTargetAmount = "123.45";
        string expectedTargetDate = "2026-04-30";
        string expectedXTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00";

        Assert.Equal(expectedID, parameters.ID);
        Assert.NotNull(parameters.Accounts);
        Assert.Equal(expectedAccounts.Count, parameters.Accounts.Count);
        for (int i = 0; i < expectedAccounts.Count; i++)
        {
            Assert.Equal(expectedAccounts[i], parameters.Accounts[i]);
        }
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedNotes, parameters.Notes);
        Assert.Equal(expectedObjectGroupID, parameters.ObjectGroupID);
        Assert.Equal(expectedObjectGroupTitle, parameters.ObjectGroupTitle);
        Assert.Equal(expectedOrder, parameters.Order);
        Assert.Equal(expectedStartDate, parameters.StartDate);
        Assert.Equal(expectedTargetAmount, parameters.TargetAmount);
        Assert.Equal(expectedTargetDate, parameters.TargetDate);
        Assert.Equal(expectedXTraceID, parameters.XTraceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PiggyBankUpdateParams
        {
            ID = "123",
            Notes = "Some notes",
            ObjectGroupID = "5",
            ObjectGroupTitle = "Example Group",
            TargetAmount = "123.45",
            TargetDate = "2026-04-30",
        };

        Assert.Null(parameters.Accounts);
        Assert.False(parameters.RawBodyData.ContainsKey("accounts"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Order);
        Assert.False(parameters.RawBodyData.ContainsKey("order"));
        Assert.Null(parameters.StartDate);
        Assert.False(parameters.RawBodyData.ContainsKey("start_date"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new PiggyBankUpdateParams
        {
            ID = "123",
            Notes = "Some notes",
            ObjectGroupID = "5",
            ObjectGroupTitle = "Example Group",
            TargetAmount = "123.45",
            TargetDate = "2026-04-30",

            // Null should be interpreted as omitted for these properties
            Accounts = null,
            Name = null,
            Order = null,
            StartDate = null,
            XTraceID = null,
        };

        Assert.Null(parameters.Accounts);
        Assert.False(parameters.RawBodyData.ContainsKey("accounts"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Order);
        Assert.False(parameters.RawBodyData.ContainsKey("order"));
        Assert.Null(parameters.StartDate);
        Assert.False(parameters.RawBodyData.ContainsKey("start_date"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PiggyBankUpdateParams
        {
            ID = "123",
            Accounts =
            [
                new()
                {
                    ID = JsonSerializer.Deserialize<JsonElement>("{}"),
                    AccountID = "3",
                    CurrentAmount = "123.45",
                    Name = "Checking account",
                },
            ],
            Name = "New digital camera",
            Order = 5,
            StartDate = "2026-04-01",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        Assert.Null(parameters.Notes);
        Assert.False(parameters.RawBodyData.ContainsKey("notes"));
        Assert.Null(parameters.ObjectGroupID);
        Assert.False(parameters.RawBodyData.ContainsKey("object_group_id"));
        Assert.Null(parameters.ObjectGroupTitle);
        Assert.False(parameters.RawBodyData.ContainsKey("object_group_title"));
        Assert.Null(parameters.TargetAmount);
        Assert.False(parameters.RawBodyData.ContainsKey("target_amount"));
        Assert.Null(parameters.TargetDate);
        Assert.False(parameters.RawBodyData.ContainsKey("target_date"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new PiggyBankUpdateParams
        {
            ID = "123",
            Accounts =
            [
                new()
                {
                    ID = JsonSerializer.Deserialize<JsonElement>("{}"),
                    AccountID = "3",
                    CurrentAmount = "123.45",
                    Name = "Checking account",
                },
            ],
            Name = "New digital camera",
            Order = 5,
            StartDate = "2026-04-01",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",

            Notes = null,
            ObjectGroupID = null,
            ObjectGroupTitle = null,
            TargetAmount = null,
            TargetDate = null,
        };

        Assert.Null(parameters.Notes);
        Assert.True(parameters.RawBodyData.ContainsKey("notes"));
        Assert.Null(parameters.ObjectGroupID);
        Assert.True(parameters.RawBodyData.ContainsKey("object_group_id"));
        Assert.Null(parameters.ObjectGroupTitle);
        Assert.True(parameters.RawBodyData.ContainsKey("object_group_title"));
        Assert.Null(parameters.TargetAmount);
        Assert.True(parameters.RawBodyData.ContainsKey("target_amount"));
        Assert.Null(parameters.TargetDate);
        Assert.True(parameters.RawBodyData.ContainsKey("target_date"));
    }

    [Fact]
    public void Url_Works()
    {
        PiggyBankUpdateParams parameters = new() { ID = "123" };

        var url = parameters.Url(new() { });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://demo.firefly-iii.org/api/v1/piggy-banks/123"), url)
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        PiggyBankUpdateParams parameters = new()
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
        var parameters = new PiggyBankUpdateParams
        {
            ID = "123",
            Accounts =
            [
                new()
                {
                    ID = JsonSerializer.Deserialize<JsonElement>("{}"),
                    AccountID = "3",
                    CurrentAmount = "123.45",
                    Name = "Checking account",
                },
            ],
            Name = "New digital camera",
            Notes = "Some notes",
            ObjectGroupID = "5",
            ObjectGroupTitle = "Example Group",
            Order = 5,
            StartDate = "2026-04-01",
            TargetAmount = "123.45",
            TargetDate = "2026-04-30",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        PiggyBankUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class PiggyBankUpdateParamsAccountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PiggyBankUpdateParamsAccount
        {
            ID = JsonSerializer.Deserialize<JsonElement>("{}"),
            AccountID = "3",
            CurrentAmount = "123.45",
            Name = "Checking account",
        };

        JsonElement expectedID = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedAccountID = "3";
        string expectedCurrentAmount = "123.45";
        string expectedName = "Checking account";

        Assert.True(JsonElement.DeepEquals(expectedID, model.ID));
        Assert.Equal(expectedAccountID, model.AccountID);
        Assert.Equal(expectedCurrentAmount, model.CurrentAmount);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PiggyBankUpdateParamsAccount
        {
            ID = JsonSerializer.Deserialize<JsonElement>("{}"),
            AccountID = "3",
            CurrentAmount = "123.45",
            Name = "Checking account",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PiggyBankUpdateParamsAccount>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PiggyBankUpdateParamsAccount
        {
            ID = JsonSerializer.Deserialize<JsonElement>("{}"),
            AccountID = "3",
            CurrentAmount = "123.45",
            Name = "Checking account",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PiggyBankUpdateParamsAccount>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedID = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedAccountID = "3";
        string expectedCurrentAmount = "123.45";
        string expectedName = "Checking account";

        Assert.True(JsonElement.DeepEquals(expectedID, deserialized.ID));
        Assert.Equal(expectedAccountID, deserialized.AccountID);
        Assert.Equal(expectedCurrentAmount, deserialized.CurrentAmount);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PiggyBankUpdateParamsAccount
        {
            ID = JsonSerializer.Deserialize<JsonElement>("{}"),
            AccountID = "3",
            CurrentAmount = "123.45",
            Name = "Checking account",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PiggyBankUpdateParamsAccount
        {
            ID = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        Assert.Null(model.AccountID);
        Assert.False(model.RawData.ContainsKey("account_id"));
        Assert.Null(model.CurrentAmount);
        Assert.False(model.RawData.ContainsKey("current_amount"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new PiggyBankUpdateParamsAccount
        {
            ID = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new PiggyBankUpdateParamsAccount
        {
            ID = JsonSerializer.Deserialize<JsonElement>("{}"),

            AccountID = null,
            CurrentAmount = null,
            Name = null,
        };

        Assert.Null(model.AccountID);
        Assert.True(model.RawData.ContainsKey("account_id"));
        Assert.Null(model.CurrentAmount);
        Assert.True(model.RawData.ContainsKey("current_amount"));
        Assert.Null(model.Name);
        Assert.True(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PiggyBankUpdateParamsAccount
        {
            ID = JsonSerializer.Deserialize<JsonElement>("{}"),

            AccountID = null,
            CurrentAmount = null,
            Name = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PiggyBankUpdateParamsAccount
        {
            ID = JsonSerializer.Deserialize<JsonElement>("{}"),
            AccountID = "3",
            CurrentAmount = "123.45",
            Name = "Checking account",
        };

        PiggyBankUpdateParamsAccount copied = new(model);

        Assert.Equal(model, copied);
    }
}
