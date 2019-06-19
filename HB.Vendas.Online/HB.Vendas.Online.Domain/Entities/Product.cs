using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HB.Vendas.Online.Domain.Entities
{
    public class Product
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        public int QuantityStock { get; set; }

        public DateTime CreateOn { get; set; }

        public bool IsActive { get; set; }

        [Required]
        public ProductCategory ProductCategory { get; set; }

        public string UrlImage { get; set; }
    }
}