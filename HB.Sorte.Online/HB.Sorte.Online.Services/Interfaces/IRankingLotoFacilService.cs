using HB.Sorte.Online.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HB.Sorte.Online.Services.Interfaces
{
    public interface IRankingLotoFacilService
    {
        List<RankingLotoFacil> RankingMoreBets(List<HistoryLotoFacil> bets);
        List<int> GetLessScoreDozens(List<RankingLotoFacil> rankingBets, int quantity);
        List<int> GetMoreScoreDozens(List<RankingLotoFacil> rankingBets, int quantity);
    }
}
