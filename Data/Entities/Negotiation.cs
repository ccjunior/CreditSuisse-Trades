using System;
using System.Collections.Generic;
using System.Text;

namespace CreditSuisse_Trade.Data.Entities
{
   public class Negotiation
    {
        public DateTime ReferenceDate { get; set; }

        public string DescTrade { get; set; }

        public Negotiation(DateTime referenceDate, string descTrade)
        {
            ReferenceDate = referenceDate;
            DescTrade = descTrade;
        }
    }
}
