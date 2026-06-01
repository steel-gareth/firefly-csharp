using System;
using System.Text;
using EmceesProdTesting5.Core;
using EmceesProdTesting5.Models.Pets;

namespace EmceesProdTesting5.Tests.Models.Pets;

public class PetUploadImageParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        BinaryContent image = Encoding.UTF8.GetBytes("Example data");

        var parameters = new PetUploadImageParams
        {
            PetID = 0,
            Image = image,
            AdditionalMetadata = "additionalMetadata",
        };

        long expectedPetID = 0;
        BinaryContent expectedImage = image;
        string expectedAdditionalMetadata = "additionalMetadata";

        Assert.Equal(expectedPetID, parameters.PetID);
        Assert.Equal(expectedImage, parameters.Image);
        Assert.Equal(expectedAdditionalMetadata, parameters.AdditionalMetadata);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        BinaryContent image = Encoding.UTF8.GetBytes("Example data");

        var parameters = new PetUploadImageParams { PetID = 0, Image = image };

        Assert.Null(parameters.AdditionalMetadata);
        Assert.False(parameters.RawQueryData.ContainsKey("additionalMetadata"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        BinaryContent image = Encoding.UTF8.GetBytes("Example data");

        var parameters = new PetUploadImageParams
        {
            PetID = 0,
            Image = image,

            // Null should be interpreted as omitted for these properties
            AdditionalMetadata = null,
        };

        Assert.Null(parameters.AdditionalMetadata);
        Assert.False(parameters.RawQueryData.ContainsKey("additionalMetadata"));
    }

    [Fact]
    public void Url_Works()
    {
        PetUploadImageParams parameters = new()
        {
            PetID = 0,
            Image = Encoding.UTF8.GetBytes("Example data"),
            AdditionalMetadata = "additionalMetadata",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://petstore3.swagger.io/api/v3/pet/0/uploadImage?additionalMetadata=additionalMetadata"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PetUploadImageParams
        {
            PetID = 0,
            Image = Encoding.UTF8.GetBytes("Example data"),
            AdditionalMetadata = "additionalMetadata",
        };

        PetUploadImageParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
