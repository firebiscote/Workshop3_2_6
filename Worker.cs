using System;
using System.Threading;

namespace Workshop3_2_6
{
    public class Worker
    {
        public static int TotalBuiltItems = 0;
        public string Name { get; }
        public int WorkerBuiltItem { get; set; }

        public Worker(string name) 
        {
            Name = name;
            WorkerBuiltItem = 0;
        }

        public void Work(ITool toolLeft, ITool toolRight)
        {
            if (toolLeft.GetType() == toolRight.GetType())
                throw new Exception();
            Thread.Sleep(2000);
            toolLeft.Use();
            toolRight.Use();
            Console.WriteLine($"{Name} Built !");
            WorkerBuiltItem++;
            TotalBuiltItems++;
        }
    }
}
