using System;
using System.Net.Http;
using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Exceptions;
using EmceesProdTesting5.Models.Users;

namespace EmceesProdTesting5.Tests.Models.Users;

public class UserUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UserUpdateParams
        {
            ID = "123",
            Email = "james@firefly-iii.org",
            Blocked = false,
            BlockedCode = UserUpdateParamsBlockedCode.EmailChanged,
            Role = UserUpdateParamsRole.Owner,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        string expectedID = "123";
        string expectedEmail = "james@firefly-iii.org";
        bool expectedBlocked = false;
        ApiEnum<string, UserUpdateParamsBlockedCode> expectedBlockedCode =
            UserUpdateParamsBlockedCode.EmailChanged;
        ApiEnum<string, UserUpdateParamsRole> expectedRole = UserUpdateParamsRole.Owner;
        string expectedXTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedEmail, parameters.Email);
        Assert.Equal(expectedBlocked, parameters.Blocked);
        Assert.Equal(expectedBlockedCode, parameters.BlockedCode);
        Assert.Equal(expectedRole, parameters.Role);
        Assert.Equal(expectedXTraceID, parameters.XTraceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new UserUpdateParams
        {
            ID = "123",
            Email = "james@firefly-iii.org",
            BlockedCode = UserUpdateParamsBlockedCode.EmailChanged,
            Role = UserUpdateParamsRole.Owner,
        };

        Assert.Null(parameters.Blocked);
        Assert.False(parameters.RawBodyData.ContainsKey("blocked"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new UserUpdateParams
        {
            ID = "123",
            Email = "james@firefly-iii.org",
            BlockedCode = UserUpdateParamsBlockedCode.EmailChanged,
            Role = UserUpdateParamsRole.Owner,

            // Null should be interpreted as omitted for these properties
            Blocked = null,
            XTraceID = null,
        };

        Assert.Null(parameters.Blocked);
        Assert.False(parameters.RawBodyData.ContainsKey("blocked"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new UserUpdateParams
        {
            ID = "123",
            Email = "james@firefly-iii.org",
            Blocked = false,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        Assert.Null(parameters.BlockedCode);
        Assert.False(parameters.RawBodyData.ContainsKey("blocked_code"));
        Assert.Null(parameters.Role);
        Assert.False(parameters.RawBodyData.ContainsKey("role"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new UserUpdateParams
        {
            ID = "123",
            Email = "james@firefly-iii.org",
            Blocked = false,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",

            BlockedCode = null,
            Role = null,
        };

        Assert.Null(parameters.BlockedCode);
        Assert.True(parameters.RawBodyData.ContainsKey("blocked_code"));
        Assert.Null(parameters.Role);
        Assert.True(parameters.RawBodyData.ContainsKey("role"));
    }

    [Fact]
    public void Url_Works()
    {
        UserUpdateParams parameters = new() { ID = "123", Email = "james@firefly-iii.org" };

        var url = parameters.Url(new() { });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://demo.firefly-iii.org/api/v1/users/123"), url)
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        UserUpdateParams parameters = new()
        {
            ID = "123",
            Email = "james@firefly-iii.org",
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
        var parameters = new UserUpdateParams
        {
            ID = "123",
            Email = "james@firefly-iii.org",
            Blocked = false,
            BlockedCode = UserUpdateParamsBlockedCode.EmailChanged,
            Role = UserUpdateParamsRole.Owner,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        UserUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class UserUpdateParamsBlockedCodeTest : TestBase
{
    [Theory]
    [InlineData(UserUpdateParamsBlockedCode.EmailChanged)]
    public void Validation_Works(UserUpdateParamsBlockedCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UserUpdateParamsBlockedCode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UserUpdateParamsBlockedCode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<EmceesProdTesting5InvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UserUpdateParamsBlockedCode.EmailChanged)]
    public void SerializationRoundtrip_Works(UserUpdateParamsBlockedCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UserUpdateParamsBlockedCode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UserUpdateParamsBlockedCode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UserUpdateParamsBlockedCode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UserUpdateParamsBlockedCode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class UserUpdateParamsRoleTest : TestBase
{
    [Theory]
    [InlineData(UserUpdateParamsRole.Owner)]
    [InlineData(UserUpdateParamsRole.Demo)]
    public void Validation_Works(UserUpdateParamsRole rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UserUpdateParamsRole> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UserUpdateParamsRole>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<EmceesProdTesting5InvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UserUpdateParamsRole.Owner)]
    [InlineData(UserUpdateParamsRole.Demo)]
    public void SerializationRoundtrip_Works(UserUpdateParamsRole rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UserUpdateParamsRole> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UserUpdateParamsRole>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UserUpdateParamsRole>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UserUpdateParamsRole>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
