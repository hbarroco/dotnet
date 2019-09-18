using HB.Sorte.Online.Data.Interfaces;
using HB.Sorte.Online.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;

namespace HB.Sorte.Online.Data.Implementations
{
    public class HistoryLotoFacilRespository : IHistoryLotoFacilRepository
    {
        private readonly IDbConnection _dbConnection;

        public HistoryLotoFacilRespository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public void Add(Domain.Entities.HistoryLotoFacil entity)
        {
            throw new NotImplementedException();
        }

        public List<Domain.Entities.HistoryLotoFacil> GetAll()
        {
            throw new NotImplementedException();
        }

        public Domain.Entities.HistoryLotoFacil GetById(string entityId)
        {
            throw new NotImplementedException();
        }

        public void Remove(string entityId)
        {
            throw new NotImplementedException();
        }

        public void Update(Domain.Entities.HistoryLotoFacil entity)
        {
            throw new NotImplementedException();
        }
    }
}
