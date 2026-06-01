using System;
using System.Net.Http;

namespace Firefly.Exceptions;

public class FireflyException : Exception
{
    public FireflyException(string message, Exception? innerException = null)
        : base(message, innerException) { }

    protected FireflyException(HttpRequestException? innerException)
        : base(null, innerException) { }
}
