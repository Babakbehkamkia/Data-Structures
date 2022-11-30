using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q1BinarySearch : Processor
    {
        public Q1BinarySearch(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long [], long[]>)Solve);


        public virtual long[] Solve(long[] a, long[] b) 
        {
            //write your code here
            long[] indexes=new long[b.Length];
            for(int i=0;i<b.Length;i++)
            {
                indexes[i]=binary_search(a,b[i],0,a.Length-1);
            }
            return indexes;
        }
        public virtual long binary_search(long[] a, long x,long left, long right) 
        {
            if (left>right)
                return -1;
            long mid = (int)((left+right)/2);
            if (a[mid]>x)
                return binary_search(a,x,left,mid-1);
            else if (a[mid]<x)
                return binary_search(a,x,mid+1,right);
            else
                return mid;
        }
    }
}
