using System;
using System.Collections.Generic;
using System.Globalization;
using TradeRiskClassifier.Models;
using TradeRiskClassifier.RiskCategories;
using TradeRiskClassifier.Utilities;

namespace TradeRiskClassifier
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime referenceDate = InputHelper.ReadReferenceDate();
            int tradeCount = InputHelper.ReadTradeCount();

            var trades = new List<ITrade>();
            for(int i = 0; i <tradeCount; i++)
            {
                trades.Add(InputHelper.ReadTrade(i + 1));
            }

            // Lista de categorias de risco, em ordem de precedência:
            // Se uma operação se enquadra em  mais de uma, a primeira encontrada, de maior precedência, é escolhida.
            var riskCategories = new List<IRiskCategory>
                {
                    new ExpiredRiskCategory(),
                    new HighRiskCategory(),
                    new MediumRiskCategory()
                    // Outras categorias podem ser facilmente adicionadas aqui.
                };

            // Classifica e imprime a categoria de cada operação
            foreach (var trade in trades)
            {
                string category = "UNCATEGORIZED"; // Caso não se encaixe em nenhuma categoria
                foreach (var riskCategory in riskCategories)
                {
                    if (riskCategory.IsMatch(trade, referenceDate))
                    {
                        category = riskCategory.CategoryName;
                        break; // Pega a primeira que se encaixa
                    }
                }
                Console.WriteLine(category);
            }
        }
    }
}