using DevExpress.Mvvm;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using WPFApp1.Model.AppDBcontext;
using WPFApp1.Model.Repositories.Intefaces;
using WPFApp1.Pages.Admin;
using WPFApp1.Services;

namespace WPFApp1.ViewModel
{
    public class AllUsersEditorPageViewModel : BindableBase
    {
        public int ide;

        private readonly PageService _navigation;
        private readonly IUsersRepository _usersRepository;
        public ObservableCollection<Users_DB> Users { get; set; }


        public AllUsersEditorPageViewModel(PageService navigation, IUsersRepository usersRepository)
        {
            _navigation = navigation;
            _usersRepository = usersRepository;

            Users = new ObservableCollection<Users_DB>(_usersRepository.GetAllUsers());
        }

        public ICommand EditUser => new DelegateCommand<Users_DB>((Users_DB user) =>
        {
            _usersRepository.SetUserID(user);
            _navigation.Navigate(new UpdateUserPage());

        });

        public ICommand RemoveCurrentUser => new DelegateCommand<Users_DB>((Users_DB user) =>
        {

            MessageBoxResult result = MessageBox.Show("Удалить Пользователя?", "Удаление пользователя", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    _ = _usersRepository.RemoveUser(user);
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
