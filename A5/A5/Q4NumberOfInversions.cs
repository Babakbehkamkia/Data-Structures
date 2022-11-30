using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;


namespace A5
{
    public class Q4NumberOfInversions:Processor
    {

        public Q4NumberOfInversions(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public virtual long Solve(long n, long[] a)
        {
            //write your code here
            long number_of_inversions = 0;
            List<long> sorted_list=new List<long>();
            (sorted_list,number_of_inversions)= mergesort(n,a);
            return number_of_inversions;
        }


        public virtual (List<long>,long) mergesort(long n,long[] a)
        {
            long number_of_inversions = 0;
            // List<long> sorted_list=new List<long>();
            if (n==1)
            {
                List<long> sorted_list=new List<long>();
                foreach(var item in a)
                {
                    sorted_list.Add(item);
                }
                return (sorted_list,number_of_inversions);
            }

            // a1=[]
            // a2=[]
            List<long> a1=new List<long>();
            List<long> a2=new List<long>();
            for (int item=0;item<(int)(n/2);item++ )
                a1.Add(a[item]);

            // m=int(n/2)
            for (int item2=(int)(n/2);item2<n;item2++ )
                a2.Add(a[item2]);
            long number_to_add=0;
            List<long> b1=new List<long>();
            List<long> b2=new List<long>();
            (b1,number_to_add)=mergesort((int)(n/2),a1.ToArray());
            number_of_inversions +=number_to_add;
            (b2,number_to_add)=mergesort((n-(int)(n/2)),a2.ToArray());
            number_of_inversions +=number_to_add;
            List<long> result=new List<long>();


            int first=0;
            int second=0;
            // # k=0
            for (int k=0;k<n;k++)
            {

                if (first>=b1.Count)
                {
                    first=-1;
                    break;
                }
                if (second>=b2.Count)
                {
                    second=-1;
                    break;
                }
                if (b1[first]>b2[second])
                {
                    result.Add(b2[second]);
                    second+=1;
                }
                else
                {

                    result.Add(b1[first]);
                    number_of_inversions+=result.Count-1-first;
                    first+=1;
                }
            }
            if (first==-1)
            {
                for (int j=second;j<b2.Count;j++)
                    result.Add(b2[j]);
            }
            if (second==-1)
            {
                for (int i=first;i<b1.Count;i++)
                {
                    result.Add(b1[i]);
                    number_of_inversions +=result.Count-1-i;
                }
            }
            return (result,number_of_inversions);
        }
    }
}
