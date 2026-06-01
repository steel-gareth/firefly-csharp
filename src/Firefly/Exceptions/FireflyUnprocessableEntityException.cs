using System.Net.Http;

namespace Firefly.Exceptions;

public class FireflyUnprocessableEntityException : Firefly4xxException
{
    public FireflyUnprocessableEntityException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
