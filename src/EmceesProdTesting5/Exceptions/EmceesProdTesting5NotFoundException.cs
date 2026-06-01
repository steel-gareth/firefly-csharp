using System.Net.Http;

namespace EmceesProdTesting5.Exceptions;

public class EmceesProdTesting5NotFoundException : EmceesProdTesting54xxException
{
    public EmceesProdTesting5NotFoundException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
