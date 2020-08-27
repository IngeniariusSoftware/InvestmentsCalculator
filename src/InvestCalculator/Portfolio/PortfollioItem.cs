namespace InvestCalculator.Portfolio
{
    public class PortfollioItem
    {
        public LowLevelInvestmentInstrument InvestmentInstrument { get; }
        /// <summary>
        /// Пропорция инструмента в портфеле от 0 до 1
        /// </summary>
        public double Proportion { get; }
    }
}