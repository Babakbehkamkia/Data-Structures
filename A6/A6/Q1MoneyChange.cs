using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A6
{
    public class Q1MoneyChange: Processor
    {
        private static readonly int[] COINS = new int[] {1, 3, 4};

        public Q1MoneyChange(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>) Solve);

        public long Solve(long m)
        {
            // write your code here
            long[] d=new long[m+1];
            int n=1;
            while (n<=m)
            {
                long first=d[n-1]+1;
                long second=first;
                long third=first;
                if (n>=3)
                    second=d[n-3]+1;
                if (n>=4)
                    third=d[n-4]+1;
                
                long[] results=new long[3]{first,second,third};

                d[n]=results.Min();
                n+=1;
            }


            return d[n-1];
        }
    }
}
