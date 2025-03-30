// Copyright (c) KappaDuck. All rights reserved.
// The source code is licensed under MIT License.

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace KappaDuck.Sakura.Interop.SDL;

internal static partial class SDLNative
{
    internal static unsafe void Free<T>(T* memory) where T : unmanaged
        => Free((nint)memory);

    internal static unsafe void Free<T>(T** memory) where T : unmanaged
        => Free((nint)memory);

    internal static void Free(nint memory) => SDL_free(memory);

    [LibraryImport(LibraryName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial void SDL_free(nint memory);
}
