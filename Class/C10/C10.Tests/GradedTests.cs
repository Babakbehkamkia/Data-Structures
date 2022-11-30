using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TestCommon;
using Priority_Queue;


namespace C10.Tests
{
    [DeploymentItem("TestData")]
    [TestClass()]
    public class GradedTests
    {
        [TestMethod()]
        public void SolveTest_Q1Huffman_Node()
        {
            Node n1 = new Node('A', 2);
            Node n2 = new Node('B', 1);
            Node n3 = new Node('B', 2);
            Assert.AreEqual(n2.CompareTo(n1), -1);
            Assert.AreEqual(n3.CompareTo(n1), 1);

        }
        [TestMethod()]
        public void SolveTest_Q1Huffman_Dict()
        {
            Q1Huffman q1Huffman = new Q1Huffman("");
            Dictionary<char, int> res = q1Huffman.GenerateDict("ABRACADABRA");
            Assert.AreEqual(res['A'], 5);
            Assert.AreEqual(res['B'], 2);
            Assert.AreEqual(res['R'], 2);
            Assert.AreEqual(res['D'], 1);
            Assert.AreEqual(res['C'], 1);
        }
        
        [TestMethod(), Timeout(200)]
        public void SolveTest_Q1Huffman()
        {
            RunTest(new Q1Huffman("TD1"));
        }
        public static void RunTest(Processor p)
        {
            TestTools.RunLocalTest("C10", p.Process, p.TestDataName, p.Verifier, VerifyResultWithoutOrder: p.VerifyResultWithoutOrder,
                excludedTestCases: p.ExcludedTestCases);
        }
    }
}