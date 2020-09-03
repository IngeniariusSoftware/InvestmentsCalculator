using System;
using System.Collections.Generic;
using System.Linq;

namespace InvestCalculator
{
    /// <summary>
    ///     Необходимо переделать расчёт с циклов на функции
    /// </summary>
    public class Calculator : IDisposable
    {
        private const double IIS_PERCENT = 0.13;
        private const int MAX_IIS_RETURN = 52_000;

        /// <summary>
        ///     Расчётные параметры
        /// </summary>
        private CalculatorParams _params;

        public Calculator(CalculatorParams @params)
        {
            _params = @params;
        }

        public void Dispose()
        {
            _params = null;
        }

        //Todo Добавить флаг периода начисления процентов

        /// <summary>
        ///     Расчёт производится с тем условием, что год только начался
        /// </summary>
        /// <returns></returns>
        public CalculationResults CalculateResultSum()
        {
            var calcResultByYear = CalcSumByYears(_params.InitSum, _params.YearlyPercent, _params.MonthlyAdd,
                _params.PlanningHorizont, _params.InvestStartDate.Year, _params.IsIis);
            return new CalculationResults(calcResultByYear, _params);
        }


        public CalculationResults CalculationResultsIgnoringFirst()
        {
            var firstYearSum = CalcFirstYearIncome(_params.InitSum, _params.MonthlyAdd, _params.YearlyPercent,
                _params.InvestStartDate);
            // добавление результатов первого года
            var calcResultByYear = new Dictionary<long, double> {{_params.InvestStartDate.Year, firstYearSum}};
            CalcSumByYears(firstYearSum, _params.YearlyPercent, _params.MonthlyAdd,
                    _params.PlanningHorizont - 1, _params.InvestStartDate.Year + 1, _params.IsIis).ToList()
                .ForEach(x => calcResultByYear.Add(x.Key, x.Value));
            return new CalculationResults(calcResultByYear, _params);
        }

        private static Dictionary<long, double>
            CalcSumByYears(double initSum, double yearlyPercent, double monthlyAdd, long planningHorizont,
                long firstYear, bool isIis = false)
        {
            // допущения вся сумма внесенная за год добавляется в конце, 
            // для правильности необходимо изменить горизонт планирования до
            // месяцев и рассчитывать годовой процент через месячный
            // процент начисляется ежегодно и после всех взносов
            var calcResultByYear = new Dictionary<long, double>();
            var resultSum = initSum;
            for (var i = firstYear; (i < firstYear + planningHorizont) && ( !isIis || (resultSum< 1_000_000)) ; i++)
            {
                var yearlyIncome = monthlyAdd * 12;
                
                // если иис 
                //todo рефакторинг работы с иисом
                // калькулятор не должен прерывать расчёты
                if (isIis)
                {
                    var iisReturn = yearlyIncome * (1 + IIS_PERCENT);
                    if (iisReturn > MAX_IIS_RETURN)
                    {
                        iisReturn = MAX_IIS_RETURN;
                    }
                    yearlyIncome += iisReturn;
                }

                    resultSum += yearlyIncome;
                resultSum *= 1 + yearlyPercent;
                calcResultByYear.Add(i, resultSum);
            }

            return calcResultByYear;
        }

        private static double CalcFirstYearIncome(double initSum, double monthlyAdd, double yearlyPercent,
            DateTime investStartDate)
        {
            // +1, т.к если текущий месяц, то он всё еще остался
            var remainingMonths = 12 - investStartDate.Month + 1;
            var resultSum = initSum + monthlyAdd * remainingMonths;
            // Пересчёт процента с тем что за прошедшие месяцы не придёт
            // Todo Ошибочно брать оставшийся процент как среднегодовой * кол-во оставшихся месяцев / 12
            // необходимо пересчитать как сложный процент
            resultSum *= 1 + yearlyPercent * (remainingMonths / 12.0);
            return resultSum;
        }
    }
}