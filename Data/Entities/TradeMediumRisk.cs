using CreditSuisse_Trade.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreditSuisse_Trade.Data.Entities
{
    public class TradeMediumRisk : ITrade
    {
        public double Value { get; private set; }
        public string ClientSector { get; private set; }
        public DateTime NextPaymentDate { get; private set; }

        public string getCategory(Trade trade)
        {
            return (trade.Value > 1000000 && trade.ClientSector.Equals("Public")) ? "MEDIUMRISK" : "";
        }
    }
}
