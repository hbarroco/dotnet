using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HB.Vendas.Online.Domain.Entities
{
    public class UserType
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime CreateOn { get; set; }
    }
}