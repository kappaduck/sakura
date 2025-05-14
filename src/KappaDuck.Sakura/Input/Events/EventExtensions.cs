// Copyright (c) KappaDuck. All rights reserved.
// The source code is licensed under MIT License.

namespace KappaDuck.Sakura.Input.Events;

/// <summary>
/// Provides extension methods for the <see cref="Event"/>.
/// </summary>
public static class EventExtensions
{
    /// <summary>
    /// Provides extension methods for the <see cref="Event"/>.
    /// </summary>
    extension(Event e)
    {
        /// <summary>
        /// Determines whether the event is a mouse button down event with the specified button.
        /// </summary>
        /// <param name="button">The button to compare.</param>
        /// <returns><see langword="true"/> if the event is a mouse button down event with the specified button; otherwise, <see langword="false"/>.</returns>
        public bool IsMouseButtonDown(Mouse.Button button)
            => e.Type is EventType.MouseButtonDown && e.Mouse.Button == button;

        /// <summary>
        /// Determines whether the event is a mouse button up event with the specified button.
        /// </summary>
        /// <param name="button">The button to compare.</param>
        /// <returns><see langword="true"/> if the event is a mouse button up event with the specified button; otherwise, <see langword="false"/>.</returns>
        public bool IsMouseButtonUp(Mouse.Button button)
            => e.Type is EventType.MouseButtonUp && e.Mouse.Button == button;
    }
}
