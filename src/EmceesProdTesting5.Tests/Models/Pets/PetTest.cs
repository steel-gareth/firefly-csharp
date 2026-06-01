using System.Collections.Generic;
using System.Text.Json;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Exceptions;
using EmceesProdTesting5.Models.Pets;

namespace EmceesProdTesting5.Tests.Models.Pets;

public class PetTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Pet
        {
            Name = "doggie",
            PhotoUrls = ["string"],
            ID = 10,
            Category = new() { ID = 1, Name = "Dogs" },
            Status = PetStatus.Available,
            Tags = [new() { ID = 0, Name = "name" }],
        };

        string expectedName = "doggie";
        List<string> expectedPhotoUrls = ["string"];
        long expectedID = 10;
        Category expectedCategory = new() { ID = 1, Name = "Dogs" };
        ApiEnum<string, PetStatus> expectedStatus = PetStatus.Available;
        List<Tag> expectedTags = [new() { ID = 0, Name = "name" }];

        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPhotoUrls.Count, model.PhotoUrls.Count);
        for (int i = 0; i < expectedPhotoUrls.Count; i++)
        {
            Assert.Equal(expectedPhotoUrls[i], model.PhotoUrls[i]);
        }
        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCategory, model.Category);
        Assert.Equal(expectedStatus, model.Status);
        Assert.NotNull(model.Tags);
        Assert.Equal(expectedTags.Count, model.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], model.Tags[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Pet
        {
            Name = "doggie",
            PhotoUrls = ["string"],
            ID = 10,
            Category = new() { ID = 1, Name = "Dogs" },
            Status = PetStatus.Available,
            Tags = [new() { ID = 0, Name = "name" }],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Pet>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Pet
        {
            Name = "doggie",
            PhotoUrls = ["string"],
            ID = 10,
            Category = new() { ID = 1, Name = "Dogs" },
            Status = PetStatus.Available,
            Tags = [new() { ID = 0, Name = "name" }],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Pet>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedName = "doggie";
        List<string> expectedPhotoUrls = ["string"];
        long expectedID = 10;
        Category expectedCategory = new() { ID = 1, Name = "Dogs" };
        ApiEnum<string, PetStatus> expectedStatus = PetStatus.Available;
        List<Tag> expectedTags = [new() { ID = 0, Name = "name" }];

        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPhotoUrls.Count, deserialized.PhotoUrls.Count);
        for (int i = 0; i < expectedPhotoUrls.Count; i++)
        {
            Assert.Equal(expectedPhotoUrls[i], deserialized.PhotoUrls[i]);
        }
        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.NotNull(deserialized.Tags);
        Assert.Equal(expectedTags.Count, deserialized.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], deserialized.Tags[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Pet
        {
            Name = "doggie",
            PhotoUrls = ["string"],
            ID = 10,
            Category = new() { ID = 1, Name = "Dogs" },
            Status = PetStatus.Available,
            Tags = [new() { ID = 0, Name = "name" }],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Pet { Name = "doggie", PhotoUrls = ["string"] };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Category);
        Assert.False(model.RawData.ContainsKey("category"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Pet { Name = "doggie", PhotoUrls = ["string"] };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Pet
        {
            Name = "doggie",
            PhotoUrls = ["string"],

            // Null should be interpreted as omitted for these properties
            ID = null,
            Category = null,
            Status = null,
            Tags = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Category);
        Assert.False(model.RawData.ContainsKey("category"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Pet
        {
            Name = "doggie",
            PhotoUrls = ["string"],

            // Null should be interpreted as omitted for these properties
            ID = null,
            Category = null,
            Status = null,
            Tags = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Pet
        {
            Name = "doggie",
            PhotoUrls = ["string"],
            ID = 10,
            Category = new() { ID = 1, Name = "Dogs" },
            Status = PetStatus.Available,
            Tags = [new() { ID = 0, Name = "name" }],
        };

        Pet copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PetStatusTest : TestBase
{
    [Theory]
    [InlineData(PetStatus.Available)]
    [InlineData(PetStatus.Pending)]
    [InlineData(PetStatus.Sold)]
    public void Validation_Works(PetStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PetStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PetStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<MoreConflictingInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PetStatus.Available)]
    [InlineData(PetStatus.Pending)]
    [InlineData(PetStatus.Sold)]
    public void SerializationRoundtrip_Works(PetStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PetStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PetStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PetStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PetStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
