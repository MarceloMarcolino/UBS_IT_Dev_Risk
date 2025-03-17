using System;

namespace TradeRiskClassifier.Models
{
    /// <summary>
    /// Implementação concreta da interface ITrade
    /// A classe Trade encapsula os dados da operação e garante imutabilidade (somente leitura) após a construção do objeto.
    /// </summary>
    public class Trade : ITrade
    {
        public double Value { get; private set; }
        public string ClientSector { get; private set; }
        public DateTime NextPaymentDate { get; private set; }

        public Trade(double value, string clientSector, DateTime nextPaymentDate)
        {
            Value = value;
            ClientSector = clientSector;
            NextPaymentDate = nextPaymentDate;
        }
    }
}
