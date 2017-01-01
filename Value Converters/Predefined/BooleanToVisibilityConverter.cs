using System.Windows;

namespace AgentFire.Wpf.ValueConverters.Predefined
{
    /// <summary>
    /// Converts bool values: <see cref="true"/> to <see cref="Visibility.Visible"/>, <see cref="false"/> to <see cref="Visibility.Collapsed"/> and vise versa.
    /// Supports replacing <see cref="Visibility.Collapsed"/> with <see cref="Visibility.Hidden"/>.
    /// </summary>
    public class BooleanToVisibilityConverter : BooleanConverterBase<Visibility>
    {
        /// <summary>
        /// Default value: <see cref="false"/>. Set to <see cref="true"/> to replace <see cref="Visibility.Collapsed"/> with <see cref="Visibility.Hidden"/>.
        /// </summary>
        public bool UseHidden { get; set; } = false;

        protected override Visibility Convert(bool source)
        {
            return ProcessBoolean(source) ? Visibility.Visible : (UseHidden ? Visibility.Hidden : Visibility.Collapsed);
        }
        protected override bool ConvertBack(Visibility source)
        {
            return ProcessBoolean(source == Visibility.Visible);
        }
    }
}
