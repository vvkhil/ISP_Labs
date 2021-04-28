using System;

namespace ConsoleApp6
{
    sealed class BasketballPlayer : Sportsman, IDrink<double>,INutrition<int>,IGame
    {
        public BasketballPlayer(int age, int height, double weight)
            : base(age, height, weight)
        { }


        public override void GetInfo()
        {
            Console.WriteLine($"Name:{Name}\nAge:{Age}\nHeight:{Height}\nWeight:{Weight}\n");
        }


        double IDrink<double>.DrunkingWater(double drunkWater)
        {
            int count = 0;
            while (count < 3)
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
                        count++;
                        break;
                    case "2":
                        drunkWater = Drink(drunkWater, 0.4);
                        drunkWater = Math.Round(drunkWater, 1);
                        Console.WriteLine($"\n\nWater Now: {drunkWater}\n\n");
                        count++;
                        break;
                    case "3":
                        drunkWater = Drink(drunkWater, 0.1);
                        drunkWater = Math.Round(drunkWater, 1);
                        Console.WriteLine($"\n\nWater Now: {drunkWater}\n\n");
                        count++;
                        break;
                    default:
                        Console.WriteLine("\n\nIncorrect Input! Please try again.\n\n");
                        break;
                }
            }
            drunkWater = Math.Round(drunkWater, 1);
            return drunkWater;
        }


        int INutrition<int>.Nutrition(int calorieNow, int meatCalorie, int vegetablesCalorie, int fruitsCalorie, int porridgeCalorie)
        {
            int count = 0;
            while (count < 3)
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
                        count++;
                        break;
                    case "2":
                        calorieNow += Eat(fruitsCalorie, porridgeCalorie, meatCalorie, calorieNow);
                        Console.WriteLine($"\n\nCalorie Now: {calorieNow}\n\n");
                        count++;
                        break;
                    case "3":
                        calorieNow += Eat(porridgeCalorie, meatCalorie, fruitsCalorie, vegetablesCalorie, calorieNow);
                        Console.WriteLine($"\n\nCalorie Now: {calorieNow}\n\n");
                        count++;
                        break;
                    default:
                        Console.WriteLine("\n\nIncorrect Input! Please try again.\n\n");
                        break;
                }
            }
            return calorieNow;
        }


        public void GetInfo(int calorieNowPersonnage, double waterNowPersonnage)
        {
            Console.WriteLine($"Name:{Name}\nCalorie:{calorieNowPersonnage}\nWater:{waterNowPersonnage}\n");
        }


        public enum Shot
        {
            twoPointShot = 1,
            threePointShot,
        }


        private int points;


        public void Attack(Shot shot)
        {
            switch (shot)
            {
                case Shot.twoPointShot:
                    points += 2;
                    break;
                case Shot.threePointShot:
                    points += 3;
                    break;
            }
        }


        public void GetPoints()
        {
            Console.WriteLine("{0} points ", points);
        }


        public int GetIntPoints()
        {
            return points;
        }


        public void Game()
        {
            Random rnd = new Random();
            while (Energy > 0)
            {
                while (Energy > 70)
                {
                    Console.Write($"1:Two-point shot\n");
                    Console.Write($"2:Three-point shot\n");
                    Console.Write("Select shot:\n");
                    string choiseShot = Console.ReadLine();
                    Console.WriteLine();
                    {
                        switch (choiseShot)
                        {
                            case "1":
                                Attack(Shot.twoPointShot);
                                Energy -= 5;
                                break;
                            case "2":
                                Attack(Shot.threePointShot);
                                Energy -= 8;
                                break;
                            default:
                                Console.WriteLine("\n\nIncorrect Input! Please try again.\n\n");
                                break;
                        }
                        GetPoints();
                        GetInfoEnergy();
                    }
                }
                while (Energy > 50)
                {
                    Console.Write($"1:Two-point shot\n");
                    Console.Write($"2:Three-point shot\n");
                    Console.Write("Select shot:\n");
                    string choiseShot = Console.ReadLine();
                    Console.WriteLine();
                    int value = rnd.Next(0, 1);
                    Console.WriteLine($"Random value {value}");
                    Console.WriteLine();
                    if (value == 0)
                    {
                        switch (choiseShot)
                        {
                            case "1":
                                Attack(Shot.twoPointShot);
                                Energy -= 5;
                                break;
                            case "2":
                                Attack(Shot.threePointShot);
                                Energy -= 8;
                                break;
                            default:
                                Console.WriteLine("\n\nIncorrect Input! Please try again.\n\n");
                                break;
                        }

                    }
                    else
                    {
                        if (value == 1)
                        {
                            Energy -= 5;
                        }

                    }
                    GetPoints();
                    GetInfoEnergy();
                }
                while (Energy > 30)
                {
                    Console.Write($"1:Two-point shot\n");
                    Console.Write($"2:Three-point shot\n");
                    Console.Write("Select shot:\n");
                    string choiseShot = Console.ReadLine();
                    Console.WriteLine();
                    int value = rnd.Next(0, 2);
                    Console.WriteLine($"Random value {value}");
                    Console.WriteLine();
                    if (value == 0)
                    {
                        switch (choiseShot)
                        {
                            case "1":
                                Attack(Shot.twoPointShot);
                                Energy -= 5;
                                break;
                            case "2":
                                Attack(Shot.threePointShot);
                                Energy -= 8;
                                break;
                            default:
                                Console.WriteLine("\n\nIncorrect Input! Please try again.\n\n");
                                break;
                        }

                    }
                    else
                    {
                        if (value == 1 || value == 2)
                        {
                            Energy -= 5;
                        }

                    }
                    GetPoints();
                    GetInfoEnergy();
                }
                while (Energy > 0)
                {
                    Console.Write($"1:Two-point shot\n");
                    Console.Write($"2:Three-point shot\n");
                    Console.Write("Select shot:\n");
                    string choiseShot = Console.ReadLine();
                    Console.WriteLine();
                    int value = rnd.Next(0, 3);
                    Console.WriteLine($"Random value {value}");
                    Console.WriteLine();
                    if (value == 0)
                    {
                        switch (choiseShot)
                        {
                            case "1":
                                Attack(Shot.twoPointShot);
                                Energy -= 5;
                                break;
                            case "2":
                                Attack(Shot.threePointShot);
                                Energy -= 8;
                                break;
                            default:
                                Console.WriteLine("\n\nIncorrect Input! Please try again.\n\n");
                                break;
                        }

                    }
                    else
                    {
                        if (value == 1 || value == 2 || value == 3)
                        {
                            Energy -= 5;
                        }

                    }
                    GetPoints();
                    GetInfoEnergy();
                }
            }
        }
    }
}
