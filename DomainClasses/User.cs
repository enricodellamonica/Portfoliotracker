using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClasses {
  public  class User {
      public User()
      {
          Active = true;
          Portfolios=new List<Portfolio>();
      }
      [Key]
      public int Id { get; set; }
      public string Name { get; set; }

      public string Password { get; set; }

      public bool Active { get; set; }
      public List<Portfolio> Portfolios { get; set; } 
        }
    }
