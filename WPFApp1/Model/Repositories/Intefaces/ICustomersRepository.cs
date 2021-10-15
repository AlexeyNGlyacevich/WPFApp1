using System.Linq;
using WPFApp1.Model.AppDBcontext;

namespace WPFApp1.Model.Repositories.Intefaces
{
    public interface ICustomersRepository
    {
        int CustomerID { get; set;}

        IQueryable<Customers> GetAllCustommers();

        IQueryable<Customers> GetAllActiveCustommers();

        Customers GetThisCustomer(int customerID);

        bool AddNewCustomer(Customers customer);

        bool UpdateCustomer(Customers customer);



    }
}
