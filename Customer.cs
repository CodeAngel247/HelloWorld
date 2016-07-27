using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strike2
{
    public class Customer
    {
         public bool Selected { get; set; }
         public string CustomerName { get; set; }
         public int CustomerID { get; set; }
         public bool IsBiggerBetter { get; set; }
         public int Decimals {get; set; }
         public string Description { get; set; }

         public Customer(
             bool selected, 
             string customerName, 
             int customerID, 
             bool isBiggerBetter, 
             int decimals, 
             string description)
         {
             Selected = selected;
             CustomerName = customerName;
             CustomerID = customerID;
             IsBiggerBetter = isBiggerBetter;
             Decimals = decimals;
             Description = description;
         }
    }
}
