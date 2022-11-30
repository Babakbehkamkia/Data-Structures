using System;
using System.Collections.Generic;
using TestCommon;

namespace C7
{
    public class Q1HungryFrog : Processor
    {
        public Q1HungryFrog(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long[][], long>)Solve);


        public virtual long Solve(long n, long p, long[][] numbers)
        {
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
            return Math.Max(d_up[d_up.Count-1],d_down[d_down.Count-1]);
        }
    }
}
