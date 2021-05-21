﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace DevFlow.Converter
{
	public class RgbToHexConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			string hex = "";
			int color = int.Parse(value.ToString());

			switch (parameter)
			{
				case "R": hex = $"#FF{color.ToString("X2")}0000";break;
				case "G": hex = $"#FF00{color.ToString("X2")}00"; break;
				case "B": hex = $"#FF0000{color.ToString("X2")}"; break;
			}

			return hex;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
