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

        private InvestCalculatorContext _dbDtoContext;

        private IMapper _mapper;

        public DebugController(ILogger<DebugController> logger, InvestCalculatorContext dtoContext, IMapper mapper)
        {
            _logger = logger;
            _dbDtoContext = dtoContext;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("/api/[controller]/investTools")]
        public IEnumerable<LowLevelInvestmentInstrument> Get()
        {
            return _dbDtoContext.InvestmentInstruments.Select(x=>_mapper.Map<LowLevelInvestmentInstrumentDto, LowLevelInvestmentInstrument>(x));
        }

        [HttpPost]
        [Route("/api/[controller]/calc")]
        public CalculationResults GetCalcResults([FromBody]CalculatorParamsDto @params)
        {
            var calcParams = _mapper.Map<CalculatorParamsDto, CalculatorParams>(@params);
            using (var calculator = new Calculator(calcParams))
            {
                return calculator.CalculationResultsIgnoringFirst();
            }
        }
        
        [HttpPost]
        [Route("/api/[controller]/investTools")]
        public async Task GetCalcResults([FromBody]LowLevelInvestmentInstrumentDto dto)
        {
            await _dbDtoContext.InvestmentInstruments.AddAsync(dto);
            await _dbDtoContext.SaveChangesAsync();
        }
    }
}