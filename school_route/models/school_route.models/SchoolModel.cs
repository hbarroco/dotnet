using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_route.models
{
    public class SchoolModel
    {
        public SchoolModel() { }

        public int Id {get; set;}

        public string Name { get; set; }

        public bool Active { get; set; }
    }
}
