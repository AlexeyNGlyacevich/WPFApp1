using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFApp1.Model;
using WPFApp1.Model.AppDBcontext;

namespace WPFApp1.Services
{
    public class DataService
    {
        public int UserId { get; set; }
        public int Guid { get; set; }
        private readonly StDBEntities _datacontext;


        public DataService(StDBEntities datacontext)
        {
            _datacontext = datacontext;

        }


        public List<Main_Reestr> GetObject()
        {
            var ter = _datacontext.Main_Reestr.ToList();
            return ter;
        }


        public void GetData(int value)
        {
            Guid = value;
        }


        public List<Contracts> GetAllContracts()
        {
            var contracts = _datacontext.Contracts.ToList();
            return contracts;
        }

        public List<Contracts> GetContracts(int guid)
        {
            var contracts = _datacontext.Contracts.Where(x => x.IDKey == guid).ToList();
            return contracts;
        }

        public List<Main_Reestr> GetCurrentObjektInfo(int guid)
        {
            var contracts = _datacontext.Main_Reestr.Include(x => x.Customers)
                                                    .Include(x => x.Documentation)
                                                    .Where(x => x.ID == guid).ToList();
            return contracts;
        }

        public List<Objekt> GetDataToView()
        {
            var objekt = _datacontext.Main_Reestr
                             .Include(b => b.Respons_persons.First_Name)
                             .Include(x => x.Customers.Customer_Name)
                             .Select(x => new Objekt
                             {
                                 Id = x.ID,
                                 objectNumber = (int)x.Doc_Number,
                                 objectName = x.Object_name,
                                 projectType = x.project_type,
                                 stage = x.stage,
                                 customer = x.Customers.Customer_Name,
                                 resp_person = x.Respons_persons.First_Name
                             }).ToList();
            return objekt;


        }

        #region Добавление Удаление Редактирование Пользователей

        public List<User_Types> GetAllTypes()
        {
            var typelist = _datacontext.User_Types.ToList();
            return typelist;
        }

        public List<Users_DB> GetAllUsers()
        {
            var list = _datacontext.Users_DB.ToList();
            return list;
        }

        public void AddUser(Users_DB item)
        {
            _ = _datacontext.Users_DB.Add(item);
            _ = _datacontext.SaveChanges();
        }

        public void GetCurrentUserId(int value)
        {
            UserId = value;

        }
        public Users_DB GetCurrentUser(int id)
        {
            var user = _datacontext.Users_DB.FirstOrDefault(x=> x.ID == id);
            return user;

        }

        public void Update(Users_DB item)
        {
            var editedobjekt = _datacontext.Users_DB.Find(item.ID);
            if (editedobjekt == null) return;
            try
            {
                _datacontext.Entry(editedobjekt).CurrentValues.SetValues(item);
                _ = _datacontext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void RemoveUser(Users_DB item)
        {
            _ = _datacontext.Users_DB.Remove(item);
            _ = _datacontext.SaveChanges();
        }
        #endregion

        public void AddNewObjekt(Main_Reestr objekt)
        {
            _ = _datacontext.Main_Reestr.Add(objekt);
            _ = _datacontext.SaveChanges();
        }

        public List<Respons_persons> GetAllRespPersons()
        {
            var typelist = _datacontext.Respons_persons.ToList();
            return typelist;
        }
    }
}