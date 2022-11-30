using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace C1
{
    public class Q2BinarySearch : Processor
    {
        public Q2BinarySearch(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long>) Solve);

        public static long Solve(long[] a, long[] numbers)
        {
            return BinarySearch(a, numbers, 0, (int)a[0]);
        }

        private static long BinarySearch(long[] a, long[] numbers, int left, int right)
        {
            long answer=-1;
            while(right-left!=1)
            {
                
                int avrage= (int)((right+left)/2);
                if(numbers[avrage]==a[1])
                {
                    answer=avrage;
                    break;
                }
                if(numbers[avrage]>a[1])
                {
                    right=avrage;
                }
                
                else
                {
                    left=avrage;
                }
            }

            return answer;
        }
    }
}
