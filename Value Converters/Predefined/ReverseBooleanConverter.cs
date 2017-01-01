namespace AgentFire.Wpf.ValueConverters.Predefined
{
    /// <summary>
    /// Simply negates any boolean value.
    /// </summary>
    public sealed class ReverseBooleanConverter : ValueConverterBase<bool, bool>
    {
        /// <summary>
        /// Default value: <see cref="false"/>. Set to <see cref="true"/> to enable only source=>target reversion, but not vise versa.
        /// </summary>
        public bool OneWayReverse { get; set; } = false;

        protected override bool Convert(bool source)
        {
            return !source;
        }
        protected override bool ConvertBack(bool source)
        {
            return OneWayReverse ? source : !source;
        }
    }
}
