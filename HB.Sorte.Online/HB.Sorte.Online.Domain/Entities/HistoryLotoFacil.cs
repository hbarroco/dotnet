using System;
using System.Collections.Generic;
using System.Text;

namespace HB.Sorte.Online.Domain.Entities
{
    public class HistoryLotoFacil : Bets
    {
        public string Concourse { get; set; }
        public DateTime DateAward { get; set; }
        public decimal ValueAward { get; set; }
        public int WinnersQuantity { get; set; }   
    }
}
