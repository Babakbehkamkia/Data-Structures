using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q2MaximizingLoot : Processor
    {
        public Q2MaximizingLoot(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long>) Solve);


        public virtual long Solve(long capacity, long[] weights, long[] values)
        {
            long result=0;
            List<List<float>> rates=new List<List<float>>();
            int n=weights.Length;
            for (int i=0;i<n;i++)
            {
                rates.Add(new List<float>(){i,(float)values[i]/(float)weights[i],weights[i],values[i]});
            }
            rates=rates.OrderByDescending(m=>m[1]).ToList();
            foreach(var j in rates)
            {
                if (capacity==0)
                {
                    break;
                }
                if (capacity>=j[2])
                {
                    result+=(long)j[3];
                    capacity-=(long)j[2];
                }
                else
                {
                    float rate=j[1];
                    result+=(long)(rate*capacity);
                    capacity=0;
                }
                
            }
            return (long)result;
        }


        // public override Action<string, string> Verifier { get; set; } =
        //     TestTools.ApproximateLongVerifier;

    }
}
