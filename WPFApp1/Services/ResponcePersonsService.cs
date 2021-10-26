using DevExpress.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WPFApp1.Model.AppDBcontext;
using WPFApp1.Model.Repositories.Intefaces;

namespace WPFApp1.Services
{
    public class ResponcePersonsService : BindableBase
    {
        private readonly IResponsPersonsRepository _responsPersonsRepository;
        private readonly IContractRepository _contractRepository;
        public int ProjectID { get; set; }

        public List<Respons_persons> AllADM_Persons { get; set; }
        public List<Respons_persons> AllENG_Persons { get; set; }
        public List<Respons_persons> AllW_Persons { get; set; }


        public ResponcePersonsService(IResponsPersonsRepository responsePersonsRepository, IContractRepository contractRepository)
        {
            _responsPersonsRepository = responsePersonsRepository;
            _contractRepository = contractRepository;

            AllADM_Persons = new List<Respons_persons>(_responsPersonsRepository.GetAdminstrativePersons());
            AllENG_Persons = new List<Respons_persons>(_responsPersonsRepository.GetEngenersPersons());
            AllW_Persons = new List<Respons_persons>(_responsPersonsRepository.GetWorckers());
        }

        public IQueryable<Respons_persons> SelectRemainingADMPersons(int ProjektID)
        {
            var assigned_persons = _responsPersonsRepository.GetAdminstrativePersonsByCurrentProjekt(ProjektID);
            if (assigned_persons != null)
            {
                var result = AllADM_Persons.Except(assigned_persons).AsQueryable();
                return result;
            }
            else
            {
                return (IQueryable<Respons_persons>)AllADM_Persons;
            }
        }

        public IQueryable<Respons_persons> SelectRemainingENGPersons(int ContractID)
        {
            var assigned_persons = _responsPersonsRepository.GetEngenersByCurrentContract(ContractID);
            if (assigned_persons != null)
            {
                var result = AllENG_Persons.Except(assigned_persons).AsQueryable();
                return result;
            }
            else
            {
                return (IQueryable<Respons_persons>)AllENG_Persons;
            }
        }

        public IQueryable<Respons_persons> SelectRemainingContractADMPersons(int ContractID)
        {
            var assigned_persons = _responsPersonsRepository.GetADMPersonsByCurrentContract(ContractID);
            if (assigned_persons != null)
            {
                var result = AllADM_Persons.Except(assigned_persons).AsQueryable();
                return result;
            }
            else
            {
                return (IQueryable<Respons_persons>)AllADM_Persons;
            }
        }

        public IQueryable<Respons_persons> SelectRemainingWPersons(int ContractID)
        {
            var assigned_persons = _responsPersonsRepository.GetWorckersByCurrentContract(ContractID);
            if (assigned_persons != null)
            {
                var result = AllW_Persons.Except(assigned_persons).AsQueryable();
                return result;
            }
            else
            {
                return (IQueryable<Respons_persons>)AllW_Persons;
            }
        }

        public IEnumerable<Respons_persons> UpdateENGByCurrentContract(int ContractID, ObservableCollection<Respons_persons> collection)
        {
            var contract = _contractRepository.GetCurrentConract(ContractID);
            var list_persons = contract.Respons_persons.ToList();
            _ = list_persons.RemoveAll(x => x.PersonStats.Role == "Инженер" || x.PersonStats.Role == "Экономист");
            list_persons.AddRange(collection);

            return (IQueryable<Respons_persons>)list_persons;
 
        }
    }
}
