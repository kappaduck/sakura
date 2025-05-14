// Copyright (c) KappaDuck. All rights reserved.
// The source code is licensed under MIT License.

using KappaDuck.Sakura.Interop.SDL;
using KappaDuck.Sakura.Interop.SDL.Marshallers;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace KappaDuck.Sakura.Exceptions;

/// <summary>
/// Represents an exception that is thrown when an error occurs from the native interop.
/// </summary>
public sealed partial class SakuraNativeException : SakuraException
{
    internal SakuraNativeException(string? message) : base(message)
    {
    }

    internal static void ThrowIf([DoesNotReturnIf(true)] bool condition)
    {
        if (condition)
            Throw();
    }

    internal static void ThrowIfFailed(bool result) => ThrowIf(!result);

    internal static void ThrowIfNegative(int value) => ThrowIf(int.IsNegative(value));

    internal static unsafe void ThrowIfNull<T>(T* value) where T : unmanaged
        => ThrowIf(value is null);

    internal static void ThrowIfZero(uint value) => ThrowIf(value == 0);

    [DoesNotReturn]
    private static void Throw()
    {
        string message = SDL_GetError();
        SDL_ClearError();

        throw new SakuraNativeException(message);
    }

    [LibraryImport(SDLNative.LibraryName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial void SDL_ClearError();

    [LibraryImport(SDLNative.LibraryName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalUsing(typeof(SDLOwnedStringMarshaller))]
    private static partial string SDL_GetError();
}
