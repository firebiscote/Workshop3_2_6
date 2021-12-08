using System;
using System.Threading;

namespace Workshop3_2_6
{
    public class Worker
    {
        public static Semaphore WrenchSemaphore = new Semaphore(2, 2);
        public static Semaphore ScrewdriverSemaphore = new Semaphore(2, 2);
        public int TotalBuiltItems { get; set; }

        public Worker()
        {
            TotalBuiltItems = 0;
        }

        public void TryToWork()
        {
            WrenchSemaphore.WaitOne();
            ScrewdriverSemaphore.WaitOne();
            Wrench.Used();
            Screwdriver.Used();
            Thread.Sleep(2000);
            WrenchSemaphore.Release();
            ScrewdriverSemaphore.Release();
            Work();
        }

        public void Work()
        {
            Console.WriteLine("w");
            TotalBuiltItems++;
        }
    }
}
