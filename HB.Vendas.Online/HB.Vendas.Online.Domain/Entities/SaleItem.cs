using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HB.Vendas.Online.Domain.Entities
{
    public class SaleItem
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public Sale SaleId { get; set; }

        [Required]
        public Product ProductId { get; set; }

        [Required]
        public int QuantityProduct { get; set; }

        [Required]
        public decimal PriceProduct { get; set; }
    }
}