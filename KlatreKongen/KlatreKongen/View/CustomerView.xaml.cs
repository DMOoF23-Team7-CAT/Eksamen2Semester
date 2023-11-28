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
    public partial class CustomerView : UserControl/*, INotifyPropertyChanged*/
    {
        public CustomerView()
        {
            InitializeComponent();
            //LoadGrid();
            //IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        }

        private void BorderYear_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Border Clicked!");
        }
        private void BorderQuarter_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Border Clicked!");
        }

        private void BorderMonth_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Border Clicked!");
        }



        //public event PropertyChangedEventHandler? PropertyChanged;

        //private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}

        //public async Task LoadGrid()
        //{
        //    IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        //    string? ConnectionString = config.GetConnectionString("MyDBConnection");


        //    DataTable dt = new DataTable();
        //    using (SqlConnection con = new SqlConnection(ConnectionString))
        //    {
        //        SqlCommand cmd = new SqlCommand("select * from Customer", con);

        //        con.Open();

        //        SqlDataReader sdr = cmd.ExecuteReader();
        //        await Task.Run(() => dt.Load(sdr));
        //    }
        //    datagrid.ItemsSource = dt.DefaultView;

        //}
    }
}
