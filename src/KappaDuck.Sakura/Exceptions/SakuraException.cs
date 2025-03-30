// Copyright (c) KappaDuck. All rights reserved.
// The source code is licensed under MIT License.

namespace KappaDuck.Sakura.Exceptions;

/// <summary>
/// Represents an exception that is thrown when an error occurs in the Sakura library.
/// </summary>
public sealed class SakuraException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SakuraException"/> class.
    /// </summary>
    public SakuraException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SakuraException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The error message.</param>
    public SakuraException(string? message) : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SakuraException"/> class
    /// with a specified error message and a reference to the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">The error message.</param>
    /// <param name="innerException">The inner exception.</param>
    public SakuraException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
