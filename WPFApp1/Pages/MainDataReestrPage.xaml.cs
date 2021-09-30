using System;
using System.Windows.Controls;
using System.Windows.Data;
using WPFApp1.Model.AppDBcontext;

namespace WPFApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainDataReestrPage.xaml
    /// </summary>
    public partial class MainDataReestrPage : Page
    {
        public MainDataReestrPage()
        {
            InitializeComponent();
        }

        private void ProjektFilteredText_TextChanged(object sender, TextChangedEventArgs e)
        {
            var collection = (CollectionViewSource)GridRow3.FindResource("ProjektCollection");
            collection.View.Refresh();
        }

        private void ProjektCollection_Filter(object sender, FilterEventArgs e)
        {
            if (!(e.Item is Main_Reestr reestr)) return;

            var filteredText = ProjektFilteredText.Text;
            if (filteredText.Length == 0) return;

            if (!string.IsNullOrEmpty(reestr.Object_name) && reestr.Object_name.IndexOf(filteredText, StringComparison.OrdinalIgnoreCase) >= 0) return;
            if (!string.IsNullOrEmpty(reestr.project_type) && reestr.project_type.IndexOf(filteredText, StringComparison.OrdinalIgnoreCase) >= 0) return;
            if (!string.IsNullOrEmpty(reestr.Customers.Customer_Name) && reestr.Customers.Customer_Name.IndexOf(filteredText, StringComparison.OrdinalIgnoreCase) >= 0) return;
            e.Accepted = false;
        }
    }
}
