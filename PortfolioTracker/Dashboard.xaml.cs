using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using DomainClasses;
using System.Windows.Threading;

namespace PortfolioTracker {
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : UserControl {
        public ObservableCollection<PortfolioReturn.PortfolioReturnFields> PortfolioReturnList {
            get;
            set;
            }

        public ObservableCollection<string> Portfoliolist {
            get;
            set;
            }

        private readonly PortfolioTrackerConverterModel _db;


        public Dashboard() {
        _db = Db.ConnectionString;
            InitializeComponent();

            }

        private void BindGridData() {
            // Instantiate ObservableCollection
            PortfolioReturnList = new ObservableCollection<PortfolioReturn.PortfolioReturnFields>();

            // Get Portfolio List from DB
            var portfolioReturn = new PortfolioReturn(cb.Text);
            var stockList= portfolioReturn.StockList();
            //Add each object to ObservableCollection
            foreach(var stocks in stockList) {
                PortfolioReturnList.Add(stocks);
                }

            //bind to grid
            DgDashboard.ItemsSource = PortfolioReturnList;

            }

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
          Portfoliolist = new ObservableCollection<string>();
          var query1 = from c in _db.Portfolios select c.Name;

            var listing = query1.ToList();
            foreach (var pf in listing)
            {
                  Portfoliolist.Add(pf);
            }

            cb.ItemsSource = Portfoliolist;
        }

        private void BtSubmit_Click(object sender, RoutedEventArgs e) {
            BindGridData();

            }
    }
    }
