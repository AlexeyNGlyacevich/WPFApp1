using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFApp1.Model.AppDBcontext;

namespace WPFApp1.Model.Repositories.Intefaces
{
    public interface IResponsPersonsRepository
    {
        IQueryable<Respons_persons> GetAllPersons();

        IQueryable<Respons_persons> GetActivePersons();

        IQueryable<Respons_persons> GetAdminstrativePersons();

        IQueryable<Respons_persons> GetEngenersPersons();

        IQueryable<Respons_persons> GetWorckers();


    }
}
