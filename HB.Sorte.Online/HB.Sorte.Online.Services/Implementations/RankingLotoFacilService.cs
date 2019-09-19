using HB.Sorte.Online.Domain.Entities;
using HB.Sorte.Online.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HB.Sorte.Online.Services.Implementations
{
    public class RankingLotoFacilService : IRankingLotoFacilService
    {
        public List<int> GetLessScoreDozens(List<RankingLotoFacil> rankingBets, int quantity)
        {
            return rankingBets.OrderBy(x => x.Quantity).Take(quantity).Select(y => y.Dozen).ToList();
        }

        public List<int> GetMoreScoreDozens(List<RankingLotoFacil> rankingBets, int quantity)
        {
            return rankingBets.OrderByDescending(x => x.Quantity).Take(quantity).Select(y => y.Dozen).ToList();
        }

        public List<RankingLotoFacil> RankingMoreBets(List<HistoryLotoFacil> bets)
        {
            var rankingBets = new List<RankingLotoFacil>();

            for (int i = 1; i <= 25; i++)
            {
                rankingBets.Add(new RankingLotoFacil { Dozen = i, Quantity = 0 });
            }

            foreach (var currentBets in bets)
            {
                foreach (var currentRankingBets in rankingBets)
                {
                    if (currentRankingBets.Dozen == currentBets.Dozen1)
                        currentRankingBets.Quantity += 1;

                    if (currentRankingBets.Dozen == currentBets.Dozen2)
                        currentRankingBets.Quantity += 1;

                    if (currentRankingBets.Dozen == currentBets.Dozen3)
                        currentRankingBets.Quantity += 1;

                    if (currentRankingBets.Dozen == currentBets.Dozen4)
                        currentRankingBets.Quantity += 1;

                    if (currentRankingBets.Dozen == currentBets.Dozen5)
                        currentRankingBets.Quantity += 1;

                    if (currentRankingBets.Dozen == currentBets.Dozen6)
                        currentRankingBets.Quantity += 1;

                    if (currentRankingBets.Dozen == currentBets.Dozen7)
                        currentRankingBets.Quantity += 1;

                    if (currentRankingBets.Dozen == currentBets.Dozen8)
                        currentRankingBets.Quantity += 1;

                    if (currentRankingBets.Dozen == currentBets.Dozen9)
                        currentRankingBets.Quantity += 1;

                    if (currentRankingBets.Dozen == currentBets.Dozen10)
                        currentRankingBets.Quantity += 1;

                    if (currentRankingBets.Dozen == currentBets.Dozen11)
                        currentRankingBets.Quantity += 1;

                    if (currentRankingBets.Dozen == currentBets.Dozen12)
                        currentRankingBets.Quantity += 1;

                    if (currentRankingBets.Dozen == currentBets.Dozen13)
                        currentRankingBets.Quantity += 1;

                    if (currentRankingBets.Dozen == currentBets.Dozen14)
                        currentRankingBets.Quantity += 1;

                    if (currentRankingBets.Dozen == currentBets.Dozen15)
                        currentRankingBets.Quantity += 1;

                }
            }

            return rankingBets.OrderByDescending(x => x.Quantity).ToList();
        }
    }
}
