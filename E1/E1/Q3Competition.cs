using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TestCommon;

namespace E1
{
    public class Q3Competition : Processor
    {
        public Q3Competition(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[],long>)Solve);

        public static long Solve(long n, long[] powers)
        {
            //Your code

            long[] result=Competition(n,powers);
			return result[1];
        }
        public static long[] Competition(long n,long[] powers)
        {
            long[] result=new long[2];
            if(n==1)
            {
                result[0]=Math.Max(powers[0],powers[1]);
                result[1]=powers[0]+powers[1];
                return result;
            }
            long[] left=new long[2];
            long[] right=new long[2];
            List<long> powers_left=new List<long>();
            List<long> powers_right=new List<long>();
            long a=(long)Math.Pow(2,(n-1));
            for(int i=0;i<a;i++)
            {
                powers_left.Add(powers[i]);
                powers_right.Add(powers[i+a]);
            }
            left=Competition(n-1,powers_left.ToArray());
            right=Competition(n-1,powers_right.ToArray());
            result[0]=Math.Max(left[0],right[0]);
            if(left[0]+right[1]>left[1]+right[0])
            {
                result[1]=left[0]+right[1];
            }
            else
            {
                result[1]=left[1]+right[0];
            }
            return result;
        }
    }
}
