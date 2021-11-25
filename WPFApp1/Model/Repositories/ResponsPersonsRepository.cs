using System;
using System.Collections.ObjectModel;
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

        public IQueryable<Respons_persons> GetAdminstrativePersonsByCurrentProjekt(int ProjectID)
        {
            var persons = _appDbContext.Main_Reestr.Where(x => x.ID == ProjectID).SelectMany(y => y.Respons_persons);
            return persons;
        }

        public IQueryable<Respons_persons> GetAllPersons()
        {
            var listpersons = _appDbContext.Respons_persons.Where(x => x.ID != 0);
            return listpersons;
        }

        public IQueryable<Respons_persons> GetActivePersons()
        {
            return null;
        }

        public IQueryable<Respons_persons> GetEngenersPersons()
        {
            var persons = _appDbContext.Respons_persons.Where(x => (x.PersonStats.Role == "Инженер" || x.PersonStats.Role == "Экономист") && x.Activity == true);
            return persons;
        }

        public IQueryable<Respons_persons> GetWorckers()
        {
            var persons = _appDbContext.Respons_persons.Where(x => x.PersonStats.Role == "Специалист" && x.Activity == true);
            return persons;
        }

        public IQueryable<Respons_persons> GetEngenersByCurrentContract(int ContractID)
        {
            var persons = _appDbContext.Contracts.Where(x => x.ID == ContractID)
                                                 .SelectMany(y => y.Respons_persons)
                                                 .Where(z => z.PersonStats.Role == "Инженер" || z.PersonStats.Role == "Экономист");
            return persons;
        }

        public IQueryable<Respons_persons> GetWorckersByCurrentContract(int ContractID)
        {
            var persons = _appDbContext.Contracts.Where(x => x.ID == ContractID)
                                                .SelectMany(y => y.Respons_persons)
                                                .Where(z => z.PersonStats.Role == "Специалист");
            return persons;
        }

        public IQueryable<Respons_persons> GetADMPersonsByCurrentContract(int ContractID)
        {
            var persons = _appDbContext.Contracts.Where(x => x.ID == ContractID)
                                    .SelectMany(y => y.Respons_persons)
                                    .Where(x => x.PersonStats.Role == "ГИП" || x.PersonStats.Role=="Администратор");
            return persons;
        }

        public void SetAdminstrativePersonsByCurrentProjekt(int ProjectID, ObservableCollection<Respons_persons> collection)
        {
            var project = _appDbContext.Main_Reestr.FirstOrDefault(x => x.ID == ProjectID);
            if (project != null)
            {
                foreach (Respons_persons person in collection)
                {
                    if (person.IsSelected == true)
                    {
                        project.Respons_persons.Add(person);
                        person.IsSelected = false;
                    }
                }
            }
            _ = _appDbContext.SaveChanges();
        }

        public void UpdateAdminstrativePersonsByCurrentProject(int ProjectID, ObservableCollection<Respons_persons> collection)
        {
            var project = _appDbContext.Main_Reestr.FirstOrDefault(x => x.ID == ProjectID);
            if (project == null)
            {
                return;
            }
            else
            {
                project.Respons_persons.Clear();
                foreach (Respons_persons person in collection)
                {
                    if (person.First_Name != null)
                    {
                        project.Respons_persons.Add(person);
                    }
                }
            }
            _ = _appDbContext.SaveChanges();
        }

        public void UpdateENGPersonsByContract(int ContractID, ObservableCollection<Respons_persons> collection)
        {
            var contract = _appDbContext.Contracts.FirstOrDefault(x => x.ID == ContractID);
            if (contract == null)
            {
                return;
            }
            else
            {
                var list_persons = contract.Respons_persons.ToList();
                _ = list_persons.RemoveAll(x => x.PersonStats.Role == "Инженер" || x.PersonStats.Role == "Экономист");
                list_persons.AddRange(collection);
                contract.Respons_persons.Clear();
                foreach (Respons_persons person in list_persons)
                {
                    if (person.First_Name != null)
                    {
                        contract.Respons_persons.Add(person);
                    }
                }
            }
            _ = _appDbContext.SaveChanges();
        }

        public void UpdateAdministrativePersonsByContract(int ContractID, ObservableCollection<Respons_persons> collection)
        {
            var contract = _appDbContext.Contracts.FirstOrDefault(x => x.ID == ContractID);
            if (contract == null)
            {
                return;
            }
            else
            {
                var list_persons = contract.Respons_persons.ToList();
                _ = list_persons.RemoveAll(x => x.PersonStats.Role == "ГИП" || x.PersonStats.Role == "Администратор");
                list_persons.AddRange(collection);
                contract.Respons_persons.Clear();
                foreach (Respons_persons person in list_persons)
                {
                    if (person.First_Name != null)
                    {
                        contract.Respons_persons.Add(person);
                    }
                }
            }
            _ = _appDbContext.SaveChanges();
        }

        public void UpdateWorckersByContract(int ContractID, ObservableCollection<Respons_persons> collection)
        {
            var contract = _appDbContext.Contracts.FirstOrDefault(x => x.ID == ContractID);
            if (contract == null)
            {
                return;
            }
            else
            {
                var list_persons = contract.Respons_persons.ToList();
                _ = list_persons.RemoveAll(x => x.PersonStats.Role == "Специалист");
                list_persons.AddRange(collection);
                contract.Respons_persons.Clear();
                foreach (Respons_persons person in list_persons)
                {
                    if (person.First_Name != null)
                    {
                        contract.Respons_persons.Add(person);
                    }
                }
            }
            _ = _appDbContext.SaveChanges();
        }

        public void RemoveResponcePersonsByContract(Contracts contract)
        {
            contract.Respons_persons.Clear();

        }
    }
}