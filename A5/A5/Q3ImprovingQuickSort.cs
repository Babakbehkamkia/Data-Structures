using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q3ImprovingQuickSort:Processor
    {
        public Q3ImprovingQuickSort(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[]>)Solve);

        public virtual long[] Solve(long n, long[] a)
        {
            //write your code here
            return randomized_quick_sort(a, 0, n-1);
            
        }
        public virtual long[] randomized_quick_sort(long[] a,long l,long r)
        {
            // long l=0;
            // long r=n;
            if (l >= r)
                return a;
            System.Random random = new System.Random();
            int k = random.Next((int)l, (int)r);
            (a[l], a[k]) = (a[k], a[l]);
            // #use partition3
            long[] indexes=new long[2];
            indexes = partition3(a, l, r);
            long[] a1=randomized_quick_sort(a, l, indexes[0] - 1);
            long[] a2=randomized_quick_sort(a, indexes[1] + 1, r);
            return a;
        }
        public virtual long[] partition3(long[] a,long l,long r)
        {
            long x = a[l];
            long j = l;
            for (long i=l+1;i<r+1;i++)
            {
                if (a[i] <= x)
                {
                    j += 1;
                    (a[i], a[j]) = (a[j], a[i]);
                }
            }
            long k=inverse_partition3(a,l,j);
            // # a[l], a[k] = a[k], a[l]
            
            return new long[]{k,j};
        }
        public virtual long inverse_partition3(long[] a,long l,long r)
        {
            long x = a[l];
            long j = l;
            for (long i=l+1;i<r+1;i++)
            {
                if (a[i] < x)
                {
                    j += 1;
                    (a[i], a[j]) = (a[j], a[i]);
                }
            }
            (a[l], a[j]) = (a[j], a[l]);
            return j;
        }
    }
}
