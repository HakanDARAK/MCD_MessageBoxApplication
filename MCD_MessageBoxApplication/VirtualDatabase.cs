using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCD_MessageBoxApplication
{
    public class VirtualDatabase
    {
        public static List<Customer> Customers;

        static VirtualDatabase()
        {
            Customers = new List<Customer>();
        }
    }
}
