using System;

namespace ConsoleApp3
{
    class Human
    {
        private static string nationality = "Belarus";
        private string name;
        private int age, height;
        private double weight;


        public string Name { get; set; }

        public Human(int _age, int _height, double _weight)
        {
            age = _age;
            height = _height;
            weight = _weight;
        }
       
        
        public static void GetNationality()
        {
            Console.WriteLine($"Nationality:{nationality}");
        }
        
        public void GetInfo()
        {
            Console.WriteLine($"Name:{name}\nAge:{age}\nHeight:{height}\nWeight:{weight}\n");
        }
        
        
        public int dailyCalorieIntake;
       
        
        public int DailyCalorieIntake
        {
            get
            {
                return dailyCalorieIntake = (int)weight * 10 + height * 6 - age * 5;
            }
        }
        
        
        public double dailyWaterIntake;
        
        
        public double DailyWaterIntake
        {
            get
            {
                return dailyWaterIntake = Math.Round(0.03 * weight,1);
            }
        }
        
        
        public double Drink(double drunkWater,double volumeWater)
        {
            return drunkWater + volumeWater;
        }
        
        
        public int Eat(int product1,int product2,int calorieNow)
        {
            Console.WriteLine("Little food!");
            return calorieNow = product1 + product2;
        }
        
        
        public int Eat(int product1, int product2, int product3, int calorieNow)
        {
            Console.WriteLine("Enough food!");
            return calorieNow = product1 + product2 + product3;
        }
        
        
        public int Eat(int product1, int product2, int product3, int product4, int calorieNow)
        {
            Console.WriteLine("A lot of food!");
            return calorieNow = product1 + product2 + product3 + product4;
        }
       
       
        public double DrunkingWater(double drunkWater)
        {
            while (drunkWater < DailyWaterIntake)
            {
                Console.Write($"1:drink 0.7 L\n");
                Console.Write($"2:drink 0.4 L\n");
                Console.Write($"3:drink 0.1 L\n");
                Console.Write("Select the actions number: ");
                string Choise = Console.ReadLine();
                switch (Choise)
                {
                    case "1":
                        drunkWater = Drink(drunkWater, 0.7);
                        drunkWater = Math.Round(drunkWater, 1);
                        Console.WriteLine($"\n\nWater Now: {drunkWater}\n\n");
                        break;
                    case "2":
                        drunkWater = Drink(drunkWater, 0.4);
                        drunkWater = Math.Round(drunkWater, 1);
                        Console.WriteLine($"\n\nWater Now: {drunkWater}\n\n");
                        break;
                    case "3":
                        drunkWater = Drink(drunkWater, 0.1);
                        drunkWater = Math.Round(drunkWater, 1);
                        Console.WriteLine($"\n\nWater Now: {drunkWater}\n\n");
                        break;
                    default:
                        Console.WriteLine("\n\nIncorrect Input! Please try again.\n\n");
                        break;
                }
            }
            drunkWater = Math.Round(drunkWater, 1);
            return drunkWater;
        }
        
        
        public int Nutrition(int calorieNow, int meatCalorie, int vegetablesCalorie, int fruitsCalorie, int porridgeCalorie)
        {
            while (calorieNow < DailyCalorieIntake)
            {
                Console.Write($"1:eat meat({meatCalorie} ccal) with vegetables({vegetablesCalorie} ccal)\n");
                Console.Write($"2:eat meat({meatCalorie} ccal), porridge({porridgeCalorie} ccal) and fruits({fruitsCalorie} ccal)\n");
                Console.Write($"3:eat meat({meatCalorie} ccal), porridge({porridgeCalorie} ccal), fruits({fruitsCalorie} ccal) and vegetables({vegetablesCalorie} ccal)\n");
                Console.Write("Select the actions number: ");
                string Choise = Console.ReadLine();
                switch (Choise)
                {
                    case "1":
                        calorieNow += Eat(meatCalorie, vegetablesCalorie, calorieNow);
                        Console.WriteLine($"\n\nCalorie Now: {calorieNow}\n\n");
                        break;
                    case "2":
                        calorieNow += Eat(fruitsCalorie, porridgeCalorie, meatCalorie, calorieNow);
                        Console.WriteLine($"\n\nCalorie Now: {calorieNow}\n\n");
                        break;
                    case "3":
                        calorieNow += Eat(porridgeCalorie, meatCalorie, fruitsCalorie, vegetablesCalorie, calorieNow);
                        Console.WriteLine($"\n\nCalorie Now: {calorieNow}\n\n");
                        break;
                    default:
                        Console.WriteLine("\n\nIncorrect Input! Please try again.\n\n");
                        break;
                }
            }
            return calorieNow;
        }
        
        
        public double WeightGained(int calorieNow)
        {
            int difference = calorieNow - DailyCalorieIntake;
            Console.WriteLine($"Difference is: {difference}");
            double weightGained = (double)difference / 4000;
            Console.WriteLine($"Weight gained is: {weightGained}");
            weight += weightGained;
            return weight;
        }
        
        
        public void GetInfo(double newWeight)
        {
            Console.WriteLine($"Name:{name}\nAge:{age}\nHeight:{height}\nNew weight:{newWeight}\n");
        }
    }


    class People
    {
        Human[] data;
        public People()
        {
            data = new Human[2];
        }
        public Human this[int index]
        {
            get
            {
                return data[index];
            }
            set
            {
                data[index] = value;
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            People people = new People();
            people[0] = new Human(17, 170, 60) { Name = "Tom" };
            Human Tom = people[0];
            Human.GetNationality();
            Tom.GetInfo();
            Console.WriteLine($"\nCalorie,ccal:{Tom.DailyCalorieIntake}\nWater,L:{Tom.DailyWaterIntake}");

            int calorieNowTom = 0;
            double drunkWaterTom = 0;

            int meatCalorie = 445;
            int vegetablesCalorie = 123;
            int fruitsCalorie = 167;
            int porridgeCalorie = 234;


            Console.Write("\n\n");

            drunkWaterTom = Tom.DrunkingWater(drunkWaterTom);
            calorieNowTom = Tom.Nutrition(calorieNowTom, meatCalorie, vegetablesCalorie, fruitsCalorie, porridgeCalorie);

            double newWeightTom = Tom.WeightGained(calorieNowTom);
            Console.Write("\n\n");
            Tom.GetInfo(newWeightTom);

            Console.ReadKey();

            
            Console.Write("\n\n///////////////\nNew personage:\n///////////////\n\n");


            people[1] = new Human(17, 205, 130) { Name = "Oleg" };
            Human Oleg = people[1];
            Human.GetNationality();
            Oleg.GetInfo();
            Console.WriteLine($"\nCalorie,ccal:{Oleg.DailyCalorieIntake}\nWater,L:{Oleg.DailyWaterIntake}");

            int calorieNowOleg = 0;
            double drunkWaterOleg = 0;

            Console.Write("\n\n");

            drunkWaterOleg = Oleg.DrunkingWater(drunkWaterOleg);
            calorieNowOleg = Oleg.Nutrition(calorieNowOleg, meatCalorie, vegetablesCalorie, fruitsCalorie, porridgeCalorie);

            double newWeightOleg = Oleg.WeightGained(calorieNowOleg);
            Console.Write("\n\n");
            Oleg.GetInfo(newWeightOleg);

            Console.ReadKey();
        }
    }
}
