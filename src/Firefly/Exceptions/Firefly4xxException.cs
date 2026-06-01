using System.Net.Http;

namespace Firefly.Exceptions;

public class Firefly4xxException : FireflyApiException
{
    public Firefly4xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
