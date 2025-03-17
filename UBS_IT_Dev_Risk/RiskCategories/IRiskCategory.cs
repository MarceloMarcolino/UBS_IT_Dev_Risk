using System;
using TradeRiskClassifier.Models;

namespace TradeRiskClassifier.RiskCategories
{
    // Interface para definir uma categoria de risco
    public interface IRiskCategory
    {
        string CategoryName { get; }
        // Verifica se a operação (trade) se enquadra nesta categoria,dado a data de referência.
        bool IsMatch(ITrade trade, DateTime referenceDate);
    }
}
