using CreditSuisse_Trade.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreditSuisse_Trade.Business.Interfaces
{
   public interface INegotiationService
    {
        string GetCategory(Negotiation negotiation);
    }
}
