// Copyright (c) KappaDuck. All rights reserved.
// The source code is licensed under MIT License.

using System.Runtime.InteropServices;

namespace KappaDuck.Sakura.Interop.Handles;

/// <summary>
/// Provides a base class for safe handle implementations in which the value of <see cref="nint.Zero"/> indicates an invalid handle.
/// </summary>
/// <param name="ownsHandle"><see langword="true"/> owns the handle during the finalization phase; otherwise, <see langword="false"/>.</param>
internal abstract class SafeHandleZeroInvalid(bool ownsHandle) : SafeHandle(nint.Zero, ownsHandle)
{
    protected SafeHandleZeroInvalid() : this(ownsHandle: true)
    {
    }

    public override bool IsInvalid => handle == nint.Zero;
}
