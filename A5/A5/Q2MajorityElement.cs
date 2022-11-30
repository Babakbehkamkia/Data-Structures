using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q2MajorityElement:Processor
    {

        public Q2MajorityElement(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);


        public virtual long Solve(long n, long[] a)
        {
            //write your code here
            Array.Sort(a);
            long count=1;
            long max=0;
            for (int index=0;index<n-1;index++ )
            {
                if (a[index]==a[index+1])
                    count++;
                
                else
                {
                    if (max<count)
                        max=count;
                    count=1;
                }
            }
            
            if (max<count)
                max=count;
            if (max>(n/2))
                return 1;
            else 
                return 0;
        }
    }
}
