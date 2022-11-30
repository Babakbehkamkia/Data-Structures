using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace C2
{
    public class Q1PrimeNumbers : Processor
    {
        public Q1PrimeNumbers(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, string>) Solve);

        public static string Solve(string a)
        {
            int n=int.Parse(a);
            string result="";
            
            int max=(int)Math.Sqrt(n);
            for(int i=2;i<=max;i++)
            {
                int power=0;
                if (n%i==0)
                {
                    result+=$"{i}";
                }
                while(n%i==0)
                {
                    power++;
                    n=n/i;
                }
                if(n==1)
                {
                    if(power!=1)
                        result+=$"^{power}";
                    break;
                }
                if (power==1)
                {
                        result+="*";
                }
                if(power!=0 && power!=1)
                {
                    result+=$"^{power}*";
                }

            }
            if(n!=1)
            {
                result+=$"{n}";
            }
            return result;
        }

    }
}
