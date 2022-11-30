using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q7MaxSubarraySum : Processor
    {
        public Q7MaxSubarraySum(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);


        public virtual long Solve(long n, long[] numbers)
        {
            long max=0;
            long sum=0;
            int count=0;
            for(int i=0;i<n;i++)
            {
                sum+=numbers[i];
                if (sum>=0 && count==0)
                {
                    count+=1;
                    sum=numbers[i];
                }
                
                if (sum<0)
                {
                    sum=0;
                    count=0;
                }
                else
                {
                    if (max<sum)
                        max=sum;
                }
            }
            return max;
        }
    }
}
