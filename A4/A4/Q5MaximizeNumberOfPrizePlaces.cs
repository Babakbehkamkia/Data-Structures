using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q5MaximizeNumberOfPrizePlaces : Processor
    {
        public Q5MaximizeNumberOfPrizePlaces(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[]>) Solve);


        public virtual long[] Solve(long n)
        {
            List<long> summands =new List<long>();
            long i=1;
            while (n>2*i)
            {
                summands.Add(i);
                n-=i;
                i+=1;
            }
            summands.Add(n);

            return summands.ToArray();
        }
    }
}

