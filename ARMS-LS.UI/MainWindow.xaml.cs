using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ARMS_LS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CustomerPage customerPage = new CustomerPage();
        CustomerHistoryPage customerHistory = new CustomerHistoryPage();
        ChargesPage chargesPage = new ChargesPage();
        PaymentsPage paymentsPage = new PaymentsPage();
        ToolsPage toolsPage = new ToolsPage();

        public static Frame? StaticMainFrame;
        public MainWindow()
        {
            InitializeComponent();
            StaticMainFrame = MainFrame;
        }

        private void btn_Customer_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = customerPage;
        }

        private void btn_Customer_History_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = customerHistory;
        }

        private void btn_Charges_Page_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = chargesPage;
        }

        private void btn_Payments_Page_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = paymentsPage;
        }

        private void btn_Tools_Page_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = toolsPage;
        }
    }
}