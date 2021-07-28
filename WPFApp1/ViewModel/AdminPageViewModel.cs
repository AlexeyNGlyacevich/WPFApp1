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
       //  private readonly DataService _dataService;
       // public ObservableCollection<User_Types> UserTypes { get; set; } = new ObservableCollection<User_Types>();


        public AdminPageViewModel(PageService navigation/*, DataService dataService, MessageBus messageBus*/)
        {
            _navigation = navigation;
          //  _dataService = dataService;
          //  UserTypes = new ObservableCollection<User_Types>(_dataService.GetAllTypes());

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
