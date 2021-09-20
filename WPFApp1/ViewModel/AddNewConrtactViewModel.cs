using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
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
    public class AddNewConrtactViewModel : BindableBase
    {
        public int ContractNumber { get; set; }
        public int ObjektID { get; set; }
        public int? ObjektNumber { get; set; }
        public Main_Reestr CurrentObjekt { get; set; }

        private readonly PageService _navigation;
        private readonly DataService _dataservice;

        public AddNewConrtactViewModel(DataService dataservice, PageService navigation)
        {
            _navigation = navigation;
            _dataservice = dataservice;
            CurrentObjekt = _dataservice.GetCurrentObjektInfo(_dataservice.CurrentObjektID);
            ObjektNumber = CurrentObjekt.Doc_Number;
        }

        public ICommand AddNewContract => new DelegateCommand(() =>
        {
            if (_dataservice.CheckContractRegistrationNumber(ContractNumber))
            {
                _ = MessageBox.Show("Договор с указанным номером уже зарегистрирован!", "Добавление договора", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                Contracts contract = new Contracts
                {
                    IDKey = CurrentObjekt.ID,
                    Contract_Number = ContractNumber
                };
                _dataservice.AddNewContract(contract);
                Documentation documentation = new Documentation
                {
                    ContractID = contract.ID
                };

                _dataservice.AddNewDocumentation(documentation);
                _ = MessageBox.Show("Новый Договор Успешно Добавлен", "Добавление Договоров", MessageBoxButton.OK, MessageBoxImage.Information);
                _navigation.Refresh();
                _navigation.Refresh();
                _navigation.Navigate(new ObjectPage());
            }

        }, () => ContractNumber != 0 && ContractNumber > 9);


    }

}

