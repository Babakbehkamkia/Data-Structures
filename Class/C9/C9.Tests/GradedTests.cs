using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestCommon;

namespace C9.Tests
{
    [DeploymentItem("TestData")]
    [TestClass()]
    public class GradedTests
    {
        [TestMethod(), Timeout(200)]
        public void SolveTest_Q1Hash()
        {
            RunTest(new Q1Hash("TD1"));
        }
        public static void RunTest(Processor p)
        {
            TestTools.RunLocalTest("C9", p.Process, p.TestDataName, p.Verifier, VerifyResultWithoutOrder: p.VerifyResultWithoutOrder,
                excludedTestCases: p.ExcludedTestCases);
        }
    }
}