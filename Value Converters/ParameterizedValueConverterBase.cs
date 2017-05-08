using AgentFire.Wpf.ValueConverters.Tools;
using System;
using System.Globalization;
using System.Windows.Data;

namespace AgentFire.Wpf.ValueConverters
{
    /// <summary>
    /// Represents an abstract class that is used for WPF Value conversions from <typeparamref name="TSource"/> to <typeparamref name="TTarget"/> using a parameter of type <typeparamref name="TParameter"/>.
    /// </summary>
    /// <typeparam name="TSource">The type to convert from.</typeparam>
    /// <typeparam name="TTarget">The type to convert to.</typeparam>
    public abstract class ParameterizedValueConverterBase<TSource, TTarget, TParameter> : ValueConverterBase<TSource, TTarget>, IValueConverter
    {
        protected override TTarget Convert(TSource source) => Convert(source, default(TParameter));
        protected override TSource ConvertBack(TTarget source) => ConvertBack(source, default(TParameter));

        protected abstract TTarget Convert(TSource source, TParameter parameter);
        protected virtual TSource ConvertBack(TTarget source, TParameter parameter)
        {
            throw new NotImplementedException();
        }

        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Convert(CastTo<TSource>.From(value), CastTo<TParameter>.From(parameter));
        }
        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ConvertBack(CastTo<TTarget>.From(value), CastTo<TParameter>.From(parameter));
        }
    }
}
