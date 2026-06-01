using System.Net.Http;

namespace EmceesProdTesting5.Exceptions;

public class EmceesProdTesting54xxException : EmceesProdTesting5ApiException
{
    public EmceesProdTesting54xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
