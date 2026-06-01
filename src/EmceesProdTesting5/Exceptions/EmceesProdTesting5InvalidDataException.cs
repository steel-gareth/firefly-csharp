using System;

namespace EmceesProdTesting5.Exceptions;

public class EmceesProdTesting5InvalidDataException : EmceesProdTesting5Exception
{
    public EmceesProdTesting5InvalidDataException(string message, Exception? innerException = null)
        : base(message, innerException) { }
}
