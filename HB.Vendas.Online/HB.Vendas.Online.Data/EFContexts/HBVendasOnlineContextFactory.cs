using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace HB.Vendas.Online.Data.EFContexts
{
    public class HBVendasOnlineContextFactory : IDesignTimeDbContextFactory<HBVendasOnlineContext>, IHBVendasOnlineContextFactory
    {
        public HBVendasOnlineContext CreateDbContext(string[] args)
        {
            return this.Create();
        }

        public HBVendasOnlineContext Create()
        {
            var optionsBuilder = new DbContextOptionsBuilder<HBVendasOnlineContext>();
            optionsBuilder.UseSqlite("Data Source=CJVendasOnlineFinal.db");

            return new HBVendasOnlineContext(optionsBuilder.Options);
        }
    }
}