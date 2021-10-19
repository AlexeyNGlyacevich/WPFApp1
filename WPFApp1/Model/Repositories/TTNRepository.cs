using System;
using System.Linq;
using System.Windows;
using WPFApp1.Model.AppDBcontext;
using WPFApp1.Model.Repositories.Intefaces;

namespace WPFApp1.Model.Repositories
{
    public class TTNRepository : ITTNRepository
    {
        protected int TTN_ID { get; private set; }
        private readonly ProjectStDBEntities _appDBcontext;

        public TTNRepository(ProjectStDBEntities appDBcontext)
        {
            _appDBcontext = appDBcontext;
        }

        public void SetTTN_ID(TTN ttn)
        {
            TTN_ID = ttn.id;
        }

        public int GetTTN_ID()
        {
            return TTN_ID;
        }

        public IQueryable<TTN> GetAllTTN()
        {
            var ttn_list = _appDBcontext.TTN.AsQueryable();
            return ttn_list;
        }

        public void RemoveCurrentTTN(int TTN_ID)
        {
            TTN ttn = _appDBcontext.TTN.FirstOrDefault(x => x.id == TTN_ID);
            _ = _appDBcontext.TTN.Remove(ttn);
            _ = _appDBcontext.SaveChanges();
        }

        public TTN GetCurrentTTN(int TTN_ID)
        {
            var ttn = _appDBcontext.TTN.FirstOrDefault(x => x.id == TTN_ID);
            return ttn;
        }

        public void AddNewTTN(TTN ttn)
        {
            _ = _appDBcontext.TTN.Add(ttn);
            _ = _appDBcontext.SaveChanges();
        }

        public void UpdateTTN(TTN ttn)
        {
            var updatettn = _appDBcontext.TTN.Find(ttn.id);
            try
            {
                _appDBcontext.Entry(updatettn).CurrentValues.SetValues(ttn);
                _ = _appDBcontext.SaveChanges();
            }
            catch (Exception)
            {
                _ = MessageBox.Show("Ошибка! Проверьте правильность заполнения полей данных!", "Ошибка ввода данных", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        public bool CheckTTNRegistrationNumber(int TTN_Number)
        {
            var test = _appDBcontext.TTN.Any(x => x.Act_number == TTN_Number);
            return test;
        }
    }
}
