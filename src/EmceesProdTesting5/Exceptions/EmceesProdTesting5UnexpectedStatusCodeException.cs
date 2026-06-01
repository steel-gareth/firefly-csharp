using System.Net.Http;

namespace EmceesProdTesting5.Exceptions;

public class EmceesProdTesting5UnexpectedStatusCodeException : EmceesProdTesting5ApiException
{
    public EmceesProdTesting5UnexpectedStatusCodeException(
        HttpRequestException? innerException = null
    )
        : base(innerException) { }
}
