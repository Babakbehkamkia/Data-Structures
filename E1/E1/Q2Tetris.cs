using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TestCommon;

namespace E1
{
    public class Q2Tetris : Processor
    {
        public Q2Tetris(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[],long>)Solve);

        public static long Solve(long n, long[] arr)
        {
            //Your code
            
            long m=arr.Max();
            return tower(n,arr,m);
        }
        public static long tower(long n,long[] arr,long max_value)
        {
            if(n==1)
            {
                return max_value-arr[0];
            }
            // if(n==0)
            // {
            //     return 0;
            // }
            long count=0;
            // long max_value=arr.Max();
            long max_index=0;
            for(int i=0;i<n;i++)
            {
                if (arr[i]==max_value)
                {
                    max_index=i;
                    break;
                }
            }
            List<long> left=new List<long>();
            List<long> right=new List<long>();
            long l=0;
            if(max_index!=0)
            {
                for(int i=0;i<max_index;i++)
                {
                    left.Add(arr[i]);
                }
                l=max_value-left.Max();
                for(int x=0;x<left.Count();x++)
                {
                    left[x]+=l;
                }
                count+=tower(max_index,left.ToArray(),max_value);
            }
            
            long r=0;
            if (max_index!=n-1)
            {
                for(long j=max_index+1;j<n;j++)
                {
                    right.Add(arr[j]);
                }
                r=max_value-right.Max();
                for(int y=0;y<right.Count();y++)
                {
                    right[y]+=r;
                }
                count+=tower(n-max_index-1,right.ToArray(),max_value);
            }
            
            
            
            
            
            count+=l+r;
            
            

			return count;
        }
    }
}
