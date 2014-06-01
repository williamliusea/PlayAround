
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Misc
{
    /// <summary>
    /// Reverse adjacent nodes in a linked list
    /// Reverse the adjacent nodes in a linked list If the nodes of a linked list are as follows 
    /// 1 -> 2 -> 3 -> 4 -> 5 -> 6 -> 7 -> 8 -> 9 then after reverse they should be 2 -> 1 -> 4 -> 3 
    /// Here the number of entries are odd hence the last link is not reversed. 
    /// If number of nodes are even then last node should also be reversed.
    /// </summary>
    public class ReverseAdjacentNode
    {
        public class Node
        {
            public Node Next;
            public int d;
            public override string ToString()
            {
                return d.ToString();
            }

            public Node(int data)
            {
                d = data;
            }
        }
        public static Node Solution(Node head)
        {
            Node r = head;
            if (head.Next != null)
            {
                r = head.Next;
                var temp = r.Next;
                r.Next = head;
                head.Next = temp;

                var cur = r.Next.Next;
                var pre = r.Next;
                while (cur != null)
                {
                    if (cur.Next != null)
                    {
                        pre.Next = cur.Next;
                        temp = cur.Next.Next;
                        cur.Next.Next = cur;
                        cur.Next = temp;

                        pre = pre.Next.Next;
                        cur = pre.Next;
                    }
                    else
                    {
                        cur = cur.Next;
                    }
                }
            }

            return r;
        }

        public static Node Solution1(Node head)
        {
            if (head == null || head.Next == null) return head;
            var r = head.Next;
            head.Next = r.Next;
            r.Next = head;
            r.Next.Next = Solution1(r.Next.Next);           

            return r;
        }

        public static bool DifferentSign(int a, int b)
        {
            bool t1=(uint)a>>31==1;
            bool t2 = (uint)b >> 31 == 1;
            return  t1^t2;
        }
        public static void Test()
        {
            Assert.IsTrue(DifferentSign(100, -199));
            Assert.IsFalse(DifferentSign(100, 199));
            Assert.IsFalse(DifferentSign(-100, -199));

            var h = new Node(0);
            var c = h;
            for (int i = 1; i < 4; i++)
            {
                c.Next = new Node(i);
                c = c.Next;
            }

            h=Solution(h);
            Assert.AreEqual(0, h.Next.d);
            Assert.AreEqual(3, h.Next.Next.d);
            h = new Node(0);
            c = h;
            for (int i = 1; i < 4; i++)
            {
                c.Next = new Node(i);
                c = c.Next;
            }

            h = Solution1(h);
            Assert.AreEqual(0, h.Next.d);
            Assert.AreEqual(3, h.Next.Next.d);

            h = new Node(0);
            c = h;
            for (int i = 1; i < 5; i++)
            {
                c.Next = new Node(i);
                c = c.Next;
            }

            h = Solution(h);
            Assert.AreEqual(0, h.Next.d);
            Assert.AreEqual(4, h.Next.Next.Next.Next.d);

            h = new Node(0);
            c = h;
            for (int i = 1; i < 5; i++)
            {
                c.Next = new Node(i);
                c = c.Next;
            }

            h = Solution1(h);
            Assert.AreEqual(0, h.Next.d);
            Assert.AreEqual(4, h.Next.Next.Next.Next.d);
        }

    }
}
