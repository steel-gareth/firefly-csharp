using System;
using System.Net.Http;

namespace EmceesProdTesting5.Exceptions;

public class EmceesProdTesting5Exception : Exception
{
    public EmceesProdTesting5Exception(string message, Exception? innerException = null)
        : base(message, innerException) { }

    protected EmceesProdTesting5Exception(HttpRequestException? innerException)
        : base(null, innerException) { }
}
