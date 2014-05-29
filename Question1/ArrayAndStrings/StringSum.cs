using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayAndStrings
{
    /// <summary>
    /// Given two strings, add them together
    /// for example, 123 + 45 = 168
    /// The string can be long. So do not convert to interger
    /// </summary>
    public class StringSum
    {
        public static string Solution(string a, string b)
        {
            char[] ret = new char[Math.Max(a.Length, b.Length)];
            int l = ret.Length - 1;
            int m = Math.Max(a.Length, b.Length);
            int c = 0;
            for (int i = 0; i < m; i++)
            {
                int t;
                if (i >= a.Length)
                {
                    t = b[b.Length - i - 1] - '0' + c;
                }
                else if(i>=b.Length)
                {
                    t = a[a.Length - i - 1] - '0' + c;
                }
                else
                {
                    t = a[a.Length - i - 1] - '0' + b[b.Length - i - 1] - '0' + c;
                }
                c = t / 10;
                ret[ret.Length - 1 - i] = (char)(t % 10 + '0');
            }


            string r = new string(ret);
            if(c==1)
            {
                r = "1" + r;
            }
            return r;
        }

        public static void Test()
        {
            Assert.AreEqual("134", Solution("123", "11"));
            Assert.AreEqual("130", Solution("123", "7"));
            Assert.AreEqual("101", Solution("99", "2"));
        }
    }
}
