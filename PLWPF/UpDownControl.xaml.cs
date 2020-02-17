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
    /// Interaction logic for UpDownControl.xaml
    /// </summary>
    public partial class UpDownControl : UserControl
    {
        private int num=5;
        public int Value
        {
            get { return num; }
            set
            {
                if (value > MaxValue)
                    num = MaxValue;
                else if (value < MinValue)
                    num = MinValue;
                else
                    num = value;
                textNumber.Text = num.ToString();
            }
        }

        

        public string MyText
        {
            get { return (string)GetValue(MyTextProperty); }
            set { SetValue(MyTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyTextProperty =
            DependencyProperty.Register("MyText", typeof(string), typeof(UpDownControl), new PropertyMetadata(null));


        /// <summary>
        /// initialize the values max and min
        /// </summary>
        public UpDownControl()
        {
            InitializeComponent();
            MaxValue = 12;
            MinValue = -5;
        }

        public int MaxValue { set; get; }
        public int MinValue { set; get; }

        /// <summary>
        /// event of changes in the text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNum_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (textNumber == null || textNumber.Text == "" || textNumber.Text == "-")
            {

                textNumber.Text = "";
                return;
            }

        }

        /// <summary>
        /// button for up the value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdUp_Click(object sender, RoutedEventArgs e)
        {
            Value++;
        }

        /// <summary>
        /// button for down the value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
   

        private void cmdDown_Click(object sender, RoutedEventArgs e)
        {
            Value--;

        }
    }

}

