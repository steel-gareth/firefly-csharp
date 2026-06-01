using System;
using System.Collections.Generic;
using System.Text.Json;
using Firefly.Core;
using Firefly.Models.Accounts;
using Firefly.Models.UserGroups;

namespace Firefly.Tests.Models.UserGroups;

public class UserGroupListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UserGroupListResponse
        {
            Data =
            [
                new()
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
            ],
            Links = new()
            {
                First = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=1",
                Last = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=12",
                Next = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=3",
                Prev = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=2",
                Self = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=4",
            },
            Meta = new()
            {
                Pagination = new()
                {
                    Count = 20,
                    CurrentPage = 1,
                    PerPage = 100,
                    Total = 3,
                    TotalPages = 1,
                },
            },
        };

        List<UserGroupRead> expectedData =
        [
            new()
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
        ];
        PageLink expectedLinks = new()
        {
            First = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=1",
            Last = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=12",
            Next = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=3",
            Prev = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=2",
            Self = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=4",
        };
        Meta expectedMeta = new()
        {
            Pagination = new()
            {
                Count = 20,
                CurrentPage = 1,
                PerPage = 100,
                Total = 3,
                TotalPages = 1,
            },
        };

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedLinks, model.Links);
        Assert.Equal(expectedMeta, model.Meta);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UserGroupListResponse
        {
            Data =
            [
                new()
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
            ],
            Links = new()
            {
                First = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=1",
                Last = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=12",
                Next = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=3",
                Prev = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=2",
                Self = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=4",
            },
            Meta = new()
            {
                Pagination = new()
                {
                    Count = 20,
                    CurrentPage = 1,
                    PerPage = 100,
                    Total = 3,
                    TotalPages = 1,
                },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserGroupListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UserGroupListResponse
        {
            Data =
            [
                new()
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
            ],
            Links = new()
            {
                First = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=1",
                Last = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=12",
                Next = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=3",
                Prev = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=2",
                Self = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=4",
            },
            Meta = new()
            {
                Pagination = new()
                {
                    Count = 20,
                    CurrentPage = 1,
                    PerPage = 100,
                    Total = 3,
                    TotalPages = 1,
                },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserGroupListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<UserGroupRead> expectedData =
        [
            new()
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
        ];
        PageLink expectedLinks = new()
        {
            First = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=1",
            Last = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=12",
            Next = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=3",
            Prev = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=2",
            Self = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=4",
        };
        Meta expectedMeta = new()
        {
            Pagination = new()
            {
                Count = 20,
                CurrentPage = 1,
                PerPage = 100,
                Total = 3,
                TotalPages = 1,
            },
        };

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedLinks, deserialized.Links);
        Assert.Equal(expectedMeta, deserialized.Meta);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UserGroupListResponse
        {
            Data =
            [
                new()
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
            ],
            Links = new()
            {
                First = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=1",
                Last = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=12",
                Next = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=3",
                Prev = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=2",
                Self = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=4",
            },
            Meta = new()
            {
                Pagination = new()
                {
                    Count = 20,
                    CurrentPage = 1,
                    PerPage = 100,
                    Total = 3,
                    TotalPages = 1,
                },
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UserGroupListResponse
        {
            Data =
            [
                new()
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
            ],
            Links = new()
            {
                First = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=1",
                Last = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=12",
                Next = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=3",
                Prev = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=2",
                Self = "https://demo.firefly-iii.org/api/v1/OBJECT?&page=4",
            },
            Meta = new()
            {
                Pagination = new()
                {
                    Count = 20,
                    CurrentPage = 1,
                    PerPage = 100,
                    Total = 3,
                    TotalPages = 1,
                },
            },
        };

        UserGroupListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
