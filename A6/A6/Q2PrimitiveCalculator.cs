using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A6
{
    public class Q2PrimitiveCalculator : Processor
    {
        public Q2PrimitiveCalculator(string testDataName) : base(testDataName) { }
        
        public override string Process(string inStr) => 
            TestTools.Process(inStr, (Func<long, long[]>) Solve);

        public long[] Solve(long n)
        {
            // write your code here
            List<long> sequence = new List<long>();
            long[] d=new long[n+1];
            // for i in range(m+1):
            //     d.append(0)
            long m=1;
            while (m<=n)
            {
                long first=d[m-1]+1;
                long third =first;
                if (m%3==0)
                    third=d[(int)(m/3)]+1;
                long second=first;
                if (m%2==0)
                    second=d[(int)(m/2)]+1;
                
                long[] results=new long[3]{first,second,third};

                d[m]=results.Min();
                m+=1;
            }
            m-=1;
            while (m>1)
            {
                sequence.Add(m);
                long first=d[m-1];
                long second=int.MaxValue;
                long third=int.MaxValue;
                if (m%2==0)
                    second=d[(int)(m/2)];
                if (m%3==0)
                    third=d[(int)(m/3)];
                long[] results=new long[3]{first,second,third};
                long minimum=results.Min();
                if (minimum==third)
                    m=(int)(m/3);
                else if (minimum==second)
                    m=(int)(m/2);
                
                else
                    m-=1;
            }
            sequence.Add(1);
            sequence.Reverse();
            return sequence.ToArray();
        }
    }
}
