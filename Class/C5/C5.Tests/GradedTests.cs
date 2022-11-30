using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using TestCommon;

namespace C4.Tests
{
    [DeploymentItem("TestData")]
    [TestClass()]
    public class GradedTests
    {
        [TestMethod(), Timeout(900)]
        public void SolveTest_Q1CupCake()
        {
            RunTest(new Q1CupCake("TD1"));
        }

        public static void RunTest(Processor p)
        {
            TestTools.RunLocalTest("C4", p.Process, p.TestDataName, p.Verifier, VerifyResultWithoutOrder: p.VerifyResultWithoutOrder,
                excludedTestCases: p.ExcludedTestCases);
        }
    }
}