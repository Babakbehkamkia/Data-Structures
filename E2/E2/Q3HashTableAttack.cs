using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TestCommon;

namespace E2
{
    public class Q3HashTableAttack : Processor
    {
        public Q3HashTableAttack (string testDataName) : base(testDataName) 
        {
        }

        public override string Process(string inStr)
        {
            long bucketCount = long.Parse(inStr);
            return string.Join("\n", Solve(bucketCount));
        }

        public string[] Solve(long bucketCount)
        {
            long max = (long)(bucketCount * 0.9);
            string[] result = new string[max];
            // long hash = GetBucketNumber("1", bucketCount);
            long hash = GetBucketNumber("a", bucketCount);
            long i = 0;
            result[i++] = "a";
            while (i < max)
            {
                string newString = "";
                string str="a";
                while (GetBucketNumber(newString, bucketCount) != hash)
                {
                    str.Append('a');
                    newString = str.ToString();
                }
                result[i++] = newString;
            }
            return result;
        }

        #region Chars
        static char[] LowChars = Enumerable
            .Range(0, 26)
            .Select(n => (char)('a' + n))
            .ToArray();

        static char[] CapChars = Enumerable
            .Range(0, 26)
            .Select(n => (char)('A' + n))
            .ToArray();

        static char[] Numbers = Enumerable
            .Range(0, 10)
            .Select(n => (char)('0' + n))
            .ToArray();

        static char[] AllChars = 
            LowChars.Concat(CapChars).Concat(Numbers).ToArray();
        #endregion


        // پیاده‌سازی مورد استفاده دات‌نت برای پیدا کردن شماره باکت
        // https://referencesource.microsoft.com/#mscorlib/system/collections/generic/dictionary.cs,bcd13bb775d408f1
        public static long GetBucketNumber(string str, long bucketCount) =>
            (str.GetHashCode() & 0x7FFFFFFF) % bucketCount;
    }
}
