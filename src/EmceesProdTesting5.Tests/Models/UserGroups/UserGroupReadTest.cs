using System;
using System.Collections.Generic;
using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Exceptions;
using EmceesProdTesting5.Models.UserGroups;
using Attachments = EmceesProdTesting5.Models.Attachments;

namespace EmceesProdTesting5.Tests.Models.UserGroups;

public class UserGroupReadTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UserGroupRead
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

        string expectedID = "2";
        Attributes expectedAttributes = new()
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
        };
        Attachments::ObjectLink expectedLinks = new()
        {
            O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
            Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
        };
        string expectedType = "user_groups";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAttributes, model.Attributes);
        Assert.Equal(expectedLinks, model.Links);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UserGroupRead
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserGroupRead>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UserGroupRead
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserGroupRead>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "2";
        Attributes expectedAttributes = new()
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
        };
        Attachments::ObjectLink expectedLinks = new()
        {
            O0 = new() { Rel = "self", Uri = "/OBJECTS/1" },
            Self = "https://demo.firefly-iii.org/api/v1/OBJECTS/1",
        };
        string expectedType = "user_groups";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAttributes, deserialized.Attributes);
        Assert.Equal(expectedLinks, deserialized.Links);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UserGroupRead
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

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UserGroupRead
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

        UserGroupRead copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AttributesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Attributes
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
        };

        bool expectedCanSeeMembers = true;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        bool expectedInUse = false;
        List<Member> expectedMembers =
        [
            new()
            {
                Roles = [Role.Ro],
                UserEmail = "james@firefly-iii.org",
                UserID = "5",
                You = false,
            },
        ];
        string expectedPrimaryCurrencyCode = "EUR";
        int expectedPrimaryCurrencyDecimalPlaces = 2;
        string expectedPrimaryCurrencyID = "12";
        string expectedPrimaryCurrencySymbol = "$";
        string expectedTitle = "demo@firefly";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");

        Assert.Equal(expectedCanSeeMembers, model.CanSeeMembers);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedInUse, model.InUse);
        Assert.NotNull(model.Members);
        Assert.Equal(expectedMembers.Count, model.Members.Count);
        for (int i = 0; i < expectedMembers.Count; i++)
        {
            Assert.Equal(expectedMembers[i], model.Members[i]);
        }
        Assert.Equal(expectedPrimaryCurrencyCode, model.PrimaryCurrencyCode);
        Assert.Equal(expectedPrimaryCurrencyDecimalPlaces, model.PrimaryCurrencyDecimalPlaces);
        Assert.Equal(expectedPrimaryCurrencyID, model.PrimaryCurrencyID);
        Assert.Equal(expectedPrimaryCurrencySymbol, model.PrimaryCurrencySymbol);
        Assert.Equal(expectedTitle, model.Title);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Attributes
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Attributes>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Attributes
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Attributes>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedCanSeeMembers = true;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");
        bool expectedInUse = false;
        List<Member> expectedMembers =
        [
            new()
            {
                Roles = [Role.Ro],
                UserEmail = "james@firefly-iii.org",
                UserID = "5",
                You = false,
            },
        ];
        string expectedPrimaryCurrencyCode = "EUR";
        int expectedPrimaryCurrencyDecimalPlaces = 2;
        string expectedPrimaryCurrencyID = "12";
        string expectedPrimaryCurrencySymbol = "$";
        string expectedTitle = "demo@firefly";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-04-01T00:00:00+00:00");

        Assert.Equal(expectedCanSeeMembers, deserialized.CanSeeMembers);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedInUse, deserialized.InUse);
        Assert.NotNull(deserialized.Members);
        Assert.Equal(expectedMembers.Count, deserialized.Members.Count);
        for (int i = 0; i < expectedMembers.Count; i++)
        {
            Assert.Equal(expectedMembers[i], deserialized.Members[i]);
        }
        Assert.Equal(expectedPrimaryCurrencyCode, deserialized.PrimaryCurrencyCode);
        Assert.Equal(
            expectedPrimaryCurrencyDecimalPlaces,
            deserialized.PrimaryCurrencyDecimalPlaces
        );
        Assert.Equal(expectedPrimaryCurrencyID, deserialized.PrimaryCurrencyID);
        Assert.Equal(expectedPrimaryCurrencySymbol, deserialized.PrimaryCurrencySymbol);
        Assert.Equal(expectedTitle, deserialized.Title);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Attributes
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Attributes { };

        Assert.Null(model.CanSeeMembers);
        Assert.False(model.RawData.ContainsKey("can_see_members"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.InUse);
        Assert.False(model.RawData.ContainsKey("in_use"));
        Assert.Null(model.Members);
        Assert.False(model.RawData.ContainsKey("members"));
        Assert.Null(model.PrimaryCurrencyCode);
        Assert.False(model.RawData.ContainsKey("primary_currency_code"));
        Assert.Null(model.PrimaryCurrencyDecimalPlaces);
        Assert.False(model.RawData.ContainsKey("primary_currency_decimal_places"));
        Assert.Null(model.PrimaryCurrencyID);
        Assert.False(model.RawData.ContainsKey("primary_currency_id"));
        Assert.Null(model.PrimaryCurrencySymbol);
        Assert.False(model.RawData.ContainsKey("primary_currency_symbol"));
        Assert.Null(model.Title);
        Assert.False(model.RawData.ContainsKey("title"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Attributes { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Attributes
        {
            // Null should be interpreted as omitted for these properties
            CanSeeMembers = null,
            CreatedAt = null,
            InUse = null,
            Members = null,
            PrimaryCurrencyCode = null,
            PrimaryCurrencyDecimalPlaces = null,
            PrimaryCurrencyID = null,
            PrimaryCurrencySymbol = null,
            Title = null,
            UpdatedAt = null,
        };

        Assert.Null(model.CanSeeMembers);
        Assert.False(model.RawData.ContainsKey("can_see_members"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.InUse);
        Assert.False(model.RawData.ContainsKey("in_use"));
        Assert.Null(model.Members);
        Assert.False(model.RawData.ContainsKey("members"));
        Assert.Null(model.PrimaryCurrencyCode);
        Assert.False(model.RawData.ContainsKey("primary_currency_code"));
        Assert.Null(model.PrimaryCurrencyDecimalPlaces);
        Assert.False(model.RawData.ContainsKey("primary_currency_decimal_places"));
        Assert.Null(model.PrimaryCurrencyID);
        Assert.False(model.RawData.ContainsKey("primary_currency_id"));
        Assert.Null(model.PrimaryCurrencySymbol);
        Assert.False(model.RawData.ContainsKey("primary_currency_symbol"));
        Assert.Null(model.Title);
        Assert.False(model.RawData.ContainsKey("title"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Attributes
        {
            // Null should be interpreted as omitted for these properties
            CanSeeMembers = null,
            CreatedAt = null,
            InUse = null,
            Members = null,
            PrimaryCurrencyCode = null,
            PrimaryCurrencyDecimalPlaces = null,
            PrimaryCurrencyID = null,
            PrimaryCurrencySymbol = null,
            Title = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Attributes
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
        };

        Attributes copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MemberTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Member
        {
            Roles = [Role.Ro],
            UserEmail = "james@firefly-iii.org",
            UserID = "5",
            You = false,
        };

        List<ApiEnum<string, Role>> expectedRoles = [Role.Ro];
        string expectedUserEmail = "james@firefly-iii.org";
        string expectedUserID = "5";
        bool expectedYou = false;

        Assert.NotNull(model.Roles);
        Assert.Equal(expectedRoles.Count, model.Roles.Count);
        for (int i = 0; i < expectedRoles.Count; i++)
        {
            Assert.Equal(expectedRoles[i], model.Roles[i]);
        }
        Assert.Equal(expectedUserEmail, model.UserEmail);
        Assert.Equal(expectedUserID, model.UserID);
        Assert.Equal(expectedYou, model.You);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Member
        {
            Roles = [Role.Ro],
            UserEmail = "james@firefly-iii.org",
            UserID = "5",
            You = false,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Member>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Member
        {
            Roles = [Role.Ro],
            UserEmail = "james@firefly-iii.org",
            UserID = "5",
            You = false,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Member>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        List<ApiEnum<string, Role>> expectedRoles = [Role.Ro];
        string expectedUserEmail = "james@firefly-iii.org";
        string expectedUserID = "5";
        bool expectedYou = false;

        Assert.NotNull(deserialized.Roles);
        Assert.Equal(expectedRoles.Count, deserialized.Roles.Count);
        for (int i = 0; i < expectedRoles.Count; i++)
        {
            Assert.Equal(expectedRoles[i], deserialized.Roles[i]);
        }
        Assert.Equal(expectedUserEmail, deserialized.UserEmail);
        Assert.Equal(expectedUserID, deserialized.UserID);
        Assert.Equal(expectedYou, deserialized.You);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Member
        {
            Roles = [Role.Ro],
            UserEmail = "james@firefly-iii.org",
            UserID = "5",
            You = false,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Member { };

        Assert.Null(model.Roles);
        Assert.False(model.RawData.ContainsKey("roles"));
        Assert.Null(model.UserEmail);
        Assert.False(model.RawData.ContainsKey("user_email"));
        Assert.Null(model.UserID);
        Assert.False(model.RawData.ContainsKey("user_id"));
        Assert.Null(model.You);
        Assert.False(model.RawData.ContainsKey("you"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Member { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Member
        {
            // Null should be interpreted as omitted for these properties
            Roles = null,
            UserEmail = null,
            UserID = null,
            You = null,
        };

        Assert.Null(model.Roles);
        Assert.False(model.RawData.ContainsKey("roles"));
        Assert.Null(model.UserEmail);
        Assert.False(model.RawData.ContainsKey("user_email"));
        Assert.Null(model.UserID);
        Assert.False(model.RawData.ContainsKey("user_id"));
        Assert.Null(model.You);
        Assert.False(model.RawData.ContainsKey("you"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Member
        {
            // Null should be interpreted as omitted for these properties
            Roles = null,
            UserEmail = null,
            UserID = null,
            You = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Member
        {
            Roles = [Role.Ro],
            UserEmail = "james@firefly-iii.org",
            UserID = "5",
            You = false,
        };

        Member copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RoleTest : TestBase
{
    [Theory]
    [InlineData(Role.Ro)]
    [InlineData(Role.MngTrx)]
    [InlineData(Role.MngMeta)]
    [InlineData(Role.ReadBudgets)]
    [InlineData(Role.ReadPiggies)]
    [InlineData(Role.ReadSubscriptions)]
    [InlineData(Role.ReadRules)]
    [InlineData(Role.ReadRecurring)]
    [InlineData(Role.ReadWebhooks)]
    [InlineData(Role.ReadCurrencies)]
    [InlineData(Role.MngBudgets)]
    [InlineData(Role.MngPiggies)]
    [InlineData(Role.MngSubscriptions)]
    [InlineData(Role.MngRules)]
    [InlineData(Role.MngRecurring)]
    [InlineData(Role.MngWebhooks)]
    [InlineData(Role.MngCurrencies)]
    [InlineData(Role.ViewReports)]
    [InlineData(Role.ViewMemberships)]
    [InlineData(Role.Full)]
    [InlineData(Role.Owner)]
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
        Assert.Throws<EmceesProdTesting5InvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Role.Ro)]
    [InlineData(Role.MngTrx)]
    [InlineData(Role.MngMeta)]
    [InlineData(Role.ReadBudgets)]
    [InlineData(Role.ReadPiggies)]
    [InlineData(Role.ReadSubscriptions)]
    [InlineData(Role.ReadRules)]
    [InlineData(Role.ReadRecurring)]
    [InlineData(Role.ReadWebhooks)]
    [InlineData(Role.ReadCurrencies)]
    [InlineData(Role.MngBudgets)]
    [InlineData(Role.MngPiggies)]
    [InlineData(Role.MngSubscriptions)]
    [InlineData(Role.MngRules)]
    [InlineData(Role.MngRecurring)]
    [InlineData(Role.MngWebhooks)]
    [InlineData(Role.MngCurrencies)]
    [InlineData(Role.ViewReports)]
    [InlineData(Role.ViewMemberships)]
    [InlineData(Role.Full)]
    [InlineData(Role.Owner)]
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
