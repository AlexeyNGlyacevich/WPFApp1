using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFApp1.Model.AppDBcontext;
using System.Data.Entity;

namespace WPFApp1.Model
{
    public class DBContextDataWorcker : BindableBase
    {
        public static List<Objekt> GetDataToView()
        {
            using (StDBEntities db = new StDBEntities())
            {
                List<Objekt> objekt = db.Main_Reestr.Include(b => b.Respons_persons.First_Name)
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
        }


        public static List<Contracts> GetDataToContracts<T>()
        {
            using (StDBEntities db = new StDBEntities())
            {
                var temp = db.Contracts.Include(x => x.Main_Reestr.ID).Include(x => x.Approval_List.Current_Values)
                                       .Include(x => x.Approval_List1.Current_Values)
                                       .ToList();
                return temp;
            }
        }



        public static bool ToLogin(string login, string pass, string usertype)
        {
            using (StDBEntities db = new StDBEntities())
            {
                bool answer = db.Users_DB.Include(x => x.User_Types.User_Type)
                                         .Any(x => x.UserLogin.Equals(login) &&
                                                 x.UserPass.Equals(pass) &&
                                                 x.User_Types.User_Type.Equals(usertype));
                return answer;
            }
        }


        public static string GetUserType(string login, string pass)
        {
            using (StDBEntities db = new StDBEntities())
            {
                string temp = db.Users_DB.Include(x => x.User_Types.User_Type)
                                         .Where(x => x.UserLogin == login && x.UserPass == pass)
                                         .Select(x => x.User_Types.User_Type)
                                         .FirstOrDefault();
                return temp;
            }
        }



    }
}
