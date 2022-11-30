using System;
using System.Linq;
using System.Collections.Generic;
using TestCommon;

namespace A10
{
    public class Contact
    {
        public string Name;
        public int Number;

        public Contact(string name, int number)
        {
            Name = name;
            Number = number;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() ^ this.Number.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            var other = obj as Contact;
            return this.Name == other.Name && this.Number == other.Number;
        }
    }

    public class Q1PhoneBook : Processor
    {
        public Q1PhoneBook(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string[], string[]>)Solve);

        // protected Dictionary<int, Contact> PhoneBookList;

        public string[] Solve(string[] commands)
        {
            Dictionary<int, Contact> PhoneBookList = new Dictionary<int, Contact>();
            List<string> result = new List<string>(commands.Length);
            foreach (var cmd in commands)
            {
                var toks = cmd.Split();
                var cmdType = toks[0];
                var args = toks.Skip(1).ToArray();
                int number = int.Parse(args[0]);
                switch (cmdType)
                {
                    case "add":
                        if (PhoneBookList.ContainsKey(number))
                        {
                            PhoneBookList[number].Name = args[1];
                        }
                        else
                        {
                            PhoneBookList.Add(number, new Contact(args[1], number));
                        }
                        break;
                    case "del":
                        if (PhoneBookList.ContainsKey(number))
                        {
                            PhoneBookList[number].Name = "not found";
                        }
                        break;
                    case "find":
                        // result.Add(Find(number));
                        if (PhoneBookList.ContainsKey(number))
                        {
                            result.Add(PhoneBookList[number].Name);
                        }
                        else
                        {
                            result.Add("not found");
                        }
                        break;
                }
            }
            return result.ToArray();
        }
    }
}