using System;

namespace DataStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            // Array<int> arr = new Array<int>();
            // for (int i = 0; i < 10; i++)
            // {
            //     arr.AddLast(i);
            // }
            // Console.WriteLine(arr);

            // arr.Add(1, 100);
            // Console.WriteLine(arr);

            // arr.AddFirst(-1);
            // Console.WriteLine(arr);

            //Console.ReadLine();

            // LoopQueue<int> queue = new LoopQueue<int>();
            // for (int i = 0; i < 10; i++)
            // { 
            //     queue.Enqueue(i);
            //     Console.WriteLine(queue); 
            //     if (i % 3 == 2)
            //     {
            //         queue.Dequeue();
            //         Console.WriteLine(queue);
            //     }
            // }
            // Solution s = new Solution();
            // s.IsValid("{()}");
            int opCount = 100000;

            ArrayQueue<int> arrayQueue = new ArrayQueue<int>();
            double time1 = testQueue(arrayQueue, opCount);
            Console.WriteLine("ArraryQueue, time: " + time1 + "ms");

            LoopQueue<int> loopQueue = new LoopQueue<int>();
            double time2 = testQueue(loopQueue, opCount);
            Console.WriteLine("LoopQueue, time: " + time2 + "ms");
        }

        //测试使用q运行opCount个进队和出队操作所需要的时间，单位：秒
        public static double testQueue(iQueue<int> q, int count)
        {
            Random r = new Random();
            var startTime = System.DateTime.Now;

            for (int i = 0; i < count; i++)
            {
                q.Enqueue(r.Next(int.MaxValue));
            }
            for (int i = 0; i < count; i++)
            {
                q.Dequeue();
            }

            var endTime = System.DateTime.Now;
            var ts = endTime - startTime;
            return ts.Milliseconds;
        }
    }
}