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
using BL;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for add_contruct.xaml
    /// </summary>
    public partial class add_contruct : Window
    {
        private BL.IBL bl;
        private Mother mother;
        private Nanny nanny;
        private Child child;
        private Contract contract;
        public add_contruct()
        {
            bl = BL.FactoryBl.getBl();
            mother = new Mother();
            nanny = new Nanny();
            child = new Child();
            contract = new Contract();
            InitializeComponent();
            mom_child_nan_stackpanel.Visibility = Visibility.Visible;
            select_mother_conbobox.ItemsSource = bl.getListMothers();
            select_nanny_conbobox.ItemsSource = bl.getListNannys();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            // System.Windows.Data.CollectionViewSource contractViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("contractViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // contractViewSource.Source = [generic data source]
        }

        private void select_mother_conbobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (select_mother_conbobox.SelectedItem == null)
            {
                return;
            }
            try
            {
                select_child_conbobox.ItemsSource = null;
                select_child_conbobox.ItemsSource = bl.getListChilds(select_mother_conbobox.SelectedItem as Mother);
                mother = select_mother_conbobox.SelectedItem as Mother;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                select_mother_conbobox.SelectedItem = null;
            }

        }

        private void select_nanny_conbobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        nanny=select_nanny_conbobox.SelectedItem as Nanny;
       
             
        }

        private void select_child_conbobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           child= select_child_conbobox.SelectedItem as Child;
        }

        private void select_button_Click(object sender, RoutedEventArgs e)
        {
            contract.MotherID = mother.id;
            contract.childID = child.id;
            contract.NannyID = nanny.id;
            contract.ContracPer = nanny.per_hour_able;
            contract.salaryPerHour = nanny.salaryPerHour;
            contract.salaryPerMonth = nanny.salaryPerMonth;

            contract_grid.DataContext = contract;
            contract_grid.Visibility = Visibility.Visible;
            mom_child_nan_stackpanel.Visibility = Visibility.Hidden;
        }

        private void add_contract_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime d1 = DateTime.Parse(startDatePicker.Text.ToString());
                DateTime d2 = DateTime.Parse(endDatePicker.Text.ToString());
                if (d2.Subtract(d1).TotalDays < 30)
                    throw new Exception("The contract must be at least for a month");
                bl.addContract(contract);
                MessageBox.Show(bl.getListContracts().LastOrDefault().ToString(), "This contract has been added:");
                this.Close();
            }
            catch (Exception x)
            {

                MessageBox.Show(x.Message);
            }
        }

        private void payment_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                bl.addContract(contract);
                MessageBox.Show(bl.getListContracts().LastOrDefault().totalSalary.ToString(), "סך הכל עלות:");
                bl.deleteContract(bl.getListContracts().LastOrDefault().num_contract);
            }
            catch (Exception x)
            {

                MessageBox.Show(x.Message);
            }

        }
    }
}
