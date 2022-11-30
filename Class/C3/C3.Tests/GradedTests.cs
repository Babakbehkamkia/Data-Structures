using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TestCommon;

namespace C3.Tests
{
    [DeploymentItem("TestData")]
    [TestClass()]
    public class GradedTests
    {
        [TestMethod(), Timeout(500)]
        public void SolveTest_Q1MaximumPerimeterTriangle()
        {
            RunTest(new Q1MaximumPerimeterTriangle("TD1"));
        }

        public static void RunTest(Processor p)
        {
            TestTools.RunLocalTest("C3", p.Process, p.TestDataName, p.Verifier, VerifyResultWithoutOrder: p.VerifyResultWithoutOrder,
                excludedTestCases: p.ExcludedTestCases);
        }

    }
}