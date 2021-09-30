using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFApp1.Model.AppDBcontext;
using WPFApp1.Pages;
using WPFApp1.Pages.Contract;
using WPFApp1.Services;

namespace WPFApp1.ViewModel
{
    public class AllContractsViewModel : BindableBase
    {
        private readonly PageService _navigation;
        private readonly DataService _dataservice;
        private ObservableCollection<Contracts> Contracts = new ObservableCollection<Contracts>();
        public ObservableCollection<Contracts> AllContracts
        {
            get => Contracts;
            set
            {
                Contracts = value;
                RaisePropertiesChanged();
            }
        }

        public AllContractsViewModel(PageService navigation, DataService dataservice)
        {
            _navigation = navigation;
            _dataservice = dataservice;
            Contracts = new ObservableCollection<Contracts>(dataservice.GetAllContracts());
        }

        public ICommand GoToMainReestrPage => new DelegateCommand(() =>
        {
            _navigation.Navigate(new MainDataReestrPage());
            _navigation.Refresh();
        });

        public ICommand GoToTenderReestr => new DelegateCommand(() =>
        {
            _navigation.Navigate(new AllTendersPage());
            _navigation.Refresh();
        });

        public ICommand EditContract => new DelegateCommand<Contracts>((Contracts contract) =>
        {
            _dataservice.GetContractID(contract);
            _navigation.Navigate(new ContractPage());
        });


    }
}
