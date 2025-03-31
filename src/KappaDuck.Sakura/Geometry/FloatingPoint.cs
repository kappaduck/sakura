// Copyright (c) KappaDuck. All rights reserved.
// The source code is licensed under MIT License.

using System.Numerics;

namespace KappaDuck.Sakura.Geometry;

internal static class FloatingPoint
{
    /// <summary>
    /// The machine epsilon for <see cref="float"/>. It is based on C++'s FLT_EPSILON.
    /// </summary>
    internal const float MachineEpsilon = 1.192092896e-07f;

    internal static bool IsNearlyZero(float value) => MathF.Abs(value) < MachineEpsilon;

    internal static void ThrowIfDivideByZero<T>(T value) where T : INumber<T>
    {
        if (T.IsZero(value))
            throw new DivideByZeroException();
    }
}
