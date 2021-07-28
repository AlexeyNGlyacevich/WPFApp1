using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPFApp1.Pages.Admin;
using WPFApp1.Services;
using WPFApp1.Pages;
using WPFApp1.Model;
using WPFApp1.CustomControls;

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
                _ = MessageBox.Show("Неверный пароль");
            }
        }/*, () => !string.IsNullOrWhiteSpace(Password) && !string.IsNullOrWhiteSpace(User_Login)*/);




    }
}
