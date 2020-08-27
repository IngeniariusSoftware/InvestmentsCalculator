using System.ComponentModel;

namespace InvestCalculator.Portfolio
{
    /// <summary>
    /// Высокоуровневые инструменты инвестирования
    /// </summary>
    public enum HighLevelInvestmentInstruments
    {
        [Description("Акции")]
        Shares,
        [Description("Облигации")]
        Obligations,
        [Description("Наличные")]
        Cash
    }
}