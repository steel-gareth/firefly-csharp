using System;
using System.Net.Http;
using System.Text.Json;
using Firefly.Core;
using Firefly.Exceptions;
using Firefly.Models.Users;

namespace Firefly.Tests.Models.Users;

public class UserCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UserCreateParams
        {
            Email = "james@firefly-iii.org",
            Blocked = false,
            BlockedCode = BlockedCode.EmailChanged,
            Role = Role.Owner,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        string expectedEmail = "james@firefly-iii.org";
        bool expectedBlocked = false;
        ApiEnum<string, BlockedCode> expectedBlockedCode = BlockedCode.EmailChanged;
        ApiEnum<string, Role> expectedRole = Role.Owner;
        string expectedXTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00";

        Assert.Equal(expectedEmail, parameters.Email);
        Assert.Equal(expectedBlocked, parameters.Blocked);
        Assert.Equal(expectedBlockedCode, parameters.BlockedCode);
        Assert.Equal(expectedRole, parameters.Role);
        Assert.Equal(expectedXTraceID, parameters.XTraceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new UserCreateParams
        {
            Email = "james@firefly-iii.org",
            BlockedCode = BlockedCode.EmailChanged,
            Role = Role.Owner,
        };

        Assert.Null(parameters.Blocked);
        Assert.False(parameters.RawBodyData.ContainsKey("blocked"));
        Assert.Null(parameters.XTraceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-Trace-Id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new UserCreateParams
        {
            Email = "james@firefly-iii.org",
            BlockedCode = BlockedCode.EmailChanged,
            Role = Role.Owner,

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
        var parameters = new UserCreateParams
        {
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
        var parameters = new UserCreateParams
        {
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
        UserCreateParams parameters = new() { Email = "james@firefly-iii.org" };

        var url = parameters.Url(new() { });

        Assert.True(TestBase.UrisEqual(new Uri("https://demo.firefly-iii.org/api/v1/users"), url));
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        UserCreateParams parameters = new()
        {
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
        var parameters = new UserCreateParams
        {
            Email = "james@firefly-iii.org",
            Blocked = false,
            BlockedCode = BlockedCode.EmailChanged,
            Role = Role.Owner,
            XTraceID = "40c71bbb-c676-4f24-83cf-cc725d7d7a00",
        };

        UserCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class BlockedCodeTest : TestBase
{
    [Theory]
    [InlineData(BlockedCode.EmailChanged)]
    public void Validation_Works(BlockedCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BlockedCode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BlockedCode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<FireflyInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BlockedCode.EmailChanged)]
    public void SerializationRoundtrip_Works(BlockedCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BlockedCode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BlockedCode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BlockedCode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BlockedCode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class RoleTest : TestBase
{
    [Theory]
    [InlineData(Role.Owner)]
    [InlineData(Role.Demo)]
    public void Validation_Works(Role rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Role> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Role>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<FireflyInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Role.Owner)]
    [InlineData(Role.Demo)]
    public void SerializationRoundtrip_Works(Role rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Role> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Role>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Role>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Role>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
