using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Core.Entities
{
    public class EmployModel
    {
        public int Id { get; set; }
        public string FisrtName { get; set; }
        public string LastName { get; set; }
        public string Dept { get; set; }
        public int salary { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
