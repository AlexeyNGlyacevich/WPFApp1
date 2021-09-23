using DevExpress.Mvvm;
using System.Windows;
using System.Windows.Input;
using WPFApp1.Pages.Admin;
using WPFApp1.Services;
using WPFApp1.Pages;
using WPFApp1.Model;

namespace WPFApp1.ViewModel
{
    public class LoginPageViewModel : BindableBase
    {
        private readonly PageService _navigation;

        public string Password { get; set; }
        public string User_Login {get; set; }
        public string User_type { get; set; }

        public LoginPageViewModel(PageService navigation)
        {
            _navigation = navigation;

        }

        public ICommand Login => new DelegateCommand(() =>
        {


            User_type = DBContextDataWorcker.GetUserType(User_Login, Password);

            if (DBContextDataWorcker.ToLogin(User_Login, Password, User_type))
            {

                if (User_type == "Admin")
                {
                    _navigation.Navigate(new AdminPage());
                }
                else if (User_type == "Ingener")
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
