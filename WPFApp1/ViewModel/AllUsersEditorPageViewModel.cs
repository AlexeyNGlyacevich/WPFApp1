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

        private readonly PageService _navigation;
        private readonly DataService _dataservice;
        public ObservableCollection<Users_DB> Users { get; set; }


        public AllUsersEditorPageViewModel(PageService navigation, DataService dataservice)
        {
            _navigation = navigation;
            _dataservice = dataservice;

            Users = new ObservableCollection<Users_DB>(_dataservice.GetAllUsers());
        }

        public ICommand EditUser => new DelegateCommand<Users_DB>((Users_DB user) =>
        {
            _dataservice.GetCurrentUserId(user.ID);
            _navigation.Navigate(new UpdateUserPage());

        });

        public ICommand RemoveCurrentUser => new DelegateCommand<Users_DB>((Users_DB user) =>
        {

            MessageBoxResult result = MessageBox.Show("Удалить Пользователя?", "Удаление пользователя", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    _dataservice.RemoveUser(user);
                    _ = MessageBox.Show("Пользователь Удален.", "Удаление пользователя", MessageBoxButton.OK, MessageBoxImage.Information);
                    _navigation.GoToBack();
                    break;
                case MessageBoxResult.No:
                    _ = MessageBox.Show("Удаление Пользователя отменено", "Удаление пользователя", MessageBoxButton.OK, MessageBoxImage.Information);
                    _navigation.GoToBack();
                    break;
                case MessageBoxResult.None:
                    break;
                case MessageBoxResult.OK:
                    break;
                case MessageBoxResult.Cancel:
                    break;
                default:
                    break;
            }
        });

    }
}
