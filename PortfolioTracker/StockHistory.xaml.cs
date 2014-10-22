using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
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
using DataLayer;
using DomainClasses;


namespace PortfolioTracker {
    /// <summary>
    /// Interaction logic for StockHistory.xaml
    /// </summary>
    public partial class StockHistory : UserControl {
        private readonly PortfolioTrackerConverterModel _db;
        public ObservableCollection<StockTimeSerie> StockTimeSeriesCollection {
            get;
            set;
            }

        public ObservableCollection<string> StockCollection {
            get;
            set;
            }



        public StockHistory() {
        _db = Db.ConnectionString;
            InitializeComponent();
           
        }
        private void BindGridData() {

            StockTimeSeriesCollection= new ObservableCollection<StockTimeSerie>();

        var query1 =(from s in _db.Stocks
                        where s.Symbol==cb.Text
                        select s.StockTimeSeries).FirstOrDefault().ToList();

            //Add each object to ObservableCollection
            foreach(var sts in query1) {
                StockTimeSeriesCollection.Add(sts);
                }

            //bind to grid
            DgStockHistory.ItemsSource = StockTimeSeriesCollection;

            }
 

        private void ComboboxLoaded(object sender, RoutedEventArgs e)
        {
            StockCollection = new ObservableCollection<string>();
          var query1 = from c in _db.Stocks select c.Symbol;

            var listing = query1.ToList();
            foreach (var pf in listing)
            {
                  StockCollection.Add(pf);
            }

            cb.ItemsSource = StockCollection;
       

        }


        private void submit_Click(object sender, RoutedEventArgs e) {
            BindGridData();

            }

        private void cancel_Click(object sender, RoutedEventArgs e) {

            }
    }
    }
