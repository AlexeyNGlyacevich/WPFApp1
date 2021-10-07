using DevExpress.Mvvm;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WPFApp1.Model.AppDBcontext;
using WPFApp1.Pages;
using WPFApp1.Pages.Tender;
using WPFApp1.Services;

namespace WPFApp1.ViewModel
{
    public class AllTendersPageViewModel : BindableBase
    {
        private readonly PageService _navigation;
        private readonly DataService _dataservice;
        private ObservableCollection<Tenders> Tenders;
        public ObservableCollection<Tenders> AllTenders
        {
            get => Tenders;
            set
            {
                Tenders = value;
                RaisePropertiesChanged();
            }
        }

        public AllTendersPageViewModel(PageService navigation, DataService dataservice)
        {
            _navigation = navigation;
            _dataservice = dataservice;
            Tenders = new ObservableCollection<Tenders>(dataservice.GetAllTenders());
        }

        public ICommand GoToCurrentTender => new DelegateCommand<Tenders>((Tenders tender) =>
        {
            _dataservice.GetCurrentTenderID(tender);
            _navigation.Navigate(new TenderPage());
        });

        public ICommand GoToTTNReestr => new DelegateCommand(() =>
        {
            _navigation.Navigate(new AllTTNPage());
            _navigation.Refresh();

        });

        public ICommand GoToContractsReestr => new DelegateCommand(() =>
        {
            _navigation.Navigate(new AllContractsPage());
            _navigation.Refresh();
        });

        public ICommand GoToMainReestrPage => new DelegateCommand(() =>
        {
            _navigation.Navigate(new MainDataReestrPage());
            _navigation.Refresh();
        });
    }
}
