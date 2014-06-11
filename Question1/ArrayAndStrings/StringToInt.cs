using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayAndStrings
{
    public class StringToInt
    {
        public static bool solution(string s, out int o)
        {
            // cases 
            // 1.s = null or count=0
            // 2. s has '-'
            // 3. s out of range
            // 4. s has  ' ' before or after
            // 5. s is not interger # or contains not supported char
            o = 0;
            if (s == null || s.Length == 0) return false;
            bool minus = false;
            bool begin = false;
            bool end = false;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] <= '9' && s[i] >= '0')
                {
                    begin = true;
                    if (end) return false;
                    if (minus) o = o * 10 - (s[i] - '0');
                    else o = o * 10 + s[i] - '0';
                    // check overflow
                    if ((o < 0) ^ minus) return false;
                }
                else if (s[i] == ' ')
                {
                    if (begin) end = true;
                }
                else if (s[i] == '-')
                {
                    if (minus && begin) return false;
                    minus = true;
                }
                else return false;
            }

            return true;
        }

        public static void Test()
        {
            int r;
            Assert.IsFalse(solution("", out r));
            Assert.IsFalse(solution(" 1 2", out r));
            Assert.IsFalse(solution(" 1-2", out r));
            Assert.IsTrue(solution(" -12 ", out r));
            Assert.AreEqual(-12, r);
            Assert.IsTrue(solution(" 012 ", out r));
            Assert.AreEqual(12, r);
            Assert.IsFalse(solution(int.MaxValue.ToString() + "0", out r));
            Assert.IsFalse(solution(int.MinValue.ToString() + "0", out r));

        }
    }
}
