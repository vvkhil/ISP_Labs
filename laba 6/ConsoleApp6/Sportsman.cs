using System;

namespace ConsoleApp6
{
    class Sportsman : Human<int>
    {
        private int energy;
        public int Energy
        {
            set
            {
                energy = value;
            }
            get
            {
                return energy;
            }
        }


        public int RecoveryEnergy()
        {
            return Energy = 100;
        }


        private static string nationality = "Belarus";


        public Sportsman(int age, int height, double weight)
            : base(age, height, weight)
        { }


        public static void GetNationality()
        {
            Console.WriteLine($"Nationality:{nationality}");
        }


        public override void GetInfo()
        {
            Console.WriteLine($"Age:{Age}\nHeight:{Height}\nWeight:{Weight}\n");
        }


        public int dailyCalorieIntake;


        public int DailyCalorieIntake
        {
            get
            {
                return dailyCalorieIntake = (int)Weight * 10 + Height * 6 - Age * 5;
            }
        }


        public double dailyWaterIntake;


        public double DailyWaterIntake
        {
            get
            {
                return dailyWaterIntake = Math.Round(0.03 * Weight, 1);
            }
        }


        public void GetInfoDailyIntake()
        {
            Console.WriteLine($"Daily water intake,L:{DailyWaterIntake}\nDaily calorie intake,ccal:{DailyCalorieIntake}\n");
        }


        public double Drink(double drunkWater, double volumeWater)
        {
            return drunkWater + volumeWater;
        }


        public int Eat(int product1, int product2, int calorieNow)
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


        public double WeightGained(int calorieNow)
        {
            int difference = calorieNow - DailyCalorieIntake;
            Console.WriteLine($"Difference is: {difference}");
            double weightGained = (double)difference / 4000;
            Console.WriteLine($"Weight gained is: {weightGained}");
            Weight += weightGained;
            return Weight;
        }


        public void GetInfo(double newWeight)
        {
            Console.WriteLine($"Age:{Age}\nHeight:{Height}\nNew weight:{newWeight}\n");
        }


        public int GetEnergy(int calorieNowPersonnage, double waterNowPersonnage)
        {
            if (calorieNowPersonnage >= DailyCalorieIntake && waterNowPersonnage >= DailyWaterIntake)
            {
                Energy = 100;
            }
            else
            {
                if ((calorieNowPersonnage >= DailyCalorieIntake && waterNowPersonnage < DailyWaterIntake) ||
                    (calorieNowPersonnage < DailyCalorieIntake && waterNowPersonnage >= DailyWaterIntake))
                {
                    Energy = 90;
                }
                else
                {
                    if (calorieNowPersonnage < DailyCalorieIntake && waterNowPersonnage < DailyWaterIntake)
                    {
                        Energy = 80;
                    }
                }
            }
            return Energy;
        }


        public void GetInfoEnergy()
        {
            Console.WriteLine($"Energy:{Energy}\n");
        }


    }
    
    
}
