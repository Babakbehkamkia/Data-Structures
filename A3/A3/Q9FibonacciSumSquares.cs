using System;
using System.Collections.Generic;
using TestCommon;

namespace A3
{
    public class Q9FibonacciSumSquares : Processor
    {
        public Q9FibonacciSumSquares(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>)Solve);

        public long Solve(long n)
        {
            long current=get_fibonacci_huge_naive(n,10);
            long previous=get_fibonacci_huge_naive(n-1,10);
            long sum=(current+previous)*current;

            return sum % 10;
        }
        public long get_fibonacci_huge_naive(long a, long b)
        {
            List<long> fib_list=new List<long>(){0,1,1};

            int count=0;
            for(int i=3;i<=a;i++)
            {
                fib_list.Add((fib_list[i-1]+fib_list[i-2])%b);
                if (fib_list[fib_list.Count-1]==1 && fib_list[fib_list.Count-2]==0)
                {
                    count+=1;
                    break;
                }
            }
            
                

            if (count==0)
                return fib_list[fib_list.Count-1];
            long answer=(long) a%(fib_list.Count-2);
            return fib_list[(int)answer];
        }
    }
}
