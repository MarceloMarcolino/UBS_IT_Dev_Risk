using System;

namespace TradeRiskClassifier.Models
{
    /// <summary>
    /// Interface que define os dados essencias de uma operação (Trade)
    /// A interface define claramente os membros que representam uma operação comercial. Isso permite que diversas implementações sejam criadas se necessário.
    /// </summary>
    public interface ITrade
    {
        double Value { get; } // Indica o valor da operação em dólar(es)
        string ClientSector { get; } // Indica o setor do cliente, que pode ser "Public" ou "Private"
        DateTime NextPaymentDate { get; } // Indica a data esperado do próximo pagamento do cliente ao banco
    }
}
