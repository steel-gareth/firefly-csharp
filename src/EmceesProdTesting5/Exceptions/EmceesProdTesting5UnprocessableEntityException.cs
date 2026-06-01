using System.Net.Http;

namespace EmceesProdTesting5.Exceptions;

public class EmceesProdTesting5UnprocessableEntityException : EmceesProdTesting54xxException
{
    public EmceesProdTesting5UnprocessableEntityException(
        HttpRequestException? innerException = null
    )
        : base(innerException) { }
}
