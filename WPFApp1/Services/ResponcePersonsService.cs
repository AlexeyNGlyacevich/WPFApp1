using DevExpress.Mvvm;
using System.Collections.Generic;
using System.Linq;
using WPFApp1.Model.AppDBcontext;
using WPFApp1.Model.Repositories.Intefaces;

namespace WPFApp1.Services
{
    public class ResponcePersonsService : BindableBase
    {
        private readonly IResponsPersonsRepository _responsPersonsRepository;
        public int ProjectID { get; set; }

        public List<Respons_persons> AllADM_Persons { get; set; }
        public List<Respons_persons> AllENG_Persons { get; set; }


        public ResponcePersonsService(IResponsPersonsRepository responsePersonsRepository)
        {
            _responsPersonsRepository = responsePersonsRepository;

            AllADM_Persons = new List<Respons_persons>(_responsPersonsRepository.GetAdminstrativePersons());
            AllENG_Persons = new List<Respons_persons>(_responsPersonsRepository.GetEngenersPersons());
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

    }
}
