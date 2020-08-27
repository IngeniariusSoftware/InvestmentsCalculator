using System.ComponentModel.DataAnnotations;

namespace InvestCalculator.Portfolio
{
    public class LowLevelInvestmentInstrument
    {
        [Key]
        public long Id { get; }
        public string Name { get;}
        public HighLevelInvestmentInstruments InvestmentInstrumentType { get;}

        public LowLevelInvestmentInstrument(long id, string name, HighLevelInvestmentInstruments investmentInstrumentType)
        {
            Id = id;
            Name = name;
            InvestmentInstrumentType = investmentInstrumentType;
        }
    }
}