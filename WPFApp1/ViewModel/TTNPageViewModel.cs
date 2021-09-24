using DevExpress.Mvvm;
using System;
using System.Windows;
using System.Windows.Input;
using WPFApp1.Model.AppDBcontext;
using WPFApp1.Services;

namespace WPFApp1.ViewModel
{
    public class TTNPageViewModel : BindableBase
    {
        private readonly PageService _navigation;
        private readonly DataService _dataservice;
        public TTN TTN { get; set; } = new TTN();

        private int? _contractID;
        public int? ContractID
        {
            get => _contractID;
            set
            {
                _contractID = value;
                RaisePropertiesChanged();
            }
        }
        private int? _act_number;
        public int? Act_Number
        {
            get => _act_number;
            set
            {
                _act_number = value;
                RaisePropertiesChanged();
            }
        }
        private DateTime? _date_of_accept;
        public DateTime? Date_of_Accept
        {
            get => _date_of_accept;
            set
            {
                _date_of_accept = value;
                RaisePropertiesChanged();
            }
        }
        private string _customer;
        public string Customer
        {
            get => _customer;
            set
            {
                _customer = value;
                RaisePropertiesChanged();
            }
        }
        private DateTime? _date_of_contract;
        public DateTime? Date_of_contract
        {
            get => _date_of_contract;
            set
            {
                _date_of_contract = value;
                RaisePropertiesChanged();
            }
        }
        private double? _value_with_NDS;
        public double? Value_with_NDS
        {
            get => _value_with_NDS;
            set
            {
                _value_with_NDS = value;
                RaisePropertiesChanged();
            }
        }
        private DateTime? _date_of_invoice_ESF;
        public DateTime? Date_of_Invoice_ESF
        {
            get => _date_of_invoice_ESF;
            set
            {
                _date_of_invoice_ESF = value;
                RaisePropertiesChanged();
            }
        }
        private double? _with_general_contractor;
        public double? With_general_Contractor
        {
            get => _with_general_contractor;
            set
            {
                _with_general_contractor = value;
                RaisePropertiesChanged();
            }
        }
        private double? _with_subcontractor;
        public double? With_subcontractor
        {
            get => _with_subcontractor;
            set
            {
                _with_subcontractor = value;
                RaisePropertiesChanged();
            }
        }


        public TTNPageViewModel(PageService navigation, DataService dataservice)
        {
            _dataservice = dataservice;
            _navigation = navigation;
            TTN = _dataservice.GetCurrentTTN(_dataservice.TTNID);

            ContractID = TTN.ContractID;
            Act_Number = TTN.Act_number;
            Date_of_Accept = TTN.Date_of_accept;
            Customer = TTN.Customer;
            Date_of_contract = TTN.Date_of_contract;
            Value_with_NDS = TTN.Value_with_NDS;
            Date_of_Invoice_ESF = TTN.Date_of_invoice_ESF;
            With_general_Contractor = TTN.with_general_contractor;
            With_subcontractor = TTN.with_subcontractors;
        }

        public ICommand ContractSaveChanged => new DelegateCommand(() =>
        {
            if (_dataservice.CheckTTNRegistrationNumber((int)Act_Number) && TTN.Act_number != Act_Number)
            {
                _ = MessageBox.Show("Накладная с указанным номером уже существует!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                try
                {
                    TTN.ContractID = ContractID;
                    TTN.Act_number = Act_Number;
                    TTN.Date_of_accept = Date_of_Accept;
                    TTN.Customer = Customer;
                    TTN.Date_of_contract = Date_of_contract;
                    TTN.Value_with_NDS = Value_with_NDS;
                    TTN.Date_of_invoice_ESF = Date_of_Invoice_ESF;
                    TTN.with_general_contractor = With_general_Contractor;
                    TTN.with_subcontractors = With_subcontractor;

                    _dataservice.UpdateTTN(TTN);
                    _ = MessageBox.Show("Изменения Успешно Сохранены", "Cохранение Изменений", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch
                {
                    _ = MessageBox.Show("Ошибка", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
        }, () => ContractID != TTN.ContractID || Act_Number != TTN.Act_number || Date_of_Accept != TTN.Date_of_accept || Customer != TTN.Customer || Date_of_contract != TTN.Date_of_contract ||
                 Value_with_NDS != TTN.Value_with_NDS || Date_of_Invoice_ESF != TTN.Date_of_invoice_ESF || With_general_Contractor != TTN.with_general_contractor || With_subcontractor != TTN.with_subcontractors);

        public ICommand RestoreCurrentTTNData => new DelegateCommand(() =>
        {
            ContractID = TTN.ContractID;
            Act_Number = TTN.Act_number;
            Date_of_Accept = TTN.Date_of_accept;
            Customer = TTN.Customer;
            Date_of_contract = TTN.Date_of_contract;
            Value_with_NDS = TTN.Value_with_NDS;
            Date_of_Invoice_ESF = TTN.Date_of_invoice_ESF;
            With_general_Contractor = TTN.with_general_contractor;
            With_subcontractor = TTN.with_subcontractors;

        }, () => ContractID != TTN.ContractID || Act_Number != TTN.Act_number || Date_of_Accept != TTN.Date_of_accept || Customer != TTN.Customer || Date_of_contract != TTN.Date_of_contract ||
                 Value_with_NDS != TTN.Value_with_NDS || Date_of_Invoice_ESF != TTN.Date_of_invoice_ESF || With_general_Contractor != TTN.with_general_contractor || With_subcontractor != TTN.with_subcontractors);
    }
}
