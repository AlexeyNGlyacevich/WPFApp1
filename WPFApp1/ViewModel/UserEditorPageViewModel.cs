using DevExpress.Mvvm;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using WPFApp1.Model.AppDBcontext;
using WPFApp1.Model.Repositories.Intefaces;
using WPFApp1.Services;

namespace WPFApp1.ViewModel
{
    public class UserEditoPageViewModel : BindableBase
    {
        public string Login { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string EMail { get; set; }
        public int Role { get; set; }
        public string Pass { get; set; }

        private readonly PageService _navigation;
        private readonly IUsersRepository _usersRepository;
        public ObservableCollection<User_Types> UserTypes { get; set; }


        public UserEditoPageViewModel(PageService navigation, IUsersRepository userRepository)
        {
            _navigation = navigation;
            _usersRepository = userRepository;
            UserTypes = new ObservableCollection<User_Types>(_usersRepository.GetAllTypes());
        }

        public ICommand AddNewUser => new DelegateCommand(() =>
        {
            Users_DB Newuser = new Users_DB() { UserLogin = Login, FirstName = Firstname, LastName = Lastname, Email = EMail, TypeID = Role, UserPass = Pass };
            _ = _usersRepository.AddUser(Newuser);
            _ = MessageBox.Show("Новый пользователь успешно добавлен", "Добавление Пользователя", MessageBoxButton.OK, MessageBoxImage.Information);
            _navigation.GoToBack();

        }, () => !string.IsNullOrEmpty(Login) && !string.IsNullOrEmpty(Firstname) && !string.IsNullOrEmpty(Lastname) && !string.IsNullOrEmpty(Pass) && Role != 0);

    }
}