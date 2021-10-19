using DevExpress.Mvvm;
using System.Windows.Input;
using WPFApp1.Pages.Admin;
using WPFApp1.Services;

namespace WPFApp1.ViewModel
{
    public class AdminPageViewModel : BindableBase
    {
        private readonly PageService _navigation;

        public AdminPageViewModel(PageService navigation)
        {
            _navigation = navigation;
        }

        public ICommand AddUser => new DelegateCommand(() =>
        {
            _navigation.Navigate(new UserEditorPage());
        });

        public ICommand EditUsers => new DelegateCommand(() =>
        {
            _navigation.Navigate(new AllUsersEditorPage());
        });

        public ICommand EditResponsPersons => new DelegateCommand(() =>
        {
            _navigation.Navigate(new EditResponsPersonsPage());
        });


    }
}
