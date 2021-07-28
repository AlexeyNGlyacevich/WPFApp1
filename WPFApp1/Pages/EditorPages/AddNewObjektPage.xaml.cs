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

namespace WPFApp1.Pages.EditorPages
{
    /// <summary>
    /// Логика взаимодействия для AddNewObjektPage.xaml
    /// </summary>
    public partial class AddNewObjektPage : Page
    {
        public AddNewObjektPage()
        {
            InitializeComponent();
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text == null || !e.Text.All(char.IsDigit))
            {
                e.Handled = true;
            }
        }
    }
}
