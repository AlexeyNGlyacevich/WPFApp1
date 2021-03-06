using System.Collections.ObjectModel;
using System.Linq;
using WPFApp1.Model.AppDBcontext;

namespace WPFApp1.Model.Repositories.Intefaces
{
    public interface IResponsPersonsRepository
    {
        IQueryable<Respons_persons> GetAllPersons();

        IQueryable<Respons_persons> GetActivePersons();

        IQueryable<Respons_persons> GetAdminstrativePersons();

        IQueryable<Respons_persons> GetAdminstrativePersonsByCurrentProjekt(int projektID);

        void SetAdminstrativePersonsByCurrentProjekt(int ProjektID, ObservableCollection<Respons_persons> collection);

        void UpdateAdminstrativePersonsByCurrentProject(int ProjectID, ObservableCollection<Respons_persons> collection);

        void UpdateENGPersonsByContract(int ContractID, ObservableCollection<Respons_persons> collection);

        void UpdateAdministrativePersonsByContract(int ContractID, ObservableCollection<Respons_persons> collection);

        void UpdateWorckersByContract(int ContractID, ObservableCollection<Respons_persons> collection);

        IQueryable<Respons_persons> GetEngenersPersons();

        IQueryable<Respons_persons> GetEngenersByCurrentContract(int contractID);

        IQueryable<Respons_persons> GetWorckersByCurrentContract(int contractID);

        IQueryable<Respons_persons> GetADMPersonsByCurrentContract(int contractID);

        IQueryable<Respons_persons> GetWorckers();

        void RemoveResponcePersonsByContract(Contracts contract);



    }
}
