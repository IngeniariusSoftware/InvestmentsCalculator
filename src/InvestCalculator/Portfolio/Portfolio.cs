using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace InvestCalculator.Portfolio
{
    public class Portfolio
    {
        public List<PortfollioItem> PortfollioItems { get;}
        
        [IgnoreDataMember]
        public double SharesPercent => PortfollioItems
            .Where(x => x.InvestmentInstrument.InvestmentInstrumentType ==
                        HighLevelInvestmentInstruments.Shares)
            .Sum(x => x.Proportion);

        [IgnoreDataMember]
        public double ObligationsPercent => PortfollioItems
            .Where(x => x.InvestmentInstrument.InvestmentInstrumentType ==
                        HighLevelInvestmentInstruments.Shares)
            .Sum(x => x.Proportion);
        
        public PortfolioType PortfolioType 
        {
            get
            {
                // акций больше 65%
                if (SharesPercent > 0.65)
                    return PortfolioType.Risky;
                // акций немного, облигаций много
                if (SharesPercent <= 0.5 && ObligationsPercent >= 0.3)
                    return PortfolioType.Conservative;
                // сбалансированный портфель
                return PortfolioType.Balanced;
            }
        }

        public Portfolio(IEnumerable<PortfollioItem> portfollioItems)
        {
            PortfollioItems = portfollioItems.ToList();
        }
    }
}