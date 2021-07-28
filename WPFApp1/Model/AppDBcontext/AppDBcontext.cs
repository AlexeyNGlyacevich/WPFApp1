using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WPFApp1.Model.AppDBcontext
{
    internal class AppDBcontext : DbContext
    {
        public AppDBcontext() : base("DBconnectionString")
        {
        }
    }
}
