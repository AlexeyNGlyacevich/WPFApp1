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
using WPFApp1.Model.AppDBcontext;

namespace WPFApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для ObjectPage.xaml
    /// </summary>
    public partial class ObjectPage : Page
    {
        public ObjectPage()
        {
            InitializeComponent();
        }

        private void Cust_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tb = (TextBox)e.OriginalSource;
            if (tb.SelectionStart != 0)
            {
                Cust.SelectedItem = null; // Если набирается текст сбросить выбраный элемент
            }
            var collection = (CollectionViewSource)mGrid.FindResource("CustomerCollection");
            collection.View.Refresh();
        }

        private void CustomerCollection_Filter(object sender, FilterEventArgs e)
        {

            if (!(e.Item is Customers customer)) return;
            var filteredtext = Cust.Text;
            if (filteredtext.Length == 0) return;


            if (!string.IsNullOrEmpty(customer.Customer_Name) && customer.Customer_Name.IndexOf(filteredtext, StringComparison.OrdinalIgnoreCase) >= 0) return;
            e.Accepted = false;
        }



    }

}

