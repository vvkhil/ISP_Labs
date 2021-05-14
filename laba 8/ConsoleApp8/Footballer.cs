using System;

namespace ConsoleApp8
{
    sealed class Footballer : Sportsman, INutrition<int>, IDrink<double>, IGame
    {
        public Footballer(int age, int height, double weight)
            : base(age, height, weight)
        { }

        // Объявляем делегат
        public delegate void FootballHandler(string message);
        // Создаем переменную делегата
        FootballHandler _deleg;
        // Регистрируем делегат
        public void RegisterHandler(FootballHandler del)
        {
            _deleg += del; // добавляем делегат
        }
        // Отмена регистрации делегата
        public void UnregisterHandler(FootballHandler del)
        {
            _deleg -= del; // удаляем делегат
        }

        public void Game()
        {
            Random rnd = new Random();
            while (Energy > 0)
            {
                while (Energy > 70)
                {
                    Console.Write($"1:Shot after acceleration\n");
                    Console.Write($"2:Shot\n");
                    Console.Write("Select actions:\n");
                    string choiseActions = Console.ReadLine();
                    int firstValue = rnd.Next(0, 3);
                    Console.WriteLine($"Random value {firstValue}");
                    Console.WriteLine();
                    {
                        switch (choiseActions)
                        {
                            case "1":
                                Attack(Activity.acceleration);
                                Attack(Activity.shot);
                                break;
                            case "2":
                                if (firstValue == 0)
                                {
                                    Attack(Activity.shot);
                                }
                                else
                                {
                                    if (firstValue == 1 || firstValue == 2 || firstValue == 3)
                                    {
                                        Energy -= 5;
                                        if (_deleg != null)
                                        {
                                            _deleg($"Wasted energy");
                                        }
                                    }
                                }
                                break;
                            default:
                                Console.WriteLine("\n\nIncorrect Input! Please try again.\n\n");
                                break;
                        }
                        GetGoals();
                        GetInfoEnergy();
                    }
                }
                while (Energy > 40)
                {
                    Console.Write($"1:Shot after acceleration\n");
                    Console.Write($"2:Shot\n");
                    Console.Write("Select actions:\n");
                    string choiseShot = Console.ReadLine();
                    int firstValue = rnd.Next(0, 1);
                    int secondValue = rnd.Next(0, 4);
                    Console.WriteLine($"Random value {firstValue}");
                    Console.WriteLine();
                    {
                        switch (choiseShot)
                        {
                            case "1":
                                if (firstValue == 0)
                                {
                                    Attack(Activity.acceleration);
                                    Attack(Activity.shot);
                                }
                                else
                                {
                                    if (firstValue == 1)
                                    {
                                        Energy -= 5;
                                        if (_deleg != null)
                                        {
                                            _deleg($"Wasted energy");
                                        }
                                    }
                                }
                                break;
                            case "2":
                                if (secondValue == 0)
                                {
                                    Attack(Activity.shot);
                                }
                                else
                                {
                                    if (secondValue == 1 || secondValue == 2 || secondValue == 3 || secondValue == 4)
                                    {
                                        Energy -= 5;
                                        if (_deleg != null)
                                        {
                                            _deleg($"Wasted energy");
                                        }
                                    }
                                }
                                break;
                            default:
                                Console.WriteLine("\n\nIncorrect Input! Please try again.\n\n");
                                break;
                        }
                        GetGoals();
                        GetInfoEnergy();
                    }
                }
                while (Energy > 0)
                {
                    Console.Write($"1:Shot after acceleration\n");
                    Console.Write($"2:Shot\n");
                    Console.Write("Select actions:\n");
                    string choiseShot = Console.ReadLine();
                    int firstValue = rnd.Next(0, 2);
                    int secondValue = rnd.Next(0, 5);
                    Console.WriteLine($"Random value {firstValue}");
                    Console.WriteLine();
                    {
                        switch (choiseShot)
                        {
                            case "1":
                                if (firstValue == 0)
                                {
                                    Attack(Activity.acceleration);
                                    Attack(Activity.shot);
                                }
                                else
                                {
                                    if (firstValue == 1 || firstValue == 2)
                                    {
                                        Energy -= 5;
                                        if (_deleg != null)
                                        {
                                            _deleg($"Wasted energy");
                                        }
                                    }
                                }
                                break;
                            case "2":
                                if (secondValue == 0)
                                {
                                    Attack(Activity.shot);
                                }
                                else
                                {
                                    if (secondValue == 1 || secondValue == 2 || secondValue == 3 || secondValue == 4 || secondValue == 5)
                                    {
                                        Energy -= 5;
                                        if (_deleg != null)
                                        {
                                            _deleg($"Wasted energy");
                                        }
                                    }
                                }
                                break;
                            default:
                                Console.WriteLine("\n\nIncorrect Input! Please try again.\n\n");
                                break;
                        }
                        GetGoals();
                        GetInfoEnergy();
                    }
                }
            }
        }

        public override void GetInfo()
        {
            Console.WriteLine($"Name:{Name}\nHeight:{Height}\nWeight:{Weight}\n");
        }


        double IDrink<double>.DrunkingWater(double drunkWater)
        {
            int count = 0;
            while (count < 4)
            {
                Console.Write($"1:drink 1.0 L\n");
                Console.Write($"2:drink 0.7 L\n");
                Console.Write($"3:drink 0.4 L\n");
                Console.Write("Select the actions number: ");
                string Choise = Console.ReadLine();
                switch (Choise)
                {
                    case "1":
                        drunkWater = Drink(drunkWater, 1.0);
                        drunkWater = Math.Round(drunkWater, 1);
                        Console.WriteLine($"\n\nWater Now: {drunkWater}\n\n");
                        count++;
                        break;
                    case "2":
                        drunkWater = Drink(drunkWater, 0.7);
                        drunkWater = Math.Round(drunkWater, 1);
                        Console.WriteLine($"\n\nWater Now: {drunkWater}\n\n");
                        count++;
                        break;
                    case "3":
                        drunkWater = Drink(drunkWater, 0.4);
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
            while (count < 4)
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


        public enum Activity
        {
            acceleration = 1,
            shot,
        }


        private int goals;


        public void Attack(Activity activity)
        {
            switch (activity)
            {
                case Activity.acceleration:
                    Energy -= 5;
                    break;
                case Activity.shot:
                    goals += 1;
                    Energy -= 4;
                    break;
            }
        }


        public void GetGoals()
        {
            Console.WriteLine("{0} goals ", goals);
        }


        public int GetIntGoals()
        {
            return goals;
        }
    }
}