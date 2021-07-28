using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;
using WPFApp1.Services;
using WPFApp1.Pages;
using System.Windows.Input;

namespace WPFApp1.ViewModel
{
    public class MainViewModel : BindableBase
    {
        private readonly PageService _navigation;

        public Page CurrentPage { get; set; }

        public MainViewModel(PageService navigation)
        {
            navigation.OnePageChanged += page => CurrentPage = page;
            navigation.Navigate(new SelectRolePage());
            _navigation = navigation;
        }

        public ICommand GoToBack => new DelegateCommand(() =>
        {
            _navigation.GoToBack();
        
        }, () => _navigation.CanGoToBack);

        public ICommand GoToMainReestr => new DelegateCommand(() =>
        {
            _navigation.ClearStack();
            _navigation.Navigate(new MainDataReestrPage());
        });





    }

  
}
