using System;
using System.Linq;
using System.Windows;
using WPFApp1.Model.AppDBcontext;
using WPFApp1.Model.Repositories.Intefaces;

namespace WPFApp1.Model.Repositories
{
    public class ContractRepository : IContractRepository
    {
        private readonly ProjectStDBEntities _appDBcontext;
        private readonly IResponsPersonsRepository _responsPersons;
        public int ContractID { get; set; }
        public int ProjektID { get; set; }

        public ContractRepository(ProjectStDBEntities appDBcontext, IResponsPersonsRepository responsPersons)
        {
            _appDBcontext = appDBcontext;
            _responsPersons = responsPersons;
        }

        public bool AddNewContract(Contracts contract)
        {
            try
            {
                _ = _appDBcontext.Contracts.Add(contract);
                _ = _appDBcontext.SaveChanges();
            }
             catch (Exception)
            {
                _ = MessageBox.Show("Exception", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return true;
        }

        public bool AddNewDocumentation(Documentation documentation)
        {
            try
            {
                _ = _appDBcontext.Documentation.Add(documentation);
                _ = _appDBcontext.SaveChanges();
            }
            catch (Exception)
            {
                _ = MessageBox.Show("Exception", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return true;
        }

        public bool CheckContractRegistrationNumber(string number)
        {
            var test = _appDBcontext.Contracts.Any(x => x.Contract_Number == number);
            return test;
        }

        public IQueryable<Contracts> GetAllContracts()
        {
            var contracts = _appDBcontext.Contracts;
            return contracts;
        }

        public Contracts GetCurrentConract(int contractID)
        {
            var contract = _appDBcontext.Contracts.FirstOrDefault(x => x.ID == contractID);
            return contract;
        }

        public Documentation GetDocumentationDataForCurrentContract(int contractID)
        {
            var documentation = _appDBcontext.Documentation.FirstOrDefault(x => x.ContractID == contractID);
            return documentation;
        }

        public IQueryable<Contracts> GetProjektContracts(int projektID)
        {
            var contracts = _appDBcontext.Contracts.Where(x => x.IDKey == projektID);
            return contracts;
        }

        public bool RemoveCurrentContract(int contractID)
        {
            try
            {
                Documentation documentation = _appDBcontext.Documentation.FirstOrDefault(x => x.ContractID == contractID);
                _ = _appDBcontext.Documentation.Remove(documentation);
                Contracts contract = _appDBcontext.Contracts.FirstOrDefault(x => x.ID == contractID);
                _responsPersons.RemoveResponcePersonsByContract(contract);
                _ = _appDBcontext.Contracts.Remove(contract);
                _ = _appDBcontext.SaveChanges();
            }
            catch (Exception)
            {
                _ = MessageBox.Show("Exception", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return true;

        }

        public void SetContractID(Contracts contract)
        {
            ContractID = contract.ID;
        }

        public void UpdateContract(Contracts contract, Documentation documentation)
        {
            var updatecontract = _appDBcontext.Contracts.Find(contract.ID);
            var updatedocumentation = _appDBcontext.Documentation.Find(documentation.ID);
            try
            {
                _appDBcontext.Entry(updatecontract).CurrentValues.SetValues(contract);
                _appDBcontext.Entry(updatedocumentation).CurrentValues.SetValues(documentation);
                _ = _appDBcontext.SaveChanges();
            }
            catch (Exception)
            {
                _ = MessageBox.Show("Ошибка! Проверьте правильность заполнения полей данных!", "Ошибка ввода данных", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        public IQueryable<Currency_type> GetAllTypes()
        {
            return _appDBcontext.Currency_type;
        }
    }
}
