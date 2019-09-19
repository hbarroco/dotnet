using HB.Sorte.Online.Domain.Entities;
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

        public static List<HistoryLotoFacil> ReadLatestBetsFromFile() {

            var stream = new StreamReader(@"C:\LotoFacil\CurrentLotoFacil.csv");

            string linha = null;
            string currentConcurso = string.Empty;
            string newConcurso = string.Empty;
            var lotoFacil = new HistoryLotoFacil();
            var betsLotoFacil = new List<HistoryLotoFacil>();
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
                        lotoFacil = new HistoryLotoFacil();
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
                            lotoFacil.ValueAward = GetValueLineBetFromFile(currentColunas[8], currentColunas[9]);

                        betsLotoFacil.Add(lotoFacil);
                    }
                }
            }

            stream.Close();

            return betsLotoFacil;
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
        
        public static void PrintBets(int countBet, List<int> itemsSorted, List<int> lastBets)
        {
            var countAssertsLastBets = 0;
            foreach (var valueSorted in itemsSorted)
            {
                foreach (var lastBet in lastBets)
                {
                    if (lastBet == valueSorted)
                        countAssertsLastBets += 1;
                }
            }

            var betsFormated = new StringBuilder();
            betsFormated.Append(string.Format(" Aposta {0}: ", countBet.ToString()));
            betsFormated.Append(itemsSorted[0].ToString());
            betsFormated.Append(" - ");
            betsFormated.Append(itemsSorted[1].ToString());
            betsFormated.Append(" - ");
            betsFormated.Append(itemsSorted[2].ToString());
            betsFormated.Append(" - ");
            betsFormated.Append(itemsSorted[3].ToString());
            betsFormated.Append(" - ");
            betsFormated.Append(itemsSorted[4].ToString());
            betsFormated.Append(" - ");
            betsFormated.Append(itemsSorted[5].ToString());
            betsFormated.Append(" - ");
            betsFormated.Append(itemsSorted[6].ToString());
            betsFormated.Append(" - ");
            betsFormated.Append(itemsSorted[7].ToString());
            betsFormated.Append(" - ");
            betsFormated.Append(itemsSorted[8].ToString());
            betsFormated.Append(" - ");
            betsFormated.Append(itemsSorted[9].ToString());
            betsFormated.Append(" - ");
            betsFormated.Append(itemsSorted[10].ToString());
            betsFormated.Append(" - ");
            betsFormated.Append(itemsSorted[11].ToString());
            betsFormated.Append(" - ");
            betsFormated.Append(itemsSorted[12].ToString());
            betsFormated.Append(" - ");
            betsFormated.Append(itemsSorted[13].ToString());
            betsFormated.Append(" - ");
            betsFormated.Append(itemsSorted[14].ToString());

            betsFormated.Append(string.Format("\n Quantidade acertos com base no ultimo sorteio : {0}", countAssertsLastBets.ToString()));

            Console.WriteLine(betsFormated.ToString());
            Console.WriteLine("\n");
        }

        private static decimal GetValueLineBetFromFile(string value1, string value2)
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
