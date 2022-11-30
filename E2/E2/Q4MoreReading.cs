using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace E2
{
    public class Q4MoreReading: Processor
    {
        public Q4MoreReading(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long,long,long,long, long[][], long>)Solve);


        public static long Solve(long nodeCount,long edgeCount,long libraryPrice, long roadPrice,long[][] edges)
        {
            if (libraryPrice<=roadPrice)
            {
                return libraryPrice*nodeCount;
            }
            List<List<long>> adj=new List<List<long>>();
            for(int i=1;i<=nodeCount;i++)
            {
                List<long> l=new List<long>();
                for (int j=0;j<edgeCount;j++)
                {
                    if(edges[j][0]==i)
                    {
                        l.Add(edges[j][1]-1);
                    }
                    if(edges[j][1]==i)
                    {
                        l.Add(edges[j][0]-1);
                    }
                }
                adj.Add(l);
            }
            long scc=0;
            long[] visited=new long[nodeCount];
            for(int i=0;i<nodeCount;i++)
            {
                if (visited[i]==0)
                {
                    visited[i]=1;
                    Queue<long> q = new Queue<long>();
                    q.Enqueue(i);
                    while(q.Count!=0)
                    {
                        int node=(int)q.Dequeue();
                        for(int j=0;j<adj[node].Count;j++)
                        {
                            if(visited[adj[node][j]]==0)
                            {
                                q.Enqueue(adj[node][j]);
                                visited[adj[node][j]]=1;
                            }
                        }
                    }
                    scc+=1;
                }
            }
            return scc*libraryPrice + (nodeCount-scc)*roadPrice;
        }
    }
}
