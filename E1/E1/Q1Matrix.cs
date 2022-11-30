using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TestCommon;

namespace E1
{
    public class Q1Matrix : Processor
    {
        public Q1Matrix(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long[,]>)Solve);

        public static long[,] Solve(long n, long[] rows,long[] columns)
        {
            long[,] res = new long[n, n];
			//Your code
			for (int i=0;i<rows.Length;i++)
            {
                long max_index = rows.ToList().IndexOf(rows.Max());
                int k=0;
                while(rows[max_index]>0)
                {
                    if(columns[k]>0)
                    {
                        res[max_index,k]=1;
                        rows[max_index]-=1;
                        columns[k]-=1;
                    }
                    k++;
                }
            }
            return res;
        }
    }
}
