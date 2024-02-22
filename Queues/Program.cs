using System;
using System.Diagnostics.Metrics;
using System.Numerics;
using Queues.Models;
namespace Queues
{
    internal class Program
    {

        public static bool IsAscending(Queue<int> q)
        {
            Queue<int> copy = Copy(q);
            int x = copy.Remove();
            while (!copy.IsEmpty())
            {
                int y = copy.Remove();
                if (x > y)
                    return false;
                x=copy.Remove();
            }
            return true;
        }

        public static Queue<T> Copy<T>(Queue<T> original)
        {
            Queue<T> copy = new Queue<T>();
            Queue<T> temp = new Queue<T>();
            while (!original.IsEmpty())
            {
                temp.Insert(original.Remove());

            }
            while (!temp.IsEmpty())
            {
                copy.Insert(temp.Head());
                original.Insert(temp.Remove());
            }
            return copy;

        }

        public static int MinVal(Queue<int> q)
        {
            int min = int.MaxValue;
            Queue<int> copy = Copy(q);
            while (!copy.IsEmpty())
            {
                int val = copy.Remove();
                if ( val < min)
                    min = val;   
            }
            return min;

        }

        public static void RemoveMinVal(Queue<int> q)
        {
            Queue<int> temp = new Queue<int>();
            int min = MinVal(q);
            while(!q.IsEmpty())
            {
                if (q.Head() != min)
                    temp.Insert(q.Remove());
                else
                    q.Remove();
            }
            while(!temp.IsEmpty())
            {
                q.Insert(temp.Remove());
            }
        }

        public static int Count<T>(Queue<T> q)
        {
            int counter = 0;
            //ניצור עותק נוסף של התור
            Queue<T> temp = Copy(q);
            //נרוקן את העותק
            while (!temp.IsEmpty())
            {
                counter++;
                temp.Remove();
            }
            //נחזיר את הכמות
            return counter;
        }

        //תרגיל 4
        public static Queue<int> OrderAsc(Queue<int> q)
        {
            Queue<int> copy = Copy(q);
            Queue<int> q2 = new Queue<int>();
            while (!copy.IsEmpty())
            {
                q2.Insert(MinVal(copy));
                RemoveMinVal(copy);
            }
            return q2;
        }

        //תרגיל 5 
        public static void AddToMiddle<T>(Queue<T> q, T value)
        {
            int count = Count(q);
           
            for(int i =0; i<count; i++)
            {
                q.Insert(q.Remove());
                if(i==count/2-1)
                {
                    q.Insert(value);
                }
            }
        }

        //תרגיל 6
        public static int CountNoCopy(Queue<int> q)
        {
            int counter = 0;
            q.Insert(-1);
            int value = q.Remove();
            while(value!=-1) 
            {
                q.Insert(value);
                counter++;
                value = q.Remove();
            }
            return counter;
        }

        //תרגיל 7
        public static Queue<T> Mizug<T>(Queue<T> q1, Queue<T> q2)
        {
            int counter = 0;
            Queue<T> q3= new Queue<T>();
            while (!q1.IsEmpty() && !q2.IsEmpty())
            {
                if(counter%2==0)
                q3.Insert(q1.Remove());
                else
                q3.Insert(q2.Remove());
            }
            while (!q1.IsEmpty())
            {
                q3.Insert(q1.Remove());
            }
            while(!q2.IsEmpty())
            {
                q3.Insert(q2.Remove());
            }
            return q3;
        }

        public static void Mizug(Queue<int> q1, Queue<int> q2)
        {
            int count = Count(q1);
            while( !q2.IsEmpty())
            {
                if(q1.Head()<q2.Head())
                    q1.Insert(q1.Remove());
                else
                    q1.Insert(q2.Remove());
                count--;
            }
           while(count>0)
            {
                q1.Insert(q1.Remove());
                count--;
            }
        }
       
        public static bool BoolOk(Queue<char> q)
        {
            bool ok = false;
            Queue<char> temp = Copy(q);
            if (temp.Head() != 'T' || temp.Head() != 'F')
                return false;
            int howMany = Count(temp);
            for(int i=0; i<howMany-1; i++)
            {
                char value1 = temp.Remove();
                char value2 = temp.Remove();
                if (((value1 == 'A' || value1 == 'O') && (value2 == 'T' || value2 == 'F')) || ((value2 == 'A' || value2 == 'O') && (value1 == 'T' || value1 == 'F')))
                    ok = true;
                else ok = false;
            }
            if (temp.Remove() != 'T' || temp.Remove() != 'F')
                ok = false;
            return ok;
        }

        public static Queue<int> TheBiggestQueue(Queue<int> q)
        {
            Queue<int> temp = Copy(q);
            Queue<int> qnew = new Queue<int>();
            int max = 0;
            int value = temp.Remove();
            while (!temp.IsEmpty())
            {
                while (value != -1)
                {
                    if (value > max)
                        max = value;
                    value = temp.Remove();
                }
                qnew.Insert(max);
                value = temp.Remove();
            }
            return qnew;
        }

        public static int MakeTheBigNum(Queue<int> q)
        {
            Queue<int> temp = Copy(q);
           int value = temp.Remove();
            int num = value;
            while (!temp.IsEmpty())
            {
                int p10 = 10;
                value = temp.Remove();
                num += value * p10;
                p10 *= 10;
            }
            return num;
        }

        public static Queue<int> E5(Queue<int> q1, Queue<int> q2)
        {
            int bothsum = MakeTheBigNum(q1) + MakeTheBigNum(q2);
            Queue<int> qnew = new Queue<int>();
            while(bothsum > 0)
            {
                qnew.Insert(bothsum / 10);
                bothsum /= 10;
            }
            return qnew;


        }
        static void Main(string[] args)
        {
            Queue<int> q1= new Queue<int>();    
            q1.Insert(1);
            q1.Insert(2);
            q1.Insert(3);
            q1.Insert(4);
            q1.Insert(5);
            Console.WriteLine(q1);
            Console.WriteLine(QueueHelper.Count(q1));
            Console.WriteLine(IsAscending(q1));
            Console.WriteLine(MinVal(q1));
            RemoveMinVal(q1);
            Console.WriteLine(q1);
            AddToMiddle(q1, 1);
            Console.WriteLine(q1);
            Console.WriteLine(CountNoCopy(q1));
        }
    }
}