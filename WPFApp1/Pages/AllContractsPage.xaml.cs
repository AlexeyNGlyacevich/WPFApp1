using System.Windows.Controls;
using System.Windows.Data;
using WPFApp1.Model.AppDBcontext;

namespace WPFApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для AllContractsPage.xaml
    /// </summary>
    public partial class AllContractsPage : Page
    {
        public AllContractsPage()
        {
            InitializeComponent();
        }

        private void ContractCollection_Filter(object sender, FilterEventArgs e)
        {
            if (!(e.Item is Contracts contract)) return;

            var filteredText = ContractFilteredText.Text;
            if (filteredText.Length == 0) return;

            //if (!string.IsNullOrEmpty(contract.Object_name) && contract.Object_name.Contains(filteredText)) return;
            //if (!string.IsNullOrEmpty(contract.Note) && contract.Note.Contains(filteredText)) return;
            if (!string.IsNullOrEmpty(contract.Contract_Number) && contract.Contract_Number.ToString().Contains(filteredText)) return;
            e.Accepted = false;
        }

        private void ContractFilteredText_TextChanged(object sender, TextChangedEventArgs e)
        {
            var collection = (CollectionViewSource)GridRow2.FindResource("ContracsCollection");
            collection.View.Refresh();
        }
    }
}
