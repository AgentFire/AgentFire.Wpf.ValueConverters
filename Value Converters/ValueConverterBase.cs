using System;
using System.Globalization;
using System.Windows.Data;

namespace AgentFire.Wpf.ValueConverters
{
    public abstract class ValueConverterBase<TSource, TTarget> : IValueConverter
    {
        protected abstract TTarget Convert(TSource source);
        protected virtual TSource ConvertBack(TTarget source)
        {
            throw new NotImplementedException();
        }

        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (Equals(value, default(TSource)))
            {
                return Convert(default(TSource));
            }
            else if (value is TSource)
            {
                return Convert((TSource)value);
            }

            return default(TTarget);
        }
        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (Equals(value, default(TTarget)))
            {
                return ConvertBack(default(TTarget));
            }
            else if (value is TTarget)
            {
                return ConvertBack((TTarget)value);
            }

            return default(TSource);
        }
    }
}
