using Microsoft.Data.SqlClient;
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
using ARMS_LS.Logic;
using ARMS_LS.Entities;
using System.Data;

namespace ARMS_LS
{
    /// <summary>
    /// Interaction logic for CustomerPage.xaml
    /// </summary>
    public partial class CustomerPage : Page
    {
        public CustomerPage()
        {
            InitializeComponent();

            //List<Entities.Customer> customers = new List<Entities.Customer>();
            //DataTable customersTable  = Logic.Customer.customerList("");
            //foreach (DataRow row in customersTable.Rows)
            //{
            //    customers.Add(new Entities.Customer
            //    {
            //        Id = Convert.ToInt32(row["CusNo"]),
            //        Name = row["Name"].ToString(),
            //        Address = row["Address"].ToString()
            //    });
            //}
            
            

            using (var context = new Entities.Models.ARMSls_DbContext())
            {
                var customers = context.Customers.ToList();
                // Now 'customers' contains a list of all customers entities
                customerList.ItemsSource = customers;

            }
        }
    }

    
}
