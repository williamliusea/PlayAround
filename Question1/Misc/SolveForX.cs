using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misc
{
    /// <summary>
    /// Write the following function
    /// double  solveForX(string s) {   }
    /// input will be linear equation in x with +1 or -1 coefficient.
    /// output will be value of x.
    /// s can be as follows
    /// i/p   x + 9 - 2 -4 + x = - x + 5 - 1 + 3 - x   o/p  1.00
    /// i/p    x + 9 -1 = 0  o/p -8.00
    /// i/p    x + 4 = - 3 - x  o/p  -3.500
    /// 
    /// it has second part
    /// if the i/p string can have ‘(‘ or  ‘)’
    /// x + 9 - 2 -(4 + x) = - (x + 5 - 1 + 3) - x
    /// x + 9 + (3 + - x - ( -x + (3 - (9 - x) +x = 9 -(5 +x )

    /// </summary>
    public class SolveForX
    {
        public static double solveForX(string s)
        {
            int xc = 0;
            bool equal = false;
            bool minus = false;
            int sum = 0;
            for (int i = 0; i < s.Length; i++)
            {
                switch (s[i])
                {
                    case 'x':
                        if (equal ^ minus) xc--;
                        else xc++;
                        minus = false;
                        break;
                    case '-':
                        minus = true;
                        break;
                    case '+':
                        minus = false;
                        break;
                    case '=':
                        equal = true;
                        minus = false;
                        break;
                    default:
                        if (s[i] >= '0' && s[i] <= '9')
                        {
                            if (equal ^ minus) sum += (s[i] - '0');
                            else sum -= (s[i] - '0');
                        }
                        break;
                }
            }

            return sum / (double)xc;
        }

        public static void Test()
        {
            Assert.AreEqual(1.0, solveForX("x + 9 - 2 -4 + x = - x + 5 - 1 + 3 - x"));
            Assert.AreEqual(-8.0, solveForX("x + 9 -1 = 0"));
            Assert.AreEqual(-3.50, solveForX("x + 4 = - 3 - x"));
        }
    }
}
