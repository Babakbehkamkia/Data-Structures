using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestCommon;

namespace C6.Tests
{
    [DeploymentItem("TestData")]
    [TestClass()]
    public class GradedTests
    {
        [TestMethod(), Timeout(1000)]
        public void SolveTest_Q1Game()
        {
            RunTest(new Q1Game("TD1"));
        }

        public static void RunTest(Processor p)
        {
            TestTools.RunLocalTest("C6", p.Process, p.TestDataName, p.Verifier, VerifyResultWithoutOrder: p.VerifyResultWithoutOrder,
                excludedTestCases: p.ExcludedTestCases);
        }
    }
}