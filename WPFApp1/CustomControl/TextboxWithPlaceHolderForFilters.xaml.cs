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

namespace WPFApp1.CustomControl
{
    /// <summary>
    /// Логика взаимодействия для TextboxWithPlaceHolderForFilters.xaml
    /// </summary>
    public partial class TextboxWithPlaceHolderForFilters : UserControl
    {
        public TextboxWithPlaceHolderForFilters()
        {
            InitializeComponent();
        }

        public string PlaceHolder
        {
            get => (string)GetValue(PlaceHolderProperty);
            set => SetValue(PlaceHolderProperty, value);
        }

        // Using a DependencyProperty as the backing store for PlaceHolder.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlaceHolderProperty =
            DependencyProperty.Register("PlaceHolder", typeof(string), typeof(TextboxWithPlaceHolderForFilters));


        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(TextboxWithPlaceHolderForFilters), new FrameworkPropertyMetadata(TextProperty) { BindsTwoWayByDefault = true });

    }
}
