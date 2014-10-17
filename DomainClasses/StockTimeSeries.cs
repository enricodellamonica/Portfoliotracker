using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClasses {
    public class StockTimeSerie {
        [Key]
        public int Id {
            get;
            set;
            }
        public decimal Price {
            get;
            set;
            }
        public DateTime Day {
            get;
            set;
            }
        public virtual Stock Stock {
            get;
            set;
            }


        }
    }
