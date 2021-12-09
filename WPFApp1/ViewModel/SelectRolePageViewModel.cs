using DevExpress.Mvvm;
using System.Windows.Input;
using WPFApp1.Pages;
using WPFApp1.Pages.Admin;
using WPFApp1.Services;

namespace WPFApp1.ViewModel
{

    public class SelectRolePageViewModel : BindableBase
    {
        private readonly PageService _navigation;

        public SelectRolePageViewModel(PageService navigation)
        {
            _navigation = navigation;
        }

        public ICommand LoginDirector => new DelegateCommand(() =>
        {
            _navigation.Navigate(new MainDataReestrPage());
        });

        public ICommand LoginEngineer => new DelegateCommand(() =>
        {
            _navigation.Navigate(new AdminPage());
        });


    }
}
