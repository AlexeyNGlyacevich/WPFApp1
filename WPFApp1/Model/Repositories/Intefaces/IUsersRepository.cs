using System.Linq;
using WPFApp1.Model.AppDBcontext;

namespace WPFApp1.Model.Repositories.Intefaces
{
    public interface IUsersRepository
    {
        int UserID { get; set; }

        IQueryable<User_Types> GetAllTypes();

        IQueryable<Users_DB> GetAllUsers();

        bool AddUser(Users_DB user);

        void SetUserID(Users_DB user);

        Users_DB GetCurrentUser(int userID);

        void UpdateUser(Users_DB user);

        bool RemoveUser(Users_DB user);

        bool ByLogin(string login, string pass, string usertype);

        string GetUserType(string login, string pass);

    }
}
