using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestCommon;

namespace C11.Tests
{

    [DeploymentItem("TestData", "C11_TestData")]
    [TestClass()]
    public class GradedTests
    {
        [TestMethod(), Timeout(1000)]
        public void SolveTest_Q1MinCost()
        {
            RunTest(new Q1MinCost("TD1"));
        }

        [TestMethod(),Timeout(1000)]
        public void SolveTest_Q2Path()
        {
            RunTest(new Q2Path("TD2"));
        }


        public static void RunTest(Processor p)
        {
            TestTools.RunLocalTest("C11", p.Process, p.TestDataName, p.Verifier,
                VerifyResultWithoutOrder: p.VerifyResultWithoutOrder,
                excludedTestCases: p.ExcludedTestCases);
        }

    }
}
