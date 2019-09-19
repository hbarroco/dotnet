using HB.Sorte.Online.ConsoleTest.Utilities;
using HB.Sorte.Online.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HB.Sorte.Online.ConsoleTest.TypeBets
{
    public class BetFixedTableNineDozensGames
    {
        private List<int> _lastBets;
        private readonly IHistoryLotoFacilService _historyLotoFacilService;
        private readonly IRankingLotoFacilService _rankingLotoFacilService;
        private readonly IFixedTableNineDozensService _fixedTableNineDozensService;

        public BetFixedTableNineDozensGames(ServiceProvider serviceProvider, List<int> lastBets)
        {
            this._lastBets = lastBets;
            this._historyLotoFacilService = serviceProvider.GetService<IHistoryLotoFacilService>();
            this._rankingLotoFacilService = serviceProvider.GetService<IRankingLotoFacilService>();
            this._fixedTableNineDozensService = serviceProvider.GetService<IFixedTableNineDozensService>();
        }


        public void Run()
        {
            var countBet = 0;

            Console.WriteLine(" ###### START - Apostas Online - BetFixedTableNineDozens ###### \n ");

            var fixedTableNineDozens = this._fixedTableNineDozensService.GetAll();

            foreach (var currentFixedTableNineDozens in fixedTableNineDozens)
            {
                countBet += 1;

                var listFixedNumbers = new List<int>(Array.ConvertAll(currentFixedTableNineDozens.FixedNumbers.Split(','), int.Parse));

                var randomOnetoFiften = Utility.GetRandomNumbers(1, 15, 9, listFixedNumbers);

                var allNumbers = new List<int>();
                allNumbers.AddRange(listFixedNumbers);
                allNumbers.AddRange(randomOnetoFiften);
                allNumbers.Sort();

                Utility.PrintBets(countBet, allNumbers, this._lastBets);
            }
            

            Console.WriteLine(" ###### FINISH - Apostas Online - BetFixedTableNineDozens ###### \n ");
        }
    }
}
