using System;
using TradeRiskClassifier.Models;

namespace TradeRiskClassifier.RiskCategories
{
    // Categoria HIGHRISK: Operações com valor superior a 1.000.000, com cliente do setor Privado (Private).
    public class HighRiskCategory : IRiskCategory
    {
        public string CategoryName => "HIGHRISK";

        public bool IsMatch(ITrade trade, DateTime referenceDate)
        {
            return trade.Value > 1000000 && trade.ClientSector.Equals("Private", StringComparison.OrdinalIgnoreCase);
        }
    }
}
