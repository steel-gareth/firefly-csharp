using System.Net.Http;

namespace Firefly.Exceptions;

public class FireflyUnexpectedStatusCodeException : FireflyApiException
{
    public FireflyUnexpectedStatusCodeException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
