using HB.Sorte.Online.ConsoleTest.Utilities;
using HB.Sorte.Online.Domain.Entities;
using HB.Sorte.Online.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HB.Sorte.Online.ConsoleTest.TypeBets
{
    public class BetTwentyDozensInSixGames
    {   
        private List<int> _lastBets;
        private readonly IHistoryLotoFacilService _historyLotoFacilService;
        private readonly IRankingLotoFacilService _rankingLotoFacilService;

        public BetTwentyDozensInSixGames(ServiceProvider serviceProvider, List<int> lastBets)
        {   
            this._lastBets = lastBets;
            this._historyLotoFacilService = serviceProvider.GetService<IHistoryLotoFacilService>();
            this._rankingLotoFacilService = serviceProvider.GetService<IRankingLotoFacilService>();
        }

        public void Run()
        {
            Console.WriteLine(" ###### START - Apostas Online - BetTwentyDozensInSixGames ###### \n ");

            var listBets = BetTwentyDozensInSixGamesCore(6);

            //Ordering the bets to return
            StringBuilder betsFormated = new StringBuilder();
            var countBet = 0;
            var countAssertsLastBets = 0;
            foreach (var item in listBets)
            {
                countBet += 1;
                var itemsSorted = new List<int>();
                itemsSorted.Add(item.Dozen1);
                itemsSorted.Add(item.Dozen2);
                itemsSorted.Add(item.Dozen3);
                itemsSorted.Add(item.Dozen4);
                itemsSorted.Add(item.Dozen5);
                itemsSorted.Add(item.Dozen6);
                itemsSorted.Add(item.Dozen7);
                itemsSorted.Add(item.Dozen8);
                itemsSorted.Add(item.Dozen9);
                itemsSorted.Add(item.Dozen10);
                itemsSorted.Add(item.Dozen11);
                itemsSorted.Add(item.Dozen12);
                itemsSorted.Add(item.Dozen13);
                itemsSorted.Add(item.Dozen14);
                itemsSorted.Add(item.Dozen15);
                itemsSorted.Sort();

                Utility.PrintBets(countBet, itemsSorted, this._lastBets);
            }

            Console.WriteLine(" ###### FINISH - Apostas Online - BetTwentyDozensInSixGames ###### \n ");
        }

        private List<Bets> BetTwentyDozensInSixGamesCore(int quantityBets)
        {
            //Generated Randons and LessScoreds
            var bets = this._historyLotoFacilService.GetAll();
            var rankingBets = this._rankingLotoFacilService.RankingMoreBets(bets);
            var lessFiveDozens = this._rankingLotoFacilService.GetLessScoreDozens(rankingBets, 5);
            var randomOnetoFiften = Utility.GetRandomNumbers(1, 15, 9);
            var randonSixtentoTwentFive = Utility.GetRandomNumbers(16, 25, 6);

            //Created the main fifteen randons
            var fifteenRandons = new List<int>();
            fifteenRandons.AddRange(randomOnetoFiften);
            fifteenRandons.AddRange(randonSixtentoTwentFive);

            //Genereated five numbers excluding some numbers
            var excludedGeneratedFiveNumbers = new List<int>();
            //excludedGeneratedFiveNumbers.AddRange(lessFiveDozens);
            excludedGeneratedFiveNumbers.AddRange(fifteenRandons);
            var listFiveNumbers = Utility.GetRandomNumbers(1, 25, 5, excludedGeneratedFiveNumbers);

            #region Genereating 6 Bets based the randons above
            var listBets = new List<Bets>();
            var currentBets = new Bets();

            for (int i = 0; i < quantityBets; i++)
            {
                if (i == 0)
                {
                    currentBets = new Bets();
                    currentBets.Dozen1 = listFiveNumbers[0];
                    currentBets.Dozen2 = fifteenRandons[1];
                    currentBets.Dozen3 = fifteenRandons[2];
                    currentBets.Dozen4 = fifteenRandons[3];
                    currentBets.Dozen5 = listFiveNumbers[1];
                    currentBets.Dozen6 = fifteenRandons[5];
                    currentBets.Dozen7 = fifteenRandons[6];
                    currentBets.Dozen8 = listFiveNumbers[2];
                    currentBets.Dozen9 = fifteenRandons[8];
                    currentBets.Dozen10 = fifteenRandons[9];
                    currentBets.Dozen11 = fifteenRandons[10];
                    currentBets.Dozen12 = listFiveNumbers[3];
                    currentBets.Dozen13 = fifteenRandons[12];
                    currentBets.Dozen14 = fifteenRandons[13];
                    currentBets.Dozen15 = listFiveNumbers[4];
                    listBets.Add(currentBets);
                }
                else if (i == 1)
                {
                    currentBets = new Bets();
                    currentBets.Dozen1 = fifteenRandons[0];
                    currentBets.Dozen2 = listFiveNumbers[0];
                    currentBets.Dozen3 = fifteenRandons[2];
                    currentBets.Dozen4 = listFiveNumbers[1];
                    currentBets.Dozen5 = fifteenRandons[4];
                    currentBets.Dozen6 = fifteenRandons[5];
                    currentBets.Dozen7 = listFiveNumbers[2];
                    currentBets.Dozen8 = fifteenRandons[7];
                    currentBets.Dozen9 = fifteenRandons[8];
                    currentBets.Dozen10 = listFiveNumbers[3];
                    currentBets.Dozen11 = fifteenRandons[10];
                    currentBets.Dozen12 = fifteenRandons[11];
                    currentBets.Dozen13 = fifteenRandons[12];
                    currentBets.Dozen14 = listFiveNumbers[4];
                    currentBets.Dozen15 = fifteenRandons[14];
                    listBets.Add(currentBets);
                }
                else if (i == 2)
                {
                    currentBets = new Bets();
                    currentBets.Dozen1 = fifteenRandons[0];
                    currentBets.Dozen2 = fifteenRandons[1];
                    currentBets.Dozen3 = listFiveNumbers[0];
                    currentBets.Dozen4 = fifteenRandons[3];
                    currentBets.Dozen5 = fifteenRandons[4];
                    currentBets.Dozen6 = listFiveNumbers[1];
                    currentBets.Dozen7 = fifteenRandons[6];
                    currentBets.Dozen8 = fifteenRandons[7];
                    currentBets.Dozen9 = listFiveNumbers[2];
                    currentBets.Dozen10 = fifteenRandons[9];
                    currentBets.Dozen11 = fifteenRandons[10];
                    currentBets.Dozen12 = fifteenRandons[11];
                    currentBets.Dozen13 = listFiveNumbers[3];
                    currentBets.Dozen14 = fifteenRandons[13];
                    currentBets.Dozen15 = listFiveNumbers[4];
                    listBets.Add(currentBets);
                }
                else if (i == 3)
                {
                    currentBets = new Bets();
                    currentBets.Dozen1 = listFiveNumbers[0];
                    currentBets.Dozen2 = fifteenRandons[1];
                    currentBets.Dozen3 = fifteenRandons[2];
                    currentBets.Dozen4 = listFiveNumbers[1];
                    currentBets.Dozen5 = fifteenRandons[4];
                    currentBets.Dozen6 = fifteenRandons[5];
                    currentBets.Dozen7 = listFiveNumbers[2];
                    currentBets.Dozen8 = fifteenRandons[7];
                    currentBets.Dozen9 = fifteenRandons[8];
                    currentBets.Dozen10 = fifteenRandons[9];
                    currentBets.Dozen11 = listFiveNumbers[3];
                    currentBets.Dozen12 = fifteenRandons[11];
                    currentBets.Dozen13 = fifteenRandons[12];
                    currentBets.Dozen14 = listFiveNumbers[4];
                    currentBets.Dozen15 = fifteenRandons[14];
                    listBets.Add(currentBets);
                }
                else if (i == 4)
                {
                    currentBets = new Bets();
                    currentBets.Dozen1 = fifteenRandons[0];
                    currentBets.Dozen2 = listFiveNumbers[0];
                    currentBets.Dozen3 = fifteenRandons[2];
                    currentBets.Dozen4 = fifteenRandons[3];
                    currentBets.Dozen5 = listFiveNumbers[1];
                    currentBets.Dozen6 = fifteenRandons[5];
                    currentBets.Dozen7 = fifteenRandons[6];
                    currentBets.Dozen8 = fifteenRandons[7];
                    currentBets.Dozen9 = fifteenRandons[8];
                    currentBets.Dozen10 = listFiveNumbers[2];
                    currentBets.Dozen11 = fifteenRandons[10];
                    currentBets.Dozen12 = listFiveNumbers[3];
                    currentBets.Dozen13 = listFiveNumbers[4];
                    currentBets.Dozen14 = fifteenRandons[13];
                    currentBets.Dozen15 = fifteenRandons[14];
                    listBets.Add(currentBets);
                }
                else
                {
                    currentBets = new Bets();
                    currentBets.Dozen1 = fifteenRandons[0];
                    currentBets.Dozen2 = fifteenRandons[1];
                    currentBets.Dozen3 = listFiveNumbers[0];
                    currentBets.Dozen4 = fifteenRandons[3];
                    currentBets.Dozen5 = fifteenRandons[4];
                    currentBets.Dozen6 = listFiveNumbers[1];
                    currentBets.Dozen7 = fifteenRandons[6];
                    currentBets.Dozen8 = listFiveNumbers[2];
                    currentBets.Dozen9 = listFiveNumbers[3];
                    currentBets.Dozen10 = fifteenRandons[9];
                    currentBets.Dozen11 = listFiveNumbers[4];
                    currentBets.Dozen12 = fifteenRandons[11];
                    currentBets.Dozen13 = fifteenRandons[12];
                    currentBets.Dozen14 = fifteenRandons[13];
                    currentBets.Dozen15 = fifteenRandons[14];
                    listBets.Add(currentBets);
                }
            }
            #endregion

            return listBets;
        }

    }
}
