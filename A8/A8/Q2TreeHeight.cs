using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A8
{
    public class Q2TreeHeight : Processor
    {
        public Q2TreeHeight(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public long Solve(long nodeCount, long[] tree)
        {
            long[] T=new long[nodeCount];
            var root=tree.ToList().IndexOf(-1);
            T[root]=1;
            for(var vertex=0;vertex<nodeCount;vertex++)
            {
                var height = 0;
                long current = vertex;
                while(current!=-1)
                {
                    height += 1;
                    current = tree[(int)current];
                    if(current<0)
                    {
                        continue;
                    }
                    if( T[current]!=0)
                    {
                    T[vertex] = T[current] + height;
                    break;
                    }
                    
                }
            }
            return T.Max();
        }
    }
}
