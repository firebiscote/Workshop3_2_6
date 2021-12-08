using System;
using System.Threading;

namespace Workshop3_2_6
{
    class Program
    {
        private delegate void ThreadWorker(object state);

        static void Main(string[] args)
        {
            Worker w1 = new Worker("worker1");
            Worker w2 = new Worker("worker2");
            Worker w3 = new Worker("worker3");
            Worker w4 = new Worker("worker4");

            ITool wrench1 = new Wrench("w1");
            ITool wrench2 = new Wrench("w2");
            ITool screwdriver1 = new Screwdriver("s1");
            ITool screwdriver2 = new Screwdriver("s2");

            ThreadWorker threadWorker = (o) =>
            {
                Worker worker = (Worker)o;
                while (Worker.TotalBuiltItems < 230)
                {
                    switch (worker.Name[^1])
                    {
                        case '1':
                            if (Monitor.TryEnter(wrench1, 3000) && Monitor.TryEnter(screwdriver1, 3000))
                            {
                                worker.Work(wrench1, screwdriver1);
                                Monitor.Exit(wrench1);
                                Monitor.Exit(screwdriver1);
                            }
                            break;
                        case '2':
                            if (Monitor.TryEnter(wrench1, 3000) && Monitor.TryEnter(screwdriver2, 3000))
                            {
                                worker.Work(wrench1, screwdriver2);
                                Monitor.Exit(wrench1);
                                Monitor.Exit(screwdriver2);
                            }
                            break;
                        case '3':
                            if (Monitor.TryEnter(wrench2, 3000) && Monitor.TryEnter(screwdriver2, 3000))
                            {
                                worker.Work(wrench2, screwdriver2);
                                Monitor.Exit(wrench2);
                                Monitor.Exit(screwdriver2);
                            }
                            break;
                        case '4':
                            if (Monitor.TryEnter(wrench2, 3000) && Monitor.TryEnter(screwdriver1, 3000))
                            {
                                worker.Work(wrench2, screwdriver1);
                                Monitor.Exit(wrench2);
                                Monitor.Exit(screwdriver1);
                            }
                            break;
                    }
                }
            };

            Thread t1 = new Thread(threadWorker.Invoke);
            Thread t2 = new Thread(threadWorker.Invoke);
            Thread t3 = new Thread(threadWorker.Invoke);
            Thread t4 = new Thread(threadWorker.Invoke);

            t1.Start(w1);
            t2.Start(w2);
            t3.Start(w3);
            t4.Start(w4);

            DateTime start = DateTime.Now, end = DateTime.Now;
            while (Worker.TotalBuiltItems < 220)
            {
                end = DateTime.Now;
            }
            Console.WriteLine(end - start);
        }
    }
}
