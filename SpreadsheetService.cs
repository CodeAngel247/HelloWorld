using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.IO;
using Microsoft.Office.Interop.Excel;
using System.Windows; 


namespace Strike2
{
    public class SpreadsheetService
    {
        private Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
        private Worksheet objsheet = null;
        private string workbookPath = "C:/Users/esvensson/Desktop/MyCustomerDB.xlsx";

        private ObservableCollection<string> cells = new ObservableCollection<string>();
        public ObservableCollection<string> Cells
        {
            get { return cells; }
            set { cells = value; }
        }

        private List<Customer> customers;
        public List<Customer> Customers
        {
            get { return customers; }
            set { customers = value; }
        }

        private Customer customer;
        public Customer Customer
        {
            get;
            set;
        }
        private CustomerRetrievalPO entry;
        public  CustomerRetrievalPO Entry
        {
            get { return entry; }
            set { entry = value; }

        }

        ObservableCollection<int> sampleData = new ObservableCollection<int>();
        public ObservableCollection<int> SampleData
        {
            get
            {         
                return sampleData;
            }
            set
            {
                sampleData = value;
            }
        }

        public SpreadsheetService()
        {
            excelApp.Visible = true;
            objsheet = OpenExcelWorkbook(workbookPath, objsheet, excelApp);
            Cells = ReadExcelSheet(objsheet, excelApp);
            customer = new Customer(true, "Yoda", 666, false, 4, "Use the force, Luke!");
            Entry = new CustomerRetrievalPO(customer);
            Entry.CustomerID = 666;
            Entry.CustomerName = "Benjamin Button";
            if (sampleData.Count <= 4)
            {
                sampleData.Add(1);
                sampleData.Add(2);
                sampleData.Add(3);
                sampleData.Add(4);
            }
            SampleData = sampleData;
        }

        private Worksheet OpenExcelWorkbook(string workbookPath, Worksheet objsheet, Microsoft.Office.Interop.Excel.Application excelApp)
        {
                if (System.IO.File.Exists(workbookPath))
                {
                    var newWorkbook = excelApp.Workbooks.Open(workbookPath, true, true);
                    objsheet = (Worksheet)excelApp.ActiveWorkbook.ActiveSheet;
                }
                else
                {
                    MessageBox.Show("Unable to open file!");
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
                    excelApp = null;
                }
                return objsheet;
        }

        private ObservableCollection<string> ReadExcelSheet(Worksheet objsheet, Microsoft.Office.Interop.Excel.Application excelApp)
        {
            var range = objsheet.UsedRange;
            for (int rCnt = 1; rCnt <= 6; rCnt++)
            {
                for (int cCnt = 1; cCnt <= 3; cCnt++)
                {
                    var cellContent = ((range.Cells[rCnt, cCnt] as Microsoft.Office.Interop.Excel.Range).Value2).ToString();             
                    cells.Add(cellContent);
                }      
            }
            return cells;
        }

        public ObservableCollection<string> RetrieveCellContent()
        {
            return cells;
        }


    }
            
}
