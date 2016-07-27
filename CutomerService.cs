using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Strike2
{
  
    public class CustomerService 
    {
       
        private  CustomerViewModel _customerViewModel;

        public CustomerService(CustomerViewModel customerViewModel)
        {
            _customerViewModel = customerViewModel;
        }
        public IEnumerable<CustomerRetrievalPO> List
        {
            get
            {
                return  _customerViewModel.AvailableCustomers;
            }
            
        }
 
        public void Add()
        {
             _customerViewModel.ExecuteAddCustomer();
        }
 
        public void Delete(Customer entity)
        {
           //  _customerViewModel.Remove(entity);
           //  _customerViewModel.SaveChanges();
        }
 
        public void Update(Customer entity)
        {
           //  _customerViewModel.Entry(entity).State = System.Data.Entity.EntityState.Modified;
           //  _customerViewModel.SaveChanges();
            
        }
 
        public CustomerRetrievalPO FindCustomerById(int Id)
        {
            var result = (from r in _customerViewModel.AvailableCustomers
                            where r.CustomerID == Id select r).FirstOrDefault();
            return result; 
        }

	
        private List<Customer> allCustomers = new List<Customer>();
        public List<Customer> AllCustomers 
        { 
            
            get { return allCustomers; } 
            set { allCustomers = value; } 
        }
       

        public IEnumerable<Customer> QueryAllCustomers()
        {
        
            var resultCustomerList = new List<Customer>();
            var customerLoader = new CustomerLoader();
            var customerList = customerLoader.LoadCustomers();
            allCustomers = customerList;
            for (int customerCount = 0; resultCustomerList.Count < 5 || resultCustomerList == null; customerCount++)
            {
                resultCustomerList.Add(new Customer(
                    true,
                    "Elton John",
                    6,
                    false,
                    22,
                    "Description Of Elton John"
                ));
            }
            AllCustomers = resultCustomerList;
            return resultCustomerList;

        }
    }
}
