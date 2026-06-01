using System.Net.Http;

namespace Firefly.Exceptions;

public class FireflyUnauthorizedException : Firefly4xxException
{
    public FireflyUnauthorizedException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
