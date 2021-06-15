using CreditSuisse_Trade.Business.Interfaces;
using CreditSuisse_Trade.Data.Entities;
using CreditSuisse_Trade.Data.Validate;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreditSuisse_Trade.Business
{
    public class NegotiationService : INegotiationService
    {
        public string GetCategory(Negotiation negotiation)
        {
            var dataValidation = InputDataValidation(negotiation.DescTrade);

            if (dataValidation.Length > 0) return dataValidation;

            var fields = negotiation.DescTrade.Split(" ");

            Trade trade = new Trade(negotiation.ReferenceDate, Convert.ToDouble(fields[0].ToString()),
                                    fields[1].ToString().Trim(), DateTime.Parse(fields[2].ToString()));

            return trade.getCategory(trade);
        }

        public string InputDataValidation(string info)
        {
            var fields = info.Split(" ");

            if (fields.Length < 3) return "Dados de negociação invalidos";

            var validated = Numeric.NumericValid(fields[0]) ? "" : "Valor da Negociação inválido.";
            validated += Date.Validation(fields[2]) ? "" : " Data do Proximo Pagamento Inválido.";

            return validated;
        }
    }
}
