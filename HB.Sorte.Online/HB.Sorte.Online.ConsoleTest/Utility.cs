using HB.Sorte.Online.ConsoleTest.Entities;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace HB.Sorte.Online.ConsoleTest
{
    public static class Utility
    {
        public static string CURRENT_CULTURE = "pt-BR";

        public static List<LotoFacil> GetLastBets() {

            StreamReader stream = new StreamReader(@"C:\LotoFacil\CurrentLotoFacil.csv");

            string linha = null;
            string currentConcurso = string.Empty;
            string newConcurso = string.Empty;
            LotoFacil lotoFacil = new LotoFacil();
            List<LotoFacil> betsLotoFacil = new List<LotoFacil>();
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
                        lotoFacil = new LotoFacil();
                        lotoFacil.Concurso = currentConcurso;
                        lotoFacil.DataPremio = Convert.ToDateTime(currentColunas[1], new CultureInfo("pt-BR"));
                    }


                    indiceConcurso += 1;

                    if (indiceConcurso == 1)
                    {
                        lotoFacil.Dezena1 = Convert.ToInt32(currentColunas[2]);
                        lotoFacil.Dezena2 = Convert.ToInt32(currentColunas[3]);
                        lotoFacil.Dezena3 = Convert.ToInt32(currentColunas[4]);
                        lotoFacil.Dezena4 = Convert.ToInt32(currentColunas[5]);
                        lotoFacil.Dezena5 = Convert.ToInt32(currentColunas[6]);
                    }
                    else if (indiceConcurso == 2)
                    {
                        lotoFacil.Dezena6 = Convert.ToInt32(currentColunas[2]);
                        lotoFacil.Dezena7 = Convert.ToInt32(currentColunas[3]);
                        lotoFacil.Dezena8 = Convert.ToInt32(currentColunas[4]);
                        lotoFacil.Dezena9 = Convert.ToInt32(currentColunas[5]);
                        lotoFacil.Dezena10 = Convert.ToInt32(currentColunas[6]);
                    }
                    else if (indiceConcurso == 3)
                    {
                        lotoFacil.Dezena11 = Convert.ToInt32(currentColunas[2]);
                        lotoFacil.Dezena12 = Convert.ToInt32(currentColunas[3]);
                        lotoFacil.Dezena13 = Convert.ToInt32(currentColunas[4]);
                        lotoFacil.Dezena14 = Convert.ToInt32(currentColunas[5]);
                        lotoFacil.Dezena15 = Convert.ToInt32(currentColunas[6]);
                        lotoFacil.QuantidadeGanhadores = Convert.ToInt32(currentColunas[7]);

                        if (lotoFacil.QuantidadeGanhadores > 0)
                            lotoFacil.ValorPremio = GetValue(currentColunas[8], currentColunas[9]);

                        betsLotoFacil.Add(lotoFacil);
                    }
                }
            }

            stream.Close();

            return betsLotoFacil;
        }

        public static List<RankingLotoFacil> RankingMoreBets(List<LotoFacil> bets)
        {
            List<RankingLotoFacil> rankingBets = new List<RankingLotoFacil>();

            for (int i = 1; i <= 25; i++)
            {
                rankingBets.Add(new RankingLotoFacil { Dezena = i, Quantidade = 0 });
            }

            foreach (var currentBets in bets)
            {
                foreach (var currentRankingBets in rankingBets)
                {
                    if (currentRankingBets.Dezena == currentBets.Dezena1)
                        currentRankingBets.Quantidade += 1;

                    if (currentRankingBets.Dezena == currentBets.Dezena2)
                        currentRankingBets.Quantidade += 1;

                    if (currentRankingBets.Dezena == currentBets.Dezena3)
                        currentRankingBets.Quantidade += 1;

                    if (currentRankingBets.Dezena == currentBets.Dezena4)
                        currentRankingBets.Quantidade += 1;

                    if (currentRankingBets.Dezena == currentBets.Dezena5)
                        currentRankingBets.Quantidade += 1;

                    if (currentRankingBets.Dezena == currentBets.Dezena6)
                        currentRankingBets.Quantidade += 1;

                    if (currentRankingBets.Dezena == currentBets.Dezena7)
                        currentRankingBets.Quantidade += 1;

                    if (currentRankingBets.Dezena == currentBets.Dezena8)
                        currentRankingBets.Quantidade += 1;

                    if (currentRankingBets.Dezena == currentBets.Dezena9)
                        currentRankingBets.Quantidade += 1;

                    if (currentRankingBets.Dezena == currentBets.Dezena10)
                        currentRankingBets.Quantidade += 1;

                    if (currentRankingBets.Dezena == currentBets.Dezena11)
                        currentRankingBets.Quantidade += 1;

                    if (currentRankingBets.Dezena == currentBets.Dezena12)
                        currentRankingBets.Quantidade += 1;

                    if (currentRankingBets.Dezena == currentBets.Dezena13)
                        currentRankingBets.Quantidade += 1;

                    if (currentRankingBets.Dezena == currentBets.Dezena14)
                        currentRankingBets.Quantidade += 1;

                    if (currentRankingBets.Dezena == currentBets.Dezena15)
                        currentRankingBets.Quantidade += 1;

                }
            }

            return rankingBets.OrderByDescending(x => x.Quantidade).ToList();
        }

        public static decimal GetValue(string value1, string value2)
        {
            string value = string.Concat(value1, ",", value2);

            decimal valueReturn = 0;

            if (!string.IsNullOrEmpty(value))
            {
                value = RemoveSpecialCharacters(value);
                valueReturn = Convert.ToDecimal(value, new CultureInfo(CURRENT_CULTURE));
            }

            return valueReturn;
        }

        public static string RemoveSpecialCharacters(string str)
        {
            StringBuilder sb = new StringBuilder();
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
