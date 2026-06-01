using System;
using System.Net.Http;

namespace EmceesProdTesting5.Exceptions;

public class EmceesProdTesting5IOException : EmceesProdTesting5Exception
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

    public EmceesProdTesting5IOException(
        string message,
        HttpRequestException? innerException = null
    )
        : base(message, innerException) { }
}
