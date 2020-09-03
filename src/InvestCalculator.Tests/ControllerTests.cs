using System;
using AutoMapper;
using InvestCalculator.Api.Controllers;
using InvestCalculator.Dtos;
using InvestCalculator.Infrastructure;
using InvestCalculator.Infrastructure.DtoMaps;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace InvestCalculator.Tests
{
    [TestFixture]
    public class ControllerTests
    {
        private DebugController _controller;
        
        [OneTimeSetUp]
        public void SetUp()
        {
            var mapper = new Mapper(new MapperConfiguration(cfg=>cfg.AddProfile(new AutoMappingProfile())));
            _controller = new DebugController(Mock.Of<ILogger<DebugController>>(),null, mapper);
        }

        /// <summary>
        /// На иисе не может быть больше 1млн
        /// </summary>
        [Test]
        public void TestIisCalc()
        {
            var @params = new CalculatorParamsDto(26000, 15000, 0.13, 10, DateTime.Now, true);
            var results = _controller.GetCalcResults(@params);
            
            Assert.Less(results.ResultSum, 2_000_000);
        }
    }
}