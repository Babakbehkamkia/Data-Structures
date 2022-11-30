using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TestCommon;

namespace A2.Tests
{
    [DeploymentItem("TestData")]
    [TestClass()]
    public class GradedTests
    {
        [TestMethod()]
        public void SolveTest_Q1NaiveMaxPairWise()
        {
            RunTest(new Q1NaiveMaxPairWise("TD1"));
        }

        [TestMethod(), Timeout(1500)]
        public void SolveTest_Q2FastMaxPairWise()
        {
            RunTest(new Q2FastMaxPairWise("TD2"));
        }

        [TestMethod()]
        public void SolveTest_StressTest()
        {
            for (int k = 0; k < 100; k++)
            {
                int length = 1000;
                long[] a = new long[] { length, 0 };

                Random r = new Random();

                List<long> num = new List<long>();
                for (int j = 0; j < length; j++)
                {
                    int rnd = r.Next(1, length * 100);
                    if (!num.Contains(rnd))
                    {
                        num.Add(rnd);
                    }
                }
                long[] numbers = num.ToArray();
                
                Assert.AreEqual(Q1NaiveMaxPairWise.Solve(numbers), Q2FastMaxPairWise.Solve(numbers));
            }
        }

        public static void RunTest(Processor p)
        {
            TestTools.RunLocalTest("A2", p.Process, p.TestDataName, p.Verifier);
        }

    }
}