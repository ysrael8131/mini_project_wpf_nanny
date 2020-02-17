using BE;
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
using BL;
using Xceed.Wpf.Toolkit;

using System.Threading;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for add_mother.xaml
    /// </summary>
    public partial class add_mother : Window
    {
        BE.Mother mother;
        BL.IBL bl;
        public add_mother()
        {

            InitializeComponent();
            bl = FactoryBl.getBl();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            mother = new Mother();
            DataContext = mother;

        }
        
        /// <summary>
        /// The event of the button Next
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_Next(object sender, RoutedEventArgs e)
        {
        //    //If there are no 9 digits
        //    if (idTextBox.Text.Count() != 9)
        //    {
        //        errorMesseg2.Visibility = Visibility.Visible;
        //        return;
        //    }
            if (checkID())
            {
                first_grid_mother.Visibility = Visibility.Collapsed;
                second_grid_mother.Visibility = Visibility.Visible;
            }
           
        }

        /// <summary>
        /// The event of the button Back
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_back_Click(object sender, RoutedEventArgs e)
        {
            first_grid_mother.Visibility = Visibility.Visible;
            second_grid_mother.Visibility = Visibility.Collapsed;
        }
        /// <summary>
        /// The event of the button Create
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_create_Click(object sender, RoutedEventArgs e)
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
                        mother.arr[i].start = timeStart[i].Value.Value.TimeOfDay;
                        mother.arr[i].end = timeEnd[i].Value.Value.TimeOfDay;
                    }
                }

                bl.addMother(mother);
                second_grid_mother.Visibility = Visibility.Collapsed;
                
                System.Windows.MessageBox.Show("You are assigned to add a child", "The mother was added successfully ", MessageBoxButton.OK,MessageBoxImage.Information);
                this.Close();
                new add_child(mother).Show();
                

            }
            catch (Exception a)
            {

                System.Windows.MessageBox.Show(a.Message, "", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        private void SizeStart1(object sender, SizeChangedEventArgs e)
        {
            TimePicker time = sender as TimePicker;
            errorMessegHours.Visibility = Visibility.Collapsed;
        }
        /// <summary>
        /// Handling exceptions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textChanged1(object sender, TextChangedEventArgs e)
        {
            errorMesseg1.Visibility = Visibility.Collapsed;
            errorMesseg2.Visibility = Visibility.Collapsed;
            errorMesseg3.Visibility = Visibility.Collapsed;
     
           // nextButton.IsEnabled = true;

            //Check if digits are entered
            //long x;
            //if (!long.TryParse(idTextBox.Text, out x) && idTextBox.Text != "")
            //{

            //    errorMesseg1.Visibility = Visibility.Visible;
            //    nextButton.IsEnabled = false;

            //    return;
            //}
            ////Check if the number is negative
            //if (idTextBox.Text != "" && long.Parse(idTextBox.Text) < 0)
            //{
            //    errorMesseg3.Visibility = Visibility.Visible;
            //}
            

        }

        private bool checkID()
        {
            long x;
            if (!long.TryParse(idTextBox.Text, out x) && idTextBox.Text != "")
            {

                errorMesseg1.Visibility = Visibility.Visible;
               // nextButton.IsEnabled = false;

                return false;
            }

            //Check if the number is negative
            if (idTextBox.Text != "" && long.Parse(idTextBox.Text) < 0)
            {
                errorMesseg3.Visibility = Visibility.Visible;
                return false;
            }

            if (idTextBox.Text.Count() != 9)
            {
                errorMesseg2.Visibility = Visibility.Visible;
                return false;
            }
            return true;
        }

    }


}





