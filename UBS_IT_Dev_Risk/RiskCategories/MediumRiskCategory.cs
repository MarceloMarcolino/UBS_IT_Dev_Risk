using System;
using TradeRiskClassifier.Models;

namespace TradeRiskClassifier.RiskCategories
{
    // Categoria  MEDIUMRISK: Operações com valor superior a 1.000.000, com cliente do setor Público (Public).
    public class MediumRiskCategory : IRiskCategory
    {
        public string CategoryName => "MEDIUMRISK";
        public bool IsMatch(ITrade trade, DateTime referenceDate)
        {
            return trade.Value > 1000000 && trade.ClientSector.Equals("Public", StringComparison.OrdinalIgnoreCase);
        }
    }
}
