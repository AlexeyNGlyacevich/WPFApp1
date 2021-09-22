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
using WPFApp1.Pages;
using WPFApp1.Services;

namespace WPFApp1.ViewModel
{
    public class AddNewObjektPageViewModel : BindableBase
    {
        public int registrnumber { get; set; }
        public string cstage { get; set; }
        public string objektName { get; set; }
        public string projektType { get; set; }
        public int resp_person { get; set; }

        private readonly PageService _navigation;
        private readonly DataService _dataservice;
        public ObservableCollection<Respons_persons> RespPersons { get; set; } = new ObservableCollection<Respons_persons>();

        public AddNewObjektPageViewModel(PageService navigation, DataService dataservice)
        {
            _navigation = navigation;
            _dataservice = dataservice;
            RespPersons = new ObservableCollection<Respons_persons>(_dataservice.GetAllRespPersons());
        }


        public ICommand AddNewObjekt => new DelegateCommand(() =>
        {
            if (_dataservice.CheckObjektRegistrationNumber(registrnumber))
            {
                _ = MessageBox.Show("Проект с указанным номером уже существует!", "Новый Проект", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                Main_Reestr Newobjekt = new Main_Reestr()
                {
                    Doc_Number = registrnumber,
                    stage = cstage,
                    Object_name = objektName,
                    project_type = projektType,
                    resp_personID = resp_person,
                    Creation_Date = DateTime.Now
                };

                _dataservice.AddNewObjekt(Newobjekt);
                _ = MessageBox.Show("Новая запись добавлена в реестр", "Новый Проект", MessageBoxButton.OK, MessageBoxImage.Information);
                _navigation.Navigate(new MainDataReestrPage());
            }

        }, () => !string.IsNullOrEmpty(objektName) && !string.IsNullOrEmpty(projektType) && !string.IsNullOrEmpty(cstage) && registrnumber != 0 && resp_person != 0);

    }
}
