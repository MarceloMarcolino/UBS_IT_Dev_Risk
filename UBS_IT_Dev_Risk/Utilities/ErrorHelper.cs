using System;

namespace TradeRiskClassifier.Utilities
{
    public static class ErrorHelper
    {
        /// <summary>
        /// Exibe uma mensagem de erro formatada no console.
        /// </summary>
        /// <param name="ex">A exceção que contém a mensagem de erro.</param>
        public static void PrintError(Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: " + ex.Message);
            Console.ResetColor();
        }
    }
}
