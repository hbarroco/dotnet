using HB.Sorte.Online.ConsoleTest.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace HB.Sorte.Online.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            List<LotoFacil> bets = Utility.GetLastBets();

            List<RankingLotoFacil> rankingBets = Utility.RankingMoreBets(bets);
        }
    }
}