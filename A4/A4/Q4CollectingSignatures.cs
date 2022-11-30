using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q4CollectingSignatures : Processor
    {
        public Q4CollectingSignatures(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long>) Solve);


        public virtual long Solve(long tenantCount, long[] startTimes, long[] endTimes)
        {
            List<long> points=new List<long>();
            List<List<long>> segments=new List<List<long>>();
            for (int i=0;i<endTimes.Length;i++)
            {
                List<long> n=new List<long>(){startTimes[i],endTimes[i]};
                segments.Add(n);
            }
            segments=segments.OrderBy(m=>m[1]).ToList();
            long point = 0;
            while (segments.Count()>0)
            {
                long s=startTimes.Length;
                long e=endTimes.Length;
                point++;
                points.Add(segments[0][1]);

                List<List<long>> new_segments=new List<List<long>>();
                // List<long> new_starts=new List<long>();
                long a=points[points.Count()-1];
                for (int j=0;j<segments.Count();j++)
                {
                    
                    if (segments[j][0]>a )
                    {
                        List<long> n=new List<long>{segments[j][0],segments[j][1]};
                        new_segments.Add(n);
                        // new_starts.Add(startTimes[j]);
                    }
                }
                segments=new_segments;
                // startTimes=new_starts.ToArray();

            }
            // if len(segments):
            //     points.append(segments[0][1])
            return point;
        }
    }
}
