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

        IQueryable<Respons_persons> GetEngenersPersons();

        IQueryable<Respons_persons> GetEngenersByCurrentcontract(int contractID);

        IQueryable<Respons_persons> GetWorckersByCurrentcontract(int contractID);

        IQueryable<Respons_persons> GetWorckers();


    }
}
