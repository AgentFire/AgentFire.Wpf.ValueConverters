namespace AgentFire.Wpf.ValueConverters
{
    public abstract class BooleanConverterBase<T> : ValueConverterBase<bool, T>
    {
        /// <summary>
        /// Default value: <see cref="false"/>. Set to <see cref="true"/> if you want the logic to be inverted.
        /// </summary>
        public bool IsInverted { get; set; } = false;

        protected bool ProcessBoolean(bool source)
        {
            return IsInverted ? !source : source;
        }
    }
}
