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
using BE;
using BL;
using Exception = System.Exception;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BL.IBL bl;

        public MainWindow()
        {
            InitializeComponent();
            bl = BL.FactoryBl.getBl();


            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
           init();
         
        }

        void init()
        {
            Mother a1 = new Mother();
            a1.id = 123456789;
            a1.FirstName = "sara";
            a1.LastName = "cohen";
            a1.PhoneNumber = "0504145678";
            a1.Addres = "קאסוטו 24 ירושלים ישראל";
            a1.arr[1].day_work = true;
            a1.arr[1].start = TimeSpan.Parse("09:30");
            a1.arr[1].end = TimeSpan.Parse("10:30");
            try
            {
                bl.addMother(a1);
            }
            catch 
            {
              bl.updateMother(a1);
            }
            Mother a2 = new Mother
            {
                id = 111111111,
                FirstName = "efrat",
                LastName = "amzaleg",
                PhoneNumber = "0506134678",
                Addres = "יחזקאל 28 ירושלים ישראל",
                elevators = true,
            };

            for (int i = 0; i < 6; i++)
            {
                a2.arr[i].day_work = true;
                a2.arr[i].start = TimeSpan.Parse("15:30");
                a2.arr[i].end = TimeSpan.Parse("19:30");
            }
            try
            {
                bl.addMother(a2);
            }
            catch
            {
                bl.updateMother(a2);
            }

            Child a3 = new Child();
            a3.id = 999999999;
            a3.MotherID = 111111111;
            a3.birthDay = DateTime.Parse("12.01.2000");
            a3.FirstName = "simen";
            try
            {
                bl.addChild(a3);
            }
            catch
            {
                bl.updateChild(a3);
            }
            Child a4 = new Child();

            a4.id = 888888888;
            a4.MotherID = 111111111;
            a4.birthDay = DateTime.Parse("14.02.2011");
            a4.FirstName = "reoven";
            try
            {
                bl.addChild(a4);
            }
            catch
            {
                bl.updateChild(a4);
            }
            Child a5 = new Child();
            a5.id = 777777777;
            a5.MotherID = 123456789;
            a5.birthDay = DateTime.Parse("26.07.2000");
            a5.FirstName = "levy";
            try
            {
                bl.addChild(a5);
            }
            catch
            {
                bl.updateChild(a5);
            }
            Child a6 = new Child();
            a6.id = 666666666;
            a6.MotherID = 123456789;
            a6.birthDay = DateTime.Parse("23.02.2014");
            a6.FirstName = "gaya";
            try
            {
                bl.addChild(a6);
            }
            catch
            {
                bl.updateChild(a6);
            }

            Nanny a7 = new Nanny();
            a7.FirstName = "orit";
            a7.LastName = "cakz";
            a7.id = 123123123;
            a7.maxChilds = 3;
            a7.per_hour_able = true;
            a7.salaryPerHour = 34;
            a7.work[3].day_work = true;
            a7.work[3].start = TimeSpan.Parse("06:30");
            a7.work[3].end = TimeSpan.Parse("08:30");
            a7.addres = "קוממיות 10 קריית גת ישראל";
            a7.age_child_min = 10;
            a7.age_child_max = 15;
            a7.floor = 9;
            a7.birthDay = DateTime.Parse("15.03.1999");
            try
            {
                bl.addNanny(a7);
            }
            catch
            {
                bl.updateNanny(a7);
            }
            Nanny a8 = new Nanny
            {
                FirstName = "chya",
                LastName = "cakz",
                id = 151515151,
                maxChilds = 5,
                per_hour_able = false,
                salaryPerMonth = 4000,
                PhoneNumber = "527129013",
                floor = 10,
                addres = "אוהב ישראל 3 ביתר עילית ישראל",
                age_child_min = 12,
                age_child_max = 15,
                birthDay = DateTime.Parse("15.03.1999"),
                elevators = true,
                recommendation = "very nice nanny",
                vacation_kind = true,
                years_of_experience = "8",
                
            };
            for (int i = 0; i < 6; i++)
            {

                a8.work[i].day_work = true;
                a8.work[i].start = TimeSpan.Parse("00:00");
                a8.work[i].end = TimeSpan.Parse("23:00");
            }
            try
            {
                bl.addNanny(a8);
            }
            catch
            {
                bl.updateNanny(a8);
            }

            Nanny a9 = new Nanny();
            a9.FirstName = "leah";
            a9.LastName = "cakz";
            a9.id = 125837412;
            a9.maxChilds = 5;
            a9.per_hour_able = false;
            a9.salaryPerMonth = 4000;
            for (int i = 0; i < 6; i++)
            {

                a9.work[i].day_work = true;
                a9.work[i].start = TimeSpan.Parse("4:30");
                a9.work[i].end = TimeSpan.Parse("12:30");
            }

            a9.addres = "אילת ישראל";
            a9.age_child_min = 12;
            a9.age_child_max = 15;
            a9.birthDay = DateTime.Parse("15.03.1999");
            a9.floor = 8;

            try
            {
                bl.addNanny(a9);
            }
            catch
            {
                bl.updateNanny(a9);
            }

            Nanny a10 = new Nanny();
            a10.FirstName = "rivka";
            a10.LastName = "cakz";
            a10.id = 125837411;
            a10.maxChilds = 7;
            a10.per_hour_able = false;
            a10.salaryPerMonth = 4000;
            for (int i = 0; i < 6; i++)
            {

                a10.work[i].day_work = true;
                a10.work[i].start = TimeSpan.Parse("4:30");
                a10.work[i].end = TimeSpan.Parse("12:30");
            }
            a10.addres = "אילת ישראל";
            a10.age_child_min = 1;
            a10.age_child_max = 10;
            a10.birthDay = DateTime.Parse("15.03.1999");
            a10.floor = 7;
            try
            {
                bl.addNanny(a10);
            }
            catch
            {
                bl.updateNanny(a10);
            }
            Nanny a11 = new Nanny();
            a11.FirstName = "ester";
            a11.LastName = "cakz";
            a11.id = 125837415;
            a11.maxChilds = 5;
            a11.per_hour_able = false;
            a11.salaryPerMonth = 4000;
            a11.floor = 8;
            for (int i = 0; i < 6; i++)
            {

                a11.work[i].day_work = true;
                a11.work[i].start = TimeSpan.Parse("4:30");
                a11.work[i].end = TimeSpan.Parse("9:30");
            }

            a11.addres = "אילת ישראל";
            a11.age_child_min = 12;
            a11.age_child_max = 15;
            a11.birthDay = DateTime.Parse("15.03.1999");
            try
            {
                bl.addNanny(a11);
            }
            catch
            {
                bl.updateNanny(a11);
            }
        }
        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void add_button_Click(object sender, RoutedEventArgs e)
        {
            buttons_to_add.Visibility = Visibility.Visible;
        }
        /// <summary>
        /// An event for update all items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void update_button_Click(object sender, RoutedEventArgs e)
        {
            buttons_to_add.Visibility = Visibility.Hidden;

            Window w = new update();
            w.Show();
        }
        /// <summary>
        /// An event for grouping
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grooping_button_Click(object sender, RoutedEventArgs e)
        {
            buttons_to_add.Visibility = Visibility.Hidden;
            Window w = new GroopingWindow();
            w.Show();
        }
        /// <summary>
        /// An event for find nanny
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void find_nanny_button_Click(object sender, RoutedEventArgs e)
        {
            buttons_to_add.Visibility = Visibility.Hidden;
            Window w = new search_nanny();
            w.Show();
        }



        private void MouseEnter(object sender, MouseEventArgs e)
        {
            buttons_to_add.Visibility = Visibility.Hidden;

        }


    }
}