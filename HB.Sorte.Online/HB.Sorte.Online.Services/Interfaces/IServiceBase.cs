using System;
using System.Collections.Generic;
using System.Text;

namespace HB.Sorte.Online.Services.Interfaces
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(string entityId);
        TEntity GetById(string entityId);
        List<TEntity> GetAll();
    }
}
