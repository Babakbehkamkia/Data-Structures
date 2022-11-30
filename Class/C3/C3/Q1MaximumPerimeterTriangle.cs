using System;
using TestCommon;
using System.Linq;

namespace C3
{
    public class Q1MaximumPerimeterTriangle : Processor
    {
        public Q1MaximumPerimeterTriangle(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[]>)Solve);

        public static long[] Solve(long len,long[] edges)
        {
            long index=len-1;

            // edges=edges.OrderByDescending(m=>m).ToArray();
            Array.Sort(edges);
            while(index>=2)
            {
                long a =edges[index];
                long b=edges[index-1];
                long c=edges[index-2];
                if (b+c>a)
                {
                    return new long[3]{edges[index-2],edges[index-1],edges[index]};
                }
                else
                {
                    index--;
                }
            }
            return new long[1]{-1};

        }
    }
}
