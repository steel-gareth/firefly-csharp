using System.Net.Http;

namespace EmceesProdTesting5.Exceptions;

public class EmceesProdTesting5ForbiddenException : EmceesProdTesting54xxException
{
    public EmceesProdTesting5ForbiddenException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
