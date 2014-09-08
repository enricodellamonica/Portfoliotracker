using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClasses {
   public class UpdatedQuote {

       [Key]
       public int Id { get; set; }
       public string Symbol { get; set; }
       public decimal Price { get; set; }
       public DateTime QuoteDateTime { get; set; }
        }
    }
