using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q5OrganizingLottery:Processor
    {
        public Q5OrganizingLottery(string testDataName) : base(testDataName)
        {}
        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long[], long[]>)Solve);

        public virtual long[] Solve(long[] points, long[] starts, long[] ends)
        {
            //write your code here
            // cnt = [0] * (len(points))
            long[] cnt=new long[points.Length];
            // randomized_quick_sort(starts,0,len(starts)-1)
            // randomized_quick_sort(ends,0,len(ends)-1)
            Array.Sort(starts);
            Array.Sort(ends);
            for (int p=0;p<points.Length;p++)
            {
                long s=binary_search_s(starts,points[p],0,starts.Length-1);
                long e=binary_search_f(ends,points[p],0,ends.Length-1);
                long result=s-e;
                if (result<0)
                    cnt[p]=0;
                else
                    cnt[p]=result;
            }
            return cnt;
        }
        public virtual long binary_search_s(long[] a,long x,long left,long right)
        {
            if (right<0)
                return -1;
            if (left>right)
                return right;
            long mid = (int)((left+right)/2);
            if (a[mid]>x)
            {
                if (mid==0)
                    return -1;
                else if (a[mid-1]<x)
                    return mid-1;
                else
                    return binary_search_s(a,x,left,mid-1);
            }
            else if (a[mid]<x)
                return binary_search_s(a,x,mid+1,right);
            else
            {
                while (mid+1<a.Length)
                {
                    if (a[mid]==a[mid+1])
                        mid+=1;
                    else
                        break;
                }
                return mid;
            }
        }
        public virtual long binary_search_f(long[] a,long x,long left,long right)
        {
            if (right<0)
                return -1;
            if (left>right)
                return right;
            long mid = (int)((left+right)/2);
            if (a[mid]>x)
            {
                if (mid==0)
                    return -1;
                else if (a[mid-1]<x)
                    return mid-1;
                else
                    return binary_search_f(a,x,left,mid-1);
            }
            else if (a[mid]<x)
                return binary_search_f(a,x,mid+1,right);
            else
            {
                while (mid-1>=0)
                {
                    if (a[mid]==a[mid-1])
                        mid-=1;
                    else
                        break;
                }
                return mid-1;
            }
        }
    }
}
