using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClasses {
   public class Stock {
       public Stock() {
           StockTimeSeries=new List<StockTimeSerie>();
           }

       [Key]
       public int Id { get; set; }
       public string Symbol { get; set; }
       public string StockName { get; set; }
       public int Quantity { get; set; }
       public decimal PurchaseRate { get; set; }

       public virtual Portfolio Portfolio { get; set; }

       public List<StockTimeSerie> StockTimeSeries {
           get;
           set;
           } 


        }
    }
