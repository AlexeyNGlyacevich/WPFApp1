using DevExpress.Mvvm;
using System.Windows;
using System.Windows.Input;
using WPFApp1.Model.AppDBcontext;
using WPFApp1.Model.Repositories.Intefaces;

namespace WPFApp1.ViewModel
{
    public class AddNewConrtactViewModel : BindableBase
    {
        private string contractNumber;
        public string ContractNumber
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

        private readonly IProjektRepository _projektRepository;
        private readonly IContractRepository _contractRepository;

        public AddNewConrtactViewModel(IProjektRepository projektRepository, IContractRepository contractRepository)
        {
            _projektRepository = projektRepository;
            _contractRepository = contractRepository;
            CurrentObjekt = _projektRepository.GetCurrentProjekt(_projektRepository.ProjektID);
            ObjektNumber = CurrentObjekt.Doc_Number;
        }

        public ICommand AddNewContract => new DelegateCommand(() =>
        {
            if (_contractRepository.CheckContractRegistrationNumber(ContractNumber))
            {
                _ = MessageBox.Show("Договор с указанным номером уже зарегистрирован!", "Добавление договора", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                Contracts contract = new Contracts
                {
                    IDKey = CurrentObjekt.ID,
                    Contract_Number = ContractNumber,
                    ID_currency = 1
                };
                _ = _contractRepository.AddNewContract(contract);
                Documentation documentation = new Documentation
                {
                    ContractID = contract.ID
                };
                _ = _contractRepository.AddNewDocumentation(documentation);
                var windows = Application.Current.Windows;
                foreach (Window window in windows)
                {
                    if (window.Title.Equals("Добавление Договора"))
                    {
                        window.DialogResult = true;
                        _ = MessageBox.Show("Договор Зарегистрирован", "Добавление договора", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                }
            }
        }, () => !string.IsNullOrEmpty(ContractNumber));

    }
}

