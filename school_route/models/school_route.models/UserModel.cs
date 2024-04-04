using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_route.models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }

        public string Password { get; set; }

        public int IdCompany { get; set; }

        public string Jwt { get; set; }

        public bool Active { get; set; }
    }
}
