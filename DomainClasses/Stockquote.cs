using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClasses {
    public class Stockquote {

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class StockQuotes {

            private StockQuotesStock[] stockField;

            private string[] textField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("Stock")]
            public StockQuotesStock[] Stock {
                get {
                    return this.stockField;
                    }
                set {
                    this.stockField = value;
                    }
                }

            /// <remarks/>
            [System.Xml.Serialization.XmlTextAttribute()]
            public string[] Text {
                get {
                    return this.textField;
                    }
                set {
                    this.textField = value;
                    }
                }
            }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class StockQuotesStock {

            private string symbolField;

            private decimal lastField;

            private string dateField;

            private string timeField;

            private decimal changeField;

            private string openField;

            private string highField;

            private string lowField;

            private byte volumeField;

            private string mktCapField;

            private decimal previousCloseField;

            private string percentageChangeField;

            private string annRangeField;

            private decimal earnsField;

            private decimal peField;

            private string nameField;

            /// <remarks/>
            public string Symbol {
                get {
                    return this.symbolField;
                    }
                set {
                    this.symbolField = value;
                    }
                }

            /// <remarks/>
            public decimal Last {
                get {
                    return this.lastField;
                    }
                set {
                    this.lastField = value;
                    }
                }

            /// <remarks/>
            public string Date {
                get {
                    return this.dateField;
                    }
                set {
                    this.dateField = value;
                    }
                }

            /// <remarks/>
            public string Time {
                get {
                    return this.timeField;
                    }
                set {
                    this.timeField = value;
                    }
                }

            /// <remarks/>
            public decimal Change {
                get {
                    return this.changeField;
                    }
                set {
                    this.changeField = value;
                    }
                }

            /// <remarks/>
            public string Open {
                get {
                    return this.openField;
                    }
                set {
                    this.openField = value;
                    }
                }

            /// <remarks/>
            public string High {
                get {
                    return this.highField;
                    }
                set {
                    this.highField = value;
                    }
                }

            /// <remarks/>
            public string Low {
                get {
                    return this.lowField;
                    }
                set {
                    this.lowField = value;
                    }
                }

            /// <remarks/>
            public byte Volume {
                get {
                    return this.volumeField;
                    }
                set {
                    this.volumeField = value;
                    }
                }

            /// <remarks/>
            public string MktCap {
                get {
                    return this.mktCapField;
                    }
                set {
                    this.mktCapField = value;
                    }
                }

            /// <remarks/>
            public decimal PreviousClose {
                get {
                    return this.previousCloseField;
                    }
                set {
                    this.previousCloseField = value;
                    }
                }

            /// <remarks/>
            public string PercentageChange {
                get {
                    return this.percentageChangeField;
                    }
                set {
                    this.percentageChangeField = value;
                    }
                }

            /// <remarks/>
            public string AnnRange {
                get {
                    return this.annRangeField;
                    }
                set {
                    this.annRangeField = value;
                    }
                }

            /// <remarks/>
            public decimal Earns {
                get {
                    return this.earnsField;
                    }
                set {
                    this.earnsField = value;
                    }
                }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("P-E")]
            public decimal PE {
                get {
                    return this.peField;
                    }
                set {
                    this.peField = value;
                    }
                }

            /// <remarks/>
            public string Name {
                get {
                    return this.nameField;
                    }
                set {
                    this.nameField = value;
                    }
                }
            }



        }
    }
