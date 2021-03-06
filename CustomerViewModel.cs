
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using System.Windows;
using System.Collections;


namespace Porcupine.ViewModels
{

    public class CustomerViewModel : NavigationAwareViewModel
    {
        private ICustomerRetrievalServiceFacade customerRetrievalServiceFacade;
        private INavigationService navigationService;
        private List<CustomerRetrievalPO> availableCustomers;
        private List<CustomerRetrievalPO> selectedCustomers;
        public List<CustomerRetrievalPO> AvailableCustomers
        {
            get { return availableCustomers; }
            private set { SetProperty(ref availableCustomers, value); }

        }
        public List<CustomerRetrievalPO> SelectedCustomers
        {
            get { return selectedCustomers; }
            private set { SetProperty(ref selectedCustomers, value); }
        }
        public ICommand ExecuteAddCustomerCommand { get; set; }
        public ICommand ExecuteRemoveCustomerCommand { get; set; }

        public CustomerViewModel(
        ICustomerRetrievalServiceFacade customerRetrievalServiceFacade, 
        INavigationService navigationService)
        {
            this.customerRetrievalServiceFacade = customerRetrievalServiceFacade;
            this.navigationService = navigationService;

            InitializeCustomerollections();
            InitializeCustomerCommands();
        }

        private void InitializeCustomerCollections()
        {
            availableCustomers = customerRetrievalServiceFacade.RetrieveAllCustomers().ToList();
            selectedCustomers = new List<CustomerRetrievalPO>() 
            { 
                new CustomerRetrievalPO()
                {
                    CustomerId = 0, 
                    CustomerName = "Sparkles", 
                    Description = "Like vampires from Twilight and Magic Mike",
                    Selected = false
                } 
            };
        }
        private void InitializeCustomerCommands()
        {
            ExecuteAddCustomerCommand = new DelegateCommand(ExecuteAddCustomer);
            ExecuteRemoveCustomerCommand = new DelegateCommand(ExecuteRemoveCustomer);
        }


        public void ExecuteAddCustomer()
        {
            AddingCustomersToPersistenceCollection();
        }

        private void ExecuteRemoveCustomer()
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

            if (SelectedTCustomers.Count > 1)
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


        public override bool IsNavigationTarget(INavigationContext context)
        {
            return false;
        }

        public override void OnNavigatedTo(INavigationContext context)
        {

        }

        public override void OnNavigatedFrom(INavigationContext context)
        {
            base.OnNavigatedFrom(context);
        }
    }
}

  

