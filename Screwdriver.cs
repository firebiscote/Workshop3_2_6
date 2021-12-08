using System;
using System.Threading;

namespace Workshop3_2_6
{
    public static class Screwdriver
    {
        public static Semaphore Semaphore = new Semaphore(0, 2);

        public static void Used()
        {
            Console.WriteLine("ScrewDriver used !");
        }
    }
}
