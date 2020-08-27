using System;
using System.Linq;
using Newtonsoft.Json;
using NUnit.Framework;

namespace InvestCalculator.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class Tests
    {

        [Test]
        public void CalcResultTest()
        {
            var @params = new CalculatorParams(20000d, 10000d, 0.12, 10, DateTime.Now);
            using ( var calc = new Calculator(@params))
            {
                var result = calc.CalculateResultSum();
                TestContext.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
                Assert.AreEqual(result.ResultSum, result.CalculationResultsByYear.Last().Value, 0.1);
                Assert.Greater(result.ResultSum, 0);
            }
        }
        
        [Test]
        [TestCase("2020/01/01")]
        [TestCase("2020/02/02")]
        public void CalcResultWithCurrentMonthLessThanYearly(DateTime investStartDate)
        {
            var @params = new CalculatorParams(20000d, 10000d, 0.12, 10, investStartDate);
            using ( var calc = new Calculator(@params))
            {
                var fullFirstYearResults = calc.CalculateResultSum();
                Assert.Greater(fullFirstYearResults.ResultSum, 0);
                TestContext.WriteLine(JsonConvert.SerializeObject(fullFirstYearResults, Formatting.Indented));


                var partFirstYearResults = calc.CalculationResultsIgnoringFirst();
                Assert.Greater(partFirstYearResults.ResultSum, 0);
                TestContext.WriteLine(JsonConvert.SerializeObject(partFirstYearResults, Formatting.Indented));

                if (@params.InvestStartDate.Month != 1)
                {
                    Assert.Greater(fullFirstYearResults.ResultSum, partFirstYearResults.ResultSum);
                }
                else
                {
                    Assert.AreEqual(fullFirstYearResults.ResultSum, partFirstYearResults.ResultSum, 0.1);
                }
            }
        }
    }
}