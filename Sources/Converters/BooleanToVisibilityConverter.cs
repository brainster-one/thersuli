﻿
namespace Thersuli.Converters {
	using System;
	using System.Globalization;
	using System.Windows;
	using System.Windows.Data;

	public sealed class BooleanToVisibilityConverter : IValueConverter {
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
			if (value is bool)
				return ((bool)value ? Visibility.Visible : Visibility.Collapsed);
			return false;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
			return ((value is Visibility) && (((Visibility)value) == Visibility.Visible));
		}
	} 

}
