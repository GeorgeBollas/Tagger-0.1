﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Tagger.Converters
{
    public sealed class UpDownToIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is int m)
            {
                return System.Convert.ToDouble(value);
            }
            return 0d;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
                return System.Convert.ToInt32(value);
            }
            return 0;
        }
    }

}
