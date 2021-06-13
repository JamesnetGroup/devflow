﻿using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace DevFlow.Converter
{
    public class FileSizeConverter : MarkupExtension, IValueConverter
    {
        #region Convert

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            value = value ?? 0;
            string[] units = { "B", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
            double size = long.Parse(value.ToString());
            int unit = 0;

            while (size >= 1024 && unit < 1)
            {
                size /= 1024;
                ++unit;
            }
            if (size == 0) return "";
            return String.Format("{0:#,##0.#}{1}", size, units[unit]);
        }
        #endregion

        #region ConvertBack

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region ProvideValue

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
        #endregion
    }
}