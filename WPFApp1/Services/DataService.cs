using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPFApp1.Model;
using WPFApp1.Model.AppDBcontext;

namespace WPFApp1.Services
{
    public class DataService
    {
        public int TTNID { get; set; }
        public int TenderID { get; set; }
        public int ObjektID { get; set; }
        public int ContractID { get; set; }
        public int UserId { get; set; }
        public int CurrentObjektID { get; set; }
        private readonly StDBEntities _datacontext;


        public DataService(StDBEntities datacontext)
        {
            _datacontext = datacontext;
        }

        #region Проекты
        public List<Main_Reestr> GetObject()
        {
            var ter = _datacontext.Main_Reestr.ToList();
            return ter;
        }


        public void GetCurrentObjektID(Main_Reestr objekt)
        {
            CurrentObjektID = objekt.ID;
        }

        public bool CheckCustomerID(string name)
        {
            var test = _datacontext.Customers.Any(x => x.Customer_Name.Equals(name));
            return test;
                
        }

        public Main_Reestr GetCurrentObjektInfo(int guid)
        {
            var objekt = _datacontext.Main_Reestr.FirstOrDefault(x => x.ID == guid);
            return objekt;
        }

        public List<Main_Reestr> GetDataToView()
        {
            var objekt = _datacontext.Main_Reestr.ToList();
            return objekt;
        }
        public void AddNewObjekt(Main_Reestr objekt)
        {
            _ = _datacontext.Main_Reestr.Add(objekt);
            _ = _datacontext.SaveChanges();
        }

        public List<Contracts> GetContractsForCurrentObjekt(int id)
        {
            var current = _datacontext.Contracts.Where(x => x.IDKey == id).ToList();
            return current;
        }


        public List<Tenders> GetTendersForCurrentObject(int id)
        {
            var current = _datacontext.Tenders.Include(x => x.Main_Reestr).Where(x => x.IDKey == id).ToList();
            return current;
        }


        public List<TTN> GetTTNsForCurrentObjekt(int id)
        {
            var ttnlist = _datacontext.TTN.Include(x => x.Contracts.Main_Reestr)
                                          .Where(x => x.Contracts.Main_Reestr.ID == id)
                                          .ToList();
            return ttnlist;
        }

        public void UpdateObjekt(Main_Reestr objekt)
        {
            var updateobjekt = _datacontext.Main_Reestr.Find(objekt.ID);
            try
            {
                _datacontext.Entry(updateobjekt).CurrentValues.SetValues(objekt);
                _ = _datacontext.SaveChanges();
            }
            catch (Exception)
            {
                _ = MessageBox.Show("Ошибка! Проверьте правильность заполнения полей данных!", "Ошибка ввода данных", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        public bool CheckObjektRegistrationNumber(int ObjektNumber)
        {
            var test = _datacontext.Main_Reestr.Any(x => x.Doc_Number == ObjektNumber);
            return test;
        }



        #endregion

        #region Договора
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


        public Contracts GetCurrentConract(int id)
        {
            var contract = _datacontext.Contracts.FirstOrDefault(x => x.ID == id);
            return contract;
        }
        public Documentation GetDocumentationDataForCurrentContract(int id)
        {
            var documentation = _datacontext.Documentation.FirstOrDefault(x => x.ContractID == id);
            return documentation;
        }

        public bool CheckContractRegistrationNumber(int number)
        {
            var test = _datacontext.Contracts.Any(x => x.Contract_Number == number);
            return test;
        }
        public void GetContractID(Contracts contract)
        {
            ContractID = contract.ID;
        }

        public void AddNewContract(Contracts contract)
        {
            _ = _datacontext.Contracts.Add(contract);
            _ = _datacontext.SaveChanges();
        }

        public void AddNewDocumentation(Documentation documentation)
        {
            _ = _datacontext.Documentation.Add(documentation);
            _ = _datacontext.SaveChanges();
        }

        public void RemoveCurrentContract(int ContractID)
        {
            Documentation documentation = _datacontext.Documentation.FirstOrDefault(x => x.ContractID == ContractID);
            _ = _datacontext.Documentation.Remove(documentation);
            Contracts contract = _datacontext.Contracts.FirstOrDefault(x => x.ID == ContractID);
            _ = _datacontext.Contracts.Remove(contract);
            _ = _datacontext.SaveChanges();
        }

        public void UpdateContract(Contracts contract, Documentation documentation)
        {
            var updatecontract = _datacontext.Contracts.Find(contract.ID);
            var updatedocumentation = _datacontext.Documentation.Find(documentation.ID);
            try
            {
                _datacontext.Entry(updatecontract).CurrentValues.SetValues(contract);
                _datacontext.Entry(updatedocumentation).CurrentValues.SetValues(documentation);
                _ = _datacontext.SaveChanges();
            }
            catch (Exception)
            {
                _ = MessageBox.Show("Ошибка! Проверьте правильность заполнения полей данных!", "Ошибка ввода данных", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
        #endregion

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
            var user = _datacontext.Users_DB.FirstOrDefault(x => x.ID == id);
            return user;

        }

        public void Update(Users_DB user)
        {
            var editedobjekt = _datacontext.Users_DB.Find(user.ID);
            if (editedobjekt == null)
            {
                return;
            }

            try
            {
                _datacontext.Entry(editedobjekt).CurrentValues.SetValues(user);
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

        public List<Respons_persons> GetAllRespPersons()
        {
            var typelist = _datacontext.Respons_persons.ToList();
            return typelist;
        }

        #region Тендеры

        public void GetCurrentTenderID(Tenders tender)
        {
            TenderID = tender.ID;
        }

        public Tenders GetCurrentTender(int TenderID)
        {
            var tender = _datacontext.Tenders.FirstOrDefault(x => x.ID == TenderID);
            return tender;
        }
        public bool CheckTenderRegistrationNumber(string number)
        {
            var test = _datacontext.Tenders.Any(x => x.Tender_number.Equals(number));
            return test;
        }

        public void AddNewTender(Tenders tender)
        {
            _ = _datacontext.Tenders.Add(tender);
            _ = _datacontext.SaveChanges();
        }

        public void RemoveCurrentTender(int TenderID)
        {
            Tenders tender = _datacontext.Tenders.FirstOrDefault(x => x.ID == TenderID);
            _ = _datacontext.Tenders.Remove(tender);
            _ = _datacontext.SaveChanges();
        }

        public void UpdateTender(Tenders tender)
        {
            var updatetender = _datacontext.Tenders.Find(tender.ID);
            try
            {
                _datacontext.Entry(updatetender).CurrentValues.SetValues(tender);
                _ = _datacontext.SaveChanges();
            }
            catch (Exception)
            {
                _ = MessageBox.Show("Ошибка! Проверьте правильность заполнения полей данных!", "Ошибка ввода данных", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        public List<Tenders> GetAllTenders()
        {
            var tenders = _datacontext.Tenders.ToList();
            return tenders;
        }

        #endregion

        #region TTN(TN)

        public void GetCurrentTTNID(TTN ttn)
        {
            TTNID = ttn.id;
        }

        public void RemoveCurrentTTN(int TTN_ID)
        {
            TTN ttn = _datacontext.TTN.FirstOrDefault(x => x.id == TTN_ID);
            _ = _datacontext.TTN.Remove(ttn);
            _ = _datacontext.SaveChanges();
        }

        public List<TTN> GetAllTTN()
        {
            var ttn_list = _datacontext.TTN.ToList();
            return ttn_list;
        }

        public void AddNewTTN(TTN ttn)
        {
            _ = _datacontext.TTN.Add(ttn);
            _ = _datacontext.SaveChanges();
        }

        public TTN GetCurrentTTN(int TTNid)
        {
            var ttn = _datacontext.TTN.FirstOrDefault(x => x.id == TTNid);
            return ttn;
        }

        public void UpdateTTN(TTN ttn)
        {
            var updatettn = _datacontext.TTN.Find(ttn.id);
            try
            {
                _datacontext.Entry(updatettn).CurrentValues.SetValues(ttn);
                _ = _datacontext.SaveChanges();
            }
            catch (Exception)
            {
                _ = MessageBox.Show("Ошибка! Проверьте правильность заполнения полей данных!", "Ошибка ввода данных", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        public bool CheckTTNRegistrationNumber(int TTN_Number)
        {
            var test = _datacontext.TTN.Any(x => x.Act_number == TTN_Number);
            return test;
        }
        #endregion
        public List<Customers> GetAllCustomers()
        {
            var customerslist = _datacontext.Customers.ToList();
            return customerslist;
        }
    }
}