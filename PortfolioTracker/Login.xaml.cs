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
using System.Windows.Shapes;
using DataLayer;
//using DomainClasses.StockQuoteService;


namespace PortfolioTracker {
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window {
        private Query q;
        public Login() {
            InitializeComponent();
            //var client = new StockQuoteSoapClient();
            //var result = client.GetQuote("ibm, msft");
            q = new Query();
            new MockUser("fabio", "scopel");
            }

        private void Button_Click(object sender, RoutedEventArgs e) {
        if(q.CheckUserAuthetication(TbUser.Text, TbPass.Text)) {

            this.Hide();
            var win = new MainWindow();
            win.Show();

            }
        else {
            MessageBox.Show("username or password is invalid");

            }

            }
        }
    }
