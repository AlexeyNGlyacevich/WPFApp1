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
using WPFApp1.Model.Repositories.Intefaces;
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
        private readonly IUsersRepository _usersRepository;

        public ObservableCollection<User_Types> UserTypes { get; set; } = new ObservableCollection<User_Types>();
        public Users_DB EditUser { get; set; }

        public UpdateUserPageViewModel(PageService navigation, IUsersRepository usersRepository)
        {
            _navigation = navigation;
            _usersRepository = usersRepository;

            UserTypes = new ObservableCollection<User_Types>(_usersRepository.GetAllTypes());
            EditUser = new Users_DB();


            EditUser = _usersRepository.GetCurrentUser(_usersRepository.UserID);

            CurrentID = EditUser.ID;
            Login = EditUser.UserLogin;
            Firstname = EditUser.FirstName;
            Lastname = EditUser.LastName;
            EMail = EditUser.Email;
            Role = (int)EditUser.TypeID;
            Pass = EditUser.UserPass;

        }


        public ICommand UpdateUser => new DelegateCommand(() =>
        {
            Users_DB Newuser = new Users_DB { ID = CurrentID, UserLogin = Login, FirstName = Firstname, LastName = Lastname, Email = EMail, TypeID = Role, UserPass = Pass };

            _usersRepository.UpdateUser(Newuser);
            _ = MessageBox.Show("Изменения Сохранены");
            _navigation.GoToBack();

        }, () => !string.IsNullOrEmpty(Login) && !string.IsNullOrEmpty(Firstname) && !string.IsNullOrEmpty(Lastname) && !string.IsNullOrEmpty(Pass) && Role != 0);


    }
}
