using System;

namespace Workshop3_2_6
{
    public class Screwdriver : ITool
    {
        public string Name { get; }

        public Screwdriver(string name)
        {
            Name = name;
        }

        public void Use()
        {
            Console.WriteLine($"{Name} used !");
        }
    }
}
