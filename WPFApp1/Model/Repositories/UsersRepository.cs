using System;
using System.Linq;
using System.Windows;
using WPFApp1.Model.AppDBcontext;
using WPFApp1.Model.Repositories.Intefaces;

namespace WPFApp1.Model.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ProjectStDBEntities _appDbContext;
        public int UserID { get; set; }

        public UsersRepository(ProjectStDBEntities appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public bool AddUser(Users_DB user)
        {
            try
            {
                _ = _appDbContext.Users_DB.Add(user);
                _ = _appDbContext.SaveChanges();
            }
            catch (Exception)
            {
                _ = MessageBox.Show("Exception", "Ошибка ", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        public IQueryable<User_Types> GetAllTypes()
        {
            var typelist = _appDbContext.User_Types;
            return typelist;
        }

        public IQueryable<Users_DB> GetAllUsers()
        {
            var list = _appDbContext.Users_DB;
            return list;
        }

        public Users_DB GetCurrentUser(int UserID)
        {
            var user = _appDbContext.Users_DB.FirstOrDefault(x => x.ID == UserID);
            return user;
        }

        public bool RemoveUser(Users_DB user)
        {
            try
            {
                _ = _appDbContext.Users_DB.Remove(user);
                _ = _appDbContext.SaveChanges();
            }
            catch (Exception)
            {
                _ = MessageBox.Show("Exception", "Ошибка ", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        public void SetUserID(Users_DB user)
        {
            UserID = user.ID;
        }

        public void UpdateUser(Users_DB user)
        {
            var editedobject = _appDbContext.Users_DB.Find(user.ID);
            if (editedobject == null)
            {
                return;
            }

            try
            {
                _appDbContext.Entry(editedobject).CurrentValues.SetValues(user);
                _ = _appDbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ByLogin(string login, string pass, string usertype)
        {
            bool answer = _appDbContext.Users_DB.Any(x => x.UserLogin.Equals(login) &&
                                                          x.UserPass.Equals(pass) &&
                                                          x.User_Types.User_Type.Equals(usertype));
            return answer;
        }

        public string GetUserType(string login, string pass)
        {
            string temp = _appDbContext.Users_DB.Where(x => x.UserLogin == login && x.UserPass == pass)
                                                .Select(x => x.User_Types.User_Type)
                                                .FirstOrDefault();
            return temp;
        }
    }
}
