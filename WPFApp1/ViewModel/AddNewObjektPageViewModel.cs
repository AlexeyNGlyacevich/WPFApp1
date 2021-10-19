using DevExpress.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using WPFApp1.Model.AppDBcontext;
using WPFApp1.Model.Repositories.Intefaces;
using WPFApp1.Pages;
using WPFApp1.Services;

namespace WPFApp1.ViewModel
{
    public class AddNewObjektPageViewModel : BindableBase
    {
        public int Registrnumber { get; set; }
        public string Stage { get; set; }
        public string ObjektName { get; set; }
        public string ProjektType { get; set; }
        public int Resp_person { get; set; }

        private readonly PageService _navigation;
        private readonly IProjektRepository _projektRepository;
        private readonly IResponsPersonsRepository _responsPersonsRepository;
        public ObservableCollection<Respons_persons> RespPersons { get; set; }

        public AddNewObjektPageViewModel(PageService navigation, IProjektRepository projektRepository, IResponsPersonsRepository responsPersonsRepository)
        {
            _navigation = navigation;
            _projektRepository = projektRepository;
            _responsPersonsRepository = responsPersonsRepository;
            RespPersons = new ObservableCollection<Respons_persons>(_responsPersonsRepository.GetAdminstrativePersons());
        }

        public ICommand AddNewObjekt => new DelegateCommand(() =>
        {
            if (_projektRepository.CheckObjektRegistrationNumber(Registrnumber))
            {
                _ = MessageBox.Show("Проект с указанным номером уже существует!", "Новый Проект", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                Main_Reestr Newobjekt = new Main_Reestr()
                {
                    Doc_Number = Registrnumber,
                    stage = Stage,
                    Object_name = ObjektName,
                    project_type = ProjektType,
                    resp_personID = Resp_person,
                    Creation_Date = DateTime.Now,
                    CustomerID = 10
                };

                _projektRepository.AddNewProjekt(Newobjekt);
                _ = MessageBox.Show("Новая запись добавлена в реестр", "Новый Проект", MessageBoxButton.OK, MessageBoxImage.Information);
                _navigation.Navigate(new MainDataReestrPage());
            }

        }, () => !string.IsNullOrEmpty(ObjektName) && !string.IsNullOrEmpty(ProjektType) && !string.IsNullOrEmpty(Stage) && Registrnumber != 0 && Resp_person != 0);

    }
}
