using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using System.Xml;
using System.Xml.Serialization;
using DataLayer;
using DomainClasses;
using DomainClasses.StockQuoteService;
using System.Xml.Linq;

namespace PortfolioTracker {
    /// <summary>
    /// Interaction logic for StockManager.xaml
    /// </summary>
    public partial class StockManager : UserControl {
        private readonly PortfolioTrackerConverterModel _db;
        private int _id;
        private Portfolio _portfolio;
        private StockQuote.StockQuotes _stockQuotes;
        private StockTimeSerie _stockTimeSerie;
        private Stock _stock;

        public ObservableCollection<Stock> StockCollection {
            get;
            set;
            }
        
        public StockManager( int id) {
            _db = Db.ConnectionString;
            InitializeComponent();

            _portfolio = _db.Portfolios.Find(id);
            _portfolio.Stocks = new List<Stock>();
            PortfolioName.Content = _portfolio.Name;

            BindGridData();

        }

        private void BindGridData() {
            // Instantiate ObservableCollection
            StockCollection = new ObservableCollection<Stock>();

            // Get Portfolio List from DB
            var list = _db.Stocks.ToList();

            //Add each object to ObservableCollection
            foreach(var stock in list) {
                StockCollection.Add(stock);
                }

            //bind to grid
            DgStock.ItemsSource = StockCollection;

            }
        private void SaveStock(int id) {

            //if id is supplied it means its an Update
            if(id > 0) {               
                _stock = _db.Stocks.Find(id);
                _stock.Symbol = TbSymbol.Text;
                _stock.Quantity =int.Parse(TbQuantity.Text);
                _stock.PurchaseRate = decimal.Parse(TbPrice.Text);
               _stock.StockName = LbCompanyName.Content.ToString();


            }
            else
            {
                
                _stock = new Stock() {
                Symbol = TbSymbol.Text,
                Quantity =int.Parse(TbQuantity.Text),
                PurchaseRate = decimal.Parse(TbPrice.Text),
                StockName = LbCompanyName.Content.ToString(),
                
                };

                
               

                _stock.StockTimeSeries.Add(_stockTimeSerie);
                
                _db.Stocks.Add(_stock);
                
               
                //only instantiate one property because it is null

     
                _portfolio.Stocks.Add(_stock);
           
                

            }

            _db.SaveChanges();
            _id = 0;
            BindGridData();

            }



        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            var item = (Stock)DgStock.SelectedItem;
            if(item != null) {
                _id = item.Id;
                TbSymbol.Text = item.Symbol;
                TbQuantity.Text = item.Quantity.ToString();
                TbPrice.Text = item.PurchaseRate.ToString();
                LbCompanyName.Content = item.StockName;
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var item = (Stock)DgStock.SelectedItem;
            if(item != null) {
                _id = item.Id;
                var stock = _db.Stocks.Find(_id);
                _db.Stocks.Remove(stock);
                _db.SaveChanges();
                _id = 0;
                BindGridData();
                MessageBox.Show("Record deleted!!");


                }
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e) {

       

            var client = new StockQuoteSoapClient();
            var result = client.GetQuote(TbSymbol.Text);
            // instantiate serializer
            var serializer = new XmlSerializer(typeof(StockQuote.StockQuotes));


            // Read results to a reader
            using(var reader = new StringReader(result)) {
                // We are doing DESERIALIZING opertion of XML Serializer.
                // As we are receiving serialized response from service we have to desirialize it to populate Model
                _stockQuotes = (StockQuote.StockQuotes)serializer.Deserialize(reader);

                }

            // check for null to avoid exception
            if(_stockQuotes != null) {
                //stockQuotes contains array of StockQuotesStock class in Stock property
                //so we loop through each
                foreach(var stockquote in _stockQuotes.Stock) {
                    LbCompanyName.Content = stockquote.Name;
                    _stockTimeSerie = new StockTimeSerie()
                    {
                        Day = DateTime.Parse(stockquote.Date),
                        Price = stockquote.PE
                    };

                }
                    
                }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e) {
            SaveStock(_id);

            }

            
    }
    }
