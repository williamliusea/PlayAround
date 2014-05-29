using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayAndStrings
{
    public class EvaluateReversePolishNotation
    {
        public static double Solution(string[] input)
        {
            var s = new Stack<double>();
            foreach (var item in input)
            {
                double a, b;
                switch (item)
                {
                    case "+":
                        a = s.Pop();
                        b = s.Pop();
                        s.Push(a+b);
                        break;
                    case "-":
                        a = s.Pop();
                        b = s.Pop();
                        s.Push(b - a);
                        break;
                    case "*":
                        a = s.Pop();
                        b = s.Pop();
                        s.Push(a * b);
                        break;
                    case "/":
                        a = s.Pop();
                        b = s.Pop();
                        s.Push(b/a);
                        break;
                    default:
                        s.Push(double.Parse(item));
                        break;
                }
            }

            return s.Pop();
        }
        public static void Test()
        {
            Assert.AreEqual(-1, Solution(new string[] { "1", "2", "-" }));
            Assert.AreEqual(1, Solution(new string[] { "1", "2", "+", "3", "/" }));
            Assert.AreEqual(2, Solution(new string[] { "3", "2", "*", "3", "/" }));
        }
    }
}
