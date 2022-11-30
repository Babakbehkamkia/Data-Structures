using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace E2
{
    public class Q1ShortestPath: Processor
    {
        public Q1ShortestPath(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[][], long[]>)Solve);


        public static long[] Solve(long nodeCount, long[][] matrix)
        {
            for(int itter=1;itter<=nodeCount;itter++)
            {
                long[][] NewMatrix= matrix;
                for (int i=0;i<nodeCount;i++)
                {
                    for (int j=0;j<nodeCount;j++)
                    {
                        if (i==itter-1 || j==itter-1 || i==j)
                        {
                            continue;
                        }
                        else
                        {
                            long min=matrix[i][j];
                            if (min>matrix[i][itter-1]+matrix[itter-1][j])
                            {
                                min=matrix[i][itter-1]+matrix[itter-1][j];
                            }
                            NewMatrix[i][j]=min;
                        }
                    }
                    matrix=NewMatrix;
                }
            }
            List<long> result=new List<long>();
            for(int i=0;i<nodeCount;i++)
            {
                for(int j=0;j<nodeCount;j++)
                {
                    if(matrix[i][j]!=0)
                    {
                        result.Add(matrix[i][j]);
                    }
                }
            }
            return result.ToArray();
        }
    }
}
