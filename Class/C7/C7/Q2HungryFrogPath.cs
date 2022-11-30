using System;
using System.Collections.Generic;
using TestCommon;

namespace C7
{
    public class Q2HungryFrogPath : Processor
    {
        public Q2HungryFrogPath(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long[][], long[]>)Solve);


        public static long[] Solve(long n, long p, long[][] numbers)
        {
            long[] path=new long[n];
            List<long> d_up=new List<long>(){numbers[0][0]};
            List<long> d_down=new List<long>(){numbers[1][0]};
            // d_down=[b[0]]
            for (int i=1;i<n;i++)
            {
                long x_up=d_up[d_up.Count-1]+numbers[0][i];
                long y_up=d_down[d_down.Count-1]+numbers[0][i]-p;
                d_up.Add(Math.Max(x_up,y_up));

                long x_down=d_up[d_up.Count-2]+numbers[1][i]-p;
                long y_down=d_down[d_down.Count-1]+numbers[1][i];
                d_down.Add(Math.Max(x_down,y_down));
            }
            if (d_up[d_up.Count-1]>d_down[d_down.Count-1])
                path[n-1]=0;
            else
                path[n-1]=1;
            int k=(int)n-2;
            while (k>=0)
            {
                if (path[k+1]==0)
                {
                    if (d_up[k]==d_up[k+1]-numbers[0][k+1])
                    {
                        path[k]=0;
                    }
                    else
                    {
                        path[k]=1;
                    }
                }
                else
                {
                    if(d_down[k]==d_down[k+1]-numbers[1][k+1])
                    {
                        path[k]=1;
                    }
                    else
                    {
                        path[k]=0;
                    }
                }
                k--;
            }
            return path;
        }
    }
}
