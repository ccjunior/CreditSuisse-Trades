using CreditSuisse_Trade.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreditSuisse_Trade.Business.Interfaces
{
    public interface ITrade
    {
        double Value { get; }
        string ClientSector { get; }
        DateTime NextPaymentDate { get; }

        string getCategory(Trade trade);
    }
}
