using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strike2
{

    public class CustomerRetrievalPO : INotifyPropertyChanged
    { 

        private Customer customer;
        public Customer Customer
        {
            get { return customer; }
            set { customer = value; }
        }

        public CustomerRetrievalPO(Customer customer)
        {
            this.customer = customer;
            this.CustomerID = customer.CustomerID;
            this.CustomerName = customer.CustomerName;
            this.Selected = customer.Selected;
            
        }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        #endregion


        #region Properties
        private int customerID;
        public int CustomerID
        {
            get
            {
                return customerID;
            }
            set
            {
                customerID = value;
                OnPropertyChanged("CustomerID");
            }
        }

        private string customerName;
        public string CustomerName
        {
            get
            {
                return customerName;
            }
            set
            {
                customerName = value;
                OnPropertyChanged("CustomerName");
            }
        }

        private bool selected;
        public bool Selected
        {
            get
            {
                return selected;
            }
            set
            {
                selected = value;
                OnPropertyChanged("Selected");
            }
        }
        #endregion

    }

}
