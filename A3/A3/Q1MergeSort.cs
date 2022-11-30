using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A3
{
    public class Q1MergeSort : Processor
    {
        public Q1MergeSort(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[]>)Solve);

        public long[] Solve(long n, long[] a)
        {
            if(n==1)
            {
                return a;
            }
            long[] a1=new long[(int)n/2];
            long[] a2=new long[(int)((n+1)/2)];
            for(int i=0;i<(int)n/2;i++)
            {
                a1[i]=a[i];
            }
            int m=(int)n/2;
            for(int j=(int)n/2;j<n;j++)
            {
                a2[j-m]=a[j];
            }
            long[] b1=Solve((long)n/2,a1);
            long[] b2=Solve((long)(n-(n/2)),a2);
            long[] result=new long[n];


            int first=0;
            int second=0;
            int k;
            for(k=0;k<n;k++)
            {
                if(first>=b1.Length )
                {
                    first=-1;
                    break;
                }
                if(second>=b2.Length )
                {
                    second=-1;
                    break;
                }
                if(b1[first]>=b2[second])
                {
                    result[k]=b2[second];
                    second++;
                }
                else
                {
                    result[k]=b1[first];
                    first++;
                }
            }
            // k--;
            if(first==-1)
            {
                for(int i=second;i<b2.Length;i++)
                {
                    result[k]=b2[i];
                    k++;
                }
            }
            if(second==-1)
            {
                for(int i=first;i<b1.Length;i++)
                {
                    result[k]=b1[i];
                    k++;
                }
            }


            return result;
        }
    }
}
