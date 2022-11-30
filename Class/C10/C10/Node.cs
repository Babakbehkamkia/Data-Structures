﻿using System;

namespace C10
{
    public class Node : IComparable<Node>
    {
        public int freq;
        public char chr;
        public Node left;
        public Node right;
        public Node(char c, int f)
        {
            freq = f;
            chr = c;
        }

        public int CompareTo(Node other)
        {
            // freq -> CHR 
            //YOUR CODE
            if (this.freq == other.freq)
            {
                return this.chr.CompareTo(other.chr);
            }
            return this.freq.CompareTo(other.freq);
        }
    }
}