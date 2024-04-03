using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_route.models
{
    public class PassengerModel
    {
        public PassengerModel() { }

        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public string AdultResponsibleName { get; set; }

        public string AdultResponsibleLastName { get; set; }

        public string AdultResponsiblePhoneNumber { get; set; }

        public bool Active { get; set; }

        public int IdCompany { get; set; }

        public int IdSchool { get; set; }
    }
}
