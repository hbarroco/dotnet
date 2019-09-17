using HB.Sorte.Online.ConsoleTest.Entities;
using HB.Sorte.Online.ConsoleTest.TypeBets;
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
            Console.WriteLine("START - Apostas Online - \n ");

           BetTwentyDozensInSixGames.PrintBetTwentyDozensInSixGames(new List<int> { 2, 3, 5, 6, 7, 10, 11, 12, 14, 17, 19, 20, 21, 24, 25 });

            Console.WriteLine("FINISH - Apostas Online - ");

            Console.ReadLine();
        }
    }
}