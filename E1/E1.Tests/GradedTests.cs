using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestCommon;

namespace E1.Tests
{
    [DeploymentItem("TestData")]
    [TestClass()]
    public class GradedTests
    {
        [TestMethod(), Timeout(200)]
        public void SolveTest_Q1CupCake()
        {
            RunTest(new Q1Matrix("TD1"));
        }
        [TestMethod(), Timeout(400)]
        public void SolveTest_Q2Tetris()
        {
            RunTest(new Q2Tetris("TD2"));
        }
        [TestMethod(), Timeout(200)]
        public void SolveTest_Q3Competition()
        {
            RunTest(new Q3Competition("TD3"));
        }
        
        [TestMethod(), Timeout(1000)]
        public void SolveTest_Q4EvenNumbers()
        {
            RunTest(new Q4EvenNumbers("TD4"));
        }

        public static void RunTest(Processor p)
        {
            TestTools.RunLocalTest("E1", p.Process, p.TestDataName, p.Verifier, VerifyResultWithoutOrder: p.VerifyResultWithoutOrder,
                excludedTestCases: p.ExcludedTestCases);
        }
    }
}