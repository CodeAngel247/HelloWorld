using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows;
using System.ComponentModel;

namespace Strike2
{
    public class MainWindowViewModel
    {
            private CustomerViewModel customerViewModel;
            public CustomerViewModel CustomerViewModel
            {
                get { return customerViewModel; }
                set { customerViewModel = value; }
            }
            private string windowTitle;
            public string WindowTitle
            {
                get { return windowTitle; }
                set { windowTitle = value; }
            }

            public MainWindowViewModel(string windowTitle)
            {
                this.windowTitle = windowTitle;

                WindowTitle = windowTitle;
                var customerLoader = new CustomerLoader();
                InitializeCustomerCollections();
                var customerServiceFacade = new CustomerRetrievalServiceFacade();
                var allCustomers = customerServiceFacade.RetrieveAllCustomers(customerLoader);
            }

            private ICommand buttonCommand;
            public ICommand ButtonCommand
            {
                get
                {
                    return buttonCommand;
                }
                set
                {
                    buttonCommand = value;
                }
            }

            public void ShowMessage(object obj)
            {
                MessageBox.Show(obj.ToString());
            }


         private List<CustomerRetrievalPO> availableCustomers;
        public List<CustomerRetrievalPO> AvailableCustomers
        {
            get { return availableCustomers; }
            set
            {
                availableCustomers = value;
                OnPropertyChanged("AvailableCustomers");
            }

        }

        private List<CustomerRetrievalPO> selectedCustomers;
        public List<CustomerRetrievalPO> SelectedCustomers
        {
            get { return selectedCustomers; }
            set
            {
                selectedCustomers = value;
                OnPropertyChanged("SelectedCustomers");
            }
        }

        public ICommand ExecuteAddCustomerCommand { get; set; }
        public ICommand ExecuteRemoveCustomerCommand { get; set; }

        private void InitializeCustomerCollections()
        {
            this.selectedCustomers = new List<CustomerRetrievalPO>();
            var selectedCustomer =                new CustomerRetrievalPO(new Customer(
                    true,
                    "Sparkles",
                    666,
                    false,
                    4,
                    "Like Vampires and Magic Mike"));
            selectedCustomers.Add(selectedCustomer);
        }
        private void InitializeCustomersCommands()
        {
            //   ExecuteAddCustomerCommand = new DelegateCommand(ExecuteAddCustomer); 
            //   ExecuteRemoveCustomerCommand = new DelegateCommand(ExecuteRemoveCustomer);
        }


        public void ExecuteAddCustomer()
        {
            AddingCustomersToPersistenceCollection();
        }

        private void ExecuteRemoveTrait()
        {

        }

        private void AddingCustomersToPersistenceCollection()
        {
            foreach (var customer in AvailableCustomers)
            {
                if (customer.Selected && !AvailableCustomers.Contains(customer))
                {
                    SelectedCustomers.Add(customer);
                }
            }

            if (SelectedCustomers.Count >= 1)
            {
                foreach (var customer in SelectedCustomers)
                {
                    if (AvailableCustomers.Contains(customer))
                    {
                        AvailableCustomers.Remove(customer);
                    }
                }
            }
        }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler SetProperty;
        private void OnPropertyChanged(string propertyName)
        {
            if (SetProperty != null)
            {
                SetProperty(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion


    }
}