// Copyright (c) KappaDuck. All rights reserved.
// The source code is licensed under MIT License.

using System.Runtime.InteropServices;

namespace KappaDuck.Sakura.Input.Events;

/// <summary>
/// Represents an event from the game loop.
/// </summary>
[StructLayout(LayoutKind.Explicit)]
public struct Event
{
    /// <summary>
    /// The type of the event.
    /// </summary>
    [FieldOffset(0)]
    public readonly EventType Type;

    /// <summary>
    /// The display event data.
    /// </summary>
    [FieldOffset(0)]
    public readonly DisplayEvent Display;

    [FieldOffset(0)]
    private unsafe fixed byte _padding[128];
}
