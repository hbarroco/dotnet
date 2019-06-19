using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HB.Vendas.Online.Domain.Entities
{
    public class Sale
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public User UserSale { get; set; }

        [Required]
        public DateTime DateSale { get; set; }

        [Required]
        public int TotalSale { get; set; }
    }
}