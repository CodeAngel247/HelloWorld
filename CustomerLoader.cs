using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strike2
{
    public class CustomerLoader
    {

        public List<Customer> Customers
        {
            get 
            { 
                return LoadCustomers();  
            }
            set 
            {
                Customers = value;
            }
        }


        public List<Customer> LoadCustomers()
        {
            var customersToLoad = new List<Customer>();

            customersToLoad.Add(new Customer(true, "Emily", 5, false, 1, "Description Here"));
            customersToLoad.Add(new Customer(true, "Olivia", 5, false, 1, "Description Here"));
            customersToLoad.Add(new Customer(true, "Joshua", 5, false, 1, "Description Here"));
            customersToLoad.Add(new Customer(true, "Linda", 5, false, 1, "Description Here"));
            customersToLoad.Add(new Customer(true, "Paul", 5, false, 1, "Description Here"));

            return customersToLoad;
        }
    }
}
