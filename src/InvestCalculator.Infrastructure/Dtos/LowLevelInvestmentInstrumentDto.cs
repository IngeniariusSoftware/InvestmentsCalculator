using InvestCalculator.Portfolio;

namespace InvestCalculator.Dtos
{
    /// <summary>
    /// Dto to <see cref="LowLevelInvestmentInstrument"/>
    /// </summary>
    public class LowLevelInvestmentInstrumentDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public HighLevelInvestmentInstruments InvestmentInstrumentType { get; set; }
    }
}