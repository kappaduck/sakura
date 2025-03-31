// Copyright (c) KappaDuck. All rights reserved.
// The source code is licensed under MIT License.

using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.InteropServices;

namespace KappaDuck.Sakura.Geometry;

/// <summary>
/// Represents an angle.
/// </summary>
[StructLayout(LayoutKind.Auto)]
public readonly struct Angle :
    IAdditionOperators<Angle, Angle, Angle>,
    ISubtractionOperators<Angle, Angle, Angle>,
    IMultiplyOperators<Angle, float, Angle>,
    IDivisionOperators<Angle, float, Angle>,
    IUnaryNegationOperators<Angle, Angle>,
    IComparable,
    IComparable<Angle>,
    IEquatable<Angle>
{
    private Angle(float radians) => Radians = radians;

    /// <summary>
    /// Gets the angle in radians.
    /// </summary>
    public float Radians { get; }

    /// <summary>
    /// Gets the angle in degrees.
    /// </summary>
    public float Degrees => (float)(Radians * 180 / Math.PI);

    /// <summary>
    /// Gets the computed sine of the angle.
    /// </summary>
    public float Sin => MathF.Sin(Radians);

    /// <summary>
    /// Gets the computed cosine of the angle.
    /// </summary>
    public float Cos => MathF.Cos(Radians);

    /// <summary>
    /// Gets the computed tangent of the angle.
    /// </summary>
    public float Tan => MathF.Tan(Radians);

    /// <summary>
    /// Gets the zero angle.
    /// </summary>
    public static Angle Zero { get; } = new(0f);

    /// <summary>
    /// Implicitly converts a float to an angle.
    /// </summary>
    /// <param name="radians">The angle in radians.</param>
    public static implicit operator Angle(float radians) => new(radians);

    /// <summary>
    /// Explicitly converts an angle to a float.
    /// </summary>
    /// <param name="angle">The angle.</param>
    public static explicit operator float(Angle angle) => angle.Radians;

    /// <summary>
    /// Adds two angles.
    /// </summary>
    /// <param name="left">The left angle.</param>
    /// <param name="right">The right angle.</param>
    /// <returns>The sum of the angles.</returns>
    public static Angle operator +(Angle left, Angle right) => new(left.Radians + right.Radians);

    /// <summary>
    /// Subtracts two angles.
    /// </summary>
    /// <param name="left">The left angle.</param>
    /// <param name="right">The right angle.</param>
    /// <returns>The difference of the angles.</returns>
    public static Angle operator -(Angle left, Angle right) => new(left.Radians - right.Radians);

    /// <summary>
    /// Multiplies an angle by a scalar.
    /// </summary>
    /// <param name="left">The angle.</param>
    /// <param name="right">Scalar to multiply by.</param>
    /// <returns>The product of the angle and the scalar.</returns>
    public static Angle operator *(Angle left, float right) => new(left.Radians * right);

    /// <summary>
    /// Multiplies an angle by a scalar.
    /// </summary>
    /// <param name="left">Scalar to multiply by.</param>
    /// <param name="right">The angle.</param>
    /// <returns>The product of the angle and the scalar.</returns>
    public static Angle operator *(float left, Angle right) => new(left * right.Radians);

    /// <summary>
    /// Divides an angle by a scalar.
    /// </summary>
    /// <param name="left">The angle.</param>
    /// <param name="right">Scalar to divide by.</param>
    /// <returns>The quotient of the angle and the scalar.</returns>
    public static Angle operator /(Angle left, float right)
    {
        FloatingPoint.ThrowIfDivideByZero(right);

        return new(left.Radians / right);
    }

    /// <summary>
    /// Negates an angle.
    /// </summary>
    /// <param name="value">The angle to negate.</param>
    /// <returns>The negated angle.</returns>
    public static Angle operator -(Angle value) => new(-value.Radians);

    /// <summary>
    /// Compares two angles are equal.
    /// </summary>
    /// <param name="left">The left angle.</param>
    /// <param name="right">The right angle.</param>
    /// <returns><see langword="true"/> if the angles are equal; otherwise, <see langword="false"/>.</returns>
    public static bool operator ==(Angle left, Angle right) => left.Equals(right);

    /// <summary>
    /// Compares two angles are not equal.
    /// </summary>
    /// <param name="left">The left angle.</param>
    /// <param name="right">The right angle.</param>
    /// <returns><see langword="true"/> if the angles are not equal; otherwise, <see langword="false"/>.</returns>
    public static bool operator !=(Angle left, Angle right) => !(left == right);

    /// <summary>
    /// Determines whether the left angle is less than the right angle.
    /// </summary>
    /// <param name="left">The left angle.</param>
    /// <param name="right">The right angle.</param>
    /// <returns><see langword="true"/> if the left angle is less than the right angle; otherwise, <see langword="false"/>.</returns>
    public static bool operator <(Angle left, Angle right) => left.Radians < right.Radians;

    /// <summary>
    /// Determines whether the left angle is greater than the right angle.
    /// </summary>
    /// <param name="left">The left angle.</param>
    /// <param name="right">The right angle.</param>
    /// <returns><see langword="true"/> if the left angle is greater than the right angle; otherwise, <see langword="false"/>.</returns>
    public static bool operator >(Angle left, Angle right) => left.Radians > right.Radians;

    /// <summary>
    /// Determines whether the left angle is less than or equal to the right angle.
    /// </summary>
    /// <param name="left">The left angle.</param>
    /// <param name="right">The right angle.</param>
    /// <returns><see langword="true"/> if the left angle is less than or equal to the right angle; otherwise, <see langword="false"/>.</returns>
    public static bool operator <=(Angle left, Angle right) => left.Radians <= right.Radians;

    /// <summary>
    /// Determines whether the left angle is greater than or equal to the right angle.
    /// </summary>
    /// <param name="left">The left angle.</param>
    /// <param name="right">The right angle.</param>
    /// <returns><see langword="true"/> if the left angle is greater than or equal to the right angle; otherwise, <see langword="false"/>.</returns>
    public static bool operator >=(Angle left, Angle right) => left.Radians >= right.Radians;

    /// <summary>
    /// Creates an angle from degrees.
    /// </summary>
    /// <param name="degrees">The angle in degrees.</param>
    /// <returns>The angle.</returns>
    public static Angle FromDegrees(float degrees) => new((float)(degrees * Math.PI / 180f));

    /// <summary>
    /// Creates an angle from radians.
    /// </summary>
    /// <param name="radians">The angle in radians.</param>
    /// <returns>The angle.</returns>
    public static Angle FromRadians(float radians) => new(radians);

    /// <summary>
    /// Normalizes the angle to a range.
    /// </summary>
    /// <remarks>
    /// By default, the range is from 0 to 360 degrees.
    /// </remarks>
    /// <param name="min">The minimum value of the range.</param>
    /// <param name="max">The maximum value of the range.</param>
    /// <returns>The normalized angle.</returns>
    public Angle Normalize(float min = 0f, float max = 360f)
    {
        float range = max - min;
        return FromDegrees(((((Degrees - min) % range) + range) % range) + min);
    }

    /// <inheritdoc/>
    public int CompareTo(Angle other) => Radians.CompareTo(other.Radians);

    /// <inheritdoc/>
    public int CompareTo(object? obj)
    {
        if (obj is null)
            return 1;

        if (obj is Angle x)
            return CompareTo(x);

        throw new ArgumentException("Object is not an Angle.", nameof(obj));
    }

    /// <summary>
    /// Compares two angles are equal.
    /// </summary>
    /// <param name="other">The angle to compare.</param>
    /// <returns><see langword="true"/> if the angles are equal; otherwise, <see langword="false"/>.</returns>
    public readonly bool Equals(Angle other) => FloatingPoint.IsNearlyZero(Radians - other.Radians);

    /// <inheritdoc/>
    public override readonly bool Equals([NotNullWhen(true)] object? obj)
        => obj is Angle angle && Equals(angle);

    /// <inheritdoc/>
    public override readonly int GetHashCode() => Radians.GetHashCode();

    /// <inheritdoc/>
    public override string ToString() => $"{Degrees}°";
}
