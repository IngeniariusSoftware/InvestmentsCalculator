using System.Collections.Generic;
using System.Linq;

namespace InvestCalculator
{
    public class CalculationResults
    {
        /// <summary>
        /// Коллекция значений расчётов по годам,
        /// ключ - год, значение - сумма в конце года
        /// </summary>
        public Dictionary<long, double> CalculationResultsByYear { get; }

        private CalculatorParams _params;

        public double ResultSum
        {
            get
            {
                if (CalculationResultsByYear.Any())
                {
                    return CalculationResultsByYear.Last().Value;
                }

                return 0;
            }
        }

        public CalculationResults(Dictionary<long, double> calcResults, CalculatorParams @params)
        {
            CalculationResultsByYear = calcResults;
            _params = @params;
        }
        
        // Todo сделать экспорт расчётов в csv||excel
    }
}