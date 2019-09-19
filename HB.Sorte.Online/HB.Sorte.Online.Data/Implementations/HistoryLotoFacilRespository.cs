using HB.Sorte.Online.Data.Interfaces;
using HB.Sorte.Online.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;
using Microsoft.Extensions.Options;
using HB.Sorte.Online.Data.Connection;
using System.Linq;

namespace HB.Sorte.Online.Data.Implementations
{
    public class HistoryLotoFacilRespository : IHistoryLotoFacilRepository
    {   
        private readonly HBConfiguration _hbConfiguration;
        private readonly ProviderConnection _providerConnection;

        public HistoryLotoFacilRespository(IOptionsMonitor<HBConfiguration> hbConfiguration)
        {   
            _hbConfiguration = hbConfiguration.CurrentValue;
            _providerConnection = new ProviderConnection(_hbConfiguration.ConnectionString);
        }

        public void Add(HistoryLotoFacil entity)
        {
            var query = @"
                    INSERT INTO [dbo].[HistoryLotoFacil]
                        (Concourse, DateAward, ValueAward, WinnersQuantity
                        ,Dozen1, Dozen2, Dozen3, Dozen4, Dozen5, Dozen6, Dozen7, Dozen8
                        ,Dozen9, Dozen10, Dozen11, Dozen12, Dozen13, Dozen14, Dozen15])
                    VALUES
                        (@Concourse, @DateAward, @ValueAward, @WinnersQuantity, @Dozen1
                        ,@Dozen2, @Dozen3, @Dozen4, @Dozen5, @Dozen6, @Dozen7, @Dozen8,
                        ,@Dozen9, @Dozen10, @Dozen11, @Dozen12, @Dozen13, @Dozen14, @Dozen15) ";
            

            using (var dbConnection = this._providerConnection.GetHBApostasConnection)
            {
                dbConnection.Execute(query, entity);
            }
        }

        public void Add(List<HistoryLotoFacil> entity)
        {
            var query = @"
                    INSERT INTO [dbo].[HistoryLotoFacil] 
                        (Concourse, DateAward, ValueAward, WinnersQuantity
                        ,Dozen1, Dozen2, Dozen3, Dozen4, Dozen5, Dozen6, Dozen7, Dozen8
                        ,Dozen9, Dozen10, Dozen11, Dozen12, Dozen13, Dozen14, Dozen15) 
                    VALUES 
                        (@Concourse, @DateAward, @ValueAward, @WinnersQuantity, @Dozen1 
                        ,@Dozen2, @Dozen3, @Dozen4, @Dozen5, @Dozen6, @Dozen7, @Dozen8 
                        ,@Dozen9, @Dozen10, @Dozen11, @Dozen12, @Dozen13, @Dozen14, @Dozen15 ) ";

            using (var dbConnection = this._providerConnection.GetHBApostasConnection)
            {
                dbConnection.Execute(query, entity);
            }
        }

        public List<HistoryLotoFacil> GetAll()
        {
            var query = @"
                    SELECT Concourse, DateAward, ValueAward, WinnersQuantity 
                        ,Dozen1, Dozen2, Dozen3, Dozen4, Dozen5, Dozen6, Dozen7, Dozen8 
                        ,Dozen9, Dozen10, Dozen11, Dozen12, Dozen13, Dozen14, Dozen15 
                    FROM [dbo].[HistoryLotoFacil] ";

            var historyLotoFacil = new List<HistoryLotoFacil>();

            using (var dbConnection = this._providerConnection.GetHBApostasConnection)
            {
                historyLotoFacil = dbConnection.Query<HistoryLotoFacil>(query).ToList();
            }

            return historyLotoFacil;
        }

        public Domain.Entities.HistoryLotoFacil GetById(string entityId)
        {
            throw new NotImplementedException();
        }

        public void Remove(string entityId)
        {
            var query = "DELETE HistoryLotoFacil WHERE Concourse = @Concourse";

            if (string.IsNullOrEmpty(entityId))
                query = "DELETE HistoryLotoFacil";

            using (var dbConnection = this._providerConnection.GetHBApostasConnection)
            {
                dbConnection.Execute(query, new { Concourse = entityId });
            }

        }

        public void Update(HistoryLotoFacil entity)
        {
            throw new NotImplementedException();
        }
    }
}
