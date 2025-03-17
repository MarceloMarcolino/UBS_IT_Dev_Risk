using System;
using System.Globalization;
using TradeRiskClassifier.Models;

namespace TradeRiskClassifier.Utilities
{
    /// <summary>
    /// Cada método de leitura utiliza try/catch para capturar erros e, em caso de exceção, chama recursivamente o próprio método para solicitar uma nova entrada.
    /// A utilização de métodos auxiliares centraliza a validação, tornando o código do Main mais limpo e facilitando futuras mudanças na estratégia de leitura.
    /// </summary>
    public static class InputHelper
    {
        /// <summary>
        /// Lê a data de referência do Console e valida o formato.
        /// Caso ocorra erro, exibe a mensagem e solicita novamente.
        /// </summary>
        public static DateTime ReadReferenceDate()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Please enter the reference date (MM/dd/yyyy), for example, 12/11/2020:");
            Console.ResetColor();
            try
            {
                string input = Console.ReadLine() ?? throw new InvalidOperationException("No input provided.");
                if (DateTime.TryParseExact(input, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                {
                    return date;
                }
                else
                {
                    throw new FormatException("Invalid date format.");
                }
            }
            catch (Exception ex)
            {
                ErrorHelper.PrintError(ex);
                return ReadReferenceDate();
            }
        }

        /// <summary>
        /// Lê o número de operações do Console e valida a entrada.
        /// Em caso de erro, notifica o usuário e repete a leitura.
        /// </summary>
        public static int ReadTradeCount()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Please enter the number of operations (e.g., 4):");
            Console.ResetColor();
            try
            {
                string input = Console.ReadLine() ?? throw new InvalidOperationException("No input provided.");
                if (int.TryParse(input, out int count))
                {
                    return count;
                }
                else
                {
                    throw new FormatException("Invalid number format.");
                }
            }
            catch (Exception ex)
            {
                ErrorHelper.PrintError(ex);
                return ReadTradeCount();
            }
        }

        public static ITrade ReadTrade(int index)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Enter the details for operation {index} in the following format: VALUE SECTOR DATE (MM/dd/yyyy)");
            Console.ResetColor();
            try
            {
                string input = Console.ReadLine() ?? throw new InvalidOperationException("No input provided.");
                string[] tokens = input.Split(' ');
                if (tokens.Length != 3)
                    throw new FormatException("Invalid format. Please enter exactly 3 fields separated by spaces.");

                if (!double.TryParse(tokens[0], NumberStyles.Any, CultureInfo.InvariantCulture, out double value))
                    throw new FormatException("Invalid value.");

                string clientSector = tokens[1];

                if (!DateTime.TryParseExact(tokens[2], "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime nextPaymentDate))
                    throw new FormatException("Invalid payment date.");

                return new Trade(value, clientSector, nextPaymentDate);
            }
            catch (Exception ex)
            {
                ErrorHelper.PrintError(ex);
                return ReadTrade(index);
            }
        }
    }
}
