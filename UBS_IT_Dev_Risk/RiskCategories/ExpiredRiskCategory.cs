using System;
using System.Collections.Generic;
using System.Linq;
using System;
using TradeRiskClassifier.Models;

namespace TradeRiskClassifier.RiskCategories
{
    // Categoria EXPIRED: Operação cuja próxima data de pagamento está atrasada há mais de 30 dias, baseado na data de referência que será disponibilizada.
    public class ExpiredRiskCategory : IRiskCategory
    {
        public string CategoryName => "EXPIRED";
        public bool IsMatch(ITrade trade, DateTime referenceDate)
        {
            return (referenceDate - trade.NextPaymentDate).TotalDays > 30;
        }
    }
}
