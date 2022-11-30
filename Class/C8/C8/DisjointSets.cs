using System;
using System.Collections.Generic;

namespace C8
{
    class DisjointSets
    {
        public int[] parent;
        int n;
        public DisjointSets(int n)
        {
            this.n=n;
            this.parent=new int[n];
            this.makeSet();
        }

        public void makeSet()
        {
            for (int i =0;i<n;i++)
            {
                parent[i]=i+1;
            }
        }

        public int find(int x)
        {
            //Implement find
            if (parent[x-1]!=x)
            {
                parent[x-1]=find(parent[x-1]);
            }
            return parent[x-1];
        }

        public void union(int x, int y)
        {
            //Implement making union
            int xRoot=find(x);
            int yRoot=find(y);
            if (xRoot==yRoot)
            {
                return;
            }
            else
            {
                int max=Math.Max(xRoot,yRoot);
                parent[xRoot-1]=max;
                parent[yRoot-1]=max;
            }
        }   
    }
}
