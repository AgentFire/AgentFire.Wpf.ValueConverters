using System;
using System.Windows;

namespace AgentFire.Wpf.ValueConverters.Predefined
{
    /// <summary>
    /// Returns boolean depending on whether the source <see cref="object"/> is <see cref="null"/>: if an object is <see cref="null"/> - <see cref="Visibility.Collapsed"/>, if not - to <see cref="Visibility.Visible"/>.
    /// Supports replacing <see cref="Visibility.Collapsed"/> with <see cref="Visibility.Hidden"/>.
    /// Supports inverting boolean logic.
    /// </summary>
    public class NullToVisibilityConverter : ValueConverterBase<object, Visibility>
    {
        /// <summary>
        /// Default value: <see cref="false"/>. Set to <see cref="true"/> to replace <see cref="Visibility.Collapsed"/> with <see cref="Visibility.Hidden"/>.
        /// </summary>
        public bool UseHidden { get; set; } = false;

        /// <summary>
        /// Default value: <see cref="false"/>. Set to <see cref="true"/> if you want the logic to be inverted: to return <see cref="Visibility.Visible"/> if the source is <see cref="null"/>.
        /// </summary>
        public bool IsInverted { get; set; } = false;

        protected override Visibility Convert(object source)
        {
            return ((source == null && !IsInverted) || (source != null && IsInverted)) ? (UseHidden ? Visibility.Hidden : Visibility.Collapsed) : Visibility.Visible;
        }
        /// <summary>
        /// Always throws an <see cref="InvalidOperationException"/>.
        /// </summary>
        protected override sealed object ConvertBack(Visibility source)
        {
            throw new InvalidOperationException();
        }
    }
}
