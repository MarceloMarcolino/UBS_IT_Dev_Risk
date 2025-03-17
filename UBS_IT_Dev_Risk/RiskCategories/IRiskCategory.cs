using System;
using TradeRiskClassifier.Models;

namespace TradeRiskClassifier.RiskCategories
{
    /// <summary>
    /// Interface que define uma categoria de risco e o método de verificação.
    /// Essa interface permite a criação de múltiplas categorias de risco que podem ser facilmente gerenciadas e adicionadas, seguindo o princípio de verdadeiro/falso.
    /// </summary>
    public interface IRiskCategory
    {
        // Nome da categoria
        string CategoryName { get; }
        // Método para verificar se uma operação (trade) se enquadra na categoria
        bool IsMatch(ITrade trade, DateTime referenceDate);
    }
}
