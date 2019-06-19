using HB.Vendas.Online.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HB.Vendas.Online.Data.EFContexts
{
    public class HBVendasOnlineContext : DbContext
    {
        const string connectionString = "Server=(localhost);Database=ClientDb;Trusted_Connection=True;";


        public HBVendasOnlineContext(DbContextOptions<HBVendasOnlineContext> options)
            : base(options)
        {
        }

        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<UserType> UserType { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Sale> Sale { get; set; }
        public DbSet<SaleItem> SaleItem { get; set; }
        public DbSet<User> User { get; set; }

        public DbSet<Sample> Sample { get; set; }
    }
}
