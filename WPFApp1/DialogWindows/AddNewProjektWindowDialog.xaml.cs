using System.Linq;
using System.Windows;
using System.Windows.Input;
using WPFApp1.Model.AppDBcontext;

namespace WPFApp1.DialogWindows
{
    /// <summary>
    /// Логика взаимодействия для AddNewProjektWindowDialog.xaml
    /// </summary>
    public partial class AddNewProjektWindowDialog : Window
    {
        public AddNewProjektWindowDialog()
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
