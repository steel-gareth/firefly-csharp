using System;
using System.Net.Http;
using System.Text.Json;
using Firefly.Core;
using Firefly.Exceptions;
using Firefly.Models.Accounts;
using Firefly.Models.Search;

namespace Firefly.Tests.Models.Search;

public class SearchAccountsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SearchAccountsParams
        {
            Field = Field.All,
            Query = "checking",
            Limit = 10,
            Page = 1,
            Type = AccountTypeFilter.All,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        ApiEnum<string, Field> expectedField = Field.All;
        string expectedQuery = "checking";
        int expectedLimit = 10;
        int expectedPage = 1;
        ApiEnum<string, AccountTypeFilter> expectedType = AccountTypeFilter.All;
        string expectedXTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00";

        Assert.Equal(expectedField, parameters.Field);
        Assert.Equal(expectedQuery, parameters.Query);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedPage, parameters.Page);
        Assert.Equal(expectedType, parameters.Type);
        Assert.Equal(expectedXTraceID, parameters.XTraceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SearchAccountsParams { Field = Field.All, Query = "checking" };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.Type);
        Assert.False(parameters.RawQueryData.ContainsKey("type"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SearchAccountsParams
        {
            Field = Field.All,
            Query = "checking",

            // Null should be interpreted as omitted for these properties
            Limit = null,
            Page = null,
            Type = null,
            XTraceID = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.Type);
        Assert.False(parameters.RawQueryData.ContainsKey("type"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void Url_Works()
    {
        SearchAccountsParams parameters = new()
        {
            Field = Field.All,
            Query = "checking",
            Limit = 10,
            Page = 1,
            Type = AccountTypeFilter.All,
        };

        var url = parameters.Url(new() { });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://demo.firefly-iii.org/api/v1/search/accounts?field=all&query=checking&limit=10&page=1&type=all"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        SearchAccountsParams parameters = new()
        {
            Field = Field.All,
            Query = "checking",
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
        var parameters = new SearchAccountsParams
        {
            Field = Field.All,
            Query = "checking",
            Limit = 10,
            Page = 1,
            Type = AccountTypeFilter.All,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        SearchAccountsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class FieldTest : TestBase
{
    [Theory]
    [InlineData(Field.All)]
    [InlineData(Field.Iban)]
    [InlineData(Field.Name)]
    [InlineData(Field.Number)]
    [InlineData(Field.ID)]
    public void Validation_Works(Field rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Field> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Field>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<FireflyInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Field.All)]
    [InlineData(Field.Iban)]
    [InlineData(Field.Name)]
    [InlineData(Field.Number)]
    [InlineData(Field.ID)]
    public void SerializationRoundtrip_Works(Field rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Field> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Field>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Field>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Field>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
