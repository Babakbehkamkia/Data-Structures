using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q1ChangingMoney : Processor
    {
        public Q1ChangingMoney(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>) Solve);


        public virtual long Solve(long money)
        {
            long count=0;
            long[] coins=new long[3]{10,5,1};
            foreach(long i in coins)
            {
                // while (money-i>=0)
                // {
                //     money-=i;
                //     count+=1;
                // }
                long a=(long)money/i;
                count=count+a;
                money=money%i;
            }
            return count;
        }
    }
}
