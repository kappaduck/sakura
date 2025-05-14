// Copyright (c) KappaDuck. All rights reserved.
// The source code is licensed under MIT License.

using KappaDuck.Sakura.Geometry;
using KappaDuck.Sakura.Interop.SDL;
using KappaDuck.Sakura.Interop.SDL.Marshallers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace KappaDuck.Sakura.Video.Displays;

/// <summary>
/// Native methods for <see cref="Display"/>.
/// </summary>
public sealed partial class Display
{
    [LibraryImport(SDLNative.LibraryName), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.U1)]
    private static partial bool SDL_GetClosestFullscreenDisplayMode(uint display, int width, int height, float refreshRate, [MarshalAs(UnmanagedType.U1)] bool includeHighDensityMode, out DisplayMode displayMode);

    [LibraryImport(SDLNative.LibraryName), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static unsafe partial DisplayMode* SDL_GetCurrentDisplayMode(uint display);

    [LibraryImport(SDLNative.LibraryName), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial DisplayOrientation SDL_GetCurrentDisplayOrientation(uint display);

    [LibraryImport(SDLNative.LibraryName), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static unsafe partial DisplayMode* SDL_GetDesktopDisplayMode(uint display);

    [LibraryImport(SDLNative.LibraryName), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalUsing(typeof(CallerOwnedArrayMarshaller<,>), CountElementName = "length")]
    private static partial Span<uint> SDL_GetDisplays(out int length);

    [LibraryImport(SDLNative.LibraryName), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.U1)]
    private static partial bool SDL_GetDisplayBounds(uint display, out RectInt bounds);

    [LibraryImport(SDLNative.LibraryName), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial float SDL_GetDisplayContentScale(uint display);

    [LibraryImport(SDLNative.LibraryName), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static unsafe partial uint SDL_GetDisplayForPoint(Vector2Int* point);

    [LibraryImport(SDLNative.LibraryName), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static unsafe partial uint SDL_GetDisplayForRect(RectInt* rectangle);

    [LibraryImport(SDLNative.LibraryName), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalUsing(typeof(SDLOwnedStringMarshaller))]
    private static partial string SDL_GetDisplayName(uint display);

    [LibraryImport(SDLNative.LibraryName), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial uint SDL_GetDisplayProperties(uint display);

    [LibraryImport(SDLNative.LibraryName), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.U1)]
    private static partial bool SDL_GetDisplayUsableBounds(uint display, out RectInt bounds);

    [LibraryImport(SDLNative.LibraryName), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static unsafe partial DisplayMode** SDL_GetFullscreenDisplayModes(uint display, out int count);

    [LibraryImport(SDLNative.LibraryName), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial DisplayOrientation SDL_GetNaturalDisplayOrientation(uint display);

    [LibraryImport(SDLNative.LibraryName), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial uint SDL_GetPrimaryDisplay();
}
