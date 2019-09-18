using HB.Sorte.Online.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HB.Sorte.Online.Services.Interfaces
{
    public interface IHistoryLotoFacilService : IServiceBase<HistoryLotoFacil>
    {
        void Add(List<HistoryLotoFacil> entity);

        void LoadHistory(List<HistoryLotoFacil> entity);
    }
}
