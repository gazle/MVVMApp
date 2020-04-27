using System;
using System.Globalization;
using System.Windows.Data;

namespace MVVMApp1
{
    class SampleConverter : IValueConverter
    {
        public static IValueConverter Instance { get; } = new SampleConverter();

        private SampleConverter() { }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}