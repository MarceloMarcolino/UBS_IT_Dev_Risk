using System;

namespace TradeRiskClassifier.Models
{
    // Interface que define os dados de uma  operação (Trade)
    public interface ITrade
    {
        double Value { get; } // Indica o valor da operação em dólar
        string ClientSector { get; } // Indica o setor do cliente, que pode ser "Public" ou "Private"
        DateTime NextPaymentDate { get; } // Indica a expectativa da data do próximo pagamento do cliente ao banco
    }
}
