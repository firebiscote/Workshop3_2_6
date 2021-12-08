using System;
using System.Threading;

namespace Workshop3_2_6
{
    class Program
    {
        private delegate void DELG(object state);
        private static string wrench = "Utilisation de la wrench";
        private static string screwdriver = "Utilisation du screwdriver";
        private static Semaphore wrenchS;
        private static Semaphore screwdriverS;
        public static int totalWork;

        static void Main(string[] args)
        {
            totalWork = 0;
            wrenchS = new Semaphore(2, 2);
            screwdriverS = new Semaphore(2, 2);
            DELG d = (state) =>
            {
                wrenchS.WaitOne();
                screwdriverS.WaitOne();
                Console.WriteLine(wrench);
                Console.WriteLine(screwdriver);
                Console.WriteLine($"Work {state}");
                totalWork++;
                wrenchS.Release();
                screwdriverS.Release();
            };
            DateTime start = DateTime.Now, end = DateTime.Now;
            while (totalWork < 220) {
                Thread t1 = new Thread(d.Invoke);
                Thread t2 = new Thread(d.Invoke);
                Thread t3 = new Thread(d.Invoke);
                Thread t4 = new Thread(d.Invoke);

                t1.Start("T1");
                t2.Start("T2");
                t3.Start("T3");
                t4.Start("T4");
                end = DateTime.Now;
            }
            Console.WriteLine(end - start);

        }
    }
}
