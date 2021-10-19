using DevExpress.Mvvm;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WPFApp1.Model.AppDBcontext;
using WPFApp1.Model.Repositories.Intefaces;
using WPFApp1.Pages;
using WPFApp1.Pages.Tender;
using WPFApp1.Services;

namespace WPFApp1.ViewModel
{
    public class AllTendersPageViewModel : BindableBase
    {
        private readonly PageService _navigation;
        private readonly ITenderRepository _tenderRepository;
        public ObservableCollection<Tenders> Tenders { get; set; }

        public AllTendersPageViewModel(PageService navigation, ITenderRepository tenderRepository)
        {
            _navigation = navigation;
            _tenderRepository = tenderRepository;
            Tenders = new ObservableCollection<Tenders>(_tenderRepository.GetAlltenders());
        }

        public ICommand GoToCurrentTender => new DelegateCommand<Tenders>((Tenders tender) =>
        {
            _tenderRepository.SetCurrentTenderID(tender);
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
