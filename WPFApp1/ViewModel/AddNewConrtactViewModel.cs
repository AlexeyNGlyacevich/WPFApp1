using DevExpress.Mvvm;
using System.Windows;
using System.Windows.Input;
using WPFApp1.Model.AppDBcontext;
using WPFApp1.Model.Repositories.Intefaces;
using WPFApp1.Services;

namespace WPFApp1.ViewModel
{
    public class AddNewConrtactViewModel : BindableBase
    {
        private int contractNumber;
        public int ContractNumber
        {
            get => contractNumber;
            set
            {
                contractNumber = value;
                RaisePropertiesChanged();
            }
        }
        public int ObjektID { get; set; }
        public int? ObjektNumber { get; set; }
        public Main_Reestr CurrentObjekt { get; set; }

        private readonly DataService _dataservice;
        private readonly IProjektRepository _projektRepository;

        public AddNewConrtactViewModel(DataService dataservice, IProjektRepository projektRepository)
        {
            _dataservice = dataservice;
            _projektRepository = projektRepository;
            CurrentObjekt = _projektRepository.GetCurrentProjekt(_projektRepository.ProjektID);
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
                _ = MessageBox.Show("Договор Зарегистрирован", "Добавление договора", MessageBoxButton.OK, MessageBoxImage.Error);
               
            }
            
        }, () => ContractNumber != 0 && ContractNumber > 9);


    }

}

