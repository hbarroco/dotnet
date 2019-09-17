using HB.Sorte.Online.ConsoleTest.Entities;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace HB.Sorte.Online.ConsoleTest.Utilities
{
    public static class Utility
    {
        public static string CURRENT_CULTURE = "pt-BR";

        public static List<GameLotoFacil> GetLastBets() {

            var stream = new StreamReader(@"C:\LotoFacil\CurrentLotoFacil.csv");

            string linha = null;
            string currentConcurso = string.Empty;
            string newConcurso = string.Empty;
            var lotoFacil = new GameLotoFacil();
            var betsLotoFacil = new List<GameLotoFacil>();
            int indiceConcurso = 0;
            string header = "Conc.";

            while ((linha = stream.ReadLine()) != null)
            {
                string[] currentColunas = linha.Split(',');

                newConcurso = currentColunas[0];

                if (!newConcurso.Equals(header))
                {

                    if (newConcurso != currentConcurso)
                    {
                        indiceConcurso = 0;
                        currentConcurso = currentColunas[0];
                        lotoFacil = new GameLotoFacil();
                        lotoFacil.Concourse = currentConcurso;
                        lotoFacil.DateAward = Convert.ToDateTime(currentColunas[1], new CultureInfo("pt-BR"));
                    }


                    indiceConcurso += 1;

                    if (indiceConcurso == 1)
                    {
                        lotoFacil.Dozen1 = Convert.ToInt32(currentColunas[2]);
                        lotoFacil.Dozen2 = Convert.ToInt32(currentColunas[3]);
                        lotoFacil.Dozen3 = Convert.ToInt32(currentColunas[4]);
                        lotoFacil.Dozen4 = Convert.ToInt32(currentColunas[5]);
                        lotoFacil.Dozen5 = Convert.ToInt32(currentColunas[6]);
                    }
                    else if (indiceConcurso == 2)
                    {
                        lotoFacil.Dozen6 = Convert.ToInt32(currentColunas[2]);
                        lotoFacil.Dozen7 = Convert.ToInt32(currentColunas[3]);
                        lotoFacil.Dozen8 = Convert.ToInt32(currentColunas[4]);
                        lotoFacil.Dozen9 = Convert.ToInt32(currentColunas[5]);
                        lotoFacil.Dozen10 = Convert.ToInt32(currentColunas[6]);
                    }
                    else if (indiceConcurso == 3)
                    {
                        lotoFacil.Dozen11 = Convert.ToInt32(currentColunas[2]);
                        lotoFacil.Dozen12 = Convert.ToInt32(currentColunas[3]);
                        lotoFacil.Dozen13 = Convert.ToInt32(currentColunas[4]);
                        lotoFacil.Dozen14 = Convert.ToInt32(currentColunas[5]);
                        lotoFacil.Dozen15 = Convert.ToInt32(currentColunas[6]);
                        lotoFacil.WinnersQuantity = Convert.ToInt32(currentColunas[7]);

                        if (lotoFacil.WinnersQuantity > 0)
                            lotoFacil.ValueAward = GetValueLineBet(currentColunas[8], currentColunas[9]);

                        betsLotoFacil.Add(lotoFacil);
                    }
                }
            }

            stream.Close();

            return betsLotoFacil;
        }

        public static List<RankingLotoFacil> RankingMoreBets(List<GameLotoFacil> bets)
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
            
        public static List<int> GetRandomNumbers(int valueMin, int valueMax, int countItems, List<int> excludeNumbers = null)
        {
            var random = new Random();
            var randomNumbers = new HashSet<int>();

            if (excludeNumbers == null)
                excludeNumbers = new List<int>();

            for (int i = 0; i < countItems; i++)
            {
                //var numberRandom = random.Next(min, max);
                //while (!randomNumbers.Add(numberRandom)) ;

                var numberRandom = 0;

                do
                {
                    numberRandom = random.Next(valueMin, valueMax);
                } while (excludeNumbers.Contains(numberRandom) || randomNumbers.Contains(numberRandom));

                randomNumbers.Add(numberRandom);
            }

            return randomNumbers.ToList();
        }

        public static List<int> GetLessScoreDozens(List<RankingLotoFacil> rankingBets, int quantity)
        {
            return rankingBets.OrderBy(x => x.Quantity).Take(quantity).Select(y => y.Dozen).ToList();
        }

        private static List<int> GetMoreScoreDozens(List<RankingLotoFacil> rankingBets, int quantity)
        {
            return rankingBets.OrderByDescending(x => x.Quantity).Take(quantity).Select(y => y.Dozen).ToList();
        }
        
        private static decimal GetValueLineBet(string value1, string value2)
        {
            var value = string.Concat(value1, ",", value2);

            decimal valueReturn = 0;

            if (!string.IsNullOrEmpty(value))
            {
                value = RemoveSpecialCharacters(value);
                valueReturn = Convert.ToDecimal(value, new CultureInfo(CURRENT_CULTURE));
            }

            return valueReturn;
        }

        private static string RemoveSpecialCharacters(string str)
        {
            var sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_' || c == ',')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
    }
}
