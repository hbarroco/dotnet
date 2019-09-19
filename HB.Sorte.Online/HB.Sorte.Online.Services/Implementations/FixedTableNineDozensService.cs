using HB.Sorte.Online.Data.Interfaces;
using HB.Sorte.Online.Domain.Entities;
using HB.Sorte.Online.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HB.Sorte.Online.Services.Implementations
{
    public class FixedTableNineDozensService : IFixedTableNineDozensService
    {
        private readonly IFixedTableNineDozensRepository _repository;

        public FixedTableNineDozensService(IFixedTableNineDozensRepository repository)
        {
            this._repository = repository;
        }

        public void Add(FixedTableNineDozens entity)
        {
            this._repository.Add(entity);
        }

        public List<FixedTableNineDozens> GetAll()
        {
            return this._repository.GetAll();
        }

        public FixedTableNineDozens GetById(string entityId)
        {
            return this._repository.GetById(entityId);
        }

        public void Remove(string entityId)
        {
            this._repository.Remove(entityId);
        }

        public void Update(FixedTableNineDozens entity)
        {
            this._repository.Update(entity);
        }
    }
}
