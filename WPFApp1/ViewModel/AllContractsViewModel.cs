using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFApp1.Model.AppDBcontext;
using WPFApp1.Services;

namespace WPFApp1.ViewModel
{
    public class AllContractsViewModel : BindableBase
    {
        private readonly PageService _navigation;
        private readonly DataService _dataservice;
        public ObservableCollection<Contracts> Contract { get; set; } = new ObservableCollection<Contracts>();

        public AllContractsViewModel(PageService navigation, DataService dataservice)
        {
            _navigation = navigation;
            _dataservice = dataservice;
            Contract = new ObservableCollection<Contracts>(dataservice.GetAllContracts());
        }





    }
}
