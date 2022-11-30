using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A2
{
    public class Q2FastMaxPairWise : Processor
    {
        public Q2FastMaxPairWise(string testDataName) : base(testDataName) { }
        public override string Process(string inStr) => 
            Solve(inStr.Split(new char[] { '\n', '\r', ' ' },
                StringSplitOptions.RemoveEmptyEntries)
                 .Select(s => long.Parse(s))
                 .ToArray()).ToString();

        public static long Solve(long[] numbers)
        {
            int n = numbers.Length;
            long max_product1 = 0;
            long max_product2=0;
            long max_index=0;
            for(int i=0;i<n;i++)
            {
                if( max_product1<numbers[i])
                {
                    max_product1=numbers[i];
                    max_index=i;
                }
            }
            numbers[max_index]=0;
            

            for (int j=0;j<n;j++)
            {
                if( max_product2<numbers[j])
                {
                    max_product2=numbers[j];
                }
            }        
            return max_product1*max_product2;
        }
    }
}
