using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPFApp1.Model.AppDBcontext;
using WPFApp1.Pages.Admin;
using WPFApp1.Services;
using WPFApp1.Services.Event;

namespace WPFApp1.ViewModel
{
   public class AllUsersEditorPageViewModel : BindableBase
    {
        public int ide;
        private readonly EventBus _eventBus;
        private readonly PageService _navigation;
        private readonly DataService _dataservice;
        public ObservableCollection<Users_DB> Users { get; set; }
        public ObservableCollection<int> Guid { get; set; } = new ObservableCollection<int>();

        public AllUsersEditorPageViewModel(PageService navigation, DataService dataservice, EventBus eventBus)
        {
            _navigation = navigation;
            _dataservice = dataservice;
            _eventBus = eventBus;
            Users = new ObservableCollection<Users_DB>(_dataservice.GetAllUsers());
        }

        public ICommand EditUser => new DelegateCommand<Users_DB>((Users_DB user) =>
        {
            _dataservice.GetCurrentUserId(user.ID);
            _ = _eventBus.Publish(new OnEditEvent<Users_DB>(user));
            _navigation.Navigate(new UpdateUserPage());

        });

        public ICommand RemoveCurrentUser => new DelegateCommand<Users_DB>((Users_DB user) =>
        {
            _dataservice.RemoveUser(user);
            _ = MessageBox.Show("Пользователь удален");
            _navigation.GoToBack();

        });

    }
}
