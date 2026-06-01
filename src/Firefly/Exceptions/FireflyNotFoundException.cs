using System.Net.Http;

namespace Firefly.Exceptions;

public class FireflyNotFoundException : Firefly4xxException
{
    public FireflyNotFoundException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
