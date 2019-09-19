using HB.Sorte.Online.Data.Connection;
using HB.Sorte.Online.Data.Interfaces;
using HB.Sorte.Online.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using Microsoft.Extensions.Options;
using System.Linq;

namespace HB.Sorte.Online.Data.Implementations
{
    public class FixedTableNineDozensRepository : IFixedTableNineDozensRepository
    {
        private readonly HBConfiguration _hbConfiguration;
        private readonly ProviderConnection _providerConnection;

        public FixedTableNineDozensRepository(IOptionsMonitor<HBConfiguration> hbConfiguration)
        {
            _hbConfiguration = hbConfiguration.CurrentValue;
            _providerConnection = new ProviderConnection(_hbConfiguration.ConnectionString);
        }

        public void Add(FixedTableNineDozens entity)
        {
            throw new NotImplementedException();
        }

        public List<FixedTableNineDozens> GetAll()
        {
            var query = @" SELECT Id, FixedNumbers FROM FixedTableNineDozens; ";
            var fixedTableNineDozens = new List<FixedTableNineDozens>();

            using (var dbConnection = this._providerConnection.GetHBApostasConnection)
            {
                fixedTableNineDozens = dbConnection.Query<FixedTableNineDozens>(query).ToList();
            }

            return fixedTableNineDozens;
        }

        public FixedTableNineDozens GetById(string entityId)
        {
            throw new NotImplementedException();
        }

        public void Remove(string entityId)
        {
            throw new NotImplementedException();
        }

        public void Update(FixedTableNineDozens entity)
        {
            throw new NotImplementedException();
        }
    }
}
