using System;
using System.Collections.Generic;
using TestCommon;

namespace A3
{
    public class Q2FibonacciFast : Processor
    {
        public Q2FibonacciFast(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>)Solve);

        public long Solve(long n)
        {
            List<int> fib_list=new List<int>(){0,1};
            if(n==0)
                return fib_list[0];
            for(int i=2;i<=n;i++)
                fib_list.Add(fib_list[i-1]+fib_list[i-2]);
            
            return fib_list[(int)n];
        }
    }
}
