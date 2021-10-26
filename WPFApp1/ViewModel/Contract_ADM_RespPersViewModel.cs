using DevExpress.Mvvm;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using WPFApp1.Model.AppDBcontext;
using WPFApp1.Model.Repositories.Intefaces;
using WPFApp1.Services;

namespace WPFApp1.ViewModel
{
    public class Contract_ADM_RespPersViewModel : BindableBase
    {
        private readonly IResponsPersonsRepository _responsPersonsRepository;
        private readonly IContractRepository _contractRepository;
        private readonly ResponcePersonsService _personsService;

        public int ContractID { get; set; }
        public ObservableCollection<Respons_persons> AssignedADMPersons { get; set; }
        public ObservableCollection<Respons_persons> RemainingADMPersons { get; set; }
        public Respons_persons RemPerson { get; set; }
        public Respons_persons AddPerson { get; set; }


        public Contract_ADM_RespPersViewModel(IResponsPersonsRepository responsPersonsRepository, ResponcePersonsService personsServive, IContractRepository contractRepository)
        {
            _responsPersonsRepository = responsPersonsRepository;
            _personsService = personsServive;
            _contractRepository = contractRepository;
            ContractID = _contractRepository.ContractID;
            AssignedADMPersons = new ObservableCollection<Respons_persons>(_responsPersonsRepository.GetADMPersonsByCurrentContract(ContractID));
            RemainingADMPersons = new ObservableCollection<Respons_persons>(_personsService.SelectRemainingContractADMPersons(ContractID));
        }

        public ICommand SaveChangesByADM_Persons => new DelegateCommand(() =>
        {
            _responsPersonsRepository.UpdateAdministrativePersonsByContract(ContractID, AssignedADMPersons);
            var windows = Application.Current.Windows;
            foreach (Window window in windows)
            {
                if (window.Name.Equals("ADM_PersonList"))
                {
                    window.DialogResult = true;
                    return;
                }
            }
        });

        public ICommand RemoveFromCurrentADMcollection => new DelegateCommand(() =>
        {
            if (RemPerson == null)
            {
                return;
            }
            else
            {
                RemainingADMPersons.Add(RemPerson);
                _ = AssignedADMPersons.Remove(RemPerson);

            }
        });

        public ICommand AddToCurrentADMcollection => new DelegateCommand(() =>
        {
            if (AddPerson == null)
            {
                return;
            }
            else
            {
                AssignedADMPersons.Add(AddPerson);
                _ = RemainingADMPersons.Remove(AddPerson);
            }
        });
    }
}
