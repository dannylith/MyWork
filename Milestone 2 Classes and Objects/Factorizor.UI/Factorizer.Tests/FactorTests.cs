using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factorizer.BLL;
using NUnit.Framework;

namespace Factorizer.Tests
{
    [TestFixture]
    class FactorTests
    {

        [TestCase(20, new[]{1, 2, 4, 5, 10, 20})]
        [TestCase(50, new[] { 1,2,5,10,25,50 })]
        [TestCase(55, new[] { 1,5,11,55 })]
        public void TestFactorArray(int x, int[] expected)
        {
            FactorFinder findFactor = new FactorFinder();
            int[] result = findFactor.FactorArray(x);

            Assert.AreEqual(expected, result);
        }
        [TestCase(6, true)]
        [TestCase(28, true)]
        [TestCase(496, true)]
        [TestCase(5, false)]
        public void TestPerfectNumber(int x, bool expected)
        {
            PerfectChecker perfectNumber = new PerfectChecker();
            bool result = perfectNumber.PerfectNumber(x);

            Assert.AreEqual(expected, result);
        }

        [TestCase(2, true)]
        [TestCase(3, true)]
        [TestCase(23, true)]
        [TestCase(25, false)]
        public void TestPrimeNumber(int x, bool expected)
        {
            PrimeChecker primeNumber = new PrimeChecker();
            bool result = primeNumber.PrimeNumber(x);

            Assert.AreEqual(expected, result);
        }
    }
}
