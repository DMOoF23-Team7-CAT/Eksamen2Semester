using KlatreKongen.Model.Base;
using KlatreKongen.ViewModel;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Diagnostics;
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

namespace KlatreKongen.View
{
    /// <summary>
    /// Interaction logic for OverviewView.xaml
    /// </summary>
    public partial class OverviewView : UserControl
    {
        OverviewViewModel overviewVM;
        
       
        public OverviewView()
        {
            overviewVM = new OverviewViewModel();
            InitializeComponent();

        }

        private void bt_Update_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bt_Delete_Click(object sender, RoutedEventArgs e)
        {
            DataGrid dg = this.dg_Overview;

            // Check if an item is selected in the DataGrid
            if (dg.SelectedItem != null)
            {                
                var id = (DataRowView)dg.SelectedItem;
                var PK_ID = Convert.ToInt32(id.Row["CustomerId"].ToString());

                // With the customer ID, we can now delete the customer
                overviewVM.RemoveCustomer(PK_ID);
            }
            else
            {
                // Handle the case where no item is selected
                MessageBox.Show("Please select a customer to delete.");
            }

            //Can't get it to refresh the DataGrid tho
            dg_Overview.Items.Refresh();

        }


        //Customer selectedCustomer = dg_Overview.SelectedItem as Customer;
        //if (selectedCustomer != null)
        //{
        //    overviewVM.RemoveCustomer(selectedCustomer.Id);
        //}


        private void tb_SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(dg_Overview.ItemsSource);

            if (view is not null && view.SourceCollection is DataView dataView)
            {
                dataView.RowFilter = $"CustomerName LIKE '%{tb_SearchBox.Text}%'";
            }
        }
    }
}


