// Copyright (c) KappaDuck. All rights reserved.
// The source code is licensed under MIT License.

using KappaDuck.Sakura.Exceptions;
using KappaDuck.Sakura.Interop.SDL;
using KappaDuck.Sakura.Interop.SDL.Marshallers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace KappaDuck.Sakura.Core;

internal sealed partial class Properties : IDisposable
{
    private readonly uint _id;

    internal Properties()
    {
        _id = SDL_CreateProperties();

        SakuraNativeException.ThrowIfZero(_id);
    }

    public void Dispose() => SDL_DestroyProperties(_id);

    internal T Get<T>(string name, T defaultValue) => Get(_id, name, defaultValue);

    internal void Set<T>(string name, T value) => Set(_id, name, value);

    internal static T Get<T>(uint propertiesId, string name, T defaultValue)
    {
        return defaultValue switch
        {
            bool boolean => (T)(object)SDL_GetBooleanProperty(propertiesId, name, boolean),
            float floating => (T)(object)SDL_GetFloatProperty(propertiesId, name, floating),
            long number => (T)(object)SDL_GetNumberProperty(propertiesId, name, number),
            string str => (T)(object)SDL_GetStringProperty(propertiesId, name, str),
            nint pointer => (T)(object)SDL_GetPointerProperty(propertiesId, name, pointer),
            _ => throw new NotSupportedException($"The type {typeof(T)} is not supported.")
        };
    }

    internal static void Set<T>(uint propertiesId, string name, T value)
    {
        bool isSet = value switch
        {
            bool boolean => SDL_SetBooleanProperty(propertiesId, name, boolean),
            float floating => SDL_SetFloatProperty(propertiesId, name, floating),
            long number => SDL_SetNumberProperty(propertiesId, name, number),
            string str => SDL_SetStringProperty(propertiesId, name, str),
            _ => throw new NotSupportedException($"The type {typeof(T)} is not supported.")
        };

        SakuraNativeException.ThrowIfFailed(isSet);
    }

    [LibraryImport(SDLNative.LibraryName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial uint SDL_CreateProperties();

    [LibraryImport(SDLNative.LibraryName)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial void SDL_DestroyProperties(uint propertiesId);

    [LibraryImport(SDLNative.LibraryName, StringMarshalling = StringMarshalling.Utf8)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.U1)]
    private static partial bool SDL_GetBooleanProperty(uint propertiesId, string name, [MarshalAs(UnmanagedType.U1)] bool defaultValue);

    [LibraryImport(SDLNative.LibraryName, StringMarshalling = StringMarshalling.Utf8)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial float SDL_GetFloatProperty(uint propertiesId, string name, float defaultValue);

    [LibraryImport(SDLNative.LibraryName, StringMarshalling = StringMarshalling.Utf8)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial long SDL_GetNumberProperty(uint propertiesId, string name, long defaultValue);

    [LibraryImport(SDLNative.LibraryName, StringMarshalling = StringMarshalling.Utf8)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial nint SDL_GetPointerProperty(uint propertiesId, string name, nint defaultValue);

    [LibraryImport(SDLNative.LibraryName, StringMarshalling = StringMarshalling.Utf8)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalUsing(typeof(SDLOwnedStringMarshaller))]
    private static partial string SDL_GetStringProperty(uint propertiesId, string name, string defaultValue);

    [LibraryImport(SDLNative.LibraryName, StringMarshalling = StringMarshalling.Utf8)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.U1)]
    private static partial bool SDL_SetBooleanProperty(uint propertiesId, string name, [MarshalAs(UnmanagedType.U1)] bool value);

    [LibraryImport(SDLNative.LibraryName, StringMarshalling = StringMarshalling.Utf8)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.U1)]
    private static partial bool SDL_SetFloatProperty(uint propertiesId, string name, float value);

    [LibraryImport(SDLNative.LibraryName, StringMarshalling = StringMarshalling.Utf8)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.U1)]
    private static partial bool SDL_SetNumberProperty(uint propertiesId, string name, long value);

    [LibraryImport(SDLNative.LibraryName, StringMarshalling = StringMarshalling.Utf8)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.U1)]
    private static partial bool SDL_SetStringProperty(uint propertiesId, string name, string value);
}
