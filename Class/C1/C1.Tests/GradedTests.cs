using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TestCommon;

namespace C1.Tests
{
    [DeploymentItem("TestData")]
    [TestClass()]
    public class GradedTests
    {
        [TestMethod(), Timeout(1000)]
        public void SolveTest_Q1LinearSearch()
        {
            RunTest(new Q1LinearSearch("TD1"));
        }

        [TestMethod(), Timeout(250)]
        public void SolveTest_Q2BinarySearch()
        {
            RunTest(new Q2BinarySearch("TD2"));
        }

        // [TestMethod()]
        // public void SolveTest_SearchStressTest()
        // {
        //     for (int k = 0; k < 100; k++)
        //     {
        //         int length = 1000;
        //         long[] a = new long[] { length, 0 };

        //         Random r = new Random();

        //         List<long> num = new List<long>();
        //         for (int j = 0; j < length; j++)
        //         {
        //             int rnd = r.Next(1, length * 100);
        //             if (!num.Contains(rnd))
        //             {
        //                 num.Add(rnd);
        //             }
        //         }

        //         length = num.Count;
        //         int index = r.Next(0, length);
        //         long[] numbers = num.ToArray();
        //         Array.Sort(numbers);

        //         a[0] = length;
        //         a[1] = numbers[index];
        //         Assert.AreEqual(Q1LinearSearch.Solve(a, numbers), Q2BinarySearch.Solve(a, numbers));
        //         Assert.AreEqual(Q1LinearSearch.Solve(a, numbers), index);
        //     }
        // }

        public static void RunTest(Processor p)
        {
            TestTools.RunLocalTest("C1", p.Process, p.TestDataName, p.Verifier, VerifyResultWithoutOrder: p.VerifyResultWithoutOrder,
                excludedTestCases: p.ExcludedTestCases);
        }

    }
}