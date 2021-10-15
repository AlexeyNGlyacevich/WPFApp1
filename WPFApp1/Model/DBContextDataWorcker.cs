﻿using DevExpress.Mvvm;
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





        public static bool ToLogin(string login, string pass, string usertype)
        {
            using (ProjectStDBEntities db = new ProjectStDBEntities())
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
            using (ProjectStDBEntities db = new ProjectStDBEntities())
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
