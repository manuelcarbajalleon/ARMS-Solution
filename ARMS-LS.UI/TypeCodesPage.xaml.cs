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
using Microsoft.VisualBasic;
using System.Windows.Controls.Primitives;
using System.Reflection;
using ARMS_LS.UI;
using static ARMS_LS.TypeCodesPage;
namespace ARMS_LS
{
    /// <summary>
    /// Interaction logic for TypeCodesPage.xaml
    /// </summary>
    public partial class TypeCodesPage : Page
    {

        
        public TypeCodesPage()
        {
            InitializeComponent();
            
            Refresh();
            
            //using (var context = new Entities.Models.ARMSls_DbContext())
            //{
            //    var typeCodes = context.TypeCodes.ToList();
            //    // Now 'customers' contains a list of all customers entities
            //    typeCodesList.ItemsSource = typeCodes;
            //}
        }

        private void Refresh()
        {
            List< TypeCodeViewModel> lst = new List< TypeCodeViewModel>();
            using (var context = new Entities.Models.ARMSls_DbContext())
            { 
                lst = (from d in context.TypeCodes
                       select new TypeCodeViewModel
                       {
                           Code = d.TypeCode1,
                           Description = d.Description
                       }).ToList();
            }
            typeCodesList.ItemsSource = lst;
        }
        public class TypeCodeViewModel
        {
            public string? Code { get; set; }
            public string? Description { get; set; }
        }
        private void typeCodesList_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            //if (e.Column.Header.ToString() != "Code" && e.Column.Header.ToString() != "Description"
            //    && e.Column.Header.ToString() != "")
            //{
            //    e.Column.Visibility = Visibility.Collapsed;
            //}
            //else
            //{
            //    
                e.Column.HeaderStyle = new Style(typeof(DataGridColumnHeader));
                e.Column.HeaderStyle.Setters.Add(new Setter(DataGridColumnHeader.HorizontalContentAlignmentProperty, HorizontalAlignment.Center));
                e.Column.HeaderStyle.Setters.Add(new Setter(DataGridColumnHeader.FontWeightProperty, FontWeights.Bold));
            //
                if (e.Column.Header.ToString() == "Description")
                {
                    e.Column.Width = 203;
                }
            //    else {
            //        e.Column.Header = "Code";
            //    }
            //    
            //}
            //Console.Write("Column:" + e.Column.Header.ToString());
        }

        private void typeCodesList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGridRow? row = sender as DataGridRow;
            
            using (var context = new Entities.Models.ARMSls_DbContext())
            {
                if (row != null && row.IsSelected)
                {
                    // Get the data item associated with the clicked row
                    // This will be of the type you are binding to your DataGrid
                    var clickedItem = row.DataContext;
                    string propertyName = "Code";

                    // Get the Type of the object
                    Type type = clickedItem.GetType();

                    // Get the PropertyInfo for the specified property name
                    PropertyInfo? property = type.GetProperty(propertyName);

                    object? value = property!.GetValue(clickedItem, null);

                    //var clickedItem1 = clickedItem.GetType().GetProperty("TypeCode1");
                    // Perform actions based on the clicked row, e.g., display details
                    MessageBox.Show($"Clicked on item: {value!.ToString()}");
                }
            }

            

            
        }
        private void btn_Select_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            TypeCodesFormPage typeCodesFormPage = new TypeCodesFormPage("0");
            TypeCodeFrame.Content = typeCodesFormPage;
        }

        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            if (typeCodesList.SelectedItem != null)
            {
                // The SelectedItem will be of the type of your data source's items.
                // For example, if your DataGrid is bound to a list of 'MyDataItem' objects,
                // then SelectedItem will be an instance of 'MyDataItem'.
                TypeCodeViewModel? selectedItem = typeCodesList.SelectedItem as TypeCodeViewModel;

                if (selectedItem != null)
                {


                    // Now, you can access the properties of the selectedItem object.
                    // Replace 'PropertyName' with the actual name of the property
                    // that corresponds to the column you want to get the value from.
                    string? cellValue = selectedItem.Code;
                    
                    if (cellValue != null)
                    {
                        TypeCodesFormPage typeCodesFormPage = new TypeCodesFormPage(cellValue);
                        TypeCodeFrame.Content = typeCodesFormPage;
                    }                 

                }
            }
            else
            {
                MessageBox.Show("Please select an item to edit.", "No Item Selected", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            
        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (typeCodesList.SelectedItem != null)
            {
                MessageBoxResult result = MessageBox.Show(
                       "Are you sure you want to delete this item?",
                       "Confirm Deletion",
                       MessageBoxButton.YesNo,
                       MessageBoxImage.Warning
                   );

                if (result == MessageBoxResult.Yes)
                {

                    // The SelectedItem will be of the type of your data source's items.
                    // For example, if your DataGrid is bound to a list of 'MyDataItem' objects,
                    // then SelectedItem will be an instance of 'MyDataItem'.
                    TypeCodeViewModel? selectedItem = typeCodesList.SelectedItem as TypeCodeViewModel;

                    if (selectedItem != null)
                    {


                        // Now, you can access the properties of the selectedItem object.
                        // Replace 'PropertyName' with the actual name of the property
                        // that corresponds to the column you want to get the value from.
                        string? cellValue = selectedItem.Code;
                        using (var context = new Entities.Models.ARMSls_DbContext())
                        {
                            var oTypeCodes = context.TypeCodes.Find(cellValue);
                            if (oTypeCodes != null)
                            {
                                context.TypeCodes.Remove(oTypeCodes);
                                context.SaveChanges();
                                Refresh();
                            }
                        }
                        // You can then cast 'cellValue' to its specific type if needed.
                        // string stringValue = cellValue as string; 
                        // int intValue = (int)cellValue; 

                    }
                    
                }
                
            }
            else
            {
                MessageBox.Show("Please select an item to delete.", "No Item Selected", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btn_Print_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_List_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
