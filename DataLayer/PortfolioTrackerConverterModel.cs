using DomainClasses;

namespace DataLayer {
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PortfolioTrackerConverterModel : DbContext {
        // Your context has been configured to use a 'PortfolioTrackerConverterModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'DataLayer.PortfolioTrackerConverterModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'PortfolioTrackerConverterModel' 
        // connection string in the application configuration file.
        public PortfolioTrackerConverterModel()
            : base("name=PortfolioTrackerConverterModel") {
            }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Stock> Stocks { get; set; } 
        public DbSet<Portfolio> Portfolios { get; set; } 
        public DbSet<StockTimeSerie> StockTimeSeries { get; set; } 
        public DbSet<StockQuote> StockQuotes { get; set; } 

        }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
    }