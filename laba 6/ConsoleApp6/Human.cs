using System;

namespace ConsoleApp6
{
    abstract class Human<T> 
    {
        public string Name { get; set; }
        public T Age { get; set; }
        public T Height { get; set; }
        public double Weight { get; set; }


        public Human(T age, T height, double weight)
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
