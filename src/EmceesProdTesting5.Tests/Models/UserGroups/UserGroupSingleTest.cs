using System;
using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.UserGroups;

namespace EmceesProdTesting5.Tests.Models.UserGroups;

public class UserGroupSingleTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UserGroupSingle
        {
            Data = new()
            {
                ID = "2",
                Attributes = new()
                {
                    CanSeeMembers = true,
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    InUse = false,
                    Members =
                    [
                        new()
                        {
                            Roles = [Role.Ro],
                            UserEmail = "james@firefly-iii.org",
                            UserID = "5",
                            You = false,
                        },
                    ],
                    PrimaryCurrencyCode = "EUR",
                    PrimaryCurrencyDecimalPlaces = 2,
                    PrimaryCurrencyID = "12",
                    PrimaryCurrencySymbol = "$",
                    Title = "demo@firefly",
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
                Links = new()
                {
                    O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                    Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
                },
                Type = "user_groups",
            },
        };

        UserGroupRead expectedData = new()
        {
            ID = "2",
            Attributes = new()
            {
                CanSeeMembers = true,
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                InUse = false,
                Members =
                [
                    new()
                    {
                        Roles = [Role.Ro],
                        UserEmail = "james@firefly-iii.org",
                        UserID = "5",
                        You = false,
                    },
                ],
                PrimaryCurrencyCode = "EUR",
                PrimaryCurrencyDecimalPlaces = 2,
                PrimaryCurrencyID = "12",
                PrimaryCurrencySymbol = "$",
                Title = "demo@firefly",
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            },
            Links = new()
            {
                O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
            },
            Type = "user_groups",
        };

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UserGroupSingle
        {
            Data = new()
            {
                ID = "2",
                Attributes = new()
                {
                    CanSeeMembers = true,
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    InUse = false,
                    Members =
                    [
                        new()
                        {
                            Roles = [Role.Ro],
                            UserEmail = "james@firefly-iii.org",
                            UserID = "5",
                            You = false,
                        },
                    ],
                    PrimaryCurrencyCode = "EUR",
                    PrimaryCurrencyDecimalPlaces = 2,
                    PrimaryCurrencyID = "12",
                    PrimaryCurrencySymbol = "$",
                    Title = "demo@firefly",
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
                Links = new()
                {
                    O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                    Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
                },
                Type = "user_groups",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserGroupSingle>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UserGroupSingle
        {
            Data = new()
            {
                ID = "2",
                Attributes = new()
                {
                    CanSeeMembers = true,
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    InUse = false,
                    Members =
                    [
                        new()
                        {
                            Roles = [Role.Ro],
                            UserEmail = "james@firefly-iii.org",
                            UserID = "5",
                            You = false,
                        },
                    ],
                    PrimaryCurrencyCode = "EUR",
                    PrimaryCurrencyDecimalPlaces = 2,
                    PrimaryCurrencyID = "12",
                    PrimaryCurrencySymbol = "$",
                    Title = "demo@firefly",
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
                Links = new()
                {
                    O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                    Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
                },
                Type = "user_groups",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserGroupSingle>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        UserGroupRead expectedData = new()
        {
            ID = "2",
            Attributes = new()
            {
                CanSeeMembers = true,
                CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                InUse = false,
                Members =
                [
                    new()
                    {
                        Roles = [Role.Ro],
                        UserEmail = "james@firefly-iii.org",
                        UserID = "5",
                        You = false,
                    },
                ],
                PrimaryCurrencyCode = "EUR",
                PrimaryCurrencyDecimalPlaces = 2,
                PrimaryCurrencyID = "12",
                PrimaryCurrencySymbol = "$",
                Title = "demo@firefly",
                UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
            },
            Links = new()
            {
                O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
            },
            Type = "user_groups",
        };

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UserGroupSingle
        {
            Data = new()
            {
                ID = "2",
                Attributes = new()
                {
                    CanSeeMembers = true,
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    InUse = false,
                    Members =
                    [
                        new()
                        {
                            Roles = [Role.Ro],
                            UserEmail = "james@firefly-iii.org",
                            UserID = "5",
                            You = false,
                        },
                    ],
                    PrimaryCurrencyCode = "EUR",
                    PrimaryCurrencyDecimalPlaces = 2,
                    PrimaryCurrencyID = "12",
                    PrimaryCurrencySymbol = "$",
                    Title = "demo@firefly",
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
                Links = new()
                {
                    O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                    Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
                },
                Type = "user_groups",
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UserGroupSingle
        {
            Data = new()
            {
                ID = "2",
                Attributes = new()
                {
                    CanSeeMembers = true,
                    CreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                    InUse = false,
                    Members =
                    [
                        new()
                        {
                            Roles = [Role.Ro],
                            UserEmail = "james@firefly-iii.org",
                            UserID = "5",
                            You = false,
                        },
                    ],
                    PrimaryCurrencyCode = "EUR",
                    PrimaryCurrencyDecimalPlaces = 2,
                    PrimaryCurrencyID = "12",
                    PrimaryCurrencySymbol = "$",
                    Title = "demo@firefly",
                    UpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00"),
                },
                Links = new()
                {
                    O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
                    Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
                },
                Type = "user_groups",
            },
        };

        UserGroupSingle copied = new(model);

        Assert.Equal(model, copied);
    }
}
