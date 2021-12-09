using System;
using System.Linq;
using System.Windows;
using WPFApp1.Model.AppDBcontext;
using WPFApp1.Model.Repositories.Intefaces;

namespace WPFApp1.Model.Repositories
{
    internal class TenderRepository : ITenderRepository
    {
        protected int TenderID { get; private set; }
        private readonly ProjectStDBEntities _appDBcontext;

        public TenderRepository(ProjectStDBEntities appDBcontext)
        {
            _appDBcontext = appDBcontext;
        }

        public void AddNewTender(Tenders tender)
        {
            _ = _appDBcontext.Tenders.Add(tender);
            _ = _appDBcontext.SaveChanges();
        }

        public bool CheckTenderRegistrationNumber(string number)
        {
            var test = _appDBcontext.Tenders.Any(x => x.Tender_number.Equals(number));
            return test;
        }

        public IQueryable<Tenders> GetAlltenders()
        {
            var tenders = _appDBcontext.Tenders;
            return tenders;
        }

        public Tenders GetCuttentTender(int TenderID)
        {
            var tender = _appDBcontext.Tenders.FirstOrDefault(x => x.ID == TenderID);
            return tender;
        }

        public int GetTenderID()
        {
            return TenderID;
        }

        public void RemoveCurrentTender(int TenderID)
        {
            Tenders tender = _appDBcontext.Tenders.FirstOrDefault(x => x.ID == TenderID);
            _ = _appDBcontext.Tenders.Remove(tender);
            _ = _appDBcontext.SaveChanges();
        }

        public void SetCurrentTenderID(Tenders tender)
        {
            TenderID = tender.ID;
        }

        public void UpdateTender(Tenders tender)
        {
            var updatetender = _appDBcontext.Tenders.Find(tender.ID);
            try
            {
                _appDBcontext.Entry(updatetender).CurrentValues.SetValues(tender);
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
