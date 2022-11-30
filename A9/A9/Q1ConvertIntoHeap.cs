using System;
using System.Collections.Generic;
using TestCommon;

namespace A9
{
    public class Q1ConvertIntoHeap : Processor
    {
        public Q1ConvertIntoHeap(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], Tuple<long, long>[]>)Solve);

        public Tuple<long, long>[] Solve(long[] array)
        {
            
            List<Tuple<long,long>> swaps=new List<Tuple<long, long>>();
            List<Tuple<long,long>> swapsToadd=new List<Tuple<long, long>>();
            int i=(int)((array.Length-2)/2);
            while (i>=0)
            {
                swapsToadd=siftDown(array,i);
                foreach(var item in swapsToadd)
                {
                    swaps.Add(item);
                }
                i-=1;
            }
            return swaps.ToArray();
            // return new Tuple<long, long>[0];
        }
        public List<Tuple<long,long>> siftDown(long[] data,int index)
        {
            int i=index;
            List<Tuple<long,long>> swaps=new List<Tuple<long, long>>();
            while (i<=(int)((data.Length -2)/2))
            {
                int min=i;
                if (data.Length-1>=i*2+1)
                {
                    if (data[min]>data[2*i+1])
                    {
                        min=2*i+1;
                    }
                }
                if (data.Length-1>=i*2+2)
                {
                    if (data[min]>data[2*i+2])
                    {
                        min=2*i+2;
                    }
                }
                if (min!=i)
                {
                    swaps.Add(Tuple.Create((long)i,(long)min));
                    long temp=data[i];
                    data[i]=data[min];
                    data[min]=temp;
                    i=min;
                    continue;
                }
                break;
            }
            return swaps;
        }
    }
}
