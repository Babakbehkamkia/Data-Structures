using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A6
{
    public class Q4LCSOfTwo : Processor
    {
        public Q4LCSOfTwo(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long>)Solve);

        public long Solve(long[] seq1, long[] seq2)
        {
            // write your code here
            var n =seq1.Length;
            var m =seq2.Length;
            long[,] a=new long[n+1,m+1];
            for(var j=1;j<m+1;j++)
            {
                for(var i=1;i<n+1;i++)
                {
                    var insertion=a[i,j-1];
                    var deletion=a[i-1,j];
                    var match=a[i-1,j-1]+1;
                    var mismatch=a[i-1,j-1];
                    if(seq1[i-1]==seq2[j-1])
                    {
                        a[i,j]=new long[]{deletion,insertion,match}.Max();
                    }
                    else{
                        a[i,j]=new long[]{deletion,insertion,mismatch}.Max(); 
                    }
                }
            }
            return a[n,m];
        }
    }
}
