using System;
using Cirrious.CrossCore.Converters;

namespace MvxImageViewBindingSample.Core.Converters
{
    public class BoolStringValueConverter : MvxValueConverter<bool, string>
    {
        protected override string Convert(bool value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value ? parameter as string : null;
        }
    }
}

