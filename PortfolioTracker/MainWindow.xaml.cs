using System.Windows;

namespace PortfolioTracker {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            MyContentControl.Content = new Dashboard();
        }


        private void Dashboard_Click(object sender, RoutedEventArgs e)
        {
           MyContentControl.Content = new Dashboard();
            
        }

        private void Portfolio_Click(object sender, RoutedEventArgs e) {
        MyContentControl.Content = new PortfolioManager();


            }

        private void Reports_Click(object sender, RoutedEventArgs e)
        {
        MyContentControl.Content = new Reports();

        }

 
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
        MyContentControl.Content = new Login();


        }

        private void History_Click(object sender, RoutedEventArgs e)
        {
            MyContentControl.Content = new StockHistory();
            }
    }
    }
