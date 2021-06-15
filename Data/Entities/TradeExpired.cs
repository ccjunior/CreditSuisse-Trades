using CreditSuisse_Trade.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreditSuisse_Trade.Data.Entities
{
    public class TradeExpired : ITrade
    {
        public double Value { get; private set; }
        public string ClientSector { get; private set; }
        public DateTime NextPaymentDate { get; private set; }

        public string getCategory(Trade trade)
        {
            return ((trade.ReferenceDate.Subtract(trade.NextPaymentDate)).Days > 30) ? "EXPIRED" : "";
        }
    }
}
