using DevExpress.Mvvm;
using System.Linq;
using WPFApp1.Services;
using WPFApp1.Pages;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WPFApp1.Model.AppDBcontext;
using WPFApp1.Pages.EditorPages;
using WPFApp1.Model.Repositories.Intefaces;
using WPFApp1.DialogWindows;

namespace WPFApp1.ViewModel
{
    public class MainDataReestrViewModel : BindableBase
    {
        private readonly PageService _navigation;
        private readonly IProjektRepository _projektRepository;
        public ObservableCollection<Main_Reestr> Main_Reestr { get; set; }
        public ObservableCollection<Respons_persons> ResponsPersons { get; set; }
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




        public MainDataReestrViewModel(PageService navigation, IProjektRepository projektRepository)
        {
            _navigation = navigation;
            _projektRepository = projektRepository;
            Main_Reestr = new ObservableCollection<Main_Reestr>(_projektRepository.GetProjektsToView().OrderByDescending(x => x.ID));
            //ResponsPersons = new ObservableCollection<Respons_persons>();
        }

        public ICommand EditObject => new DelegateCommand<Main_Reestr>((Main_Reestr objekt) =>
        {
            _projektRepository.SetCurrentProjectID(objekt);
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
            AddNewProjektWindowDialog newProjekt = new AddNewProjektWindowDialog();
            _ = newProjekt.ShowDialog();
            if (newProjekt.DialogResult == true)
            {
                Main_Reestr = new ObservableCollection<Main_Reestr>(_projektRepository.GetProjektsToView().OrderByDescending(x => x.ID));
            }
        });

    }
}
