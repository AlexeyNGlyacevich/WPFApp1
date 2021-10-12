using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFApp1.Model.AppDBcontext;
using WPFApp1.Model.Repositories.Intefaces;

namespace WPFApp1.Model.Repositories
{
    public class ResponsPersonsRepository : IResponsPersonsRepository
    {
        private readonly ProjectStDBEntities _appDbContext;

        public ResponsPersonsRepository(ProjectStDBEntities appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IQueryable<Respons_persons> GetAdminstrativePersons()
        {
            var admistrators = _appDbContext.Respons_persons.Where(x => x.Person_stats.Equals("GIP") || x.Person_stats.Equals("Administrator"))
                                                            .Where(y => y.Activity.Equals(true));
            return admistrators;
        }

        public IQueryable<Respons_persons> GetAllPersons()
        {
            var listpersons = _appDbContext.Respons_persons;
            return listpersons;
        }

        public IQueryable<Respons_persons> GetActivePersons()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Respons_persons> GetEngenersPersons()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Respons_persons> GetWorckers()
        {
            throw new NotImplementedException();
        }
    }
}