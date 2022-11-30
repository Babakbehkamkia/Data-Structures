using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Priority_Queue;

namespace C11
{
    class Graph
    {
        private long nodeCount;
        private List<Tuple<Node,long>>[] Edges;
        public Graph(long nc)
        {
            nodeCount = nc;
            Edges = new List<Tuple<Node, long>>[(int)nc];
            for (int i = 0; i < nc; i++)
                Edges[i] = new List<Tuple<Node, long>>();
        }
        public void AddEdge(long start,long end,long weight)
        {
            //Your code
            this.Edges[start].Add(new Tuple<Node, long>(new Node(end, 0), weight));
        }
        public long UCS(long start,long goal)
        {
            //Your code
            bool[] visited = new bool[this.nodeCount];
            var Fringe = new SimplePriorityQueue<Node, Node>();
            Node start_node = new Node(start, 0);
            Fringe.Enqueue(start_node, start_node);
            while (Fringe.Count != 0)
            {
                Node min_cost_node = Fringe.Dequeue();
                visited[min_cost_node.Num] = true;
                if (min_cost_node.Num == goal)
                {
                    return min_cost_node.Cost;
                }
                foreach (var (node, weight) in this.Edges[min_cost_node.Num])
                {
                    if (!visited[node.Num])
                    {
                        Node adj = new Node(node.Num, min_cost_node.Cost + weight);
                        Fringe.Enqueue(adj, adj);
                    }
                }
            }
            return -1;
        }
        public string PathUCS(long start, long goal)
        {
            //Your code
            bool[] visited = new bool[this.nodeCount];
            var Fringe = new SimplePriorityQueue<Node, Node>();
            Node start_node = new Node(start, 0);
            Fringe.Enqueue(start_node, start_node);
            while (Fringe.Count != 0)
            {
                Node min_cost_node = Fringe.Dequeue();
                visited[min_cost_node.Num] = true;
                if (min_cost_node.Num == goal)
                {
                    return FoundPath(min_cost_node);
                }
                foreach (var (node, weight) in this.Edges[min_cost_node.Num])
                {
                    if (!visited[node.Num])
                    {
                        Node adj = new Node(node.Num, min_cost_node.Cost + weight);
                        adj.Parent=min_cost_node;
                        Fringe.Enqueue(adj, adj);
                    }
                }
            }
            return "-1";
        }

        private string FoundPath(Node current)
        {
            List<string> path=new List<string>();
            path.Add($"{current.Num+1}");
            while(current.Parent!=null)
            {
                path.Add($"{current.Parent.Num+1}");
                current=current.Parent;
            }
            path.Reverse();
            return string.Join(" ", path);
        }
    }
}
