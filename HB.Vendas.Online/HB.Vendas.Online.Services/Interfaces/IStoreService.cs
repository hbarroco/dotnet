using HB.Vendas.Online.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HB.Vendas.Online.Services.Interfaces
{
    public interface IStoreService
    {
        void Add(Store entity);
        void Update(Store entity);
        void Remove(string entityId);
        Store GetById(string entityId);
        List<Store> GetAll();
    }
}
