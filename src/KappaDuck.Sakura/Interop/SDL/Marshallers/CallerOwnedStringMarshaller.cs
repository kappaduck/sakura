// Copyright (c) KappaDuck. All rights reserved.
// The source code is licensed under MIT License.

using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace KappaDuck.Sakura.Interop.SDL.Marshallers;

/// <summary>
/// Marshals a string that is owned by the caller and it is freed automatically by the marshaller.
/// </summary>
[CustomMarshaller(typeof(string), MarshalMode.ManagedToUnmanagedOut, typeof(CallerOwnedStringMarshaller))]
internal static class CallerOwnedStringMarshaller
{
    internal static string ConvertToManaged(nint unmanaged)
        => Marshal.PtrToStringUTF8(unmanaged)!;

    internal static void Free(nint unmanaged)
        => SDLNative.Free(unmanaged);
}
