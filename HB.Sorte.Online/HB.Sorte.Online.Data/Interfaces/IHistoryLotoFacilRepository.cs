using HB.Sorte.Online.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HB.Sorte.Online.Data.Interfaces
{
    public interface IHistoryLotoFacilRepository : IRepositoryBase<HistoryLotoFacil>
    {
        void Add(List<HistoryLotoFacil> entity);
    }
}
