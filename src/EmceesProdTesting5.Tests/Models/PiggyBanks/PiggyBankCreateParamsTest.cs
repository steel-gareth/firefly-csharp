using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.PiggyBanks;

namespace EmceesProdTesting5.Tests.Models.PiggyBanks;

public class PiggyBankCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PiggyBankCreateParams
        {
            AccountID = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "New digital camera",
            StartDate = "2026-04-01",
            TargetAmount = "123.45",
            Accounts =
            [
                new()
                {
                    ID = "3",
                    CurrentAmount = "123.45",
                    Name = "Checking account",
                },
            ],
            CurrentAmount = "123.45",
            Notes = "Some notes",
            ObjectGroupID = "5",
            ObjectGroupTitle = "Example Group",
            Order = 5,
            TargetDate = "2026-04-30",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        JsonElement expectedAccountID = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedName = "New digital camera";
        string expectedStartDate = "2026-04-01";
        string expectedTargetAmount = "123.45";
        List<Account> expectedAccounts =
        [
            new()
            {
                ID = "3",
                CurrentAmount = "123.45",
                Name = "Checking account",
            },
        ];
        string expectedCurrentAmount = "123.45";
        string expectedNotes = "Some notes";
        string expectedObjectGroupID = "5";
        string expectedObjectGroupTitle = "Example Group";
        int expectedOrder = 5;
        string expectedTargetDate = "2026-04-30";
        string expectedXTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00";

        Assert.True(JsonElement.DeepEquals(expectedAccountID, parameters.AccountID));
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedStartDate, parameters.StartDate);
        Assert.Equal(expectedTargetAmount, parameters.TargetAmount);
        Assert.NotNull(parameters.Accounts);
        Assert.Equal(expectedAccounts.Count, parameters.Accounts.Count);
        for (int i = 0; i < expectedAccounts.Count; i++)
        {
            Assert.Equal(expectedAccounts[i], parameters.Accounts[i]);
        }
        Assert.Equal(expectedCurrentAmount, parameters.CurrentAmount);
        Assert.Equal(expectedNotes, parameters.Notes);
        Assert.Equal(expectedObjectGroupID, parameters.ObjectGroupID);
        Assert.Equal(expectedObjectGroupTitle, parameters.ObjectGroupTitle);
        Assert.Equal(expectedOrder, parameters.Order);
        Assert.Equal(expectedTargetDate, parameters.TargetDate);
        Assert.Equal(expectedXTraceID, parameters.XTraceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PiggyBankCreateParams
        {
            AccountID = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "New digital camera",
            StartDate = "2026-04-01",
            TargetAmount = "123.45",
            Notes = "Some notes",
            ObjectGroupID = "5",
            ObjectGroupTitle = "Example Group",
            TargetDate = "2026-04-30",
        };

        Assert.Null(parameters.Accounts);
        Assert.False(parameters.RawBodyData.ContainsKey("accounts"));
        Assert.Null(parameters.CurrentAmount);
        Assert.False(parameters.RawBodyData.ContainsKey("current_amount"));
        Assert.Null(parameters.Order);
        Assert.False(parameters.RawBodyData.ContainsKey("order"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new PiggyBankCreateParams
        {
            AccountID = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "New digital camera",
            StartDate = "2026-04-01",
            TargetAmount = "123.45",
            Notes = "Some notes",
            ObjectGroupID = "5",
            ObjectGroupTitle = "Example Group",
            TargetDate = "2026-04-30",

            // Null should be interpreted as omitted for these properties
            Accounts = null,
            CurrentAmount = null,
            Order = null,
            XTraceID = null,
        };

        Assert.Null(parameters.Accounts);
        Assert.False(parameters.RawBodyData.ContainsKey("accounts"));
        Assert.Null(parameters.CurrentAmount);
        Assert.False(parameters.RawBodyData.ContainsKey("current_amount"));
        Assert.Null(parameters.Order);
        Assert.False(parameters.RawBodyData.ContainsKey("order"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PiggyBankCreateParams
        {
            AccountID = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "New digital camera",
            StartDate = "2026-04-01",
            TargetAmount = "123.45",
            Accounts =
            [
                new()
                {
                    ID = "3",
                    CurrentAmount = "123.45",
                    Name = "Checking account",
                },
            ],
            CurrentAmount = "123.45",
            Order = 5,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        Assert.Null(parameters.Notes);
        Assert.False(parameters.RawBodyData.ContainsKey("notes"));
        Assert.Null(parameters.ObjectGroupID);
        Assert.False(parameters.RawBodyData.ContainsKey("object_group_id"));
        Assert.Null(parameters.ObjectGroupTitle);
        Assert.False(parameters.RawBodyData.ContainsKey("object_group_title"));
        Assert.Null(parameters.TargetDate);
        Assert.False(parameters.RawBodyData.ContainsKey("target_date"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new PiggyBankCreateParams
        {
            AccountID = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "New digital camera",
            StartDate = "2026-04-01",
            TargetAmount = "123.45",
            Accounts =
            [
                new()
                {
                    ID = "3",
                    CurrentAmount = "123.45",
                    Name = "Checking account",
                },
            ],
            CurrentAmount = "123.45",
            Order = 5,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",

            Notes = null,
            ObjectGroupID = null,
            ObjectGroupTitle = null,
            TargetDate = null,
        };

        Assert.Null(parameters.Notes);
        Assert.True(parameters.RawBodyData.ContainsKey("notes"));
        Assert.Null(parameters.ObjectGroupID);
        Assert.True(parameters.RawBodyData.ContainsKey("object_group_id"));
        Assert.Null(parameters.ObjectGroupTitle);
        Assert.True(parameters.RawBodyData.ContainsKey("object_group_title"));
        Assert.Null(parameters.TargetDate);
        Assert.True(parameters.RawBodyData.ContainsKey("target_date"));
    }

    [Fact]
    public void Url_Works()
    {
        PiggyBankCreateParams parameters = new()
        {
            AccountID = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "New digital camera",
            StartDate = "2026-04-01",
            TargetAmount = "123.45",
        };

        var url = parameters.Url(new() { });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://demo.firefly-iii.org/api/v1/piggy-banks"), url)
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        PiggyBankCreateParams parameters = new()
        {
            AccountID = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "New digital camera",
            StartDate = "2026-04-01",
            TargetAmount = "123.45",
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
        var parameters = new PiggyBankCreateParams
        {
            AccountID = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "New digital camera",
            StartDate = "2026-04-01",
            TargetAmount = "123.45",
            Accounts =
            [
                new()
                {
                    ID = "3",
                    CurrentAmount = "123.45",
                    Name = "Checking account",
                },
            ],
            CurrentAmount = "123.45",
            Notes = "Some notes",
            ObjectGroupID = "5",
            ObjectGroupTitle = "Example Group",
            Order = 5,
            TargetDate = "2026-04-30",
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        PiggyBankCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class AccountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Account
        {
            ID = "3",
            CurrentAmount = "123.45",
            Name = "Checking account",
        };

        string expectedID = "3";
        string expectedCurrentAmount = "123.45";
        string expectedName = "Checking account";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCurrentAmount, model.CurrentAmount);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Account
        {
            ID = "3",
            CurrentAmount = "123.45",
            Name = "Checking account",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Account>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Account
        {
            ID = "3",
            CurrentAmount = "123.45",
            Name = "Checking account",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Account>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "3";
        string expectedCurrentAmount = "123.45";
        string expectedName = "Checking account";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCurrentAmount, deserialized.CurrentAmount);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Account
        {
            ID = "3",
            CurrentAmount = "123.45",
            Name = "Checking account",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Account { ID = "3", Name = "Checking account" };

        Assert.Null(model.CurrentAmount);
        Assert.False(model.RawData.ContainsKey("current_amount"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Account { ID = "3", Name = "Checking account" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Account
        {
            ID = "3",
            Name = "Checking account",

            // Null should be interpreted as omitted for these properties
            CurrentAmount = null,
        };

        Assert.Null(model.CurrentAmount);
        Assert.False(model.RawData.ContainsKey("current_amount"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Account
        {
            ID = "3",
            Name = "Checking account",

            // Null should be interpreted as omitted for these properties
            CurrentAmount = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Account { ID = "3", CurrentAmount = "123.45" };

        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Account { ID = "3", CurrentAmount = "123.45" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Account
        {
            ID = "3",
            CurrentAmount = "123.45",

            Name = null,
        };

        Assert.Null(model.Name);
        Assert.True(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Account
        {
            ID = "3",
            CurrentAmount = "123.45",

            Name = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Account
        {
            ID = "3",
            CurrentAmount = "123.45",
            Name = "Checking account",
        };

        Account copied = new(model);

        Assert.Equal(model, copied);
    }
}
