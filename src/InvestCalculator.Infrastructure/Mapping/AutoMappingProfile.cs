using AutoMapper;
using InvestCalculator.Dtos;
using InvestCalculator.Portfolio;

namespace InvestCalculator.Infrastructure.DtoMaps
{
    public class AutoMappingProfile: Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<LowLevelInvestmentInstrumentDto, LowLevelInvestmentInstrument>();
            CreateMap<LowLevelInvestmentInstrument, LowLevelInvestmentInstrumentDto>();
            CreateMap<CalculatorParamsDto, CalculatorParams>();
            CreateMap<CalculatorParams, CalculatorParamsDto>();
        }
    }
}