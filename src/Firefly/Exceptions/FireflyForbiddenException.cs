using System.Net.Http;

namespace Firefly.Exceptions;

public class FireflyForbiddenException : Firefly4xxException
{
    public FireflyForbiddenException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
