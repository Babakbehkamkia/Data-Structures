using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TestCommon;

namespace E2
{
    public class Q2ThreeChildrenMinHeap : Processor
    {
        public Q2ThreeChildrenMinHeap(string testDataName) : base(testDataName) { }
        public override string Process(string inStr)
        {
            return TestTools.Process(inStr, (Func<long,long[],long[], string>)Solve);
        }
        public string Solve(long n,long[] change,long[] heap)
        {
            long old=heap[change[0]];
            heap[change[0]]+=change[1];
            if(heap[change[0]]>old)
            {
                siftdown(change[0],heap);
            }
            else{
                siftup(change[0],heap);
            }
            return heap.ToString();
            
        }
        public void siftdown(long i,long[] tree)
        {
            long parnetIndex=(long)((i-1)/3);
            long leftIndex=(long)((3*i)+1);
            long vasatIndex=(long)((3*i)+2);
            long rightIndex=(long)((3*i)+3);
            long min=tree[leftIndex];
            if(min>tree[vasatIndex])
            {
                min=tree[vasatIndex];
            }
            if(min>tree[rightIndex])
            {
                min=tree[rightIndex];
            }
            while(tree[i]>min && i<=tree.Length/3)
            {
                if(min==tree[leftIndex])
                {
                    (tree[i],tree[leftIndex])=(tree[leftIndex],tree[i]);
                    i=leftIndex;
                }
                else if(min==tree[vasatIndex])
                {
                    
                    (tree[i],tree[vasatIndex])=(tree[vasatIndex],tree[i]);
                    i=vasatIndex;
                }
                else if(min==tree[rightIndex])
                {
                    (tree[i],tree[rightIndex])=(tree[rightIndex],tree[i]);
                    i=rightIndex;
                }
                parnetIndex=(long)((i-1)/3);
                leftIndex=(long)((3*i)+1);
                vasatIndex=(long)((3*i)+2);
                rightIndex=(long)((3*i)+3);
                


                if(leftIndex>tree.Length)
                {
                    break;
                }
                if (vasatIndex>tree.Length)
                {
                    min=tree[leftIndex];
                    if (tree[i]>min)
                    {
                        (tree[i],tree[leftIndex])=(tree[leftIndex],tree[i]);
                    }
                    break;
                    // i=leftIndex;
                }
                if(rightIndex>tree.Length)
                {
                    min=tree[leftIndex];
                    if(min>tree[vasatIndex])
                    {
                        min=tree[vasatIndex];
                    }
                    if(tree[i]>min)
                    {
                        if(min==tree[leftIndex])
                        {
                            (tree[i],tree[leftIndex])=(tree[leftIndex],tree[i]);
                            // i=leftIndex;
                        }
                        else if(min==tree[vasatIndex])
                        {
                            (tree[i],tree[vasatIndex])=(tree[vasatIndex],tree[i]);
                            // i=vasatIndex;
                        }
                    }
                    break;
                }
                
                min=tree[leftIndex];
                if(min>tree[vasatIndex])
                {
                    min=tree[vasatIndex];
                }
                if(min>tree[rightIndex])
                {
                    min=tree[rightIndex];
                }
            }
        }
        public void siftup(long i,long[] tree)
        {
            while(i>0)
            {
                long parnetIndex=(long)((i-1)/3);
                if(tree[parnetIndex]>tree[i])
                {
                (tree[parnetIndex],tree[i])=(tree[i],tree[parnetIndex]);
                i=parnetIndex;
                }
            }
        }
    }
}
