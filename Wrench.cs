using System;
using System.Threading;

namespace Workshop3_2_6
{
    public static class Wrench
    {
        public static Semaphore Semaphore = new Semaphore(0, 2);

        public static void Used()
        {
            Semaphore.WaitOne();
            Console.WriteLine("Wrench used !");
            Thread.Sleep(2000);
            Semaphore.Release();
        }
    }
}
