using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TradeRiskClassifier.Models;
using TradeRiskClassifier.RiskCategories;
using TradeRiskClassifier.Utilities;

namespace TradeRiskClassifier
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configura o título do console e exibe uma mensagem de boas-vindas com cores.
            Console.Title = "Trade Risk Classifier - Classificador de Risco";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Welcome to the Trade Risk Classifier!");
            Console.ResetColor();

            // Utiliza métodos auxiliares da classe InputHelper para centralizar a lógica de leitura e validação de entradas, reduzindo duplicação e melhorando a legibilidade.
            // Leitura validada dos dados de entrada
            DateTime referenceDate = InputHelper.ReadReferenceDate();
            int tradeCount = InputHelper.ReadTradeCount();

            var trades = new List<ITrade>();
            for(int i = 0; i <tradeCount; i++)
            {
                trades.Add(InputHelper.ReadTrade(i + 1));
            }

            // Lista de categorias de risco, em ordem de precedência:
            // A ordem é importante: se uma operação se enquadra em mais de uma, a primeira encontrada é escolhida. Dessa forma, a precedência desejada é garantida.
            var riskCategories = new List<IRiskCategory>
            {
                new ExpiredRiskCategory(),
                new HighRiskCategory(),
                new MediumRiskCategory()
                // Outras categorias podem ser facilmente adicionadas aqui.
            };

            Console.WriteLine("\nClassification Results:");
            Console.ForegroundColor = ConsoleColor.Cyan;
            // Formatação da tabela: -10 (coluna de 10 caracteres alinhada à esquerda)
            Console.WriteLine("{0,-6} {1,-15} {2,-10} {3,-15} {4,-15}", 
                              "Order", "Value (USD)", "Sector", "Next Payment", "Category");
            Console.ResetColor();
            Console.WriteLine(new string('-', 65)); // Linha separadora

            // Para cada operação, determina a categoria e exibe os dados em formato tabular.
            // Classifica cada operação utilizando LINQ para simplificar a seleção da categoria
            for (int i = 0; i < trades.Count; i++)
            {
                ITrade trade = trades[i];

                // Em vez de usar loops aninhados com if/else para determinar a categoria, foi utilizado FirstOrDefault do LINQ para selecionar a primeira categoria que satisfaça os critérios, tornando o código mais conciso.
                // Procura a primeira categoria que se encaixa
                string category = riskCategories.FirstOrDefault(rc => rc.IsMatch(trade, referenceDate))?.CategoryName ?? "UNCATEGORIZED"; // Caso não se encaixe em nenhuma categoria

                // Formata a linha da tabela
                Console.WriteLine("{0,-6} {1,-15:C} {2,-10} {3,-15:MM/dd/yyyy} {4,-15}",
                    i + 1,              // Ordem da operação
                    trade.Value,        // Valor da operação, formatado como moeda
                    trade.ClientSector, // Setor do cliente
                    trade.NextPaymentDate, // Data do próximo pagamento (formato MM/dd/yyyy)
                    category);          // Categoria determinada
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}