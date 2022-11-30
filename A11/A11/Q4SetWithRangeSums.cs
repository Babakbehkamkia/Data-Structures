using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A11
{
    public class Vertex
    {
        public long key;
        public long sum;
        public Vertex left;
        public Vertex right;
        public Vertex parent;
        public Vertex(long key, long sum, Vertex left, Vertex right, Vertex parent)
        {
            this.key = key;
            this.sum = sum;
            this.left = left;
            this.right = right;
            this.parent = parent;
        }
    }
    public class Q4SetWithRangeSums : Processor
    {
        public Q4SetWithRangeSums(string testDataName) : base(testDataName){}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string[], string[]>)Solve);

        public readonly Dictionary<char, Func<string, string>> CommandDict;

        public static long M = 1000000001;

        public static long X = 0;

        protected List<long> Data;

        

        public string[] Solve(string[] lines)
        {
            X = 0;
            root = null;
            Data = new List<long>();
            List<string> result = new List<string>();
            foreach (var line in lines)
            {
                char cmd = line[0];
                string args = line.Substring(1).Trim();
                if (cmd == 's')
                {
                    var toks = args.Split();
                    long from = long.Parse(toks[0]);
                    long to = long.Parse(toks[1]);
                    from =(long) ((from + X) % M);
                    to =(long) ((to + X) % M);
                    var output = sum(from , to);
                    X = long.Parse(output) ;
                    X = X % M ;
                    result.Add(output);
                }
                else if (cmd == '+')
                {
                    long wanted = long.Parse(args);
                    wanted = (long) ((wanted + X) % M);
                    insert(wanted.ToString());
                }
                else if (cmd == '-')
                {
                    long wanted = long.Parse(args);
                    wanted = (long) ((wanted + X) % M);
                    erase(wanted.ToString());
                }
                else if (cmd == '?')
                {
                    long wanted = long.Parse(args);
                    wanted = (long) ((wanted + X) % M);
                    var output = find(wanted.ToString());
                    result.Add(output);
                }
            }
            return result.ToArray();
        }

        private long Convert(long i)
            => i = (i + X) % M;

        private string Add(string arg)
        {
            long i = Convert(long.Parse(arg));
            long idx = Data.BinarySearch(i);
            return null;
        }

        private string Del(string arg)
        {
            long i = Convert(long.Parse(arg));
            long idx = Data.BinarySearch(i);
            return null;
        }

        private string Sum(string arg)
        {
            var toks = arg.Split();
            long l = Convert(long.Parse(toks[0]));
            long r = Convert(long.Parse(toks[1]));

            l = Data.BinarySearch(l);
            if (l < 0)
                l = ~l;

            r = Data.BinarySearch(r);
            if (r < 0)
                r = (~r - 1);
            long sum = 0;

            X = sum;

            return sum.ToString();
        }
        public static void update(Vertex v)
        {
            if (v == null)
            {
                return;
            }
            v.sum = v.key + (v.left != null ? v.left.sum : 0) + (v.right != null ? v.right.sum : 0);
            if (v.left != null)
            {
                v.left.parent = v;
            }
            if (v.right != null)
            {
                v.right.parent = v;
            }
        }

        public static void small_rotation(Vertex v)
        {
            Vertex parent = v.parent;
            if (parent == null)
            { // v????,????
                return;
            }
            Vertex grandparent = v.parent.parent;
            if (parent.left == v)
            { // v?????
                Vertex m = v.right;
                v.right = parent;
                parent.left = m;
            }
            else
            {
                Vertex m = v.left;
                v.left = parent;
                parent.right = m;
            }
            update(parent);
            update(v);
            v.parent = grandparent;
            if (grandparent != null)
            {
                if (grandparent.left == parent)
                {
                    grandparent.left = v;
                }
                else
                {
                    grandparent.right = v;
                }
            }
        }

        public static void big_rotation(Vertex v)
        {
            if (v.parent.left == v && v.parent.parent.left == v.parent)
            {
                // Zig-zig
                small_rotation(v.parent);
                small_rotation(v);
            }
            else if (v.parent.right == v && v.parent.parent.right == v.parent)
            {
                // Zig-zig
                small_rotation(v.parent);
                small_rotation(v);
            }
            else
            {
                // Zig-zag
                small_rotation(v);
                small_rotation(v);
            }
        }
        public static void splay(ref Vertex root, Vertex v)
        {
            if (v == null)
            {
                return;
            }
            while (v.parent != null)
            {
                if (v.parent.parent == null)
                {
                    small_rotation(v);
                    break;
                }
                big_rotation(v);
            }
            root = v;
        }

        public static Vertex find(ref Vertex root, long key)
        {
            Vertex v = root;
            Vertex last = root;
            Vertex next = null;
            while (v != null)
            {
                if (v.key >= key  && (next == null || v.key < next.key))
                {
                    next = v;
                }
                last = v;
                if (v.key == key)
                {
                    break;
                }
                else if (v.key < key)
                {
                    v = v.right;
                }
                else
                {
                    v = v.left;
                }
            }
            splay(ref root, last);
            return next;
        }

        public static void split(Vertex root, long key, ref Vertex left, ref Vertex right)
        {
            right = find(ref root, key);
            splay(ref root, right);
            if (right == null)
            {
                left = root;
                return;
            }
            left = right.left;
            right.left = null;
            if (left != null)
            {
                left.parent = null;
            }
            update(left);
            update(right);
        }

        public static Vertex merge(Vertex left, Vertex right)
        {
            if (left == null)
            {
                return right;
            }
            if (right == null)
            {
                return left;
            }
            Vertex min_right = right;
            while (min_right.left != null)
            {
                min_right = min_right.left;
            }
            splay(ref right, min_right);
            right.left = left;
            update(right);
            return right;
        }
        public static Vertex root = null;

        public static string insert(string x_str)
        {
            long x = long.Parse(x_str);
            Vertex left = null;
            Vertex right = null;
            Vertex new_vertex = null;
            split(root, x, ref left, ref right);
            if (right == null || right.key != x)
            {
                new_vertex = new Vertex(x, x, null, null, null);
            }
            root = merge(merge(left, new_vertex), right);
            return null;
        }

        public static string find(string x_str)
        {
            long x = long.Parse(x_str);
            Vertex ans = find(ref root, x);
            if (ans != null && ans.key == x)
            {
                return "Found";
            }
            else
            {
                return "Not found";
            }
        }
        public static string erase(string x_str)
        {
            long x = long.Parse(x_str);
            if (root == null || find(x_str) == "Not found")
            {
                return null;
            }
            Vertex w = root;
            if (root.left == null)
            {
                root = root.right;
                if (root != null)
                {
                    root.parent = null;
                }
            }
            else if (root.right == null)
            {
                root = root.left;
                if (root != null)
                {
                    root.parent = null;
                }
            }
            else
            {
                Vertex lt = root.left;
                lt.parent = null;
                root.left = null;
                root = root.right;
                root.parent = null;
                find(w.key.ToString());
                root.left = lt;
                lt.parent = root;
            }
            w = null;
            if (root != null)
            {
                update(root);
            }
            return null;
        }
        public static string sum(long from , long to)
        {
            Vertex left = null;
            Vertex middle = null;
            Vertex right = null;
            split(root, from, ref left, ref middle);
            split(middle, to + 1, ref middle, ref right);
            long ans = 0;
            if (middle != null)
            {
                ans = middle.sum;
            }
            root = merge(left, merge(middle, right));
            return ans.ToString();
        }

    }
}
