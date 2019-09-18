using HB.Sorte.Online.Data.Interfaces;
using HB.Sorte.Online.Domain.Entities;
using HB.Sorte.Online.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HB.Sorte.Online.Services.Implementations
{
    public class HistoryLotoFacilService : IHistoryLotoFacilService
    {
        private readonly IHistoryLotoFacilRepository _repository;

        public HistoryLotoFacilService(IHistoryLotoFacilRepository repository)
        {
            this._repository = repository;
        }

        public void Add(HistoryLotoFacil entity)
        {
            this._repository.Add(entity);
        }

        public void Add(List<HistoryLotoFacil> entity)
        {
            this._repository.Add(entity);
        }

        public List<HistoryLotoFacil> GetAll()
        {
            return this._repository.GetAll();
        }

        public HistoryLotoFacil GetById(string entityId)
        {
            return this._repository.GetById(entityId);
        }

        public void Remove(string entityId)
        {
            this._repository.Remove(entityId);
        }

        public void Update(HistoryLotoFacil entity)
        {
            this._repository.Update(entity);
        }

        public void LoadHistory(List<HistoryLotoFacil> entity)
        {
            this._repository.Remove(string.Empty);

            this._repository.Add(entity);
        }
    }
}
