using Priority_Queue;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TestCommon;

namespace A9
{
    public class Q3Froggie : Processor
    {
        public Q3Froggie(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long[], long[], long>)Solve);

        public long Solve(long initialDistance, long initialEnergy, long[] distance, long[] food)
        {
            long result=0;
            long distanceTogo=initialDistance-initialEnergy;
            List<long> changedItems=new List<long>();
            SimplePriorityQueue<long> pq=new SimplePriorityQueue<long>();
            for (int i=0;i<distance.Length;i++)
            {
                if (distanceTogo>distance[i])
                {
                    pq.Enqueue(distance[i],1);
                    changedItems.Add(i);
                }
                else
                {
                    pq.Enqueue(distance[i],-food[i]);   
                }
            }
            while(distanceTogo!=0)
            {
                if (distanceTogo<0)
                {
                    break;
                }
                for(int j=0;j<changedItems.Count;j++)
                {
                    long n=changedItems[j];
                    if (distanceTogo<=distance[n])
                    {
                        pq.UpdatePriority(distance[n],-food[n]);
                        changedItems.Remove(n);
                        j-=1;
                    }
                }
                
                long d=pq.Dequeue();
                if (d<distanceTogo)
                {
                    return -1;
                }
                int index=Array.IndexOf(distance,d);
                distanceTogo-=food[index];
                result+=1;
            }
            
            if(result==0)
            {
                return -1;
            }
            else
            {
                return result;
            }
            
	    }
    }

}
