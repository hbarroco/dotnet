using HB.Vendas.Online.Data.Interfaces;
using HB.Vendas.Online.Domain.Entities;
using HB.Vendas.Online.Logging.Log4Net;
using HB.Vendas.Online.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HB.Vendas.Online.Services.Implementation
{
    public class SampleService : ISampleService
    {
        private readonly ISampleData sampleData;
        private readonly ISampleData2 sampleData2;

        public SampleService(ISampleData sampleData, ISampleData2 sampleData2)
        {

            this.sampleData = sampleData;
            this.sampleData2 = sampleData2;
        }

        public void Add(Sample entity)
        {
            try
            {
                sampleData.Add(entity);
            }
            catch (Exception exception)
            {
                Logger.Log(exception.Message, LogType.Error);
                throw;
            }
        }

        public List<Sample> GetAll()
        {
            return sampleData.GetAll();
        }

        public Sample GetById(string entityId)
        {
            throw new NotImplementedException();
        }

        public void Remove(string entityId)
        {
            throw new NotImplementedException();
        }

        public void Update(Sample entity)
        {
            throw new NotImplementedException();
        }

        public List<Sample> GetUsingDapper()
        {
            Sample newSample = new Sample { Id = 99, Description = "Juca" };
            sampleData2.Add(newSample);
            var all = sampleData2.GetAll();
            var one = sampleData2.GetById("1");

            return all;
        }
    }
}
