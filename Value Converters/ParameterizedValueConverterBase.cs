using System;
using System.Globalization;
using System.Windows.Data;

namespace AgentFire.Wpf.ValueConverters
{
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
            TParameter p = ConvertParameter(parameter);

            if (Equals(value, default(TSource)))
            {
                return Convert(default(TSource), p);
            }
            else if (value is TSource)
            {
                return Convert((TSource)value, p);
            }

            return default(TTarget);
        }
        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            TParameter p = ConvertParameter(parameter);

            if (Equals(value, default(TTarget)))
            {
                return ConvertBack(default(TTarget), p);
            }
            else if (value is TTarget)
            {
                return ConvertBack((TTarget)value, p);
            }

            return default(TSource);
        }

        private static TParameter ConvertParameter(object parameter)
        {
            if (parameter != null && parameter is TParameter)
            {
                return (TParameter)parameter;
            }

            return default(TParameter);
        }
    }
}
