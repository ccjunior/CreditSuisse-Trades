using CreditSuisse_Trade.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreditSuisse_Trade.Data.Entities
{
    public class Trade : ITrade
    {
        public DateTime ReferenceDate { get; private set; }
        public double Value { get; private set; }
        public string ClientSector { get; private set; }
        public DateTime NextPaymentDate { get; private set; }


        public Trade(DateTime _referenceDate, double _value, string _clientSector, DateTime _nextPaymentDate)
        {
            ReferenceDate = _referenceDate;
            Value = _value;
            ClientSector = _clientSector;
            NextPaymentDate = _nextPaymentDate;
        }
        
        public List<ITrade> Categories = new List<ITrade>()
        {
            new TradeExpired(),
            new TradeMediumRisk(),
            new TradeHighRisk()
        };

        public string getCategory(Trade trade)
        {
            var category = "";

            foreach (var _category in Categories)
            {
                if (category.Equals(""))
                    category = _category.getCategory(trade).Equals("") ? "" : _category.getCategory(trade);
            }

            return category.Equals("") ? "Categoria não definida." : category;
        }
    }
}
