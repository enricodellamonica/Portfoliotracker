using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer {
    public class Query {
        readonly PortfolioTrackerConverterModel _db = Db.ConnectionString;


        public bool CheckUserAuthetication(string box1, string box2) {


            bool doesUserExist = _db.Users.Any(u => u.Name == box1 && u.Password == box2);

            return doesUserExist;

            }






        }
    }
