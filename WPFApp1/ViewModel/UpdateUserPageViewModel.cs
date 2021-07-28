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
    public class UpdateUserPageViewModel : BindableBase
    {
        public int CurrentID { get; set; }
        public string Login { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string EMail { get; set; }
        public int Role { get; set; }
        public string Pass { get; set; }

        private readonly PageService _navigation;
        private readonly DataService _dataservice;

        public ObservableCollection<User_Types> UserTypes { get; set; } = new ObservableCollection<User_Types>();
        public Users_DB editUser { get; set; }

        public UpdateUserPageViewModel(PageService navigation, DataService dataservice)
        {
            _navigation = navigation;
            _dataservice = dataservice;

            UserTypes = new ObservableCollection<User_Types>(_dataservice.GetAllTypes());
            editUser = new Users_DB();


            editUser = _dataservice.GetCurrentUser(_dataservice.UserId);

            CurrentID = editUser.ID;
            Login = editUser.UserLogin;
            Firstname = editUser.FirstName;
            Lastname = editUser.LastName;
            EMail = editUser.Email;
            Role = (int)editUser.TypeID;
            Pass = editUser.UserPass;

        }


        public ICommand UpdateUser => new DelegateCommand(() =>
        {
            Users_DB Newuser = new Users_DB { ID = CurrentID, UserLogin = Login, FirstName = Firstname, LastName = Lastname, Email = EMail, TypeID = Role, UserPass = Pass };

            _dataservice.Update(Newuser);
            _ = MessageBox.Show("Изменения Сохранены");
            _navigation.GoToBack();

        }, () => !string.IsNullOrEmpty(Login) && !string.IsNullOrEmpty(Firstname) && !string.IsNullOrEmpty(Lastname) && !string.IsNullOrEmpty(Pass) && Role != 0);


    }
}
