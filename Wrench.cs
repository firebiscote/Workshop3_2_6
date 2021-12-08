using System;

namespace Workshop3_2_6
{
    public class Wrench : ITool
    {
        public string Name { get; }

        public Wrench(string name)
        {
            Name = name;
        }

        public void Use()
        {
            Console.WriteLine($"{Name} used !");
        }
    }
}
