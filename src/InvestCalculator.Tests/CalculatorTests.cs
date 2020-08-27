using System;
using System.Linq;
using FluentValidation;
using InvestCalculator.Validators;
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
            using (var calc = new Calculator(@params))
            {
                var result = calc.CalculateResultSum();
                TestContext.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
                Assert.AreEqual(result.ResultSum, result.CalculationResultsByYear.Last().Value, 0.1);
                Assert.Greater(result.ResultSum, 0);
            }
        }

        /// <summary>
        ///     <see href="https://stackoverflow.com/questions/7114604/nunit-parameterized-tests-with-datetime" />>
        /// </summary>
        /// <param name="investStartDate"></param>
        [Test]
        [TestCase("2020/01/01")]
        [TestCase("2020/02/02")]
        public void CalcResultWithCurrentMonthLessThanYearly(DateTime investStartDate)
        {
            var @params = new CalculatorParams(20000d, 10000d, 0.12, 10, investStartDate);
            using (var calc = new Calculator(@params))
            {
                var fullFirstYearResults = calc.CalculateResultSum();
                Assert.Greater(fullFirstYearResults.ResultSum, 0);
                TestContext.WriteLine(JsonConvert.SerializeObject(fullFirstYearResults, Formatting.Indented));


                var partFirstYearResults = calc.CalculationResultsIgnoringFirst();
                Assert.Greater(partFirstYearResults.ResultSum, 0);
                TestContext.WriteLine(JsonConvert.SerializeObject(partFirstYearResults, Formatting.Indented));

                if (@params.InvestStartDate.Month != 1)
                    Assert.Greater(fullFirstYearResults.ResultSum, partFirstYearResults.ResultSum);
                else
                    Assert.AreEqual(fullFirstYearResults.ResultSum, partFirstYearResults.ResultSum, 0.1);
            }
        }

        [TestCase(-1, 1, 0.1, 1, "2020/01/01")]
        [TestCase(1, -1, 0.1, 1, "2020/01/01")]
        [TestCase(1, 1, -0.1, 1, "2020/01/01")]
        [TestCase(1, 1, 0.1, 0, "2020/01/01")]
        public void ValidateCalcParamsException(double initSum, double monthlyAdd, double yearlyPercent,
            int planningHorizont, DateTime investStartDate)
        {
            var @params = new CalculatorParams(initSum, monthlyAdd, yearlyPercent, planningHorizont, investStartDate);
            Assert.Throws<ValidationException>(() =>
            {
                var validator = new CalculatorParamsValidator();
                validator.ValidateAndThrow(@params);
            });
        }

        [TestCase(1, 1, 0.0001, 1, "2020/01/01")]
        public void ValidateCalcParamsSuccess(double initSum, double monthlyAdd, double yearlyPercent,
            int planningHorizont, DateTime investStartDate)
        {
            var @params = new CalculatorParams(initSum, monthlyAdd, yearlyPercent, planningHorizont, investStartDate);
            Assert.DoesNotThrow(() =>
            {
                var validator = new CalculatorParamsValidator();
                validator.ValidateAndThrow(@params);
            });
        }
    }
}