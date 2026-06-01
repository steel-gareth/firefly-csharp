using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Exceptions;
using EmceesProdTesting5.Models.Chart.Balance;

namespace EmceesProdTesting5.Tests.Models.Chart.Balance;

public class BalanceRetrieveBalanceParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BalanceRetrieveBalanceParams
        {
            End = "2019-12-27",
            Start = "2019-12-27",
            Accounts = [1, 2, 3],
            Period = Period.V1M,
            Preselected = Preselected.All,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        string expectedEnd = "2019-12-27";
        string expectedStart = "2019-12-27";
        List<long> expectedAccounts = [1, 2, 3];
        ApiEnum<string, Period> expectedPeriod = Period.V1M;
        ApiEnum<string, Preselected> expectedPreselected = Preselected.All;
        string expectedXTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00";

        Assert.Equal(expectedEnd, parameters.End);
        Assert.Equal(expectedStart, parameters.Start);
        Assert.NotNull(parameters.Accounts);
        Assert.Equal(expectedAccounts.Count, parameters.Accounts.Count);
        for (int i = 0; i < expectedAccounts.Count; i++)
        {
            Assert.Equal(expectedAccounts[i], parameters.Accounts[i]);
        }
        Assert.Equal(expectedPeriod, parameters.Period);
        Assert.Equal(expectedPreselected, parameters.Preselected);
        Assert.Equal(expectedXTraceID, parameters.XTraceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new BalanceRetrieveBalanceParams
        {
            End = "2019-12-27",
            Start = "2019-12-27",
        };

        Assert.Null(parameters.Accounts);
        Assert.False(parameters.RawQueryData.ContainsKey("accounts"));
        Assert.Null(parameters.Period);
        Assert.False(parameters.RawQueryData.ContainsKey("period"));
        Assert.Null(parameters.Preselected);
        Assert.False(parameters.RawQueryData.ContainsKey("preselected"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new BalanceRetrieveBalanceParams
        {
            End = "2019-12-27",
            Start = "2019-12-27",

            // Null should be interpreted as omitted for these properties
            Accounts = null,
            Period = null,
            Preselected = null,
            XTraceID = null,
        };

        Assert.Null(parameters.Accounts);
        Assert.False(parameters.RawQueryData.ContainsKey("accounts"));
        Assert.Null(parameters.Period);
        Assert.False(parameters.RawQueryData.ContainsKey("period"));
        Assert.Null(parameters.Preselected);
        Assert.False(parameters.RawQueryData.ContainsKey("preselected"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void Url_Works()
    {
        BalanceRetrieveBalanceParams parameters = new()
        {
            End = "2019-12-27",
            Start = "2019-12-27",
            Accounts = [1, 2, 3],
            Period = Period.V1M,
            Preselected = Preselected.All,
        };

        var url = parameters.Url(new() { });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://demo.firefly-iii.org/api/v1/chart/balance/balance?end=2019-12-27&start=2019-12-27&accounts=1%2c2%2c3&period=1M&preselected=all"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        BalanceRetrieveBalanceParams parameters = new()
        {
            End = "2019-12-27",
            Start = "2019-12-27",
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
        var parameters = new BalanceRetrieveBalanceParams
        {
            End = "2019-12-27",
            Start = "2019-12-27",
            Accounts = [1, 2, 3],
            Period = Period.V1M,
            Preselected = Preselected.All,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        BalanceRetrieveBalanceParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class PeriodTest : TestBase
{
    [Theory]
    [InlineData(Period.V1D)]
    [InlineData(Period.V1W)]
    [InlineData(Period.V1M)]
    [InlineData(Period.V3M)]
    [InlineData(Period.V6M)]
    [InlineData(Period.V1Y)]
    public void Validation_Works(Period rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Period> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Period>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<EmceesProdTesting5InvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Period.V1D)]
    [InlineData(Period.V1W)]
    [InlineData(Period.V1M)]
    [InlineData(Period.V3M)]
    [InlineData(Period.V6M)]
    [InlineData(Period.V1Y)]
    public void SerializationRoundtrip_Works(Period rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Period> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Period>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Period>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Period>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PreselectedTest : TestBase
{
    [Theory]
    [InlineData(Preselected.Empty)]
    [InlineData(Preselected.All)]
    [InlineData(Preselected.Assets)]
    [InlineData(Preselected.Liabilities)]
    public void Validation_Works(Preselected rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Preselected> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Preselected>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<EmceesProdTesting5InvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Preselected.Empty)]
    [InlineData(Preselected.All)]
    [InlineData(Preselected.Assets)]
    [InlineData(Preselected.Liabilities)]
    public void SerializationRoundtrip_Works(Preselected rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Preselected> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Preselected>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Preselected>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Preselected>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
