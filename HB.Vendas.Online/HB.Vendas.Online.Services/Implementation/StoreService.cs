using HB.Vendas.Online.Domain.Entities;
using HB.Vendas.Online.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HB.Vendas.Online.Services.Implementation
{
    public class StoreService : IStoreService
    {
        public void Add(Store entity)
        {
            throw new NotImplementedException();
        }

        public List<Store> GetAll()
        {
            var stores = new List<Store>();
            stores.Add(new Store { Id = 1, Name = "C and J Modas" });
            stores.Add(new Store { Id = 2, Name = "Cantinho da Moda" });
            stores.Add(new Store { Id = 3, Name = "Marin Modas" });

            return stores;
        }

        public Store GetById(string entityId)
        {
            throw new NotImplementedException();
        }

        public void Remove(string entityId)
        {
            throw new NotImplementedException();
        }

        public void Update(Store entity)
        {
            throw new NotImplementedException();
        }
    }
}
