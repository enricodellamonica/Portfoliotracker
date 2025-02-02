﻿
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DomainClasses;
using DomainClasses.StockQuoteService;

namespace DataLayer {
   public class PortfolioReturn {

       private readonly PortfolioTrackerConverterModel _db;
       private decimal _purchasePrice;
       private List<PortfolioReturnFields> _stockList;
       private PortfolioReturnFields _prf;

       public partial class PortfolioReturnFields
       {

           public int Id {
               get;
               set;
               }
           public string Symbol {
               get;
               set;
               }
           public string Name {
               get;
               set;
               }
           public decimal LastPrice {
               get;
               set;
               }
           public int Quantity {
               get;
               set;
               }
           public decimal TotalCost {
               get;
               set;
               }
           public decimal MarketValue {
               get;
               set;
               }
           public decimal Return {
               get;
               set;
               }
           public void TotalCostSetter(decimal purchasePrice) {

               var res = Quantity * purchasePrice;
               TotalCost = res;


               }

           public void MarketValueSetter() {
               MarketValue = Quantity * LastPrice;
               }

           public void ReturnSetter() {
               Return = MarketValue - TotalCost;
               }


       }

       public PortfolioReturn(string portfolio)
       {
           _db = Db.ConnectionString;
           var query1 = from c in _db.Stocks 
                        where c.Portfolio.Name == portfolio
                           select c; 


           var listing = query1.ToList();
            _stockList= new List<PortfolioReturnFields>();

           var symbolCsv = "";
           foreach (var p in listing)
           {
                symbolCsv += p.Symbol+", ";
               
               
           }

           // Substring to remove extra comma from symbolcsv to make usable for service.
           //eg. symbolCSV = "ibm, msft, ify, "
           // afetr substring  = "ibm, msft, ify"  
           if(symbolCsv.Length > 2)
               symbolCsv = symbolCsv.Substring(0, symbolCsv.Length - 2);

           var client = new StockQuoteSoapClient();
           var result = client.GetQuote(symbolCsv);
           // instantiate serializer
           var serializer = new XmlSerializer(typeof(StockQuote.StockQuotes));

           StockQuote.StockQuotes stockQuotes;

           // Read results to a reader
           using(var reader = new StringReader(result)) {
               // We are doing DESERIALIZING opertion of XML Serializer.
               // As we are receiving serialized response from service we have to desirialize it to populate Model
               stockQuotes = (StockQuote.StockQuotes)serializer.Deserialize(reader);

               }

           // check for null to avoid exception
           if(stockQuotes != null) {
               //stockQuotes contains array of StockQuotesStock class in Stock property
               //so we loop through each
               foreach(var stockquote in stockQuotes.Stock) {
                   // get stock from stocklist mathcing to Symbol present in StockQuote
                   // InvariantCultureIgnoreCase - to ignore upper/lower case and culture specific strings
                   var stock = listing.FirstOrDefault(s => s.Symbol.Equals(stockquote.Symbol, StringComparison.InvariantCultureIgnoreCase));
                   if(stock != null) {
                       _prf = new PortfolioReturnFields();

                       _prf.Id = stock.Id;
                       _prf.Symbol = stock.Symbol;
                       _prf.Name = stock.StockName;
                       _prf.LastPrice = stockquote.Last;
                       _prf.Quantity = stock.Quantity;
                       _prf.TotalCostSetter(stock.PurchaseRate);
                       _prf.MarketValueSetter();
                       _prf.ReturnSetter();
                       _stockList.Add(_prf);

                       }
                   }
               }



       }

       public IEnumerable<PortfolioReturnFields> StockList()
       {
           return _stockList;
       }
 


        }
    }
