using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strike2
{
    public class CustomerRetrievalServiceFacade 
    {



        public CustomerRetrievalServiceFacade()
        {
            var customerLoader = new CustomerLoader();
            var customers = RetrieveAllCustomers(customerLoader);
        }

        public IEnumerable<CustomerRetrievalPO> RetrieveAllCustomers(CustomerLoader customerLoader)
        {

            List<Customer> customerList = customerLoader.LoadCustomers().ToList();
            
            List<CustomerRetrievalPO> result = new List<CustomerRetrievalPO>();

            foreach (Customer customer in customerList)
            {
                result.Add(ConvertDMCustomerToCustomerPO(customer));
            }
            return result;

        }

        private CustomerRetrievalPO ConvertDMCustomerToCustomerPO(Customer customer)
        {
            return new CustomerRetrievalPO(customer)
            {
                Selected = customer.Selected,
                CustomerName = customer.CustomerName,
                CustomerID = customer.CustomerID
            };
        }
    }
}
