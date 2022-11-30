using System;
using System.Collections.Generic;
using TestCommon;

namespace C2
{
    public class Q2Stones : Processor
    {
        public Q2Stones(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);


        public virtual long Solve(long n, long[] stones)
        {
            long sum=0;
            int index=0;
            int count=0;
            for(int i=0;i<stones.Length;i++)
            {
                sum+=stones[i];
                if(n<=sum)
                {
                    count++;
                    index=i;
                    break;
                }
            }
            if (count==0)
            {
                index--;
            }
            return index+1;
        }
    }
}
