using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HB.Vendas.Online.Presentation.Models.Infra
{
    public class LoggedUser
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public int StoreId { get; set; }

        public string StoreName { get; set; }

        public AuthorizationRoles Role { get; set; }
    }
}
