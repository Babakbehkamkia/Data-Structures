using System;
using System.Collections.Generic;
using TestCommon;

namespace A9
{
    public class Q4ParallelProcessing : Processor
    {
        public Q4ParallelProcessing(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], Tuple<long, long>[]>)Solve);

        public Tuple<long, long>[] Solve(long threadCount, long[] jobDuration)
        {
            List<Tuple<long, long>> result=new List<Tuple<long,long>>();
            List<long[]> my_tree=new List<long[]>();
            for (int i=0;i<threadCount;i++)
                my_tree.Add(new long[]{i,0});
            foreach(var job in jobDuration) 
            {
                result.Add(Tuple.Create(my_tree[0][0], my_tree[0][1]));
                my_tree[0][1]+=job;
                siftDown(my_tree);
            }
            return result.ToArray();
            // return new Tuple<long, long>[0];
        }
        public void siftDown(List<long[]> data)
        {
            int i=0;
            while (i<=(int)((data.Count -2)/2))
            {
                int min=i;
                if (data.Count-1>=i*2+1)
                {
                    if (data[min][1]>data[2*i+1][1])
                    {
                        min=2*i+1;
                    }
                    else if (data[min][1]==data[2*i+1][1])
                    {
                        if (data[min][0]>data[2*i+1][0])
                        {
                            min=2*i+1;
                        }
                    }
                }
                if (data.Count-1>=i*2+2)
                    if (data[min][1]>data[2*i+2][1])
                    {
                        min=2*i+2;
                    }
                    else if( data[min][1]==data[2*i+2][1])
                    {
                        if (data[min][0]>data[2*i+2][0])
                        {
                            min=2*i+2;
                        }
                    }
                if (min!=i)
                {
                    long[] temp=data[i];
                    data[i]=data[min];
                    data[min]=temp;
                    i=min;
                    continue;
                }
                break;
            }
        }
    }
}
