using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A11
{
    public class Q3IsItBSTHard : Processor
    {
        public Q3IsItBSTHard(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[][], bool>)Solve);

        public bool Solve(long[][] nodes)
        {
            int length=nodes.Length;
            Node[] AllNodes=new Node[length];
            for(int i=0;i<length;i++)
            {
                Node node=new Node(nodes[i][0],nodes[i][1],nodes[i][2]);
                AllNodes[i]=node;
            }
            if(length == 0 || IsBinarySearchTree(AllNodes))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsBinarySearchTree(Node[] tree)
        {
            Queue<Node[]> q = new Queue<Node[]>(); 
            Node ln=new Node(-9999999,-1,-1);
            Node rn=new Node(9999999,-1,-1);
            q.Enqueue(new Node[3]{ln, tree[0], rn});
            // q.put([float('-inf'), tree[0], float('inf')])
            while (q.Count!=0)
            {
                Node[] n= q.Dequeue();
                Node root=n[1];
                Node left=n[0];
                Node right=n[2];
                if (root.key < left.key || root.key >= right.key)
                {
                    return false;
                }
                if (root.left != -1)
                {
                    q.Enqueue(new Node[3]{left, tree[root.left], root});
                }
                if (root.right != -1)
                {
                    q.Enqueue(new Node[3]{root, tree[root.right], right});
                }
            }
            return true;
        }
    
        
    }
    

}