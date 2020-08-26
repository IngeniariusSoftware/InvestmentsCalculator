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
            var @params = new CalculatorParams(20000d, 10000d, 13.5, 10);
            using ( var calc = new Calculator(@params))
            {
                var result = calc.CalculateResultSum();
                TestContext.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
                Assert.AreEqual(result.ResultSum, result.CalculationResultsByYear.Last().Value, 0.1);
                Assert.Greater(result.ResultSum, 0);
            }
        }
        
        [Test]
        public void CalcResultWithCurrentMonthLessThanYearly()
        {
            var @params = new CalculatorParams(20000d, 10000d, 13.5, 10);
            using ( var calc = new Calculator(@params))
            {
                var fullFirstYearResults = calc.CalculateResultSum();
                Assert.Greater(fullFirstYearResults.ResultSum, 0);
                TestContext.WriteLine(JsonConvert.SerializeObject(fullFirstYearResults, Formatting.Indented));


                var partFirstYearResults = calc.CalculationResultsIgnoringFirst();
                Assert.Greater(partFirstYearResults.ResultSum, 0);
                TestContext.WriteLine(JsonConvert.SerializeObject(partFirstYearResults, Formatting.Indented));

                Assert.Greater(fullFirstYearResults.ResultSum, partFirstYearResults.ResultSum);
            }
        }
    }
}