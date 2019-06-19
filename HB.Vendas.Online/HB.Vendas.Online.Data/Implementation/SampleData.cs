using HB.Vendas.Online.Data.EFContexts;
using HB.Vendas.Online.Data.Interfaces;
using HB.Vendas.Online.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HB.Vendas.Online.Data.Implementation
{
    public class SampleData : ISampleData
    {
        private readonly IHBVendasOnlineContextFactory dbContextFactory;

        public SampleData(IHBVendasOnlineContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public void Add(Sample entity)
        {
            using (var context = dbContextFactory.Create())
            {
                context.Add(entity);
                context.SaveChanges();

                //int a = Convert.ToInt16("a");
            }
        }

        public List<Sample> GetAll()
        {
            using (var context = dbContextFactory.Create())
            {
                return context.Sample.ToList();
            }
        }

        public Sample GetById(string entityId)
        {
            throw new NotImplementedException();
        }

        public void Remove(string entityId)
        {
            throw new NotImplementedException();
        }

        public void Update(Sample entity)
        {
            throw new NotImplementedException();
        }
    }
}
