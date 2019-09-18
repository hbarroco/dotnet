using System;
using System.Collections.Generic;
using System.Text;

namespace HB.Sorte.Online.Data.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(string entityId);
        TEntity GetById(string entityId);
        List<TEntity> GetAll();
    }
}
