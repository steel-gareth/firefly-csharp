using System.Net.Http;

namespace Firefly.Exceptions;

public class FireflyBadRequestException : Firefly4xxException
{
    public FireflyBadRequestException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
