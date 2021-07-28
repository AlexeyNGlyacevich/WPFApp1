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
    public class UserEditoPageViewModel : BindableBase
    {

        public string Login { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string EMail { get; set; }
        public int Role { get; set; }
        public string Pass { get; set; }


        private readonly EventBus _eventBus;
        private readonly PageService _navigation;
        private readonly DataService _dataservice;
        public ObservableCollection<User_Types> UserTypes { get; set; } = new ObservableCollection<User_Types>();


        public UserEditoPageViewModel(PageService navigation, DataService dataservice, EventBus eventBus)
        {
            _navigation = navigation;
            _dataservice = dataservice;
            _eventBus = eventBus;
            UserTypes = new ObservableCollection<User_Types>(_dataservice.GetAllTypes());


            //_ = _eventBus.Subscribe<OnEditEvent<Users_DB>>(EventUserDB);


        }

        //private Task EventUserDB(OnEditEvent<Users_DB> arg)
        //{
        //    //newUser = arg.Entity;
        //    //return Task.CompletedTask;
        //}


        public ICommand AddNewUser => new DelegateCommand(() =>
        {
            Users_DB Newuser = new Users_DB() { UserLogin = Login, FirstName = Firstname, LastName = Lastname, Email = EMail, TypeID = Role, UserPass = Pass };
            _dataservice.AddUser(Newuser);
            _ = MessageBox.Show("Новый пользователь успешно добавлен");
            _navigation.GoToBack();

        }, () => !string.IsNullOrEmpty(Login) && !string.IsNullOrEmpty(Firstname) && !string.IsNullOrEmpty(Lastname) && !string.IsNullOrEmpty(Pass) && Role != 0);

    }
}