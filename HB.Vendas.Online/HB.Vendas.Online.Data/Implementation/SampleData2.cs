using HB.Vendas.Online.Data.Interfaces;
using HB.Vendas.Online.Domain.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace HB.Vendas.Online.Data.Implementation
{
    public class SampleData2 : ISampleData2
    {
        private readonly IDbConnection _dbConnection;

        public SampleData2(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public void Add(Sample entity)
        {
            _dbConnection.Query<Sample>("sp_InsertUpdate_Sample", new { Id = entity.Id, Description = entity.Description }, commandType: CommandType.StoredProcedure).AsList();
        }

        public List<Sample> GetAll()
        {
            // No need to use using statement. Dapper will automatically
            // open, close and dispose the connection for you.

            //const string sql = @"SELECT * FROM Sample";
            //return _dbConnection.Query<Sample>(sql).AsList();

            return _dbConnection.Query<Sample>("sp_Get_Sample", commandType: CommandType.StoredProcedure).AsList();
        }

        public Sample GetById(string entityId)
        {
            return _dbConnection.Query<Sample>("sp_Get_Sample", new { Id = entityId }, commandType: CommandType.StoredProcedure).First();
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
