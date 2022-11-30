using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TestCommon;

namespace C2.Tests
{
    [DeploymentItem("TestData")]
    [TestClass()]
    public class GradedTests
    {
        [TestMethod(), Timeout(100)]
        public void SolveTest_Q1PrimeNumbers()
        {
            RunTest(new Q1PrimeNumbers("TD1"));
        }

		[TestMethod(), Timeout(1000)]
        public void SolveTest_Q2Stones()
        {
            RunTest(new Q2Stones("TD2"));
        }
		
        public static void RunTest(Processor p)
        {
            TestTools.RunLocalTest("C2", p.Process, p.TestDataName, p.Verifier, VerifyResultWithoutOrder: p.VerifyResultWithoutOrder,
                excludedTestCases: p.ExcludedTestCases);
        }

    }
}