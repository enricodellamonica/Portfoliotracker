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

namespace PortfolioTracker {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
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
    }
    }
