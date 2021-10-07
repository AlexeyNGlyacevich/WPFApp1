using DevExpress.Mvvm;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WPFApp1.Model.AppDBcontext;
using WPFApp1.Pages;
using WPFApp1.Pages.TTN;
using WPFApp1.Services;

namespace WPFApp1.ViewModel
{
    public class AllTTNPageViewModel : BindableBase
    {
        private readonly PageService _navigation;
        private readonly DataService _dataservice;
        private ObservableCollection<TTN> TTNs= new ObservableCollection<TTN>();
        public ObservableCollection<TTN> AllTTNs
        {
            get => TTNs;
            set
            {
                TTNs = value;
                RaisePropertiesChanged();
            }
        }

        public AllTTNPageViewModel(PageService navigation, DataService dataservice)
        {
            _navigation = navigation;
            _dataservice = dataservice;
            AllTTNs = new ObservableCollection<TTN>(_dataservice.GetAllTTN());
        }

        public ICommand GoToMainReestrPage => new DelegateCommand(() =>
        {
            _navigation.Navigate(new MainDataReestrPage());
            _navigation.Refresh();
            _navigation.Refresh();
        });

        public ICommand GoToTenderReestr => new DelegateCommand(() =>
        {
            _navigation.Navigate(new AllTendersPage());
            _navigation.Refresh();
        });

        public ICommand GoToContractsReestr => new DelegateCommand(() =>
        {
            _navigation.Navigate(new AllContractsPage());
            _navigation.Refresh();
        });

        public ICommand EditCurrentTTN => new DelegateCommand<TTN>((TTN ttn) =>
        {
            _dataservice.GetCurrentTTNID(ttn);
            _navigation.Navigate(new TTNPage());
        });
    }
}
