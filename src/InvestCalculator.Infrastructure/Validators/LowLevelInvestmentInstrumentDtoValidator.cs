using FluentValidation;
using InvestCalculator.Dtos;

namespace InvestCalculator.Infrastructure.Validators
{
    public class LowLevelInvestmentInstrumentDtoValidator: AbstractValidator<LowLevelInvestmentInstrumentDto>
    
    {
        public LowLevelInvestmentInstrumentDtoValidator()
        {
            RuleFor(dto => dto.Id).GreaterThanOrEqualTo(0);
            RuleFor(dto => dto.Name).NotEmpty();
        }
    }
}