using System;
using System.Text.Json;
using Firefly.Core;
using Firefly.Models.About;
using Firefly.Models.Attachments;
using Firefly.Models.Users;

namespace Firefly.Tests.Models.About;

public class UserReadTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UserRead
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

        string expectedID = "2";
        User expectedAttributes = new()
        {
            Email = "james@firefly-iii.org",
            Blocked = false,
            BlockedCode = UserBlockedCode.EmailChanged,
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Role = UserRole.Owner,
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };
        ObjectLink expectedLinks = new()
        {
            O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
            Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
        };
        string expectedType = "users";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAttributes, model.Attributes);
        Assert.Equal(expectedLinks, model.Links);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UserRead
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserRead>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UserRead
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserRead>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "2";
        User expectedAttributes = new()
        {
            Email = "james@firefly-iii.org",
            Blocked = false,
            BlockedCode = UserBlockedCode.EmailChanged,
            CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            Role = UserRole.Owner,
            UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
        };
        ObjectLink expectedLinks = new()
        {
            O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
            Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
        };
        string expectedType = "users";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAttributes, deserialized.Attributes);
        Assert.Equal(expectedLinks, deserialized.Links);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UserRead
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

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UserRead
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

        UserRead copied = new(model);

        Assert.Equal(model, copied);
    }
}
