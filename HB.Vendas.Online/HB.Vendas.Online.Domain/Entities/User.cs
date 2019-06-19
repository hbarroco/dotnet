using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HB.Vendas.Online.Domain.Entities
{
    public class User
    {        
        public int Id { get; set; }
             
        public string Name { get; set; }
                
        public string UserName { get; set; }
                
        public string Password { get; set; }
                
        public DateTime CreateOn { get; set; }
                
        public bool IsActive { get; set; }
                
        public UserType UserType { get; set; }

        public Store Store { get; set; }
    }
}