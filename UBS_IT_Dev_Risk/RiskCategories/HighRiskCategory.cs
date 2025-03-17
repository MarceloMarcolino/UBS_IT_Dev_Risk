using System;
using TradeRiskClassifier.Models;

namespace TradeRiskClassifier.RiskCategories
{
    /// <summary>
    /// Categoria HIGHRISK: Operações com valor superior a 1.000.000, cujo cliente é do setor Privado (Private).
    /// </summary>
    public class HighRiskCategory : IRiskCategory
    {
        public string CategoryName => "HIGHRISK";

        public bool IsMatch(ITrade trade, DateTime referenceDate)
        {
            return trade.Value > 1000000 && trade.ClientSector.Equals("Private", StringComparison.OrdinalIgnoreCase);
        }
    }
}
