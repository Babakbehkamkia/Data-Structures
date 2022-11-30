using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace C8
{
    public class Q1Number : Processor
    {
        public Q1Number(string testDataName) : base(testDataName) {
        }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[][], long>)Solve);

        public long Solve(long nodeCount, long[][] edges)
        {
            DisjointSets d=new DisjointSets((int)nodeCount);
            List<long> roots=new List<long>();
            for (int i=0;i<edges.Length;i++)
            {
                
                // int yRoot=d.find((int)edges[i][1]);
                d.union((int)edges[i][0],(int)edges[i][1]);
                // int xRoot=d.find((int)edges[i][0]);
            }
            for (int j=1;j<=nodeCount;j++)
            {
                long p=d.find(j);
                bool exist=false;
                foreach(int item in roots)
                {
                    if (item==p)
                    {
                        exist=true;
                        break;
                    }
                }
                if (!exist)
                {
                    roots.Add(p);
                }
                
            }
            return roots.Count;
        }
    }
}
