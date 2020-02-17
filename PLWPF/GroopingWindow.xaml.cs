using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BL;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for GroopingWindow.xaml
    /// </summary>
    public partial class GroopingWindow : Window
    {
        IBL bl;
        Bl_imp nn;

        public GroopingWindow()
        {
            InitializeComponent();
            bl = FactoryBl.getBl();
            nn = new Bl_imp();
        }

        private void groopByDistanceButton_Click(object sender, RoutedEventArgs e)
        {

            groupByDistance uc = new groupByDistance();

            //  image.Visibility = Visibility.Visible;
            try
            {
                groopByDistanceButton.IsEnabled = false;
                groopByMaxAgeButton.IsEnabled = false;
                groopByMinAgeButton.IsEnabled = false;
                new Thread(() =>
                {
                    
                    var source = nn.groupingContract(true).ToList();
                    Dispatcher.Invoke(new Action(() =>
                    {
                        try
                        {
                            groopByDistanceButton.IsEnabled = true;
                            groopByMaxAgeButton.IsEnabled = true;
                            groopByMinAgeButton.IsEnabled = true;
                            uc.listView.ItemsSource = source;
                            this.page.Content = uc;
                            //             image.Visibility = Visibility.Collapsed;
                        }
                        catch (Exception n)
                        {
                            MessageBox.Show(n.Message);
                        }
                    }));
                }).Start();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }



        private void groopByMaxAgeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                groupByMaxAge uc = new groupByMaxAge();
                uc.Source = nn.groupingNanny(true);
                this.page.Content = uc;

            }
            catch (Exception x)
            {

                MessageBox.Show(x.Message);
            }
        }

        private void groopByMinAgeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                groupByMinAge uc = new groupByMinAge();
                uc.Source = nn.groupingNanny(true,true);
                this.page.Content = uc;

            }
            catch (Exception x)
            {

                MessageBox.Show(x.Message);
            }
        }
    }
}
