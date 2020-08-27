using System.ComponentModel.DataAnnotations;
using InvestCalculator.Portfolio;

namespace InvestCalculator.Dtos
{
    /// <summary>
    /// Dto to <see cref="LowLevelInvestmentInstrument"/>
    /// </summary>
    public class LowLevelInvestmentInstrumentDto
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public HighLevelInvestmentInstruments InvestmentInstrumentType { get; set; }
    }
}