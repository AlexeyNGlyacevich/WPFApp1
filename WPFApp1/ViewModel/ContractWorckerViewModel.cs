using DevExpress.Mvvm;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using WPFApp1.Model.AppDBcontext;
using WPFApp1.Model.Repositories.Intefaces;
using WPFApp1.Services;

namespace WPFApp1.ViewModel
{
    public class ContractWorckerViewModel : BindableBase
   {
        private readonly IResponsPersonsRepository _responsPersonsRepository;
        private readonly ResponcePersonsService _personsService;
        private readonly IContractRepository _contractRepository;

        public int ContractID { get; set; }
        public ObservableCollection<Respons_persons> AssignedWPersons { get; set; }
        public ObservableCollection<Respons_persons> RemainingWPersons { get; set; }
        public Respons_persons RemPerson { get; set; }
        public Respons_persons AddPerson { get; set; }


        public ContractWorckerViewModel(IResponsPersonsRepository responsPersonsRepository, ResponcePersonsService personsServive, IContractRepository contractRepository)
        {
            _responsPersonsRepository = responsPersonsRepository;
            _contractRepository = contractRepository;
            _personsService = personsServive;

            ContractID = _contractRepository.ContractID;
            AssignedWPersons = new ObservableCollection<Respons_persons>(_responsPersonsRepository.GetWorckersByCurrentContract(ContractID));
            RemainingWPersons = new ObservableCollection<Respons_persons>(_personsService.SelectRemainingWPersons(ContractID));
        }

        public ICommand SaveChangesByW_Persons => new DelegateCommand(() =>
        {

            _responsPersonsRepository.UpdateWorckersByContract(ContractID, AssignedWPersons);
            var windows = Application.Current.Windows;
            foreach (Window window in windows)
            {
                if (window.Name.Equals("Worckers_List"))
                {
                    window.DialogResult = true;
                    return;
                }
            }
        });

        public ICommand RemoveFromCurrentWcollection => new DelegateCommand(() =>
        {
            if (RemPerson == null)
            {
                return;
            }
            else
            {
                RemainingWPersons.Add(RemPerson);
                _ = AssignedWPersons.Remove(RemPerson);

            }
        });

        public ICommand AddToCurrentWcollection => new DelegateCommand(() =>
        {
            if (AddPerson == null)
            {
                return;
            }
            else
            {
                AssignedWPersons.Add(AddPerson);
                _ = RemainingWPersons.Remove(AddPerson);
            }
        });
    }
}
