using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainClasses;

namespace DataLayer {
    public class MockUser {
        //private CurrencyConverterModel db = new CurrencyConverterModel();

        public MockUser(string name, string pass) {
            using(var db = Db.ConnectionString) {
                var user = new User();
                user.Name = name;
                user.Password = pass;
                db.Users.Add(user);
                db.SaveChanges();
                }
            }
        }
    }
