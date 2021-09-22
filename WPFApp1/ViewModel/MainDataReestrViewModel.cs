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

        public ObservableCollection<Main_Reestr> Main_Reestr { get; set; } = new ObservableCollection<Main_Reestr>();

        public MainDataReestrViewModel(PageService navigation, DataService dataService)
        {
            _navigation = navigation;
            _dataService = dataService;
          
            Main_Reestr = new ObservableCollection<Main_Reestr>(_dataService.GetDataToView().OrderByDescending(x => x.ID));

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

        public ICommand AddNewObjekt => new DelegateCommand(() => 
        {
            _navigation.Navigate(new AddNewObjektPage());
        });
    }
}
