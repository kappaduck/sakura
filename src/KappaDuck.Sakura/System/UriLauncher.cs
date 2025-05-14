// Copyright (c) KappaDuck. All rights reserved.
// The source code is licensed under MIT License.

using KappaDuck.Sakura.Exceptions;
using KappaDuck.Sakura.Interop.SDL;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace KappaDuck.Sakura.System;

/// <summary>
/// Provides methods to launch URLs.
/// </summary>
/// <remarks>
/// Open a URL in a separate, system-provided application. How this works will vary wildly depending on the platform.
/// This will likely launch what makes sense to handle a specific URL's protocol (a web browser for http://, etc),
/// but it might also be able to launch file managers for directories and other things.
/// What happens when you open a URL varies wildly as well: your game window may lose
/// focus and may or may not lose focus if your game was Fullscreen or grabbing input at the time.
/// </remarks>
public static partial class UriLauncher
{
    /// <summary>
    /// Open a URL/URI in the system's default web browser or other appropriate external application.
    /// </summary>
    /// <param name="url">The URL/URI to open.</param>
    /// <exception cref="SakuraNativeException">Failed to open the URL/URI.</exception>
    public static void Open(string url) => SakuraNativeException.ThrowIfFailed(SDL_OpenURL(url));

    /// <inheritdoc cref="Open(string)"/>
    public static void Open(Uri uri) => Open(uri.ToString());

    [LibraryImport(SDLNative.LibraryName, StringMarshalling = StringMarshalling.Utf8), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.U1)]
    private static partial bool SDL_OpenURL(string url);
}
