using System;
using System.Collections.Generic;

namespace InvestCalculator
{
    /// <summary>
    /// Необходимо переделать расчёт с циклов на функции
    /// </summary>
    public class Calculator: IDisposable
    {
        /// <summary>
        /// Расчётные параметры
        /// </summary>
        private CalculatorParams _params;

        public Calculator(CalculatorParams @params)
        {
            _params = @params;
        }

        //Todo Добавить флаг периода начисления процентов
        
        /// <summary>
        /// Расчёт производится с тем условием, что год только начался
        /// </summary>
        /// <returns></returns>
        public CalculationResults CalculateResultSum()
        {
            // допущения вся сумма внесенная за год добавляется в конце, 
            // для правильности необходимо изменить горизонт планирования до
            // месяцев и рассчитывать годовой процент через месячный
            // процент начисляется ежегодно и после всех взносов
            var calcResultByYear = new Dictionary<long, double>();
            var resultSum = _params.InitSum;
            for (int i = 0; i < _params.PlanningHorizont; i++)
            {
                resultSum += _params.MonthlyAdd * 12;
                resultSum *= 1 + _params.YearPercent / 100.0;
                calcResultByYear.Add(DateTime.Now.Year+i, resultSum);
            }
            return new CalculationResults(calcResultByYear, _params);
        }

        public CalculationResults CalculationResultsIgnoringFirst()
        {
            var firstYearSum = CalcFirstYearIncome(_params.InitSum, _params.MonthlyAdd, _params.YearPercent);
            
            // добавление результатов первого года
            var calcResultByYear = new Dictionary<long, double>() {{DateTime.Now.Year, firstYearSum}};
            
            //Todo переделать на отдельную функцию
            var resultSum = firstYearSum;
            for (int i = 1; i < _params.PlanningHorizont; i++)
            {
                resultSum += _params.MonthlyAdd * 12;
                resultSum *= 1 + _params.YearPercent / 100.0;
                calcResultByYear.Add(DateTime.Now.Year+i, resultSum);
            }
            return new CalculationResults(calcResultByYear, _params);
        }

        private double CalcFirstYearIncome(double initSum, double monthlyAdd, double yearlyPercent)
        {
            // +1, т.к если текущий месяц, то он всё еще остался
            var remainingMonths = 12 - DateTime.Now.Month + 1;
            var resultSum = _params.InitSum + _params.MonthlyAdd * remainingMonths;
            // Пересчёт процента с тем что за прошедшие месяцы не придёт
            resultSum *= 1+_params.YearPercent * (remainingMonths / 12.0) / 100.0;
            return  resultSum;
        }

        public void Dispose()
        {
            _params = null;
        }
    }
}
