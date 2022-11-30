using System;
using System.Collections.Generic;
using TestCommon;

namespace A3
{
    public class Q8FibonacciPartialSum : Processor
    {
        public Q8FibonacciPartialSum(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long>)Solve);

        public long Solve(long a, long b)
        {
            long sum=0;
            if(a>=b)
            {
                sum=get_fibonacci_huge_naive(a+2,10)-get_fibonacci_huge_naive(b+1,10);
            }
            if(a<b)
            {
                sum=get_fibonacci_huge_naive(b+2,10)-get_fibonacci_huge_naive(a+1,10);
            }
            sum+=10;

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
