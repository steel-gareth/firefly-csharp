using System;
using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Exceptions;
using EmceesProdTesting5.Models.Users;

namespace EmceesProdTesting5.Tests.Models.Users;

public class UserTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new User
        {
            Email = "james@firefly-iii.org",
            Blocked = false,
            BlockedCode = UserBlockedCode.EmailChanged,
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Role = UserRole.Owner,
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        string expectedEmail = "james@firefly-iii.org";
        bool expectedBlocked = false;
        ApiEnum<string, UserBlockedCode> expectedBlockedCode = UserBlockedCode.EmailChanged;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        ApiEnum<string, UserRole> expectedRole = UserRole.Owner;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");

        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedBlocked, model.Blocked);
        Assert.Equal(expectedBlockedCode, model.BlockedCode);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedRole, model.Role);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new User
        {
            Email = "james@firefly-iii.org",
            Blocked = false,
            BlockedCode = UserBlockedCode.EmailChanged,
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Role = UserRole.Owner,
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<User>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new User
        {
            Email = "james@firefly-iii.org",
            Blocked = false,
            BlockedCode = UserBlockedCode.EmailChanged,
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Role = UserRole.Owner,
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<User>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedEmail = "james@firefly-iii.org";
        bool expectedBlocked = false;
        ApiEnum<string, UserBlockedCode> expectedBlockedCode = UserBlockedCode.EmailChanged;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        ApiEnum<string, UserRole> expectedRole = UserRole.Owner;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");

        Assert.Equal(expectedEmail, deserialized.Email);
        Assert.Equal(expectedBlocked, deserialized.Blocked);
        Assert.Equal(expectedBlockedCode, deserialized.BlockedCode);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedRole, deserialized.Role);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new User
        {
            Email = "james@firefly-iii.org",
            Blocked = false,
            BlockedCode = UserBlockedCode.EmailChanged,
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Role = UserRole.Owner,
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new User
        {
            Email = "james@firefly-iii.org",
            BlockedCode = UserBlockedCode.EmailChanged,
            Role = UserRole.Owner,
        };

        Assert.Null(model.Blocked);
        Assert.False(model.RawData.ContainsKey("blocked"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new User
        {
            Email = "james@firefly-iii.org",
            BlockedCode = UserBlockedCode.EmailChanged,
            Role = UserRole.Owner,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new User
        {
            Email = "james@firefly-iii.org",
            BlockedCode = UserBlockedCode.EmailChanged,
            Role = UserRole.Owner,

            // Null should be interpreted as omitted for these properties
            Blocked = null,
            CreatedAt = null,
            UpdatedAt = null,
        };

        Assert.Null(model.Blocked);
        Assert.False(model.RawData.ContainsKey("blocked"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new User
        {
            Email = "james@firefly-iii.org",
            BlockedCode = UserBlockedCode.EmailChanged,
            Role = UserRole.Owner,

            // Null should be interpreted as omitted for these properties
            Blocked = null,
            CreatedAt = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new User
        {
            Email = "james@firefly-iii.org",
            Blocked = false,
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        Assert.Null(model.BlockedCode);
        Assert.False(model.RawData.ContainsKey("blocked_code"));
        Assert.Null(model.Role);
        Assert.False(model.RawData.ContainsKey("role"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new User
        {
            Email = "james@firefly-iii.org",
            Blocked = false,
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new User
        {
            Email = "james@firefly-iii.org",
            Blocked = false,
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),

            BlockedCode = null,
            Role = null,
        };

        Assert.Null(model.BlockedCode);
        Assert.True(model.RawData.ContainsKey("blocked_code"));
        Assert.Null(model.Role);
        Assert.True(model.RawData.ContainsKey("role"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new User
        {
            Email = "james@firefly-iii.org",
            Blocked = false,
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),

            BlockedCode = null,
            Role = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new User
        {
            Email = "james@firefly-iii.org",
            Blocked = false,
            BlockedCode = UserBlockedCode.EmailChanged,
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Role = UserRole.Owner,
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };

        User copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UserBlockedCodeTest : TestBase
{
    [Theory]
    [InlineData(UserBlockedCode.EmailChanged)]
    public void Validation_Works(UserBlockedCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UserBlockedCode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UserBlockedCode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<EmceesProdTesting5InvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UserBlockedCode.EmailChanged)]
    public void SerializationRoundtrip_Works(UserBlockedCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UserBlockedCode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UserBlockedCode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UserBlockedCode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UserBlockedCode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class UserRoleTest : TestBase
{
    [Theory]
    [InlineData(UserRole.Owner)]
    [InlineData(UserRole.Demo)]
    public void Validation_Works(UserRole rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UserRole> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UserRole>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<EmceesProdTesting5InvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UserRole.Owner)]
    [InlineData(UserRole.Demo)]
    public void SerializationRoundtrip_Works(UserRole rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UserRole> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UserRole>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UserRole>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UserRole>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
