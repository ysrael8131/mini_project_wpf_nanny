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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for buttons_to_add.xaml
    /// </summary>
    public partial class buttons_to_add : UserControl
    {
        public buttons_to_add()
        {
            InitializeComponent();
        }

        private void mother_Click(object sender, RoutedEventArgs e)
        {
            add_mother addMother=new add_mother();
            addMother.ShowDialog();
        }

        private void child_Click(object sender, RoutedEventArgs e)
        {
            add_child addChild=new add_child();
            addChild.ShowDialog();
        }

        private void nanny_Click(object sender, RoutedEventArgs e)
        {
            AddNanny addNanny=new AddNanny();
            addNanny.ShowDialog();
        }

        private void contract_Click(object sender, RoutedEventArgs e)
        {
            add_contruct addContruct = new add_contruct();
            addContruct.ShowDialog();
        }
    }
}
