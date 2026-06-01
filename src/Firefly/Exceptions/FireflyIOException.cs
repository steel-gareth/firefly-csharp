using System;
using System.Net.Http;

namespace Firefly.Exceptions;

public class FireflyIOException : FireflyException
{
    public new HttpRequestException InnerException
    {
        get
        {
            if (base.InnerException == null)
            {
                throw new ArgumentNullException();
            }
            return (HttpRequestException)base.InnerException;
        }
    }

    public FireflyIOException(string message, HttpRequestException? innerException = null)
        : base(message, innerException) { }
}
