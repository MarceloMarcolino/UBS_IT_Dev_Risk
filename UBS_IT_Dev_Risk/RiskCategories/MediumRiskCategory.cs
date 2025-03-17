using System;
using TradeRiskClassifier.Models;

namespace TradeRiskClassifier.RiskCategories
{
    /// <summary>
    /// Categoria MEDIUMRISK: Operações com valor superior a 1.000.000, cujo cliente é do setor Público (Public).
    /// </summary>
    public class MediumRiskCategory : IRiskCategory
    {
        public string CategoryName => "MEDIUMRISK";

        public bool IsMatch(ITrade trade, DateTime referenceDate)
        {
            return trade.Value > 1000000 && trade.ClientSector.Equals("Public", StringComparison.OrdinalIgnoreCase);
        }
    }
}
