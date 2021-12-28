using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkLearn.Models
{
    public class Brother
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Precedency { get; set; }
        public Boolean IsSinging { get; set; }
        public Boolean IsLector { get; set; }
        public Boolean IsAcolit { get; set; }
        public Boolean IsDiacon { get; set; }
    }
}
