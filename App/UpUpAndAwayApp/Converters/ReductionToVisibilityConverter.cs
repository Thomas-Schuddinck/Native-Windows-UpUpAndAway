using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace UpUpAndAwayApp.Converters
{
    public class ReductionToVisibilityConverter : IValueConverter {

        public ReductionToVisibilityConverter()
        {
        }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is double)
            {
                if ((double)value == 0)
                    return Visibility.Collapsed;
                return Visibility.Visible;
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
