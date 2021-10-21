using System;
using System.Linq;
using System.Windows;
using WPFApp1.Model.AppDBcontext;
using WPFApp1.Model.Repositories.Intefaces;

namespace WPFApp1.Model.Repositories
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly ProjectStDBEntities _appDBcontext;
        public int CustomerID { get; set; }

        public CustomersRepository(ProjectStDBEntities appDBcontext)
        {
            _appDBcontext = appDBcontext;
        }

        public bool AddNewCustomer(Customers customer)
        {
            try
            {
                _ = _appDBcontext.Customers.Add(customer);
                _appDBcontext.SaveChanges();
            }
            catch (Exception)
            {
                _ = MessageBox.Show("Exception", "Ошибка ", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        public IQueryable<Customers> GetAllActiveCustommers()
        {
            var activecustomerslist = _appDBcontext.Customers.Where(x => x.Status == true).OrderBy(y => y.Customer_Name);
            return activecustomerslist;
        }

        public IQueryable<Customers> GetAllCustommers()
        {
            var customerslist = _appDBcontext.Customers;
            return customerslist;
        }

        public Customers GetThisCustomer(int customerID)
        {
            var customer = _appDBcontext.Customers.FirstOrDefault(x => x.ID == customerID);
            return customer;
        }

        public bool UpdateCustomer(Customers customer)
        {
            var editedobjekt = _appDBcontext.Customers.Find(customer.ID);
            if (editedobjekt == null)
            {
                return false;
            }
            try
            {
                _appDBcontext.Entry(editedobjekt).CurrentValues.SetValues(customer);
                _ = _appDBcontext.SaveChanges();
            }
            catch (Exception)
            {
                _ = MessageBox.Show("Exception", "Ошибка ", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
    }
}