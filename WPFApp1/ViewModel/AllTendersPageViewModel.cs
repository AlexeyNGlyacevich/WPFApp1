using DevExpress.Mvvm;
using System.Collections.ObjectModel;
using WPFApp1.Model.AppDBcontext;
using WPFApp1.Services;

namespace WPFApp1.ViewModel
{
    public class AllTendersPageViewModel : BindableBase
    {
        private readonly PageService _navigation;
        private readonly DataService _dataservice;
        public ObservableCollection<Tenders> Tenders { get; set; }

        public AllTendersPageViewModel(PageService navigation, DataService dataservice)
        {
            _navigation = navigation;
            _dataservice = dataservice;
            Tenders = new ObservableCollection<Tenders>(dataservice.GetAllTenders());
        }

    }
}
