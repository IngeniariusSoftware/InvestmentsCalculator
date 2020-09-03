using System;

namespace InvestCalculator.Dtos
{
    public class CalculatorParamsDto
    {
        /// <summary>
        ///     Начальная сумма инвестиций
        /// </summary>
        public double InitSum { get; set; }

        /// <summary>
        ///     Ежемесячный прирост
        /// </summary>
        public double MonthlyAdd { get; set; }

        /// <summary>
        ///     Средний процент роста дохода в годах
        /// </summary>
        public double YearlyPercent { get; set; }

        /// <summary>
        ///     Горизонт планирования инвестиций в годах
        /// </summary>
        public int PlanningHorizont { get; set; }

        /// <summary>
        /// Является ли счёт ИИИС
        /// </summary>
        public bool IsIis { get; set; } = false;

        /// <summary>
        ///     Дата начла инвестиций
        /// </summary>
        public DateTime InvestStartDate { get; set; }
        public CalculatorParamsDto(double initSum, double monthlyAdd, double yearlyPercent, int planningHorizont, DateTime investStartDate, bool isIis=false)
        {
            InitSum = initSum;
            MonthlyAdd = monthlyAdd;
            YearlyPercent = yearlyPercent;
            PlanningHorizont = planningHorizont;
            InvestStartDate = investStartDate;
            IsIis = isIis;
        }

        public CalculatorParamsDto()
        {
            
        }
    }
}