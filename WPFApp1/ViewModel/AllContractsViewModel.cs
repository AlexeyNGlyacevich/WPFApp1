using DevExpress.Mvvm;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WPFApp1.Model.AppDBcontext;
using WPFApp1.Model.Repositories.Intefaces;
using WPFApp1.Pages;
using WPFApp1.Pages.Contract;
using WPFApp1.Services;

namespace WPFApp1.ViewModel
{
    public class AllContractsViewModel : BindableBase
    {
        private readonly PageService _navigation;
        private readonly IContractRepository _contractRepository;
        public ObservableCollection<Contracts> AllContracts { get; set; }


        public AllContractsViewModel(PageService navigation, IContractRepository contractRepository)
        {
            _navigation = navigation;
            _contractRepository = contractRepository;
            AllContracts = new ObservableCollection<Contracts>(_contractRepository.GetAllContracts());
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

        public ICommand GoToTTNReestr => new DelegateCommand(() =>
        {
            _navigation.Navigate(new AllTTNPage());
            _navigation.Refresh();

        });

        public ICommand EditContract => new DelegateCommand<Contracts>((Contracts contract) =>
        {
            _contractRepository.SetContractID(contract);
            _navigation.Navigate(new ContractPage());
        });


    }
}
