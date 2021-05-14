using System;

namespace ConsoleApp8
{
    abstract class Human
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public double Weight { get; set; }


        public Human(int age, int height, double weight)
        {
            Age = age;
            Height = height;
            Weight = weight;
        }


        public virtual void GetInfo()
        {
            Console.WriteLine($"Age:{Age}\nHeight:{Height}\nWeight:{Weight}\n");
        }


    }
}
