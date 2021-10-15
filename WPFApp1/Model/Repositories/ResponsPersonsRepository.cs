using System;
using System.Linq;
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
            var persons = _appDbContext.Respons_persons.Where(x => x.Activity.Value.Equals(true));
            var admistrators = persons.Where(x => x.PersonStats.Role.Equals("ГИП") || x.PersonStats.Role.Equals("Администратор"));    
            return admistrators;
        }

        public IQueryable<Respons_persons> GetAdminstrativePersonsByCurrentProjekt(int projektID)
        {
            var persons = _appDbContext.Main_Reestr.Where(x => x.ID == projektID).SelectMany(y => y.Respons_persons);
            return persons;
        }

        public IQueryable<Respons_persons> GetAllPersons()
        {
            var listpersons = _appDbContext.Respons_persons.Where(x => x.ID != 0);
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

        public IQueryable<Respons_persons> GetEngenersByCurrentcontract(int contractID)
        {
            var persons = _appDbContext.Contracts.Where(x => x.ID == contractID)
                                                 .SelectMany(y => y.Respons_persons)
                                                 .Where(z => (z.PersonStats.Role == "Инженер" || z.PersonStats.Role == "Экономист") && z.Activity == true);
            return persons;
        }

        public IQueryable<Respons_persons> GetWorckersByCurrentcontract(int contractID)
        {
            var persons = _appDbContext.Contracts.Where(x => x.ID == contractID)
                                                .SelectMany(y => y.Respons_persons)
                                                .Where(z => z.PersonStats.Role == "Специалист" && z.Activity == true);
            return persons;
        }
    }
}