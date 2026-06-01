using System;
using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.About;
using EmceesProdTesting5.Models.Users;

namespace EmceesProdTesting5.Tests.Models.About;

public class UserSingleTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UserSingle
        {
            Data = new()
            {
                ID = "2",
                Attributes = new()
                {
                    Email = "james@firefly-iii.org",
                    Blocked = false,
                    BlockedCode = UserBlockedCode.EmailChanged,
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Role = UserRole.Owner,
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
                Links = new()
                {
                    O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                    Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
                },
                Type = "users",
            },
        };

        UserRead expectedData = new()
        {
            ID = "2",
            Attributes = new()
            {
                Email = "james@firefly-iii.org",
                Blocked = false,
                BlockedCode = UserBlockedCode.EmailChanged,
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                Role = UserRole.Owner,
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            },
            Links = new()
            {
                O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
            },
            Type = "users",
        };

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UserSingle
        {
            Data = new()
            {
                ID = "2",
                Attributes = new()
                {
                    Email = "james@firefly-iii.org",
                    Blocked = false,
                    BlockedCode = UserBlockedCode.EmailChanged,
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Role = UserRole.Owner,
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
                Links = new()
                {
                    O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                    Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
                },
                Type = "users",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserSingle>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UserSingle
        {
            Data = new()
            {
                ID = "2",
                Attributes = new()
                {
                    Email = "james@firefly-iii.org",
                    Blocked = false,
                    BlockedCode = UserBlockedCode.EmailChanged,
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Role = UserRole.Owner,
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
                Links = new()
                {
                    O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                    Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
                },
                Type = "users",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserSingle>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        UserRead expectedData = new()
        {
            ID = "2",
            Attributes = new()
            {
                Email = "james@firefly-iii.org",
                Blocked = false,
                BlockedCode = UserBlockedCode.EmailChanged,
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                Role = UserRole.Owner,
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            },
            Links = new()
            {
                O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
            },
            Type = "users",
        };

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UserSingle
        {
            Data = new()
            {
                ID = "2",
                Attributes = new()
                {
                    Email = "james@firefly-iii.org",
                    Blocked = false,
                    BlockedCode = UserBlockedCode.EmailChanged,
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Role = UserRole.Owner,
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
                Links = new()
                {
                    O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                    Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
                },
                Type = "users",
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UserSingle
        {
            Data = new()
            {
                ID = "2",
                Attributes = new()
                {
                    Email = "james@firefly-iii.org",
                    Blocked = false,
                    BlockedCode = UserBlockedCode.EmailChanged,
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    Role = UserRole.Owner,
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
                Links = new()
                {
                    O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                    Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
                },
                Type = "users",
            },
        };

        UserSingle copied = new(model);

        Assert.Equal(model, copied);
    }
}
