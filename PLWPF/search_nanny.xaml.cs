using System;
using System.Collections.Generic;
using System.IO;
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
using System.Threading;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for search_nanny.xaml
    /// </summary>
    public partial class search_nanny : Window
    {
        BL.IBL bl;
       // private BL.Bl_imp bll;
        private Mother _selectedMother;
        private Child _selectedChild;
        private Nanny _selectedNanny;
        private Contract _selectedContract;
        public search_nanny()
        {
            bl = FactoryBl.getBl();
            //bll = new Bl_imp();
            
            _selectedMother = new Mother();
            _selectedChild = new Child();
            _selectedNanny = new Nanny();
            _selectedContract = new Contract();
            InitializeComponent();
            select_mother_combobox.ItemsSource = bl.getListMothers();
            //  nannyDataGrid.ItemsSource = bl.getListNannys();
        }

        private void select_mother_combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (select_mother_combobox.SelectedItem == null)
            {
               return; 
            }
            try
            {
                Vizibilityes();
                mother_child_stackpanel.Visibility = Visibility.Visible;
                _selectedMother = select_mother_combobox.SelectedItem as Mother;
                select_child_combobox.ItemsSource = bl.getListChilds(select_mother_combobox.SelectedItem as Mother);
                Constraints_grid.DataContext = select_mother_combobox.SelectedItem as Mother;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                select_mother_combobox.SelectedItem = null;

            }
        }

        private void select_child_combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Vizibilityes();
            mother_child_stackpanel.Visibility = Visibility.Visible;
            _selectedChild = select_child_combobox.SelectedItem as Child;
        }

        private void select_mothr_and_child_button_Click(object sender, RoutedEventArgs e)
        {
            Constraints_grid.Visibility = Visibility.Visible;
        }



        private void search_nannys_button_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                int floor = int.Parse(floor_textbox.Text);
                int max = (int)coomoBoxMaxChild.SelectedIndex+5;
                List<Nanny> findNannies = new List<Nanny>();
                search_nannys_button.IsEnabled = false;
                Vizibilityes();
                loading.Visibility = Visibility.Visible;
                new Thread(() =>
                {

                    // findNannies = bll.rangeNanny(mother.id).ToList();
                    try
                    {
                        findNannies = AllReq(_selectedMother, floor, max, _selectedChild);

                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                    
                    Dispatcher.Invoke(new Action(() =>
                    {
                        if (findNannies.Count == 0)
                        {
                            MessageBox.Show("No nannys was found by the data", "", MessageBoxButton.OK, MessageBoxImage.Information);
                            Vizibilityes();
                            mother_child_stackpanel.Visibility = Visibility.Visible;
                            search_nannys_button.IsEnabled = true;
                            return;
                        }
                        nannyDataGrid.ItemsSource = findNannies;
                        search_nannys_button.IsEnabled = true;
                        mother_child_stackpanel.Visibility = Visibility.Visible;
                        Constraints_grid.Visibility = Visibility.Visible;
                        nannys_StackPanel.Visibility = Visibility.Visible;
                        select_nanny_button.Visibility = Visibility.Visible;
                        loading.Visibility = Visibility.Collapsed;
                       
                    }));
                }).Start();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        List<Nanny> AllReq(Mother mother, int floor, int max, Child child)
        {

            List<Nanny> nanny2 = new List<Nanny>();
            List<Nanny> nanny = new List<Nanny>();
            List<Nanny> nanny1 = new List<Nanny>();

            nanny = bl.RangeNanny(mother.id).ToList();
            nanny1 = bl.RequiredMother(mother).ToList();
            if (nanny.Count != 0 && nanny1.Count != 0)
            {
                foreach (var item1 in nanny)
                {
                    foreach (var item2 in nanny1)
                    {
                        if (item1.id == item2.id)
                        {
                            nanny2.Add(item1);
                            //break;
                        }
                    }
                }
                if (nanny2.Count != 0)
                {
                    nanny2 = nanny2.FindAll(item => (item.floor <= floor)
                    && item.maxChilds <= max

                    );
                }
            }
            return nanny2;

            //&& ((child.birthDay < DateTime.Now.AddMonths(-item.age_child_min) && child.birthDay > DateTime.Now.AddMonths(-item.age_child_max)))

        }






        private void nannyDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            select_nanny_button.IsEnabled = true;
            _selectedNanny = nannyDataGrid.SelectedItem as Nanny;
        }

        private void select_nanny_button_Click(object sender, RoutedEventArgs e)
        {
            _selectedContract.MotherID = _selectedMother.id;
            _selectedContract.childID = _selectedChild.id;
            _selectedContract.NannyID = _selectedNanny.id;
            _selectedContract.ContracPer = _selectedNanny.per_hour_able;
            _selectedContract.salaryPerHour = _selectedNanny.salaryPerHour;
            _selectedContract.salaryPerMonth = _selectedNanny.salaryPerMonth;
            add_contruct_grid.DataContext = _selectedContract;
            add_contruct_grid.Visibility = Visibility.Visible;
        }
        private void add_contract_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime d1 = DateTime.Parse(startDateDatePicker.Text.ToString());
                DateTime d2 = DateTime.Parse(endDateDatePicker.Text.ToString());
                if (d2.Subtract(d1).TotalDays < 30)
                    throw new Exception("The contract must be at least for a month");
                bl.addContract(_selectedContract);
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

                bl.addContract(_selectedContract);
                MessageBox.Show(bl.getListContracts().LastOrDefault().totalSalary.ToString(), "סך הכל עלות:");
                bl.deleteContract(bl.getListContracts().LastOrDefault().num_contract);
            }
            catch (Exception x)
            {

                MessageBox.Show(x.Message);
            }

        }



        private void Vizibilityes()
        {
            mother_child_stackpanel.Visibility = Visibility.Collapsed;
            Constraints_grid.Visibility = Visibility.Collapsed;
            nannys_StackPanel.Visibility = Visibility.Collapsed;
            add_contruct_grid.Visibility = Visibility.Collapsed;
            select_nanny_button.Visibility = Visibility.Collapsed;
            loading.Visibility = Visibility.Collapsed;
        }
    }
}
