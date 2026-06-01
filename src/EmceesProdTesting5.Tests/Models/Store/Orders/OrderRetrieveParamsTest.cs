using System;
using EmceesProdTesting5.Models.Store.Orders;

namespace EmceesProdTesting5.Tests.Models.Store.Orders;

public class OrderRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new OrderRetrieveParams { OrderID = 0 };

        long expectedOrderID = 0;

        Assert.Equal(expectedOrderID, parameters.OrderID);
    }

    [Fact]
    public void Url_Works()
    {
        OrderRetrieveParams parameters = new() { OrderID = 0 };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://petstore3.swagger.io/api/v3/store/order/0"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new OrderRetrieveParams { OrderID = 0 };

        OrderRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
