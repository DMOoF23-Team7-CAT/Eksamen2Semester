using KlatreKongen.Model.Base;
using KlatreKongen.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            Customer selectedCustomer = dg_Overview.SelectedItem as Customer;
            if (selectedCustomer != null)
            {
                overviewVM.RemoveCustomer(selectedCustomer.Id);
            }
        }

/*        private void tb_SearchBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.Foreground = Brushes.White;
            tb.GotFocus -= tb_SearchBox_GotFocus;
        }

        private void tb_SearchBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;
            if (box.Text.Trim().Equals(string.Empty))
            {
                box.Text = "Indtast navn...";
                box.Foreground = Brushes.White;
                box.GotFocus += tb_SearchBox_GotFocus;
            }
        }*/

        private void tb_SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(dg_Overview.ItemsSource);

            if (view is not null && view.SourceCollection is DataView dataView)
            {
                dataView.RowFilter = $"CustomerName LIKE '%{tb_SearchBox.Text}%'";
            }
        }

/*        private void dg_Overview_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dg_Overview.SelectedItem != null)
            {
                overviewVM.SelectedObject = dg_Overview.SelectedItem;
            }
        }*/
    }
}


