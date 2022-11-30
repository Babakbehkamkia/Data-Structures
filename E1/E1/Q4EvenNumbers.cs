using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TestCommon;
using static System.Math;

namespace E1
{
    public class Q4EvenNumbers : Processor
    {
        public Q4EvenNumbers(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[],long>)Solve);

        public static long Solve(long n, long[] nums)
        {
            long sumToAdd=0;
            long sumToDelete=0;
            long sum=0;
            // [[sum of even indexes,count of even indexes],[sum of odd indexes,count of odd indexes]
            long[,] evenFirst=new long[2,2];
            long[,] oddFirst=new long[2,2];

            for(int i=0;i<n;i++)
            {
                if(i%2==1)
                {
                    evenFirst[1,1]+=1;
                    oddFirst[1,1]+=1;
                    evenFirst[1,0]+=nums[i];
                    oddFirst[1,0]+=nums[i];
                    // for evenFirst conditions
                    if(evenFirst[1,0]-evenFirst[0,0]>0)
                    {
                        if(sumToAdd-sumToDelete<evenFirst[1,0]-evenFirst[0,0] && evenFirst[1,1]==evenFirst[0,1])
                        {
                            sumToAdd=evenFirst[1,0];
                            sumToDelete=evenFirst[0,0];
                        }
                    }
                    else
                    {
                        evenFirst[0,0]=0;
                        evenFirst[1,0]=0;
                    }
                }
                if(i%2==0)
                {
                    if(i!=0)
                    {
                        oddFirst[0,1]+=1;
                        oddFirst[0,0]+=nums[i];
                    }
                    evenFirst[0,1]+=1;
                    evenFirst[0,0]+=nums[i];
                    sum+=nums[i];
                    // for oddFirst conditions
                    if(oddFirst[1,0]-oddFirst[0,0]>0)
                    {
                        if(sumToAdd-sumToDelete<oddFirst[1,0]-oddFirst[0,0] && oddFirst[1,1]==oddFirst[0,1])
                        {
                            sumToAdd=oddFirst[1,0];
                            sumToDelete=oddFirst[0,0];
                        }
                    }
                    else
                    {
                        oddFirst[0,0]=0;
                        oddFirst[1,0]=0;
                    }
                }
            }
            if(oddFirst[1,0]-oddFirst[0,0]>0)
            {
                if(sumToAdd-sumToDelete<oddFirst[1,0]-oddFirst[0,0] && oddFirst[1,1]==oddFirst[0,1])
                {
                    sumToAdd=oddFirst[1,0];
                    sumToDelete=oddFirst[0,0];
                }
            }
			return sum+sumToAdd-sumToDelete;
        }
    }
}
