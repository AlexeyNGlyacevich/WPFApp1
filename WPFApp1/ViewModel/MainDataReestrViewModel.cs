using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFApp1.Services;
using WPFApp1.Pages;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WPFApp1.Model.AppDBcontext;
using WPFApp1.Model;
using WPFApp1.Services.Message;
using WPFApp1.Pages.EditorPages;

namespace WPFApp1.ViewModel
{
    public class MainDataReestrViewModel : BindableBase
    {

        private readonly PageService _navigation;
        private readonly DataService _dataService;
        private readonly MessageBus _messageBus;
        public ObservableCollection<Objekt> Objekt { get; set; } = new ObservableCollection<Objekt>();


        public MainDataReestrViewModel(PageService navigation, DataService dataService, MessageBus messageBus)
        {
            _navigation = navigation;
            _dataService = dataService;
            _messageBus = messageBus;
            Objekt = new ObservableCollection<Objekt>(_dataService.GetDataToView());

        }

        public ICommand EditObject => new DelegateCommand<Objekt>((Objekt objekt) =>
        {
            //await _messageBus.SendTo<ObjectPageViewModel>(new Message(objekt.Id));
            _dataService.GetData(objekt.Id);
            _navigation.Navigate(new ObjectPage());
        });

        public ICommand Jointocontracts => new DelegateCommand(() =>
        {
            _navigation.Navigate(new AllContractsPage());
        });

        public ICommand AddNewObjekt => new DelegateCommand(() => 
        {
            _navigation.Navigate(new AddNewObjektPage());
        });
    }
}
