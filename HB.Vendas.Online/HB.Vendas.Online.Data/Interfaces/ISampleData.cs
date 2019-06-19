using HB.Vendas.Online.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HB.Vendas.Online.Data.Interfaces
{
    public interface ISampleData
    {
        void Add(Sample entity);
        void Update(Sample entity);
        void Remove(string entityId);
        Sample GetById(string entityId);
        List<Sample> GetAll();
    }
}
