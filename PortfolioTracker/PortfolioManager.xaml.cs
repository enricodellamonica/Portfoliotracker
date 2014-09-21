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


namespace PortfolioTracker {
    /// <summary>
    /// Interaction logic for PortfolioManager.xaml
    /// </summary>
    public partial class PortfolioManager : UserControl {
        private readonly PortfolioTrackerConverterModel _db;
        private int _id;
        public ObservableCollection<Portfolio> PortfolioList {
            get;
            set;
            }

        public PortfolioManager() {
            _db = Db.ConnectionString;
            InitializeComponent();
            BindGridData();

            }

        private void BtnSave_Click(object sender, RoutedEventArgs e) {
            SavePortfolio(_id);

            }
        private void BindGridData() {
            // Instantiate ObservableCollection
            PortfolioList = new ObservableCollection<Portfolio>();

            // Get Portfolio List from DB
            var list = _db.Portfolios.ToList();

            //Add each object to ObservableCollection
            foreach(var portfolio in list) {
                PortfolioList.Add(portfolio);
                }

            //bind to grid
            DgPortfolio.ItemsSource = PortfolioList;

            }

        private void SavePortfolio(int id)
        {
            //if id is supplied it means its an Update
            if (id > 0)
            {
                var portfolio = _db.Portfolios.Find(id);
                portfolio.Name = txtPortfolioName.Text;
                //portfolio.User= MockUser

            }
            else
            {
                var portfolio = new Portfolio()
                {
                    Name = txtPortfolioName.Text,
                    //User = 
                };
                _db.Portfolios.Add(portfolio);
                

            }
            _db.SaveChanges();
            _id = 0;
            BindGridData();
        }


        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            var item = (Portfolio)DgPortfolio.SelectedItem;
            if(item != null) {
                _id = item.Id;
                txtPortfolioName.Text = item.Name;
                }
        }

        private void Stocks_Click(object sender, RoutedEventArgs e)
        {
            var window2 = Application.Current.Windows
            .Cast<Window>()
            .FirstOrDefault(window => window is MainWindow) as MainWindow;
            var item = (Portfolio)DgPortfolio.SelectedItem;
           
            if (window2 != null) window2.Content = new StockManager( item.Id );
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var item = (Portfolio)DgPortfolio.SelectedItem;
            if(item != null) {
            _id = item.Id;
            var portfolio = _db.Portfolios.Find(_id);
                _db.Portfolios.Remove(portfolio);
                _db.SaveChanges();
                _id = 0;
                BindGridData();
                MessageBox.Show("Record deleted!!");


                }
        }


    }
    }
