using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using BE;
using Xceed.Wpf.Toolkit;
namespace PLWPF
{
    /// <summary>
    /// Interaction logic for AddNanny.xaml
    /// </summary>
    public partial class AddNanny : Window
    {
        Nanny nanny;
        BL.IBL bl;
        string[] str;
        public AddNanny()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            bl = BL.FactoryBl.getBl();
            
            nanny = new Nanny();
            str= new  string[] { "1", "2", "3", "4", "5+ " };
            years_of_experienceComboBox.ItemsSource = str;
            //initialization CoomoBox
            for (int i = 0; i < 12; i++)
            {
                if(i<4)
                {
                    from_years.Items.Add(i);
                    to_years.Items.Add(i);
                }
                if (i < 11 && i > 4)
                    maxChildsComboBox.Items.Add(i);

                from_month.Items.Add(i);
                to_month.Items.Add(i);
            }

            //Bidinig
            DataContext = nanny;

        }
        /// <summary>
        /// The event of the button Next
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_Next(object sender, RoutedEventArgs e)
        {
            //If there are no 9 digits
            if (idTextBox.Text.Count() != 9)
            {

                errorMesseg2.Visibility = Visibility.Visible;
                return;
            }
            first_grid_nanny.Visibility = Visibility.Collapsed;
            second_grid_nanny.Visibility = Visibility.Visible;
        }
        /// <summary>
        /// The event of the button Back
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            first_grid_nanny.Visibility = Visibility.Visible;
            second_grid_nanny.Visibility = Visibility.Collapsed;
        }
        /// <summary>
        /// The event of the button Create
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void add_nanny_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Manually assigning the time data
                List<TimePicker> timeStart = new List<TimePicker>() { start1, startMondayTime, startTuesdayTime, startWednesdayTime, startThursdayTime, startFridayTime };
                List<TimePicker> timeEnd = new List<TimePicker>() { end1, endMondayTime, endTuesdayTime, endWednesdayTime, endThursdayTime, endFridayTime };
                List<CheckBox> check = new List<CheckBox>() { sundayCheckBox, mondayCheckBox, tuesdayCheckBox, wednesdayCheckBox, thursdayCheckBox, fridayCheckBox };
                for (int i = 0; i < 6; i++)
                {
                    //If no hourly data were entered
                    if (check[i].IsChecked == true && (timeStart[i].Value == null || timeEnd[i].Value == null))
                    {
                        errorMessegHours.Visibility = Visibility.Visible;
                        return;
                    }
                    //If a start time is late than the end time
                    if (check[i].IsChecked == true && timeStart[i].Value.Value.TimeOfDay > timeEnd[i].Value.Value.TimeOfDay)
                    {
                        errorMessegTime.Visibility = Visibility.Visible;
                        return;
                    }

                    if (check[i].IsChecked == true)
                    {
                        nanny.work[i].start = timeStart[i].Value.Value.TimeOfDay;
                        nanny.work[i].end = timeEnd[i].Value.Value.TimeOfDay;
                    }
                }
                nanny.age_child_min = int.Parse(from_years.SelectedItem.ToString()) * 12 + int.Parse(from_month.SelectedItem.ToString());
                nanny.age_child_max= int.Parse(to_years.SelectedItem.ToString()) * 12 + int.Parse(to_month.SelectedItem.ToString());
                bl.addNanny(nanny);
                second_grid_nanny.Visibility = Visibility.Collapsed;
                System.Windows.MessageBox.Show("ID: "+nanny.id.ToString(), "The nanny was added successfully ", MessageBoxButton.OK, MessageBoxImage.Information);


                 this.Close();


            }
            catch (Exception a)
            {

                System.Windows.MessageBox.Show(a.Message);
            }

        }

        private void textChanged(object sender, TextChangedEventArgs e)
        {
            errorMesseg1.Visibility = Visibility.Collapsed;
            errorMesseg2.Visibility = Visibility.Collapsed;
            errorMesseg3.Visibility = Visibility.Collapsed;


            long x;
            if (!long.TryParse(idTextBox.Text, out x) && idTextBox.Text != "")
            {

                errorMesseg1.Visibility = Visibility.Visible;

                return;
            }
            if (idTextBox.Text != "" && long.Parse(idTextBox.Text) < 0)
            {
                errorMesseg3.Visibility = Visibility.Visible;
            }

        }


        private void Years_MouseEnter(object sender, MouseEventArgs e)
        {
            ComboBox com = sender as ComboBox;
            com.ToolTip = "choose years";
        }

        private void month_MouseEnter(object sender, MouseEventArgs e)
        {
            ComboBox com = sender as ComboBox;
            com.ToolTip = "choose months";

        }

        private void selectError(object sender, SelectionChangedEventArgs e)
        {
             errorMesseg4.Visibility = Visibility.Collapsed;
            if(int.Parse(to_years.SelectedItem.ToString())< int.Parse(from_years.SelectedItem.ToString())
                || (int.Parse(to_years.SelectedItem.ToString()) == int.Parse(from_years.SelectedItem.ToString())&&
                int.Parse(to_month.SelectedItem.ToString()) < int.Parse(from_month.SelectedItem.ToString())))
            {
                errorMesseg4.Visibility = Visibility.Visible;
            }

           
                    
        }

        private void SizeStart1(object sender, SizeChangedEventArgs e)
        {
            errorMessegHours.Visibility = Visibility.Collapsed;
        }

        private void salaryPerHourTextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox text1 = sender as TextBox;
            errorMesseg8.Visibility = Visibility.Collapsed;
            errorMesseg10.Visibility = Visibility.Collapsed;


            long x;
            if (!long.TryParse(text1.Text, out x) && text1.Text != "")
            {

                errorMesseg8.Visibility = Visibility.Visible;

                return;
            }
            if (text1.Text != "" && long.Parse(text1.Text) < 0)
            {
                errorMesseg10.Visibility = Visibility.Visible;
            }
        }

        private void sizeChanged(object sender, SizeChangedEventArgs e)
        {
            errorMessegHours.Visibility = Visibility.Collapsed;
        }
    }
}
