using System;
using System.Net.Http;
using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Exceptions;
using EmceesProdTesting5.Models.Data;

namespace EmceesProdTesting5.Tests.Models.Data;

public class DataDestroyParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DataDestroyParams
        {
            Objects = Objects.NotAssetsLiabilities,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        ApiEnum<string, Objects> expectedObjects = Objects.NotAssetsLiabilities;
        string expectedXTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00";

        Assert.Equal(expectedObjects, parameters.Objects);
        Assert.Equal(expectedXTraceID, parameters.XTraceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new DataDestroyParams { Objects = Objects.NotAssetsLiabilities };

        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new DataDestroyParams
        {
            Objects = Objects.NotAssetsLiabilities,

            // Null should be interpreted as omitted for these properties
            XTraceID = null,
        };

        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void Url_Works()
    {
        DataDestroyParams parameters = new() { Objects = Objects.NotAssetsLiabilities };

        var url = parameters.Url(new() { });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://demo.firefly-iii.org/api/v1/data/destroy?objects=not_assets_liabilities"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        DataDestroyParams parameters = new()
        {
            Objects = Objects.NotAssetsLiabilities,
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
        var parameters = new DataDestroyParams
        {
            Objects = Objects.NotAssetsLiabilities,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        DataDestroyParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ObjectsTest : TestBase
{
    [Theory]
    [InlineData(Objects.NotAssetsLiabilities)]
    [InlineData(Objects.Budgets)]
    [InlineData(Objects.Bills)]
    [InlineData(Objects.PiggyBanks)]
    [InlineData(Objects.Rules)]
    [InlineData(Objects.Recurring)]
    [InlineData(Objects.Categories)]
    [InlineData(Objects.Tags)]
    [InlineData(Objects.ObjectGroups)]
    [InlineData(Objects.Accounts)]
    [InlineData(Objects.AssetAccounts)]
    [InlineData(Objects.ExpenseAccounts)]
    [InlineData(Objects.RevenueAccounts)]
    [InlineData(Objects.Liabilities)]
    [InlineData(Objects.Transactions)]
    [InlineData(Objects.Withdrawals)]
    [InlineData(Objects.Deposits)]
    [InlineData(Objects.Transfers)]
    public void Validation_Works(Objects rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Objects> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Objects>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<EmceesProdTesting5InvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Objects.NotAssetsLiabilities)]
    [InlineData(Objects.Budgets)]
    [InlineData(Objects.Bills)]
    [InlineData(Objects.PiggyBanks)]
    [InlineData(Objects.Rules)]
    [InlineData(Objects.Recurring)]
    [InlineData(Objects.Categories)]
    [InlineData(Objects.Tags)]
    [InlineData(Objects.ObjectGroups)]
    [InlineData(Objects.Accounts)]
    [InlineData(Objects.AssetAccounts)]
    [InlineData(Objects.ExpenseAccounts)]
    [InlineData(Objects.RevenueAccounts)]
    [InlineData(Objects.Liabilities)]
    [InlineData(Objects.Transactions)]
    [InlineData(Objects.Withdrawals)]
    [InlineData(Objects.Deposits)]
    [InlineData(Objects.Transfers)]
    public void SerializationRoundtrip_Works(Objects rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Objects> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Objects>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Objects>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Objects>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
