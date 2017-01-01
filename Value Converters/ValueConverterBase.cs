using AgentFire.Wpf.ValueConverters.Tools;
using System;
using System.Globalization;
using System.Windows.Data;

namespace AgentFire.Wpf.ValueConverters
{
    /// <summary>
    /// Represents an abstract class that is used for WPF Value conversions from <typeparamref name="TSource"/> to <typeparamref name="TTarget"/>.
    /// </summary>
    /// <typeparam name="TSource">The type to convert from.</typeparam>
    /// <typeparam name="TTarget">The type to convert to.</typeparam>
    public abstract class ValueConverterBase<TSource, TTarget> : IValueConverter
    {
        /// <summary>
        /// Override this method to provide custom conversion from <typeparamref name="TSource"/> to <typeparamref name="TTarget"/>.
        /// </summary>
        /// <param name="source">Source data value.</param>
        protected abstract TTarget Convert(TSource source);
        /// <summary>
        /// Override this method to provide custom conversion back from <typeparamref name="TTarget"/> to <typeparamref name="TSource"/>.
        /// </summary>
        /// <remarks>Default implementation throws an <see cref="NotImplementedException"/>.</remarks>
        /// <param name="source">Source data value.</param>
        protected virtual TSource ConvertBack(TTarget source)
        {
            throw new NotImplementedException();
        }

        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Convert(CastTo<TSource>.From(value));
        }
        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ConvertBack(CastTo<TTarget>.From(value));
        }
    }
}
