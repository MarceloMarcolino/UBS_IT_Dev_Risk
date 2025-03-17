using System;
using System.Collections.Generic;
using System.Linq;
using System;
using TradeRiskClassifier.Models;

namespace TradeRiskClassifier.RiskCategories
{
    /// <summary>
    /// Categoria EXPIRED: Operação cuja próxima data de pagamento está atrasada há mais de 30 dias, baseado na data de referência que será disponibilizada.
    /// </summary>
    public class ExpiredRiskCategory : IRiskCategory
    {
        public string CategoryName => "EXPIRED";

        public bool IsMatch(ITrade trade, DateTime referenceDate)
        {
            // Se a data de referência for maior que a próxima data de pagamento em mais de 30 dias, a operação está expirada.
            return (referenceDate - trade.NextPaymentDate).TotalDays > 30;
        }
    }
}
