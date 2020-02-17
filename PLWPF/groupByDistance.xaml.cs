using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using  BL;
namespace PLWPF
{
    /// <summary>
    /// Interaction logic for groupByDistance.xaml
    /// </summary>
    public partial class groupByDistance : UserControl,IValueConverter
    {
        IBL bl;
        public groupByDistance()
        {
            InitializeComponent();
        }
        public object Convert(
            object value,
            Type targetType,
            object parameter,
            CultureInfo culture)
        {
            int value1 = (int)value;
            int value2 = (int)value +2;

            return "between " + value1 + " km and " + value2.ToString() + " km";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
