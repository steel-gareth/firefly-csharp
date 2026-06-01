using System;
using System.Collections.Generic;
using EmceesProdTesting5.Models.Users;

namespace EmceesProdTesting5.Tests.Models.Users;

public class UserCreateWithListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UserCreateWithListParams
        {
            Items =
            [
                new()
                {
                    ID = 10,
                    Email = "john@email.com",
                    FirstName = "John",
                    LastName = "James",
                    Password = "12345",
                    Phone = "12345",
                    Username = "theUser",
                    UserStatus = 1,
                },
            ],
        };

        List<User> expectedItems =
        [
            new()
            {
                ID = 10,
                Email = "john@email.com",
                FirstName = "John",
                LastName = "James",
                Password = "12345",
                Phone = "12345",
                Username = "theUser",
                UserStatus = 1,
            },
        ];

        Assert.NotNull(parameters.Items);
        Assert.Equal(expectedItems.Count, parameters.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], parameters.Items[i]);
        }
    }

    [Fact]
    public void Url_Works()
    {
        UserCreateWithListParams parameters = new();

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://petstore3.swagger.io/api/v3/user/createWithList"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new UserCreateWithListParams
        {
            Items =
            [
                new()
                {
                    ID = 10,
                    Email = "john@email.com",
                    FirstName = "John",
                    LastName = "James",
                    Password = "12345",
                    Phone = "12345",
                    Username = "theUser",
                    UserStatus = 1,
                },
            ],
        };

        UserCreateWithListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
