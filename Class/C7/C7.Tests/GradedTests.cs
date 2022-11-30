using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestCommon;

namespace C7.Tests
{
    [DeploymentItem("TestData")]
    [TestClass()]
    public class GradedTests
    {
        [TestMethod(), Timeout(1000)]
        public void SolveTest_Q1HungryFrog()
        {
            RunTest(new Q1HungryFrog("TD1"));
        }

        [TestMethod(), Timeout(1000)]
        public void SolveTest_Q2HungryFrogPath()
        {
            RunTest(new Q2HungryFrogPath("TD2"));
        }

        public static void RunTest(Processor p)
        {
            TestTools.RunLocalTest("C7", p.Process, p.TestDataName, p.Verifier, VerifyResultWithoutOrder: p.VerifyResultWithoutOrder,
                excludedTestCases: p.ExcludedTestCases);
        }
    }
}
