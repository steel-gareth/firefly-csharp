using System;
using EmceesProdTesting5.Models.Users;

namespace EmceesProdTesting5.Tests.Models.Users;

public class UserRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UserRetrieveParams { Username = "username" };

        string expectedUsername = "username";

        Assert.Equal(expectedUsername, parameters.Username);
    }

    [Fact]
    public void Url_Works()
    {
        UserRetrieveParams parameters = new() { Username = "username" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://petstore3.swagger.io/api/v3/user/username"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new UserRetrieveParams { Username = "username" };

        UserRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
