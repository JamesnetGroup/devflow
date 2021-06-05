using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace DevFlow.Converter
{
<<<<<<< HEAD
    public class ResourceNameConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        //var dynamic = FrameworkElement.SetResourceReference(targetType as DependencyProperty, value.ToString());
        return Application.Current.FindResource(value);
    }
=======
	public class ResourceNameConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			//var dynamic = FrameworkElement.SetResourceReference(targetType as DependencyProperty, value.ToString());
			return Application.Current.FindResource(value);
		}
>>>>>>> 2a576b7fde0e188b9e62ab3008e9d6f90580709d

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
