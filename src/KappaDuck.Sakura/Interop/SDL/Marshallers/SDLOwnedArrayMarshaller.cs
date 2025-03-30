﻿// Copyright (c) KappaDuck. All rights reserved.
// The source code is licensed under MIT License.

using System.Runtime.InteropServices.Marshalling;

namespace KappaDuck.Sakura.Interop.SDL.Marshallers;

/// <summary>
/// Marshals an array that is owned by SDL and is freed by SDL.
/// </summary>
/// <typeparam name="T">The type of the elements in the array.</typeparam>
/// <typeparam name="TUnmanaged">The type of the elements in the unmanaged array.</typeparam>
[ContiguousCollectionMarshaller]
[CustomMarshaller(typeof(Span<>), MarshalMode.Default, typeof(SDLOwnedArrayMarshaller<,>))]
internal static unsafe class SDLOwnedArrayMarshaller<T, TUnmanaged> where TUnmanaged : unmanaged
{
    internal static TUnmanaged* AllocateContainerForUnmanagedElements(Span<T> managed, out int length)
        => throw new NotSupportedException();

    internal static Span<T> AllocateContainerForManagedElements(TUnmanaged* unmanaged, int length)
    {
        if (unmanaged is null)
            return default;

        return new T[length];
    }

    internal static ReadOnlySpan<T> GetManagedValuesSource(Span<T> managed) => managed;

    internal static Span<TUnmanaged> GetUnmanagedValuesDestination(TUnmanaged* unmanaged, int length)
        => new(unmanaged, length);

    internal static ReadOnlySpan<TUnmanaged> GetUnmanagedValuesSource(TUnmanaged* unmanaged, int length)
        => new(unmanaged, length);

    internal static Span<T> GetManagedValuesDestination(Span<T> managed) => managed;
}
