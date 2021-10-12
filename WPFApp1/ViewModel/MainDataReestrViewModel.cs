using DevExpress.Mvvm;
using System.Linq;
using WPFApp1.Services;
using WPFApp1.Pages;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WPFApp1.Model.AppDBcontext;
using WPFApp1.Pages.EditorPages;
using WPFApp1.Model.Repositories;
using WPFApp1.Model.Repositories.Intefaces;

namespace WPFApp1.ViewModel
{
    public class MainDataReestrViewModel : BindableBase
    {
        private readonly PageService _navigation;
        private readonly DataService _dataService;
        private readonly IResponsPersonsRepository _responsPersons;
        private ObservableCollection<Main_Reestr> _Reester;
        public ObservableCollection<Main_Reestr> Main_Reestr
        {
            get => _Reester;
            set
            {
                _Reester = value;
                RaisePropertiesChanged();
            }
        }
        private ObservableCollection<Respons_persons> _resp_persons;
        public ObservableCollection<Respons_persons> ResponsPersons
        {
            get => _resp_persons;
            set
            {
                _resp_persons = value;
                RaisePropertiesChanged();
            }
        }
        private Main_Reestr _objekt;
        public Main_Reestr Objekt
        {
            get => _objekt;
            set
            {
                _objekt = value;
                RaisePropertiesChanged();
            }
        }
        public string CustomerName
        {
            get => _objekt.Customers.Customer_Name;
            set
            {
                _objekt.Customers.Customer_Name = value;
                RaisePropertiesChanged();
            }
        }
        public string ObjektName
        {
            get => _objekt.Object_name;
            set
            {
                _objekt.Object_name = value;
                RaisePropertiesChanged();
            }
        }
        public string ProjektType
        {
            get => _objekt.project_type;
            set
            {
                _objekt.project_type = value;
                RaisePropertiesChanged();
            }
        }
        public int? ProjektNumber
        {
            get => _objekt.Doc_Number;
            set
            {
                _objekt.Doc_Number = value;
                RaisePropertiesChanged();
            }
        }




        public MainDataReestrViewModel(PageService navigation, DataService dataService, IResponsPersonsRepository responsPersonsRepository)
        {
            _navigation = navigation;
            _dataService = dataService;
            _responsPersons = responsPersonsRepository;
            Main_Reestr = new ObservableCollection<Main_Reestr>(_dataService.GetDataToView().OrderByDescending(x => x.ID));
            //ResponsPersons = new ObservableCollection<Respons_persons>();
        }

        public ICommand EditObject => new DelegateCommand<Main_Reestr>((Main_Reestr objekt) =>
        {
            _dataService.GetCurrentObjektID(objekt);
            _navigation.Navigate(new ObjectPage());
        });

        public ICommand Jointocontracts => new DelegateCommand(() =>
        {
            _navigation.Navigate(new AllContractsPage());

        });

        public ICommand GoToTenderReestr => new DelegateCommand(() =>
        {
            _navigation.Navigate(new AllTendersPage());

        });

        public ICommand GoToTTNReestr => new DelegateCommand(() =>
        {
            _navigation.Navigate(new AllTTNPage());

        });

        public ICommand AddNewObjekt => new DelegateCommand(() =>
        {
            _navigation.Navigate(new AddNewObjektPage());
        });

    }
}
