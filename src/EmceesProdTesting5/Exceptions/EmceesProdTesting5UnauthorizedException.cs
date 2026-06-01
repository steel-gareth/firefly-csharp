using System.Net.Http;

namespace EmceesProdTesting5.Exceptions;

public class EmceesProdTesting5UnauthorizedException : EmceesProdTesting54xxException
{
    public EmceesProdTesting5UnauthorizedException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
