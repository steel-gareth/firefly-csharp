using System.Net.Http;

namespace EmceesProdTesting5.Exceptions;

public class EmceesProdTesting5BadRequestException : EmceesProdTesting54xxException
{
    public EmceesProdTesting5BadRequestException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
