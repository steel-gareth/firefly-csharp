using System;
using System.Collections.Generic;
using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Exceptions;
using EmceesProdTesting5.Models.Pets;

namespace EmceesProdTesting5.Tests.Models.Pets;

public class PetCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PetCreateParams
        {
            Name = "doggie",
            PhotoUrls = ["string"],
            ID = 10,
            Category = new() { ID = 1, Name = "Dogs" },
            Status = Status.Available,
            Tags = [new() { ID = 0, Name = "name" }],
        };

        string expectedName = "doggie";
        List<string> expectedPhotoUrls = ["string"];
        long expectedID = 10;
        Category expectedCategory = new() { ID = 1, Name = "Dogs" };
        ApiEnum<string, Status> expectedStatus = Status.Available;
        List<Tag> expectedTags = [new() { ID = 0, Name = "name" }];

        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedPhotoUrls.Count, parameters.PhotoUrls.Count);
        for (int i = 0; i < expectedPhotoUrls.Count; i++)
        {
            Assert.Equal(expectedPhotoUrls[i], parameters.PhotoUrls[i]);
        }
        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedCategory, parameters.Category);
        Assert.Equal(expectedStatus, parameters.Status);
        Assert.NotNull(parameters.Tags);
        Assert.Equal(expectedTags.Count, parameters.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], parameters.Tags[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PetCreateParams { Name = "doggie", PhotoUrls = ["string"] };

        Assert.Null(parameters.ID);
        Assert.False(parameters.RawBodyData.ContainsKey("id"));
        Assert.Null(parameters.Category);
        Assert.False(parameters.RawBodyData.ContainsKey("category"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawBodyData.ContainsKey("status"));
        Assert.Null(parameters.Tags);
        Assert.False(parameters.RawBodyData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new PetCreateParams
        {
            Name = "doggie",
            PhotoUrls = ["string"],

            // Null should be interpreted as omitted for these properties
            ID = null,
            Category = null,
            Status = null,
            Tags = null,
        };

        Assert.Null(parameters.ID);
        Assert.False(parameters.RawBodyData.ContainsKey("id"));
        Assert.Null(parameters.Category);
        Assert.False(parameters.RawBodyData.ContainsKey("category"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawBodyData.ContainsKey("status"));
        Assert.Null(parameters.Tags);
        Assert.False(parameters.RawBodyData.ContainsKey("tags"));
    }

    [Fact]
    public void Url_Works()
    {
        PetCreateParams parameters = new() { Name = "doggie", PhotoUrls = ["string"] };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://petstore3.swagger.io/api/v3/pet"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PetCreateParams
        {
            Name = "doggie",
            PhotoUrls = ["string"],
            ID = 10,
            Category = new() { ID = 1, Name = "Dogs" },
            Status = Status.Available,
            Tags = [new() { ID = 0, Name = "name" }],
        };

        PetCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Available)]
    [InlineData(Status.Pending)]
    [InlineData(Status.Sold)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<MoreConflictingInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Available)]
    [InlineData(Status.Pending)]
    [InlineData(Status.Sold)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
