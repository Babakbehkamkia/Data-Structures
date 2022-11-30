using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestCommon;

namespace C8.Tests
{
    [DeploymentItem("TestData")]
    [TestClass()]
    public class GradedTests
    {
        [TestMethod(), Timeout(2000)]
        public void SolveTest_Q1Number()
        {
            RunTest(new Q1Number("TD1"));
        }
        public static void RunTest(Processor p)
        {
            TestTools.RunLocalTest("C8", p.Process, p.TestDataName, p.Verifier, VerifyResultWithoutOrder: p.VerifyResultWithoutOrder,
                excludedTestCases: p.ExcludedTestCases);
        }
    }
}