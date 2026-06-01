using System.Net.Http;

namespace EmceesProdTesting5.Exceptions;

public class EmceesProdTesting55xxException : EmceesProdTesting5ApiException
{
    public EmceesProdTesting55xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
