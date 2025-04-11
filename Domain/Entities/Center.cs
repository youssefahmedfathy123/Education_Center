using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_Center_Domain.Entities
{
   public class Center : Entity<int>
    {
  
        public string Name { get; set; }
        public string Location { get; set; }
        public List<Branch> Branches { get; set; }

    }
}


