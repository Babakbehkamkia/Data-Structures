using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A8
{
    public class Q1CheckBrackets : Processor
    {
        public Q1CheckBrackets(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, long>)Solve);

        public long Solve(string str)
        {
            Stack<Tuple<int,char>> brackets = new Stack<Tuple<int,char>>();
            int i=0;
            foreach(var s in str)
            {
                if("[{(".Contains(s))
                {
                    brackets.Push(Tuple.Create(i,s));
                }
                if("}])".Contains(s))
                {
                    if(brackets.Count==0)
                    {
                        return (long)i+1;
                    }
                    var top=brackets.Pop();
                    if ((top.Item2 == '(' && s != ')') || (top.Item2 == '[' && s != ']') || (top.Item2 == '{' && s != '}'))
                    {
                        return (long)i+1;
                    }
                    
                }
                i++;
            }
            if(brackets.Count!=0)
            {
                return brackets.Peek().Item1+1;
            }
            return -1;
        }
    }
}
