using Dapper;
using Radar.Data.Interface;
using System.Collections.Generic;
using Radar.Domain.Entities;
using System.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Radar.Data.Implementation
{
    public class ProdutoData : IProdutoData
    {
        private readonly IDbConnection _dbConnection;

        public ProdutoData(IDbConnection dbConnection)
        {
            this._dbConnection = dbConnection;
        }

        public void Add(Produto entity)
        {
            throw new NotImplementedException();
        }

        public List<Produto> GetAll()
        {
            string query = @"SELECT Id, Name FROM Products";
            return _dbConnection.Query<Produto>(query).AsList();
        }

        public Produto GetById(string entityId)
        {
            throw new NotImplementedException();
        }


        public void Remove(string entityId)
        {
            throw new NotImplementedException();
        }

        public void Update(Produto entity)
        {
            throw new NotImplementedException();
        }
    }
}