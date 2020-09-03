using System.Collections.Generic;
using System.Linq;

namespace InvestCalculator
{
    public class CalculationResults
    {
        private CalculatorParams _params;

        /// <summary>
        ///     Коллекция значений расчётов по годам,
        ///     ключ - год, значение - сумма в конце года
        /// </summary>
        public Dictionary<long, double> CalculationResultsByYear { get; }

        public double ResultSum
        {
            get
            {
                if (CalculationResultsByYear.Any()) return CalculationResultsByYear.Last().Value;

                return 0;
            }
        }

        public Dictionary<long, double> GrowthByYear
        {
            get
            {
                if (CalculationResultsByYear?.Count >= 2)
                {
                    return
                        CalculationResultsByYear.Zip(CalculationResultsByYear.Skip(1),
                                (x, y) => new KeyValuePair<long, double>(y.Key, y.Value - x.Value))
                            .ToDictionary(x => x.Key, x => x.Value);
                }

                return null;
            }
        }

        public double MoneyGrowth
        {
            get
            {
                if (CalculationResultsByYear?.Count >= 1)
                {
                    return CalculationResultsByYear.Last().Value - CalculationResultsByYear.First().Value;
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