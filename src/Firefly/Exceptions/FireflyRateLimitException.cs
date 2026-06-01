using System.Net.Http;

namespace Firefly.Exceptions;

public class FireflyRateLimitException : Firefly4xxException
{
    public FireflyRateLimitException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
