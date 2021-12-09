using DevExpress.Mvvm;
using System.Windows;
using System.Windows.Input;
using WPFApp1.Pages.Admin;
using WPFApp1.Services;
using WPFApp1.Pages;
using WPFApp1.Model.Repositories.Intefaces;

namespace WPFApp1.ViewModel
{
    public class LoginPageViewModel : BindableBase
    {
        private readonly PageService _navigation;
        private readonly IUsersRepository _usersRepository;

        public string Password { get; set; }
        public string User_Login { get; set; }
        public string User_type { get; set; }

        public LoginPageViewModel(PageService navigation, IUsersRepository usersRepository)
        {
            _navigation = navigation;
            _usersRepository = usersRepository;
        }

        public ICommand Login => new DelegateCommand(() =>
        {


            User_type = _usersRepository.GetUserType(User_Login, Password);

            if (_usersRepository.ByLogin(User_Login, Password, User_type))
            {

                if (User_type == "Admin")
                {
                    _navigation.Navigate(new SelectRolePage());
                }
                else
                {
                    _navigation.Navigate(new MainDataReestrPage());
                }
            }
            else
            {
                _ = MessageBox.Show("Неверный пароль или логин!", "Aвторизация", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }/*, () => !string.IsNullOrWhiteSpace(Password) && !string.IsNullOrWhiteSpace(User_Login)*/);




    }
}
