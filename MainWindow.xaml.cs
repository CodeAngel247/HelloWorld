using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Strike2
{

    public partial class MainWindow : Window
    {
        private MainWindowViewModel mainWindowViewModel;
        public MainWindowViewModel MainWindowViewModel
        {
                   get
                   {
                       return mainWindowViewModel;
                   }
                    set
                    { 
                        mainWindowViewModel = value; 
                    }
         }

        public string MyTitle 
        { 
                get 
                { 
                    return "Strike2"; 
                } 
                set 
                { 
                    mainWindowViewModel.WindowTitle = value; 
                } 
        }


        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(PageLoaded);
            var customerRetrievalServiceFacade = new CustomerRetrievalServiceFacade();
            mainWindowViewModel = new MainWindowViewModel(MyTitle);
            this.DataContext = mainWindowViewModel;
            var Button = new Button();
            this.Button.Click += new RoutedEventHandler(ButtonClick);
            var customerViewModel = mainWindowViewModel.CustomerViewModel;
       //     var customerService = new CustomerService(customerViewModel);

        }

        void ButtonClick(object sender, RoutedEventArgs e)
        {
            var repository = new CustomerLoader().LoadCustomers();
            var retrieveData = new SpreadsheetService();
        }

         
        void PageLoaded(object sender, RoutedEventArgs e)
        {
            Customer customer = new Customer(true, "Emily", 45, false, 10, "Embarassing");
        }

        private void ListViewEmployeeDetails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

  
    }
}
