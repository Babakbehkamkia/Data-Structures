using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q3MaximizingOnlineAdRevenue : Processor
    {
        public Q3MaximizingOnlineAdRevenue(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long>) Solve);


        public virtual long Solve(long slotCount, long[] adRevenue, long[] averageDailyClick)
        {
            long res = 0;
            Array.Sort(averageDailyClick);
            Array.Sort(adRevenue);
            // averageDailyClick=averageDailyClick.OrderByDescending(m=>m).ToArray();
            // adRevenue=adRevenue.OrderByDescending(m=>m).ToArray();
            for (int i=0;i<slotCount;i++)
            {
                res += adRevenue[i] * averageDailyClick[i];
            }
            return res;
        }
    }
}
