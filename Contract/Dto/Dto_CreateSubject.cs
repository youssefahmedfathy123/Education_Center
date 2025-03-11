using Education_Center_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_Center_Contract.Dto
{
    public class Dto_CreateSubject
    {
        public string Name { get; set; }
        public int Branch_id { get; set; }   // (FK → Branches.id)

    }
}

