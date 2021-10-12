using DevExpress.Mvvm;
using System;
using System.Windows;
using System.Windows.Input;
using WPFApp1.Model.AppDBcontext;
using WPFApp1.Services;

namespace WPFApp1.ViewModel
{
    public class ContractViewModel : BindableBase
    {
        private int _currentcontractID;
        public int CurrentContractID
        {
            get => _currentcontractID;
            set
            {
                _currentcontractID = value;
                RaisePropertiesChanged();
            }
        }
        private int? _currentIDKey;
        public int? CurrentIDKey
        {
            get => _currentIDKey;
            set
            {
                _currentIDKey = value;
                RaisePropertiesChanged();
            }
        }
        private int? _currentcontractnumber;
        public int? CurrentContractNumber
        {
            get => _currentcontractnumber;
            set
            {
                _currentcontractnumber = value;
                RaisePropertiesChanged();
            }
        }
        private DateTime? _currentcontractsigning;
        public DateTime? CurrentContractSigning
        {
            get => _currentcontractsigning;
            set
            {
                _currentcontractsigning = value;
                RaisePropertiesChanged();
            }
        }
        private string _currentobjektname;
        public string CurrentObjektName
        {
            get => _currentobjektname;
            set
            {
                _currentobjektname = value;
                RaisePropertiesChanged();
            }
        }
        private string _currentsubjectofcontract;
        public string CurrentSubjectOfContract
        {
            get => _currentsubjectofcontract;
            set
            {
                _currentsubjectofcontract = value;
                RaisePropertiesChanged();
            }
        }
        private decimal? _currentcontractammount;
        public decimal? CurrentContractAmount
        {
            get => _currentcontractammount;
            set
            {
                _currentcontractammount = value;
                RaisePropertiesChanged();
            }
        }
        private DateTime? _currentstartdate;
        public DateTime? CurrentStartDate
        {
            get => _currentstartdate;
            set
            {
                _currentstartdate = value;
                RaisePropertiesChanged();
            }
        }
        private DateTime? _currentfinishdate;
        public DateTime? CurrentFinishDate
        {
            get => _currentfinishdate;
            set
            {
                _currentfinishdate = value;
                RaisePropertiesChanged();
            }
        }
        private string _currentprojectmanager;
        public string CurrentProjectManager
        {
            get => _currentprojectmanager;
            set
            {
                _currentprojectmanager = value;
                RaisePropertiesChanged();
            }
        }
        private string _currentnote;
        public string CurrentNote
        {
            get => _currentnote;
            set
            {
                _currentnote = value;
                RaisePropertiesChanged();
            }
        }

        private int _currentdocumentationID;
        public int CurrentDocumentationID
        {
            get => _currentdocumentationID;
            set
            {
                _currentdocumentationID = value;
                RaisePropertiesChanged();
            }
        }
        private int? _documentationcontractID;
        public int? DocumentationContractID
        {
            get => _documentationcontractID;
            set
            {
                _documentationcontractID = value;
                RaisePropertiesChanged();
            }
        }
        private DateTime? _currentprojektstartdate;
        public DateTime? CurrentProjectStartDate
        {
            get => _currentprojektstartdate;
            set
            {
                _currentprojektstartdate = value;
                RaisePropertiesChanged();
            }
        }
        private string _currentdocumentindex;
        public string CurrentDocumentIndex
        {
            get => _currentdocumentindex;
            set
            {
                _currentdocumentindex = value;
                RaisePropertiesChanged();
            }
        }
        private DateTime? _dateoftransferToSettlementGroup;
        public DateTime? DateOfTransferToSettlementGroup
        {
            get => _dateoftransferToSettlementGroup;
            set
            {
                _dateoftransferToSettlementGroup = value;
                RaisePropertiesChanged();
            }
        }
        private DateTime? _dateOfTransferToTheCostomerApproval;
        public DateTime? DateOfTransferToTheCustomerApproval
        {
            get => _dateOfTransferToTheCostomerApproval;
            set
            {
                _dateOfTransferToTheCostomerApproval = value;
                RaisePropertiesChanged();
            }
        }
        private DateTime? _dateOfAgreementbyTheCustomer;
        public DateTime? DateOfAgreementByTheCustomer
        {
            get => _dateOfAgreementbyTheCustomer;
            set
            {
                _dateOfAgreementbyTheCustomer = value;
                RaisePropertiesChanged();
            }
        }
        private DateTime? _dateOfSubmissionforInspection;
        public DateTime? DateOfSubmissionForInspection
        {
            get => _dateOfSubmissionforInspection;
            set
            {
                _dateOfSubmissionforInspection = value;
                RaisePropertiesChanged();
            }
        }
        private DateTime? _dateOfReceiptOfInspection;
        public DateTime? DateOfReceiptOfInspection
        {
            get => _dateOfReceiptOfInspection;
            set
            {
                _dateOfReceiptOfInspection = value;
                RaisePropertiesChanged();
            }
        }
        private DateTime? _startDateOfPickingAndPurchasing;
        public DateTime? StartDateOfPickingAndPurchasing
        {
            get => _startDateOfPickingAndPurchasing;
            set
            {
                _startDateOfPickingAndPurchasing = value;
                RaisePropertiesChanged();
            }
        }
        private DateTime? _dateOfSubmissiondocumentationToMPO;
        public DateTime? DateOfSubmissionDocumentationToMPO
        {
            get => _dateOfSubmissiondocumentationToMPO;
            set
            {
                _dateOfSubmissiondocumentationToMPO = value;
                RaisePropertiesChanged();
            }
        }
        private DateTime? _dateOfTransferforPickingfromMPO;
        public DateTime? DateOfTransferForPickingFromMPO
        {
            get => _dateOfTransferforPickingfromMPO;
            set
            {
                _dateOfTransferforPickingfromMPO = value;
                RaisePropertiesChanged();
            }
        }
        private DateTime? _buildStartDate;
        public DateTime? BuildStartDate
        {
            get => _buildStartDate;
            set
            {
                _buildStartDate = value;
                RaisePropertiesChanged();
            }
        }
        private DateTime? _dateOfOperationControl;
        public DateTime? DateOfOperationControl
        {
            get => _dateOfOperationControl;
            set
            {
                _dateOfOperationControl = value;
                RaisePropertiesChanged();
            }
        }
        private string _operationControlResult;
        public string OperationControleResult
        {
            get => _operationControlResult;
            set
            {
                _operationControlResult = value;
                RaisePropertiesChanged();
            }
        }
        private DateTime? _dateOfAcceptanceControl;
        public DateTime? DateOfAcceptanceControl
        {
            get => _dateOfAcceptanceControl;
            set
            {
                _dateOfAcceptanceControl = value;
                RaisePropertiesChanged();
            }
        }
        private string _acceptanceControlResult;
        public string AcceptanceControlResult
        {
            get => _acceptanceControlResult;
            set
            {
                _acceptanceControlResult = value;
                RaisePropertiesChanged();
            }
        }
        private string _acceptanceControlProtocol;
        public string AcceptanceControlProtocol
        {
            get => _acceptanceControlProtocol;
            set
            {
                _acceptanceControlProtocol = value;
                RaisePropertiesChanged();
            }
        }
        private DateTime? _dateOfSipment;
        public DateTime? DateOfShipment
        {
            get => _dateOfSipment;
            set
            {
                _dateOfSipment = value;
                RaisePropertiesChanged();
            }
        }
        private DateTime? _actionDate;
        public DateTime? ActDate
        {
            get => _actionDate;
            set
            {
                _actionDate = value;
                RaisePropertiesChanged();
            }
        }
        private int? _actNumber;
        public int? ActNumber
        {
            get => _actNumber;
            set
            {
                _actNumber = value;
                RaisePropertiesChanged();
            }
        }
        private DateTime? _date_of_PSI;
        public DateTime? Date_of_PSI
        {
            get => _date_of_PSI;
            set
            {
                _date_of_PSI = value;
                RaisePropertiesChanged();
            }
        }


        private readonly PageService _navigation;
        private readonly DataService _dataservice;

        public Contracts Contract { get; set; }
        public Documentation Documentation { get; set; }


        public ContractViewModel(PageService navigation, DataService dataservice)
        {
            _dataservice = dataservice;
            _navigation = navigation;

            Contract = new Contracts();
            Contract = _dataservice.GetCurrentConract(_dataservice.ContractID);

            CurrentContractID = Contract.ID;
            CurrentIDKey = Contract.IDKey;
            CurrentContractNumber = Contract.Contract_Number;
            CurrentContractSigning = Contract.Contract_Signing;
            CurrentObjektName = Contract.Object_name;
            CurrentSubjectOfContract = Contract.subject_of_contract;
            CurrentContractAmount = Contract.Contract_amount;
            CurrentStartDate = Contract.start_date;
            CurrentFinishDate = Contract.finish_date;
            CurrentProjectManager = Contract.Project_Manager;
            CurrentNote = Contract.Note;

            Documentation = new Documentation();
            Documentation = _dataservice.GetDocumentationDataForCurrentContract(_dataservice.ContractID);

            CurrentDocumentationID = Documentation.ID;
            DocumentationContractID = Documentation.ContractID;
            CurrentProjectStartDate = Documentation.ProjectStartDate;
            CurrentDocumentIndex = Documentation.Document_Index;
            DateOfTransferToSettlementGroup = Documentation.date_of_transfer_to_settlement_group;
            DateOfTransferToTheCustomerApproval = Documentation.date_of_transfer_to_the_customer_for_approval;
            DateOfAgreementByTheCustomer = Documentation.date_of_agreement_by_the_customer;
            DateOfSubmissionForInspection = Documentation.date_of_submission_for_inspection;
            DateOfReceiptOfInspection = Documentation.date_of_receipt_of_inspection;
            StartDateOfPickingAndPurchasing = Documentation.start_date_of_picking_and_purchasing;
            DateOfSubmissionDocumentationToMPO = Documentation.date_of_submission_of_documentation_to_MPO;
            DateOfTransferForPickingFromMPO = Documentation.date_of_transfer_for_picking_from_MPO;
            BuildStartDate = Documentation.build_start_date;
            DateOfOperationControl = Documentation.Operational_control;
            OperationControleResult = Documentation.Operational_control_result;
            DateOfAcceptanceControl = Documentation.Acceptance_control;
            AcceptanceControlResult = Documentation.Acceptance_control_results;
            AcceptanceControlProtocol = Documentation.Acceptance_control_protocol;
            DateOfShipment = Documentation.Date_of_shipment;
            ActDate = Documentation.Act_Date;
            ActNumber = Documentation.Act_number;
            Date_of_PSI = Documentation.PSI;

        }

        public ICommand ContractSaveChanges => new DelegateCommand(() =>
        {
            if (_dataservice.CheckContractRegistrationNumber((int)CurrentContractNumber) && Contract.Contract_Number != CurrentContractNumber)
            {
                _ = MessageBox.Show("Договор с указанным номером уже существует!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                try
                {
                    Contract.ID = CurrentContractID;
                    Contract.IDKey = CurrentIDKey;
                    Contract.Contract_Number = CurrentContractNumber;
                    Contract.Contract_Signing = CurrentContractSigning;
                    Contract.Object_name = CurrentObjektName;
                    Contract.subject_of_contract = CurrentSubjectOfContract;
                    Contract.Contract_amount = CurrentContractAmount;
                    Contract.start_date = CurrentStartDate;
                    Contract.finish_date = CurrentFinishDate;
                    Contract.Project_Manager = CurrentProjectManager;
                    Contract.Note = CurrentNote;

                    Documentation.ID = CurrentDocumentationID;
                    Documentation.ContractID = DocumentationContractID;
                    Documentation.ProjectStartDate = CurrentProjectStartDate;
                    Documentation.Document_Index = CurrentDocumentIndex;
                    Documentation.date_of_transfer_to_settlement_group = DateOfTransferToSettlementGroup;
                    Documentation.date_of_transfer_to_the_customer_for_approval = DateOfTransferToTheCustomerApproval;
                    Documentation.date_of_agreement_by_the_customer = DateOfAgreementByTheCustomer;
                    Documentation.date_of_submission_for_inspection = DateOfSubmissionForInspection;
                    Documentation.date_of_receipt_of_inspection = DateOfReceiptOfInspection;
                    Documentation.start_date_of_picking_and_purchasing = StartDateOfPickingAndPurchasing;
                    Documentation.date_of_submission_of_documentation_to_MPO = DateOfSubmissionDocumentationToMPO;
                    Documentation.date_of_transfer_for_picking_from_MPO = DateOfTransferForPickingFromMPO;
                    Documentation.build_start_date = BuildStartDate;
                    Documentation.Operational_control = DateOfOperationControl;
                    Documentation.Operational_control_result = OperationControleResult;
                    Documentation.Acceptance_control = DateOfAcceptanceControl;
                    Documentation.Acceptance_control_results = AcceptanceControlResult;
                    Documentation.Acceptance_control_protocol = AcceptanceControlProtocol;
                    Documentation.Date_of_shipment = DateOfShipment;
                    Documentation.Act_Date = ActDate;
                    Documentation.Act_number = ActNumber;
                    Documentation.PSI = Date_of_PSI;

                    _dataservice.UpdateContract(Contract, Documentation);
                    _ = MessageBox.Show("Изменения Успешно Сохранены", "Cохранение Изменений", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch
                {
                    _ = MessageBox.Show("Ошибка", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
        }, () => CurrentContractNumber != Contract.Contract_Number || CurrentContractSigning != Contract.Contract_Signing || CurrentStartDate != Contract.start_date || CurrentFinishDate != Contract.finish_date ||
                 CurrentSubjectOfContract != Contract.subject_of_contract || CurrentObjektName != Contract.Object_name || CurrentNote != Contract.Note || CurrentContractAmount != Contract.Contract_amount || CurrentProjectManager != Contract.Project_Manager ||
                 CurrentProjectStartDate != Documentation.ProjectStartDate || CurrentDocumentIndex != Documentation.Document_Index || DateOfTransferToSettlementGroup != Documentation.date_of_transfer_to_settlement_group ||
                 DateOfTransferToTheCustomerApproval != Documentation.date_of_transfer_to_the_customer_for_approval || DateOfAgreementByTheCustomer != Documentation.date_of_agreement_by_the_customer ||
                 DateOfSubmissionForInspection != Documentation.date_of_submission_for_inspection || DateOfReceiptOfInspection != Documentation.date_of_receipt_of_inspection || StartDateOfPickingAndPurchasing != Documentation.start_date_of_picking_and_purchasing ||
                 DateOfSubmissionDocumentationToMPO != Documentation.date_of_submission_of_documentation_to_MPO || DateOfTransferForPickingFromMPO != Documentation.date_of_transfer_for_picking_from_MPO ||
                 BuildStartDate != Documentation.build_start_date || DateOfOperationControl != Documentation.Operational_control || OperationControleResult != Documentation.Operational_control_result ||
                 DateOfAcceptanceControl != Documentation.Acceptance_control || AcceptanceControlResult != Documentation.Acceptance_control_results || AcceptanceControlProtocol != Documentation.Acceptance_control_protocol ||
                 DateOfShipment != Documentation.Date_of_shipment || ActDate != Documentation.Act_Date || ActNumber != Documentation.Act_number || Date_of_PSI != Documentation.PSI);



        public ICommand RestoreContractData => new DelegateCommand(() =>
        {
            CurrentContractID = Contract.ID;
            CurrentIDKey = Contract.IDKey;
            CurrentContractNumber = Contract.Contract_Number;
            CurrentContractSigning = Contract.Contract_Signing;
            CurrentObjektName = Contract.Object_name;
            CurrentSubjectOfContract = Contract.subject_of_contract;
            CurrentContractAmount = Contract.Contract_amount;
            CurrentStartDate = Contract.start_date;
            CurrentFinishDate = Contract.finish_date;
            CurrentProjectManager = Contract.Project_Manager;
            CurrentNote = Contract.Note;

            CurrentDocumentationID = Documentation.ID;
            DocumentationContractID = Documentation.ContractID;
            CurrentProjectStartDate = Documentation.ProjectStartDate;
            CurrentDocumentIndex = Documentation.Document_Index;
            DateOfTransferToSettlementGroup = Documentation.date_of_transfer_to_settlement_group;
            DateOfTransferToTheCustomerApproval = Documentation.date_of_transfer_to_the_customer_for_approval;
            DateOfAgreementByTheCustomer = Documentation.date_of_agreement_by_the_customer;
            DateOfSubmissionForInspection = Documentation.date_of_submission_for_inspection;
            DateOfReceiptOfInspection = Documentation.date_of_receipt_of_inspection;
            StartDateOfPickingAndPurchasing = Documentation.start_date_of_picking_and_purchasing;
            DateOfSubmissionDocumentationToMPO = Documentation.date_of_submission_of_documentation_to_MPO;
            DateOfTransferForPickingFromMPO = Documentation.date_of_transfer_for_picking_from_MPO;
            BuildStartDate = Documentation.build_start_date;
            DateOfOperationControl = Documentation.Operational_control;
            OperationControleResult = Documentation.Operational_control_result;
            DateOfAcceptanceControl = Documentation.Acceptance_control;
            AcceptanceControlResult = Documentation.Acceptance_control_results;
            AcceptanceControlProtocol = Documentation.Acceptance_control_protocol;
            DateOfShipment = Documentation.Date_of_shipment;
            ActDate = Documentation.Act_Date;
            ActNumber = Documentation.Act_number;
            Date_of_PSI = Documentation.PSI;

        }, () => CurrentContractNumber != Contract.Contract_Number || CurrentContractSigning != Contract.Contract_Signing || CurrentStartDate != Contract.start_date || CurrentFinishDate != Contract.finish_date ||
                 CurrentSubjectOfContract != Contract.subject_of_contract || CurrentObjektName != Contract.Object_name || CurrentNote != Contract.Note || CurrentContractAmount != Contract.Contract_amount || CurrentProjectManager != Contract.Project_Manager ||
                 CurrentProjectStartDate != Documentation.ProjectStartDate || CurrentDocumentIndex != Documentation.Document_Index || DateOfTransferToSettlementGroup != Documentation.date_of_transfer_to_settlement_group ||
                 DateOfTransferToTheCustomerApproval != Documentation.date_of_transfer_to_the_customer_for_approval || DateOfAgreementByTheCustomer != Documentation.date_of_agreement_by_the_customer ||
                 DateOfSubmissionForInspection != Documentation.date_of_submission_for_inspection || DateOfReceiptOfInspection != Documentation.date_of_receipt_of_inspection || StartDateOfPickingAndPurchasing != Documentation.start_date_of_picking_and_purchasing ||
                 DateOfSubmissionDocumentationToMPO != Documentation.date_of_submission_of_documentation_to_MPO || DateOfTransferForPickingFromMPO != Documentation.date_of_transfer_for_picking_from_MPO ||
                 BuildStartDate != Documentation.build_start_date || DateOfOperationControl != Documentation.Operational_control || OperationControleResult != Documentation.Operational_control_result ||
                 DateOfAcceptanceControl != Documentation.Acceptance_control || AcceptanceControlResult != Documentation.Acceptance_control_results || AcceptanceControlProtocol != Documentation.Acceptance_control_protocol ||
                 DateOfShipment != Documentation.Date_of_shipment || ActDate != Documentation.Act_Date || ActNumber != Documentation.Act_number || Date_of_PSI != Documentation.PSI);
    }


}
