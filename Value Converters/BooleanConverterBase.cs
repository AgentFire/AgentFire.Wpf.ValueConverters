namespace AgentFire.Wpf.ValueConverters
{
    public abstract class BooleanConverterBase<TSource, TTarget> : ValueConverterBase<TSource, TTarget>
    {
        /// <summary>
        /// Default value: <see cref="false"/>. Set to <see cref="true"/> if you want your boolean logic (that is, <see cref="ProcessBoolean(bool)"/> result) to be inverted.
        /// </summary>
        public bool IsInverted { get; set; } = false;

        protected bool ProcessBoolean(bool source)
        {
            return IsInverted ? !source : source;
        }
    }
}
