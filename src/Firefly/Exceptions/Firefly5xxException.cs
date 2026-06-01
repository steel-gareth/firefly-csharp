using System.Net.Http;

namespace Firefly.Exceptions;

public class Firefly5xxException : FireflyApiException
{
    public Firefly5xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
