using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q6MaximizeSalary : Processor
    {
        public Q6MaximizeSalary(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], string>) Solve);


        public virtual string Solve(long n, long[] numbers)
        {
            List<long> b=new List<long>();
            string[] str_numbers=new string[n];
            for (int k=0;k<n;k++)
            {
                str_numbers[k]=numbers[k].ToString();
            }
            foreach (var i in numbers)
            {
                b.Add(i);
            }
            long largest_lenght=0;
            foreach (var i in str_numbers)
            {
                if (largest_lenght<i.Length)
                    largest_lenght=i.Length;
            }
            for (int i=0;i<n;i++)
            {
                long a=str_numbers[i].Length;
                while (largest_lenght>=a)
                {
                    a=str_numbers[i].Length;
                    for (int j=0;j<a;j++)
                    {
                        str_numbers[i]+=str_numbers[i][j];
                        if (largest_lenght+1==str_numbers[i].Length)
                            break;
                    }
                }
            }
            List<List<long>> dict=new List<List<long>>();
            for(int i=0;i<n;i++)
            {
                dict.Add(new List<long>(){i,long.Parse(str_numbers[i])});
            }
            dict=dict.OrderByDescending(m=>m[1]).ToList();
            string res = "";
            for (int j=0;j<n;j++)
            {
                // max_item=max(a)
                // max_index=a.index(max_item)
                // res += b[max_index]
                // b.remove(b[max_index])
                // a.remove(max_item)
                int a=(int)dict[j][0];
                res+=$"{b[a]}";
            }
            return res;
        }
    }
}

