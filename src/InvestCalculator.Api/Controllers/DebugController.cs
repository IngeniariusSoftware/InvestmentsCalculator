using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InvestCalculator.Dtos;
using InvestCalculator.Infrastructure;
using InvestCalculator.Portfolio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InvestCalculator.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DebugController : ControllerBase
    {
        private readonly ILogger<DebugController> _logger;

        private LowLevelInvestmentInstrumentsDtoContext _dbDtoContext;

        private IMapper _mapper;

        public DebugController(ILogger<DebugController> logger, LowLevelInvestmentInstrumentsDtoContext dtoContext, IMapper mapper)
        {
            _logger = logger;
            _dbDtoContext = dtoContext;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<LowLevelInvestmentInstrument> Get()
        {
            return _dbDtoContext.InvestmentInstruments.Select(x=>_mapper.Map<LowLevelInvestmentInstrumentDto, LowLevelInvestmentInstrument>(x));
        }

        [HttpPost]
        [Route("api/calc")]
        public CalculationResults GetCalcResults([FromBody]CalculatorParamsDto @params)
        {
            var calcParams = _mapper.Map<CalculatorParamsDto, CalculatorParams>(@params);
            using (var calculator = new Calculator(calcParams))
            {
                return calculator.CalculationResultsIgnoringFirst();
            }
        }
    }
}