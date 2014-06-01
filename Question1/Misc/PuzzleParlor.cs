using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misc
{
    /// <summary>
    /// Puzzle "Parlor "
    /// Beautiful You Pvt. Ltd. owns several parlors. Research has shown that if a customer arrives 
    /// and there is no staff available to service them, the customer will turn around and leave, 
    /// thus costing the company a sale. Your task is to write a program that tells the company how many customers left without getting any service.
    /// 
    /// Problem Definition:
    /// 
    /// The samples below consists of function calls for 4 parlors. Function call for each parlor contains a positive integer, 
    /// representing the number of staff in the parlor, followed by a sequence of uppercase letters.
    /// 
    /// Letters in the sequence occur in pairs. The first occurrence indicates the arrival of a customer; 
    /// the second indicates the departure of that same customer. A customer will be serviced if there is an unoccupied staff. No letter will occur in more than one pair.
    /// Customers who leave without getting service always depart before customers who are currently 
    /// being serviced. There are at most 20 staff per parlor. 
    /// 
    /// Output:
    /// For each set of inputs, implement the function "simulateParlor" and output a number telling how many customers, 
    /// if any, walked away. 0 would indicate all customers were serviced.
    /// 
    /// Sample Inputs with Expected Answers
    /// simulateParlor (2, "ABBAJJKZKZ") = 0
    /// simulateParlor (3, "GACCBDDBAGEE") = 1
    /// simulateParlor (3, "GACCBGDDBAEE") = 0
    /// simulateParlor (1, "ABCBCA") = 2
    /// </summary>
    public class PuzzleParlor
    {
        /// <summary>
        /// tricky part is to avoid double count turned away customers
        /// </summary>
        /// <param name="n"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static int solution(int n, string c)
        {
            var m = new HashSet<char>();
            var away = new HashSet<char>();
            var r = 0;
            for (int i = 0; i < c.Length; i++)
            {
                if (m.Contains(c[i]))
                {
                    n++;
                    m.Remove(c[i]);
                }
                else
                {
                    if (n == 0)
                    {
                        if (!away.Contains(c[i]))
                        {
                            r++;
                            away.Add(c[i]);
                        }
                    }
                    else
                    {
                        n--;
                        m.Add(c[i]);
                    }

                }
            }

            return r;
        }

        public static void Test()
        {
            Assert.AreEqual(0, solution(2, "ABBAJJKZKZ"));
            Assert.AreEqual(1, solution(3, "GACCBDDBAGEE"));
            Assert.AreEqual(0, solution(3, "GACCBGDDBAEE"));
            Assert.AreEqual(2, solution(1, "ABCBCA"));

        }
    }
}
