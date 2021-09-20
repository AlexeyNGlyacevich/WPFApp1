using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFApp1.Model.AppDBcontext;
using WPFApp1.Pages.Admin;
using WPFApp1.Services;

namespace WPFApp1.ViewModel
{
    class AdminPageViewModel : BindableBase
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




    }
}
