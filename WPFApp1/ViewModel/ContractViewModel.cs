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
        public int CurrentContractID { get; set; }
        public int? CurrentIDKey { get; set; }
        public int CurrentContractNumber { get; set; }
        public DateTime? CurrentContractSigning { get; set; }
        public string CurrentObjektName { get; set; }
        public string CurrentSubjectOfContract { get; set; }
        public decimal? CurrentContractAmount { get; set; }
        public DateTime? CurrentStartDate { get; set; }
        public DateTime? CurrentFinishDate { get; set; }
        public string CurrentProjectManager { get; set; }
        public string CurrentNote { get; set; }

        public int CurrentDocumentationID { get; set; }
        public int? DocumentationContractID { get; set; }
        public DateTime? CurrentProjectStartDate { get; set; }
        public string CurrentDocumentIndex { get; set; }
        public DateTime? DateOfTransferToSettlementGroup { get; set; }
        public DateTime? DateOfTransferToTheCustomerApproval { get; set; }
        public DateTime? DateOfAgreementByTheCustomer { get; set; }
        public DateTime? DateOfSubmissionForInspection { get; set; }
        public DateTime? DateOfReceiptOfInspection { get; set; }
        public DateTime? StartDateOfPickingAndPurchasing { get; set; }
        public DateTime? DateOfSubmissionDocumentationToMPO { get; set; }
        public DateTime? DateOfTransferForPickingFromMPO { get; set; }
        public DateTime? BuildStartDate { get; set; }
        public DateTime? DateOfOperationControl { get; set; }
        public string OperationControleResult { get; set; }
        public DateTime? DateOfAcceptanceControl { get; set; }
        public string AcceptanceControlResult { get; set; }
        public string AcceptanceControlProtocol { get; set; }
        public DateTime? DateOfShipment { get; set; }
        public DateTime? ActDate { get; set; }
        public int? ActNumber { get; set; }


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
            RaisePropertiesChanged(nameof(Contract));

            CurrentContractID = Contract.ID;
            CurrentIDKey = Contract.IDKey;
            CurrentContractNumber = (int)Contract.Contract_Number;
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
            RaisePropertiesChanged(nameof(Documentation));

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

        }

        public ICommand ContractSaveChanged => new DelegateCommand(() =>
        {
            try
            {
                _dataservice.UpdateContract(Contract, Documentation);
                _ = MessageBox.Show("Изменения Успешно Сохранены", "Cохранение Изменений", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                _ = MessageBox.Show("Ошибка", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        });
    }





}
