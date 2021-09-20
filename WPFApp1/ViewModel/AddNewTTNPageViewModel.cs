using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPFApp1.Model.AppDBcontext;
using WPFApp1.Pages;
using WPFApp1.Services;

namespace WPFApp1.ViewModel
{
    public class AddNewTTNPageViewModel : BindableBase
    {
        public int TTNNumber { get; set; }
        public int ContractKey { get; set; }
        public Main_Reestr CurrentObjekt { get; set; }
        public ObservableCollection<Contracts> Contracts { get; set; }

        private readonly PageService _navigation;
        private readonly DataService _dataservice;

        public AddNewTTNPageViewModel(DataService dataservice, PageService navigation)
        {
            _navigation = navigation;
            _dataservice = dataservice;
            CurrentObjekt = _dataservice.GetCurrentObjektInfo(_dataservice.CurrentObjektID);
            Contracts = new ObservableCollection<Contracts>(_dataservice.GetContractsForCurrentObjekt(CurrentObjekt.ID));
        }

        public ICommand AddNewTTN => new DelegateCommand(() =>
        {
            if (_dataservice.CheckTTNRegistrationNumber(TTNNumber))
            {
                _ = MessageBox.Show("Накладная с указанным номером уже зарегистрирована!", "Добавление Накладной", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                TTN ttn = new TTN
                {
                    ContractID = ContractKey,
                    Act_number = TTNNumber
                };
                _dataservice.AddNewTTN(ttn);

                _ = MessageBox.Show("Новая Накладная Успешно Добавлена", "Добавление Накладной", MessageBoxButton.OK, MessageBoxImage.Information);
                _navigation.Refresh();
                _navigation.Refresh();
                _navigation.Navigate(new ObjectPage());
            }

        }, () => TTNNumber != 0 && TTNNumber > 9 && ContractKey != 0);
    }

}