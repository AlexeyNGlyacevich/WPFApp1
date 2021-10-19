using System;
using System.Linq;
using System.Windows;
using WPFApp1.Model.AppDBcontext;
using WPFApp1.Model.Repositories.Intefaces;

namespace WPFApp1.Model.Repositories
{
    public class ProjektRepository : IProjektRepository
    {
        private readonly ProjectStDBEntities _appDBcontext;
        public int ProjektID { get; set; }

        public ProjektRepository(ProjectStDBEntities appDBcontext)
        {
            _appDBcontext = appDBcontext;
        }

        public IQueryable<Main_Reestr> GetProjekts()
        {
            var projekt = _appDBcontext.Main_Reestr;
            return projekt;
        }

        public IQueryable<Main_Reestr> GetProjektsToView()
        {
            var projekt = _appDBcontext.Main_Reestr.AsQueryable();
            return projekt;
        }

        public IQueryable<Contracts> GetContractsForCurrentProjekt(int projektID)
        {
            var contracts = _appDBcontext.Contracts.Where(x => x.IDKey == projektID);
            return contracts;
        }

        public IQueryable<Tenders> GetTendersForCurrentProject(int projektID)
        {
            var tenders = _appDBcontext.Tenders.Where(x => x.IDKey == projektID);
            return tenders;
        }

        public IQueryable<TTN> GetTTNsForCurrentProjekt(int projektID)
        {
            var ttnslist = _appDBcontext.TTN.Where(x => x.Contracts.Main_Reestr.ID == projektID);
            return ttnslist;
        }

        public void UpdateProjekt(Main_Reestr projekt)
        {
            var updateobjekt = _appDBcontext.Main_Reestr.Find(projekt.ID);
            try
            {
                _appDBcontext.Entry(updateobjekt).CurrentValues.SetValues(projekt);
                _ = _appDBcontext.SaveChanges();
            }
            catch (Exception)
            {
                _ = MessageBox.Show("Ошибка! Проверьте правильность заполнения полей данных!", "Ошибка ввода данных", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        public void SetCurrentProjectID(Main_Reestr projekt)
        {
            ProjektID = projekt.ID;
        }

        public bool CheckCustomerID(string name)
        {
            var test = _appDBcontext.Customers.Any(x => x.Customer_Name.Equals(name));
            return test;
        }

        public Main_Reestr GetCurrentProjekt(int projektID)
        {
            var projekt = _appDBcontext.Main_Reestr.FirstOrDefault(x => x.ID == projektID);
            return projekt;
        }

        public void AddNewProjekt(Main_Reestr projekt)
        {
            _ = _appDBcontext.Main_Reestr.Add(projekt);
            _ = _appDBcontext.SaveChanges();
        }

        public bool CheckObjektRegistrationNumber(int projektNumber)
        {
            var test = _appDBcontext.Main_Reestr.Any(x => x.Doc_Number == projektNumber);
            return test;
        }


    }
}
