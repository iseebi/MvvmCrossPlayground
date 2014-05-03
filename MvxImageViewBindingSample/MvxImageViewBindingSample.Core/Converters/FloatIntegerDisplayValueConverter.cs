using System;
using Cirrious.CrossCore.Converters;

namespace MvxImageViewBindingSample.Core.Converters
{
    public class FloatIntegerDisplayValueConverter : MvxValueConverter<float, int>
    {
        protected override int Convert(float value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (int)value;
        }
    }
}

