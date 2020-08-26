namespace InvestCalculator
{
    public class CalculatorParams
    {
        /// <summary>
        /// Начальная сумма инвестиций
        /// </summary>
        public double InitSum { get; }
        /// <summary>
        /// Ежемесячный прирост
        /// </summary>
        public double MonthlyAdd { get; }
        /// <summary>
        /// Средний процент роста дохода в годах
        /// </summary>
        public double YearPercent { get; }
        /// <summary>
        /// Горизонт планирования инвестиций в годах
        /// </summary>
        public int PlanningHorizont { get; }

        /// <summary>
        /// Параметры расчёта инвестиций
        /// </summary>
        /// <param name="initSum"></param>
        /// <param name="monthlyAdd"></param>
        /// <param name="yearPercent">Процент задаётся числом например 7,2</param>
        /// <param name="planningHorizont"></param>
        public CalculatorParams(double initSum, double monthlyAdd, double yearPercent, int planningHorizont)
        {
            InitSum = initSum;
            MonthlyAdd = monthlyAdd;
            YearPercent = yearPercent;
            PlanningHorizont = planningHorizont;
        }
    }
}