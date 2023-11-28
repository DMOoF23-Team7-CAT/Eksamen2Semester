using KlatreKongen.MVVM.ViewModel;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace KlatreKongen.MVVM.View
{
    /// <summary>
    /// Interaction logic for CustomerView.xaml
    /// </summary>
    public partial class CustomerView : UserControl
    {
        private CustomerViewModel cvm = new CustomerViewModel();
        public CustomerView()
        {
            DataContext = cvm;
            InitializeComponent();
            LoadGrid();
        }

        private void BorderYear_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (bb_YearMembership.BorderThickness == new Thickness(0, 0, 4, 4))
            {
                bb_YearMembership.BorderThickness = new Thickness(3, 3, 3, 3);
                bb_YearMembership.BorderBrush = new SolidColorBrush(Colors.Beige);

                bb_QuaterMembership.BorderThickness = new Thickness(0, 0, 4, 4);
                bb_QuaterMembership.BorderBrush = new SolidColorBrush(Colors.Gray);
                (bb_QuaterMembership.BorderBrush as SolidColorBrush).Opacity = 0.2;

                bb_MonthMembership.BorderThickness = new Thickness(0, 0, 4, 4);
                bb_MonthMembership.BorderBrush = new SolidColorBrush(Colors.Gray);
                (bb_MonthMembership.BorderBrush as SolidColorBrush).Opacity = 0.2;
            }
            else
            {
                bb_YearMembership.BorderThickness = new Thickness(0, 0, 4, 4);
                bb_YearMembership.BorderBrush = new SolidColorBrush(Colors.Gray);
                (bb_YearMembership.BorderBrush as SolidColorBrush).Opacity = 0.2;
            }
        }

        private void BorderQuarter_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (bb_QuaterMembership.BorderThickness == new Thickness(0, 0, 4, 4))
            {
                bb_QuaterMembership.BorderThickness = new Thickness(3, 3, 3, 3);
                bb_QuaterMembership.BorderBrush = new SolidColorBrush(Colors.Beige);

                bb_YearMembership.BorderThickness = new Thickness(0, 0, 4, 4);
                bb_YearMembership.BorderBrush = new SolidColorBrush(Colors.Gray);
                (bb_YearMembership.BorderBrush as SolidColorBrush).Opacity = 0.2;

                bb_MonthMembership.BorderThickness = new Thickness(0, 0, 4, 4);
                bb_MonthMembership.BorderBrush = new SolidColorBrush(Colors.Gray);
                (bb_MonthMembership.BorderBrush as SolidColorBrush).Opacity = 0.2;
            }
            else
            {
                bb_QuaterMembership.BorderThickness = new Thickness(0, 0, 4, 4);
                bb_QuaterMembership.BorderBrush = new SolidColorBrush(Colors.Gray);
                (bb_QuaterMembership.BorderBrush as SolidColorBrush).Opacity = 0.2;
            }
        }

        private void BorderMonth_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (bb_MonthMembership.BorderThickness == new Thickness(0, 0, 4, 4))
            {
                bb_MonthMembership.BorderThickness = new Thickness(3, 3, 3, 3);
                bb_MonthMembership.BorderBrush = new SolidColorBrush(Colors.Beige);

                bb_QuaterMembership.BorderThickness = new Thickness(0, 0, 4, 4);
                bb_QuaterMembership.BorderBrush = new SolidColorBrush(Colors.Gray);
                (bb_QuaterMembership.BorderBrush as SolidColorBrush).Opacity = 0.2;

                bb_YearMembership.BorderThickness = new Thickness(0, 0, 4, 4);
                bb_YearMembership.BorderBrush = new SolidColorBrush(Colors.Gray);
                (bb_YearMembership.BorderBrush as SolidColorBrush).Opacity = 0.2;
            }
            else
            {
                bb_MonthMembership.BorderThickness = new Thickness(0, 0, 4, 4);
                bb_MonthMembership.BorderBrush = new SolidColorBrush(Colors.Gray);
                (bb_MonthMembership.BorderBrush as SolidColorBrush).Opacity = 0.2;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button Clicked!");
        }


        //-----------------------------------------------------------------------TEST-----------------------------------------------------------------------------
        public async Task LoadGrid()
        {
            IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            string? ConnectionString = config.GetConnectionString("MyDBConnection");


            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("select * from Membership", con);

                con.Open();

                SqlDataReader sdr = cmd.ExecuteReader();
                await Task.Run(() => dt.Load(sdr));
            }
            dg_CustomerInputSummary.ItemsSource = dt.DefaultView;

        }
    }
}
