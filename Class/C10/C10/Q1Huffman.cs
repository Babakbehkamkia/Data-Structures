using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Priority_Queue;
using TestCommon;

namespace C10
{
    public class Q1Huffman : Processor
    {
        public Q1Huffman(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, string>)Solve);

        public Dictionary<char, int> GenerateDict(string s)
        {
            // key = char | value = frequency
            //YOUR CODE
            Dictionary<char, int> dict = new Dictionary<char, int>();
            foreach (char item in s)
            {
                dict[item] = dict.GetValueOrDefault(item, 0) + 1;
            }
            return dict;
        }

        public string Solve(string s)
        {
            //YOUR CODE
            // generate dict
            var leaves = this.GenerateDict(s);
            var nodes = new SimplePriorityQueue<Node, Node>();
            foreach (var leaf in leaves)
            {
                Node new_node = new Node(leaf.Key, leaf.Value);
                nodes.Enqueue(new_node, new_node);
            }
            while (nodes.Count >= 2)
            {
                Node node1 = nodes.Dequeue();
                Node node2 = nodes.Dequeue();
                Node parent = new Node('$', node1.freq + node2.freq);
                parent.right = node2;
                parent.left = node1;
                nodes.Enqueue(parent, parent);
            }
            Node root = nodes.Dequeue();
            var codewords = new Dictionary<char, string>();
            GenerateCodes(root, "", codewords);
            StringBuilder sb = new StringBuilder();
            foreach (char c in s)
            {
                sb.Append(codewords[c]);
            }
            return sb.ToString();
        }

        private void GenerateCodes(Node root, string start, Dictionary<char, string> codewords)
        {
            if (root is null)
            {
                return;
            }
            if (root.chr != '$')
            {
                codewords.Add(root.chr, start);
            }
            else
            {
                GenerateCodes(root.left, start + '0', codewords);
                GenerateCodes(root.right, start + '1', codewords);
            }
        }
    }
}