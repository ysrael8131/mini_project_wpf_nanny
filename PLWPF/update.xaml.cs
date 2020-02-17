using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for update.xaml
    /// </summary>
    public partial class update : Window
    {

        //   private  ObservableCollection<BE.Mother> ff = new ObservableCollection<BE.Mother>();
        BL.IBL bl;
        string[] str;
        BE.Mother mother;
        BE.Child child;
        BE.Nanny nanny;


        List<TimePicker> timeStart;
        List<TimePicker> timeEnd;
        List<CheckBox> check;

        List<TimePicker> timeStart_n;
        List<TimePicker> timeEnd_n;
        List<CheckBox> check_n;
       
        public update()
        {
            bl = BL.FactoryBl.getBl();
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            timeStart_n = new List<TimePicker> { start1_n, startMondayTime_n, startTuesdayTime_n, startWednesdayTime_n, startThursdayTime_n, startFridayTime_n };
            timeEnd_n = new List<TimePicker> { end1_n, endMondayTime_n, endTuesdayTime_n, endWednesdayTime_n, endThursdayTime_n, endFridayTime_n };
            check_n = new List<CheckBox> { sundayCheckBox_n, mondayCheckBox_n, tuesdayCheckBox_n, wednesdayCheckBox_n, thursdayCheckBox_n, fridayCheckBox_n };
            
            timeStart = new List<TimePicker> { start1, startMondayTime, startTuesdayTime, startWednesdayTime, startThursdayTime, startFridayTime };
            timeEnd = new List<TimePicker> { end1, endMondayTime, endTuesdayTime, endWednesdayTime, endThursdayTime, endFridayTime };
            check = new List<CheckBox> { sundayCheckBox, mondayCheckBox, tuesdayCheckBox, wednesdayCheckBox, thursdayCheckBox, fridayCheckBox };
            List<string> lst = new List<string>
            {
                "Mother",
                "Child",
                "Nanny"
            };
            select_item_combobox.ItemsSource = lst;
            //var mothers = from item in bl.getListMothers()
            //              select item.id;
            //select_mother_conbobox.ItemsSource = mothers;


        }


        private void select_item_combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            select_mother_conbobox.ItemsSource = null;
            select_child_conbobox.ItemsSource = null;
            select_nanny_conbobox.ItemsSource = null;
            if (select_item_combobox.SelectedItem==null)
            {
                Vizibilityes();
                all_stackpanels.Visibility = Visibility.Visible;
                return;
            }
            switch (select_item_combobox.SelectedItem.ToString())
            {
                case "Mother":
                    Vizibilityes();
                    all_stackpanels.Visibility = Visibility.Visible;
                    mother_stackpanel.Visibility = Visibility.Visible;
                    //var mothers = from item in bl.getListMothers()
                    //              select item.id;
                    select_mother_conbobox.ItemsSource = bl.getListMothers();
                    break;
                case "Child":
                    Vizibilityes();
                    all_stackpanels.Visibility = Visibility.Visible;
                    mother_stackpanel.Visibility = Visibility.Visible;
                    child_stackpanel.Visibility = Visibility.Visible;
                    //mothers = from item in bl.getListMothers()
                    //          select item.id;
                    select_mother_conbobox.ItemsSource = bl.getListMothers();
                    break;
                case "Nanny":
                    Vizibilityes();
                    all_stackpanels.Visibility = Visibility.Visible;
                    nanny_stackpanel.Visibility = Visibility.Visible;
                    select_nanny_conbobox.ItemsSource = bl.getListNannys();
                    break;
                default:
                    break;
            }
        }

        private void select_mother_conbobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (select_mother_conbobox.SelectedItem==null)
            {
                return;
            }
            try
            {
                mother = null;
                cleartimepicker(timeStart);
                cleartimepicker(timeEnd);


                if (select_mother_conbobox.ItemsSource != null)
                {
                    switch (select_item_combobox.SelectedItem.ToString())
                    {
                        case "Mother":
                            if (select_mother_conbobox.SelectedItem != null)
                            {
                                //mother = bl.getMother(int.Parse(select_mother_conbobox.SelectedItem.ToString()));
                                mother= select_mother_conbobox.SelectedItem as Mother;
                                mother_grid.DataContext = mother;


                                for (int i = 0; i < 6; i++)
                                {

                                    if (check[i].IsChecked == true)
                                    {
                                        timeStart[i].Value = DateTime.Parse(mother.arr[i].start.ToString());
                                        timeEnd[i].Value = DateTime.Parse(mother.arr[i].end.ToString());
                                    }

                                }

                                Vizibilityes();
                                all_stackpanels.Visibility = Visibility.Visible;
                                mother_stackpanel.Visibility = Visibility.Visible;
                                options_buttons.Visibility = Visibility.Visible;
                            }

                            break;
                        case "Child":
                     
                            select_child_conbobox.ItemsSource = null;
                            select_child_conbobox.ItemsSource = bl.getListChilds(select_mother_conbobox.SelectedItem as Mother);
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception exception)
            {
                System.Windows.MessageBox.Show(exception.Message);
                select_mother_conbobox.SelectedItem = null;
            }
        }

        private void select_nanny_conbobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            nanny = null;
            cleartimepicker(timeStart_n);
            cleartimepicker(timeEnd_n);
            if (select_nanny_conbobox.ItemsSource != null)
            {
                nanny = select_nanny_conbobox.SelectedItem as BE.Nanny;
                nanny_grid.DataContext = nanny;
                to_years.SelectedItem = nanny.age_child_max / 12;
                to_month.SelectedItem = nanny.age_child_max % 12;
                from_years.SelectedItem = nanny.age_child_min / 12;
                from_month.SelectedItem = nanny.age_child_min % 12;
                maxChildsComboBox.SelectedItem = nanny.maxChilds;
                years_of_experienceComboBox.SelectedItem = nanny.years_of_experience;
                for (int i = 0; i < 6; i++)
                {

                    if (check_n[i].IsChecked == true)
                    {
                        timeStart_n[i].Value = DateTime.Parse(nanny.work[i].start.ToString());
                        timeEnd_n[i].Value = DateTime.Parse(nanny.work[i].end.ToString());
                    }
                }
                Vizibilityes();
                all_stackpanels.Visibility = Visibility.Visible;
                nanny_stackpanel.Visibility = Visibility.Visible;
                options_buttons.Visibility = Visibility.Visible;
            }
        }
        private void cleartimepicker(List<TimePicker> lst)
        {
            foreach (var item in lst)
            {
                item.Value = null;
            }
        }
        private void select_child_conbobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            child = null;
            Vizibilityes();
            all_stackpanels.Visibility = Visibility.Visible;
            mother_stackpanel.Visibility = Visibility.Visible;
            child_stackpanel.Visibility = Visibility.Visible;
            if (select_child_conbobox.ItemsSource != null)
            {
                child = select_child_conbobox.SelectedItem as Child;
                child_grid.DataContext = child;

                options_buttons.Visibility = Visibility.Visible;


            }

        }

        private void press_to_update_Click(object sender, RoutedEventArgs e)
        {
            switch (select_item_combobox.SelectedItem.ToString())
            {
                case "Mother":
                    all_stackpanels.Visibility = Visibility.Collapsed;
                    details_mother_stackpanel.Visibility = Visibility.Visible;
                    first_grid_mother.Visibility = Visibility.Visible;
                    break;
                case "Child":
                    details_child_stackpanel.Visibility = Visibility.Visible;
                    mother_grid.Visibility = Visibility.Collapsed;
                    break;
                case "Nanny":
                    details_nanny_stackpanel.Visibility = Visibility.Visible;
                    //nanny_scroll.Visibility = Visibility.Visible;
                    first_grid_nanny.Visibility = Visibility.Visible;

                    str = new string[] { "1", "2", "3", "4", "5+ " };
                    years_of_experienceComboBox.ItemsSource = str;

                    for (int i = 0; i < 12; i++)
                    {
                        if (i < 4)
                        {
                            from_years.Items.Add(i);
                            to_years.Items.Add(i);
                        }
                        if (i < 11 && i > 4)
                            maxChildsComboBox.Items.Add(i);

                        from_month.Items.Add(i);
                        to_month.Items.Add(i);


                    }

                    break;
                default:
                    break;
            }
        }

        private void press_to_delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (select_item_combobox.SelectedItem.ToString())
                {
                    case "Mother":
                         
                        string a="";
                        foreach (var VARIABLE in bl.getListChilds(select_mother_conbobox.SelectedItem as Mother))
                        {
                            a += "id: " + VARIABLE.id + '\n';
                        }

                        
                        ////System.Windows.MessageBox message=new MessageBox();
                          System.Windows.MessageBox.Show("אתה עלול למחוק גם את הילדים האלה"+'\n'+a,"זהירות על מחיקת ילדים",MessageBoxButton.OKCancel,  MessageBoxImage.Warning);
                        

                        






                        bl.deleteMother((select_mother_conbobox.SelectedItem as Mother).id);
                        System.Windows.MessageBox.Show(mother.id.ToString(), "This mother has been deleted");
                        this.Close();
                        break;
                    case "Child":
                        bl.deleteChild((select_child_conbobox.SelectedItem as Child).id);
                        System.Windows.MessageBox.Show(child.id.ToString(), "This child has been deleted");
                        this.Close();
                        break;
                    case "Nanny":
                        bl.deleteNanny(nanny.id);
                        System.Windows.MessageBox.Show(nanny.id.ToString(), "This nanny has been deleted");
                        this.Close();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception exception)
            {

                System.Windows.MessageBox.Show(exception.Message);
                this.Close();
            }
            
        }


       
        private void Vizibilityes()
        {
            all_stackpanels.Visibility = Visibility.Collapsed;
            mother_stackpanel.Visibility = Visibility.Collapsed;
            child_stackpanel.Visibility = Visibility.Collapsed;
            nanny_stackpanel.Visibility = Visibility.Collapsed;
            options_buttons.Visibility = Visibility.Collapsed;

            details_mother_stackpanel.Visibility = Visibility.Collapsed;
            details_nanny_stackpanel.Visibility = Visibility.Collapsed;
            details_child_stackpanel.Visibility = Visibility.Collapsed;
            first_grid_mother.Visibility = Visibility.Collapsed;
            second_grid_mother.Visibility = Visibility.Collapsed;
            first_grid_nanny.Visibility = Visibility.Collapsed;
            second_grid_nanny.Visibility = Visibility.Collapsed;
        }
        private void update_mother_button_Click(object sender, RoutedEventArgs e)
        {
            
            for (int i = 0; i < 6; i++)
            {
                if (check[i].IsChecked == true && (timeStart[i].Value == null || timeEnd[i].Value == null))
                {
                    errorMessegHours.Visibility = Visibility.Visible;
                    return;
                }
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
            if (mother.Addres == mother.SearchAddres && mother.SearchAddres != searchAddresTextBox.Text.ToString())
            {
                searchAddresTextBox.Text = addresTextBox.Text;
            }
            idTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            firstNameTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            lastNameTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            addresTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            phoneNumberTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            searchAddresTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            elevatorsCheckBox.GetBindingExpression(CheckBox.IsCheckedProperty).UpdateSource();
            for (int j = 0; j < 6; j++)
            {
                check[j].GetBindingExpression(CheckBox.IsCheckedProperty).UpdateSource();
            }
            bl.updateMother(mother);
            System.Windows.MessageBox.Show("ID: "+mother.id.ToString(), "This mother has been updated",MessageBoxButton.OK,MessageBoxImage.Information);
            select_item_combobox.SelectedItem = null;
            //this.Close();
        }

        private void next_mother_Click(object sender, RoutedEventArgs e)
        {
            first_grid_mother.Visibility = Visibility.Collapsed;
            second_grid_mother.Visibility = Visibility.Visible;
        }

        private void update_child_button_Click(object sender, RoutedEventArgs e)
        {
            idTextBox_c.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            idTextBoxMother.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            birthDayDatePicker.GetBindingExpression(DatePicker.SelectedDateProperty).UpdateSource();
            firstNameTextBox_c.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            specialNeedsCheckBox.GetBindingExpression(CheckBox.IsCheckedProperty).UpdateSource();
            detailsSpecialNeedsTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            bl.updateChild(child);
            System.Windows.MessageBox.Show("ID: "+ child.id.ToString(), "This child has been updated", MessageBoxButton.OK, MessageBoxImage.Information);
            select_item_combobox.SelectedItem = null;
            //this.Close();
        }



        private void next_nanny_Click(object sender, RoutedEventArgs e)
        {
            first_grid_nanny.Visibility = Visibility.Collapsed;
            second_grid_nanny.Visibility = Visibility.Visible;
        }

        private void back_button_nanny_Click(object sender, RoutedEventArgs e)
        {
            first_grid_nanny.Visibility = Visibility.Visible;
            second_grid_nanny.Visibility = Visibility.Collapsed;
        }

        private void update_nanny_button_Click(object sender, RoutedEventArgs e)
        {

            for (int i = 0; i < 6; i++)
            {
                if (check_n[i].IsChecked == true && (timeStart_n[i].Value == null || timeEnd_n[i].Value == null))
                {
                    errorMessegHours1.Visibility = Visibility.Visible;
                    return;
                }
                if (check_n[i].IsChecked == true && timeStart_n[i].Value.Value.TimeOfDay > timeEnd_n[i].Value.Value.TimeOfDay)
                {
                    errorMessegTime2.Visibility = Visibility.Visible;
                    return;
                }
                if (check_n[i].IsChecked == true)
                {
                    nanny.work[i].start = timeStart_n[i].Value.Value.TimeOfDay;
                    nanny.work[i].end = timeEnd_n[i].Value.Value.TimeOfDay;
                }
            }



            idTextBox_n.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            firstNameTextBox_n.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            lastNameTextBox_n.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            addresTextBox_n.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            phoneNumberTextBox_n.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            floorTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            birthDayDatePicker_n.GetBindingExpression(DatePicker.SelectedDateProperty).UpdateSource();

            elevatorsCheckBox_n.GetBindingExpression(CheckBox.IsCheckedProperty).UpdateSource();
            //maxChildsComboBox.GetBindingExpression(ComboBox.TextProperty).UpdateSource();
            // years_of_experienceComboBox.GetBindingExpression(ComboBox.TextProperty).UpdateSource();
           // recommendationTextBox1.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            per_hour_ableCheckBox1.GetBindingExpression(CheckBox.IsCheckedProperty).UpdateSource();
            salaryPerHourTextBox1.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            salaryPerMonthTextBox1.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            vacation_kindCheckBox1.GetBindingExpression(CheckBox.IsCheckedProperty).UpdateSource();

            //maxChildsComboBox.GetBindingExpression(ComboBox.TextProperty).UpdateSource(); SelectedItem="{Binding maxChilds}"
            //years_of_experienceComboBox.GetBindingExpression(ComboBox.TextProperty).UpdateSource();SelectedItem="{Binding years_of_experience}"
           // recommendationTextBox1.GetBindingExpression(TextBox.TextProperty).UpdateSource();

            for (int j = 0; j < 6; j++)
            {
                check_n[j].GetBindingExpression(CheckBox.IsCheckedProperty).UpdateSource();
            }

            nanny.age_child_min = int.Parse(from_years.SelectedItem.ToString()) * 12 + int.Parse(from_month.SelectedItem.ToString());
            nanny.age_child_max = int.Parse(to_years.SelectedItem.ToString()) * 12 + int.Parse(to_month.SelectedItem.ToString());
            nanny.years_of_experience = years_of_experienceComboBox.SelectedItem.ToString();
            nanny.maxChilds = int.Parse(maxChildsComboBox.SelectedItem.ToString());

            bl.updateNanny(nanny);
            System.Windows.MessageBox.Show("ID: " + nanny.id.ToString(), "This nanny has been updated", MessageBoxButton.OK, MessageBoxImage.Information);
            select_item_combobox.SelectedItem = null;
            //this.Close();

        }

        private void Years_MouseEnter(object sender, MouseEventArgs e)
        {
            ComboBox com = sender as ComboBox;
            com.ToolTip = "choosze years";
        }

        private void month_MouseEnter(object sender, MouseEventArgs e)
        {
            ComboBox com = sender as ComboBox;
            com.ToolTip = "choose months";

        }












        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>








        //private void SizeStart1(object sender, SizeChangedEventArgs e)
        //{
        //    errorMessegHours.Visibility = Visibility.Collapsed;
        //}



        private void textChange(object sender, TextChangedEventArgs e)
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



        private void textChange1(object sender, TextChangedEventArgs e)
        {
            errorMesseg4.Visibility = Visibility.Collapsed;
            errorMesseg5.Visibility = Visibility.Collapsed;
            errorMesseg6.Visibility = Visibility.Collapsed;


            long x;
            if (!long.TryParse(idTextBoxMother.Text, out x) && idTextBoxMother.Text != "")
            {

                errorMesseg4.Visibility = Visibility.Visible;

                return;
            }
            if (idTextBoxMother.Text != "" && long.Parse(idTextBoxMother.Text) < 0)
            {
                errorMesseg6.Visibility = Visibility.Visible;
            }


        }

        private void textChnge2(object sender, TextChangedEventArgs e)
        {
            errorMesseg7.Visibility = Visibility.Collapsed;
            long x;
            if (long.TryParse(firstNameTextBox.Text, out x))
            {
                errorMesseg7.Visibility = Visibility.Visible;
            }
        }








        //private void add_nanny_button_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {





        //        List<TimePicker> timeStart = new List<TimePicker>() { start1, startMondayTime, startTuesdayTime, startWednesdayTime, startThursdayTime, startFridayTime };
        //        List<TimePicker> timeEnd = new List<TimePicker>() { end1, endMondayTime, endTuesdayTime, endWednesdayTime, endThursdayTime, endFridayTime };
        //        List<CheckBox> check = new List<CheckBox>() { sundayCheckBox, mondayCheckBox, tuesdayCheckBox, wednesdayCheckBox, thursdayCheckBox, fridayCheckBox };
        //        for (int i = 0; i < 6; i++)
        //        {
        //            //if (check[i].IsChecked == true && (timeStart[i].Value == null || timeEnd[i].Value == null))
        //            //{
        //            //errorMessegHours.Visibility = Visibility.Visible;
        //            //return;
        //            //}
        //            //if (check[i].IsChecked == true && timeStart[i].Value.Value.TimeOfDay > timeEnd[i].Value.Value.TimeOfDay)
        //            //{
        //            //errorMessegTime.Visibility = Visibility.Visible;
        //            //return;
        //            //}
        //            if (check[i].IsChecked == true)
        //            {
        //                nanny.work[i].start = timeStart[i].Value.Value.TimeOfDay;
        //                nanny.work[i].end = timeStart[i].Value.Value.TimeOfDay;
        //            }
        //        }

        //        bl.addNanny(nanny);
        //        second_grid_nanny.Visibility = Visibility.Collapsed;


        //        // this.Close();


        //    }
        //    catch (Exception a)
        //    {

        //        System.Windows.MessageBox.Show(a.Message);
        //    }

        //}

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

        private void sizeChanged(object sender, SizeChangedEventArgs e)
        {
            TimePicker time = sender as TimePicker;
            errorMessegHours.Visibility = Visibility.Collapsed;
            errorMessegHours1.Visibility = Visibility.Collapsed;
        }
    }
}


