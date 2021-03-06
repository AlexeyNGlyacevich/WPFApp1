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
    /// Логика взаимодействия для AllTendersPage.xaml
    /// </summary>
    public partial class AllTendersPage : Page
    {
        public AllTendersPage()
        {
            InitializeComponent();
        }

        private void TendersCollection_Filter(object sender, FilterEventArgs e)
        {
            if (!(e.Item is Tenders tender)) return;

            var filteredText = TenderFilteredText.Text;
            if (filteredText.Length == 0) return;

            //if (!string.IsNullOrEmpty(contract.Object_name) && contract.Object_name.Contains(filteredText)) return;
            //if (!string.IsNullOrEmpty(contract.Note) && contract.Note.Contains(filteredText)) return;
            if (!string.IsNullOrEmpty(tender.Tender_number) && tender.Tender_number.Contains(filteredText)) return;
            e.Accepted = false;
        }

        private void TenderFilteredText_TextChanged(object sender, TextChangedEventArgs e)
        {
            var collection = (CollectionViewSource)GridRow2.FindResource("TendersCollection");
            collection.View.Refresh();
        }
    }
}
