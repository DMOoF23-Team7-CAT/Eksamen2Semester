using KlatreKongen.MVVM.ViewModel;
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

namespace KlatreKongen.MVVM.View
{
    /// <summary>
    /// Interaction logic for OverviewView.xaml
    /// </summary>
    public partial class OverviewView : UserControl
    {
        private OverviewViewModel ovm = new OverviewViewModel ();
        public OverviewView()
        {
            DataContext= ovm;
            InitializeComponent();
        }

        private void bt_Update_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bt_Delete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
