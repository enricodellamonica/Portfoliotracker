using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DomainClasses;

namespace DataLayer {
    public class MockUser {
        //private CurrencyConverterModel db = new CurrencyConverterModel();

        public MockUser(string name, string pass) {
            using(var db = Db.ConnectionString) {
                var user = new User();
                user.Name = name;
                user.Password = pass;
                int id;
                //db.Users.Add(user);

               
                var userInDb = db.Users.FirstOrDefault(e => e.Name == name);
                if (userInDb==null)
                {
                    db.Users.Add(user);
                    
                    
                }
                else
                {
                   
                    userInDb.Name = name;
                }
               
                db.SaveChanges();

                
                
                


                }
            }
        }
    }
