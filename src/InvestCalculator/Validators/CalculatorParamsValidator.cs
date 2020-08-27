using System;
using FluentValidation;

namespace InvestCalculator.Validators
{
    public class CalculatorParamsValidator : AbstractValidator<CalculatorParams>, IDisposable
    {
        private const double MIN_INIT_SUM = 0;

        private const int MIN_PLANNING_HOR = 1;
        private const int MAX_PLANNING_HOR = 50;

        private const double MIN_YEARLY_PERCENT = 0.0001;
        private const double MAX_YEARLY_PERCENT = 0.5;

        public CalculatorParamsValidator()
        {
            RuleFor(@params => @params.InitSum).GreaterThanOrEqualTo(MIN_INIT_SUM);
            RuleFor(@params => @params.PlanningHorizont).InclusiveBetween(MIN_PLANNING_HOR, MAX_PLANNING_HOR);
            RuleFor(@params => @params.YearlyPercent).InclusiveBetween(MIN_YEARLY_PERCENT, MAX_YEARLY_PERCENT);
            RuleFor(@params => @params.MonthlyAdd).GreaterThanOrEqualTo(0);
        }

        public void Dispose()
        {
        }
    }
}