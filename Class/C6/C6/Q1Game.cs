using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace C6
{
    public class Q1Game : Processor
    {
        public Q1Game(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long[][], long>)Solve);


        public static long Solve(long n, long m, long[][] prizes)
        {
            // long countHorse=0;
            long[][] result=new long[n][];
            for (int i=0;i<n;i++)
            {
                result[i]=new long[m];
            }
            result[n-1][m-1]=prizes[n-1][m-1];
            for (long i=m-2;i>=0;i--)
            {
                if(prizes[n-1][i]!=0)
                    result[n-1][i]=result[n-1][i+1]+prizes[n-1][i];
            }
            
            for(long i=n-3;i>=0;i-=2)
            {
                for (long j=m-1;j>=0;j--)
                {
                    long leftMove;
                    if (prizes[i][j]!=0 && j<m-1 && result[i][j+1]!=0)
                        leftMove=result[i][j+1]+prizes[i][j];
                    else
                        leftMove=0;
                    long horseMove=0;
                    if ((n-i)%4==1 && i<n-1 && j>=1)
                    {
                        if (prizes[i][j]!=0 && result[i+2][j-1]!=0)
                            horseMove=result[i+2][j-1]+prizes[i][j];
                        else
                            horseMove=0;
                    }
                    if ((n-i)%4==3 && j<m-1 )
                    {
                        if (prizes[i][j]!=0 && result[i+2][j+1]!=0)
                            horseMove=result[i+2][j+1]+prizes[i][j];
                        else
                            horseMove=0;
                    }
                    result[i][j]=Math.Max(leftMove,horseMove);
                }
            }
            long maxItem=0;
            for (int k=0;k<m;k++)
            {
                if (result[0][k]>maxItem)
                {
                    maxItem=result[0][k];
                }
            }


            return maxItem;
        }
    }
}
