using System;
using System.Globalization;
using TradeRiskClassifier.Models;

namespace TradeRiskClassifier.Utilities
{
    public static class InputHelper
    {
        // Lê a data de referência e verifica se o valor não é nulo
        public static DateTime ReadReferenceDate()
        {
            Console.WriteLine("Digite a data de referência (MM/dd/yyyy):");
            try
            {
                string input = Console.ReadLine() ?? throw new InvalidOperationException("Entrada nula.");
                if (DateTime.TryParseExact(input, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                {
                    return date;
                }
                else
                {
                    throw new FormatException("Formato de data inválido.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return ReadReferenceDate();
            }
        }

        // Lê o número de operações e verifica se o valor não é nulo
        public static int ReadTradeCount()
        {
            Console.WriteLine("Digite o número de operações:");
            try
            {
                string input = Console.ReadLine() ?? throw new InvalidOperationException("Entrada nula.");
                if (int.TryParse(input, out int count))
                {
                    return count;
                }
                else
                {
                    throw new FormatException("Formato de número inválido.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return ReadTradeCount();
            }
        }

        public static ITrade ReadTrade(int index)
        {
            Console.WriteLine($"Digite a operação {index} no formato: VALOR SETOR DATA(MM/dd/yyyy)");
            try
            {
                string input = Console.ReadLine() ?? throw new InvalidOperationException("Entrada nula.");
                string[] tokens = input.Split(' ');
                if (tokens.Length != 3)
                    throw new FormatException("Formato incorreto. Informe exatamente 3 campos separados por espaço.");

                if (!double.TryParse(tokens[0], NumberStyles.Any, CultureInfo.InvariantCulture, out double value))
                    throw new FormatException("Valor inválido.");

                string clientSector = tokens[1];

                if (!DateTime.TryParseExact(tokens[2], "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime nextPaymentDate))
                    throw new FormatException("Data de pagamento inválida.");

                return new Trade(value, clientSector, nextPaymentDate);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return ReadTrade(index);
            }
        }
    }
}
