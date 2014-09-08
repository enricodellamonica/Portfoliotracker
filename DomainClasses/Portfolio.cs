﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClasses {
    public class Portfolio {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string UserId { get; set; }
        }
    }
