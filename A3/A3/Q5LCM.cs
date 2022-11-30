using System;
using TestCommon;

namespace A3
{
    public class Q5LCM : Processor
    {
        public Q5LCM(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long>)Solve);

        public long Solve(long a, long b)
        {
            return (long)(a*b/Gcd(a,b));
        }
        public long Gcd(long a, long b)
        {
            if (b==0)
                return a;
            if (b>a)
                (a,b)=(b,a);
            return Gcd(b , a % b);
        }

    }
}
