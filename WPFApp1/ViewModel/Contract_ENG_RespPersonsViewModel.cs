using DevExpress.Mvvm;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using WPFApp1.Model.AppDBcontext;
using WPFApp1.Model.Repositories.Intefaces;
using WPFApp1.Services;

namespace WPFApp1.ViewModel
{
    public class Contract_ENG_RespPersonsViewModel : BindableBase
    {
        private readonly IResponsPersonsRepository _responsPersonsRepository;
        private readonly ResponcePersonsService _personsService;
        private readonly IContractRepository _contractRepository;

        public int ContractID { get; set; }
        public ObservableCollection<Respons_persons> AssignedENGPersons { get; set; }
        public ObservableCollection<Respons_persons> RemainingENGPersons { get; set; }
        public Respons_persons Person { get; set; }
        public Respons_persons AddPerson { get; set; }


        public Contract_ENG_RespPersonsViewModel(IResponsPersonsRepository responsPersonsRepository, ResponcePersonsService personsServive, IContractRepository contractRepository)
        {
            _responsPersonsRepository = responsPersonsRepository;
            _contractRepository = contractRepository;
            _personsService = personsServive;

            ContractID = _contractRepository.ContractID;
            AssignedENGPersons = new ObservableCollection<Respons_persons>(_responsPersonsRepository.GetEngenersByCurrentContract(ContractID));
            RemainingENGPersons = new ObservableCollection<Respons_persons>(_personsService.SelectRemainingENGPersons(ContractID));
        }

        public ICommand SaveChangesByResp_Persons => new DelegateCommand(() =>
        {
            _responsPersonsRepository.UpdateAdminstrativePersonsByCurrentProject(ContractID, AssignedENGPersons);
            var windows = Application.Current.Windows;
            foreach (Window window in windows)
            {
                if (window.Name.Equals("ENG_ContractPers"))
                {
                    window.DialogResult = true;
                    return;
                }
            }
        });
    }
}
