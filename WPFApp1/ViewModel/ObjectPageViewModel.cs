using DevExpress.Mvvm;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using WPFApp1.Model.AppDBcontext;
using WPFApp1.Pages;
using WPFApp1.Pages.Contract;
using WPFApp1.Pages.Tender;
using WPFApp1.Pages.TTN;
using WPFApp1.Services;

namespace WPFApp1.ViewModel
{
    internal class ObjectPageViewModel : BindableBase
    {
        private readonly PageService _navigation;
        private readonly DataService _dataservice;

        public Main_Reestr CurrentObjekt { get; set; }
        public ObservableCollection<Contracts> CurrentObjektContracts { get; set; }
        public ObservableCollection<Tenders> CurrentObjektTenders { get; set; }
        public ObservableCollection<TTN> CurrentObjektTns { get; set; }

        //public int Doc_Number { get; set; }
        //public int CustomerID { get; set; }
        //public string Contract_Number { get; set; }
        //public DateTime Contract_Date { get; set; }
        //public string Object_name { get; set; }
        //public DateTime date_of_invoice { get; set; }
        //public int general_contractor { get; set; }
        //public int sub_contractor { get; set; }
        //public string Link { get; set; }
        //public string project_type { get; set; }
        //public string stage { get; set; }
        //public int resp_personID { get; set; }


        public ObjectPageViewModel(PageService navigation, DataService dataservice)
        {
            _navigation = navigation;
            _dataservice = dataservice;

            CurrentObjekt = _dataservice.GetCurrentObjektInfo(_dataservice.CurrentObjektID);
            CurrentObjektContracts = new ObservableCollection<Contracts>(_dataservice.GetContractsForCurrentObjekt(_dataservice.CurrentObjektID));
            CurrentObjektTenders = new ObservableCollection<Tenders>(_dataservice.GetTendersForCurrentObject(_dataservice.CurrentObjektID));
            CurrentObjektTns = new ObservableCollection<TTN>(_dataservice.GetTTNsForCurrentObjekt(_dataservice.CurrentObjektID));
        }

        public ICommand ObjektSaveChanges => new DelegateCommand(() =>
        {
            try
            {
                _dataservice.UpdateObjekt(CurrentObjekt);
                _ = MessageBox.Show("Изменения Успешно Сохранены", "Cохранение Изменений", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                _ = MessageBox.Show("Ошибка", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        });

        public ICommand GetCurrentContract => new DelegateCommand<Contracts>((Contracts contract) =>
        {
            _dataservice.GetContractID(contract);
            _navigation.Navigate(new ContractPage());
        });

        public ICommand CreateNewContract => new DelegateCommand(() =>
        {
            _dataservice.ObjektID = CurrentObjekt.ID;
            _navigation.Navigate(new AddNewContractPage());
        });

        public ICommand DeleteContract => new DelegateCommand<Contracts>((Contracts contract) =>
        {
            MessageBoxResult result = MessageBox.Show("Удалить Договор?", "Удаление Договора", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    _dataservice.RemoveCurrentContract(contract.ID);
                    _ = MessageBox.Show("Договор Успешно удален.", "Удаление договора.", MessageBoxButton.OK, MessageBoxImage.Information);
                    _navigation.Refresh();
                    _navigation.Navigate(new ObjectPage());

                    break;
                case MessageBoxResult.No:
                    _ = MessageBox.Show("Удаление Договора отменено", "Удаление договора", MessageBoxButton.OK, MessageBoxImage.Stop);
                    break;
                case MessageBoxResult.None:
                    break;
                case MessageBoxResult.OK:
                    break;
                case MessageBoxResult.Cancel:
                    break;
                default:
                    break;
            }
        });

        public ICommand CreateNewTender => new DelegateCommand(() =>
        {
            _dataservice.ObjektID = CurrentObjekt.ID;
            _navigation.Navigate(new AddNewTenderPage());
        });

        public ICommand DeleteTender => new DelegateCommand<Tenders>((Tenders tender) =>
        {
            MessageBoxResult result = MessageBox.Show("Удалить Тендер?", "Удаление Тендера", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    _dataservice.RemoveCurrentTender(tender.ID);
                    _ = MessageBox.Show("Тендер Успешно удален.", "Удаление Тендера.", MessageBoxButton.OK, MessageBoxImage.Information);
                    _navigation.Refresh();
                    _navigation.Navigate(new ObjectPage());

                    break;
                case MessageBoxResult.No:
                    _ = MessageBox.Show("Удаление Тендера отменено", "Удаление Тендера", MessageBoxButton.OK, MessageBoxImage.Stop);
                    break;
                case MessageBoxResult.None:
                    break;
                case MessageBoxResult.OK:
                    break;
                case MessageBoxResult.Cancel:
                    break;
                default:
                    break;
            }
        });

        public ICommand EditCurrentTender => new DelegateCommand<Tenders>((Tenders tender) =>
        {
            _dataservice.GetCurrentTenderID(tender);
            _navigation.Navigate(new TenderPage());
        });


        public ICommand CreateNewTTN => new DelegateCommand(() =>
        {
            _dataservice.ObjektID = CurrentObjekt.ID;
            _navigation.Navigate(new AddNewTTNPage());
        });

        public ICommand EditCurrentTTN => new DelegateCommand<TTN>((TTN ttn) =>
        {
            _dataservice.GetCurrentTTNID(ttn);
            _navigation.Navigate(new TTNPage());
        });

        public ICommand DeleteTTN => new DelegateCommand<TTN>((TTN ttn) =>
        {
            MessageBoxResult result = MessageBox.Show("Удалить Накладную?", "Удаление Наклдадной", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    _dataservice.RemoveCurrentTTN(ttn.id);
                    _ = MessageBox.Show("Накладная Успешно удалена.", "Удаление Накладной.", MessageBoxButton.OK, MessageBoxImage.Information);
                    _navigation.Refresh();
                    _navigation.Navigate(new ObjectPage());

                    break;
                case MessageBoxResult.No:
                    _ = MessageBox.Show("Удаление Накладной отменено", "Удаление Накладной", MessageBoxButton.OK, MessageBoxImage.Stop);
                    break;
                case MessageBoxResult.None:
                    break;
                case MessageBoxResult.OK:
                    break;
                case MessageBoxResult.Cancel:
                    break;
                default:
                    break;
            }
        });

    }
}
