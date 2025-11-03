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
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Data;


namespace ARMS_LS.UI
{
    /// <summary>
    /// Interaction logic for TypeCodesFormPage.xaml
    /// </summary>
    public partial class TypeCodesFormPage : Page
    {
        public string? Code = "0";
        public Entities.Models.TypeCode oTypeCode = new Entities.Models.TypeCode();
        public TypeCodesFormPage(string? Code = "0")
        {
            InitializeComponent();
            this.Code = Code;
            using (var context = new Entities.Models.ARMSls_DbContext())
            {
                var oTypeCodes = context.TypeCodes.Find(this.Code);
                if (oTypeCodes != null)
                {
                    txtCode.Text = oTypeCodes.TypeCode1;
                    txtDescription.Text = oTypeCodes.Description;
                }
                this.oTypeCode = oTypeCodes!;
            }
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new Entities.Models.ARMSls_DbContext())
            {
                var oTypeCode = new Entities.Models.TypeCode();
                oTypeCode.TypeCode1 = txtCode.Text;
                oTypeCode.Description = txtDescription.Text;
                oTypeCode.Frequency = "A";
                oTypeCode.OpenInv = "A";
                oTypeCode.DateCreated = DateTime.Now;
                oTypeCode.LastModified = DateTime.Now;
                
                var transaction = context.Database.BeginTransaction(IsolationLevel.Serializable);

                if (this.Code == "0") {
                    context.TypeCodes.Add(oTypeCode);
                } else {
                    this.oTypeCode.TypeCode1 = txtCode.Text;
                    this.oTypeCode.Description = txtDescription.Text;
                    this.oTypeCode.Frequency = "A";
                    this.oTypeCode.OpenInv = "A";
                    //this.oTypeCode.DateCreated = DateTime.Now;
                    this.oTypeCode.LastModified = DateTime.Now;
                    context.Entry(this.oTypeCode).State = EntityState.Modified;
                }
                
                int updates = context.SaveChanges();
                transaction.Commit(); // solves the problem

                MainWindow.StaticMainFrame!.Content = new TypeCodesPage();
            }
        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.StaticMainFrame!.Content = new TypeCodesPage();
        }
    }
}
