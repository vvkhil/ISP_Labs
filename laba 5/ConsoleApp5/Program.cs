using System;
using System.Collections.Generic;

namespace ConsoleApp5
{
    abstract class Human
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public double Weight { get; set; }

       
        public Human( int age, int height, double weight)
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
    
    

    class Sportsman : Human
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
            :base(age,height,weight)
        {}


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


        public virtual double DrunkingWater(double drunkWater)
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


        public virtual int Nutrition(int calorieNow, int meatCalorie, int vegetablesCalorie, int fruitsCalorie, int porridgeCalorie)
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



    sealed class BasketballPlayer : Sportsman
    {
        public BasketballPlayer(int age, int height, double weight)
            : base(age, height, weight)
        { }


        public override void GetInfo()
        {
            Console.WriteLine($"Name:{Name}\nAge:{Age}\nHeight:{Height}\nWeight:{Weight}\n");
        }


        public override double DrunkingWater(double drunkWater)
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


        public override int Nutrition(int calorieNow, int meatCalorie, int vegetablesCalorie, int fruitsCalorie, int porridgeCalorie)
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



    sealed class Footballer : Sportsman
    {
        public Footballer(int age, int height, double weight)
            : base(age, height, weight)
        { }


        public override void GetInfo()
        {
            Console.WriteLine($"Name:{Name}\nHeight:{Height}\nWeight:{Weight}\n");
        }


        public override double DrunkingWater(double drunkWater)
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


        public override int Nutrition(int calorieNow, int meatCalorie, int vegetablesCalorie, int fruitsCalorie, int porridgeCalorie)
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


        public enum Actions
        {
            acceleration = 1,
            shot,
        }

        
        private int goals;


        public void Attack(Actions actions)
        {
            switch (actions)
            {
                case Actions.acceleration:
                    Energy -= 5;
                    break;
                case Actions.shot:
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
                                Attack(Actions.acceleration);
                                Attack(Actions.shot);
                                break;
                            case "2":
                                if(firstValue == 0)
                                {
                                    Attack(Actions.shot);
                                }
                                else
                                {
                                    if(firstValue == 1 || firstValue == 2 || firstValue == 3)
                                    {
                                        Energy -= 5;
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
                                    Attack(Actions.acceleration);
                                    Attack(Actions.shot);
                                }
                                else
                                {
                                    if (firstValue == 1)
                                    {
                                        Energy -= 5;
                                    }
                                }
                                break;
                            case "2":
                                if (secondValue == 0)
                                {
                                    Attack(Actions.shot);
                                }
                                else
                                {
                                    if (secondValue == 1 || secondValue == 2 || secondValue == 3 || secondValue == 4)
                                    {
                                        Energy -= 5;
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
                                    Attack(Actions.acceleration);
                                    Attack(Actions.shot);
                                }
                                else
                                {
                                    if (firstValue == 1 || firstValue == 2)
                                    {
                                        Energy -= 5;
                                    }
                                }
                                break;
                            case "2":
                                if (secondValue == 0)
                                {
                                    Attack(Actions.shot);
                                }
                                else
                                {
                                    if (secondValue == 1 || secondValue == 2 || secondValue == 3 || secondValue == 4 || secondValue == 5)
                                    {
                                        Energy -= 5;
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
    }


    
    class Footballers
    {
        Footballer[] data;
        public Footballers()
        {
            data = new Footballer[2];
        }
        public Footballer this[int index]
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



    class BasketballPlayers
    {
        BasketballPlayer[] data;
        public BasketballPlayers()
        {
            data = new BasketballPlayer[2];
        }
        public BasketballPlayer this[int index]
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



    struct PlayGround
    {
        public void StartGame()
        {
            Console.WriteLine("\n\nThe game has started!\n\n\n");
        }

        
        public void FinalScore(BasketballPlayer bk1, BasketballPlayer bk2)
        {
            Console.WriteLine($"\n\n{bk1.Name} scored {bk1.GetIntPoints()} points");
            Console.WriteLine($"{bk2.Name} scored {bk2.GetIntPoints()} points\n\n\n");
        }

        
        public void FinalScore(Footballer fk1, Footballer fk2)
        {
            Console.WriteLine($"\n\n{fk1.Name} scored {fk1.GetIntGoals()} goals");
            Console.WriteLine($"{fk2.Name} scored {fk2.GetIntGoals()} goals\n\n\n");
        }

        
        public void GetWinner(BasketballPlayer bk1, BasketballPlayer bk2)
        {
            if (bk1.GetIntPoints() > bk2.GetIntPoints())
            {
                Console.WriteLine($"\n\n{bk1.Name} is winner \n\n\n");
            }
            else
            {
                if (bk2.GetIntPoints() > bk1.GetIntPoints())
                {
                    Console.WriteLine($"\n\n{bk2.Name} is winner \n\n\n");
                }
                else
                {
                    if (bk1.GetIntPoints() == bk2.GetIntPoints())
                    {
                        Console.WriteLine("\n\nDraw game!\n\n\n");
                    }
                }
            }
        }

        
        public void GetWinner(Footballer fk1, Footballer fk2)
        {
            if (fk1.GetIntGoals() > fk2.GetIntGoals())
            {
                Console.WriteLine($"\n\n{fk1.Name} is winner \n\n\n");
            }
            else
            {
                if (fk2.GetIntGoals() > fk1.GetIntGoals())
                {
                    Console.WriteLine($"\n\n{fk2.Name} is winner \n\n\n");
                }
                else
                {
                    if (fk1.GetIntGoals() == fk2.GetIntGoals())
                    {
                        Console.WriteLine("\n\nDraw game!\n\n\n");
                    }
                }
            }
        }
    }

    
    
    class Program
    {
        static void Main(string[] args)
        {
            int meatCalorie = 445;
            int vegetablesCalorie = 123;
            int fruitsCalorie = 167;
            int porridgeCalorie = 234;
            bool isCorrect = true;
            Console.Write($"\nStart\n");
            while (isCorrect)
            {
                 Console.Write($"\n1:Footballers\n");
                 Console.Write($"2:Basketball players\n");
                 Console.Write($"3:Create List\n");
                 Console.Write($"4:Exit\n");
                 Console.Write("Make a choice:\n");
                 string choiseSportsman = Console.ReadLine();
                 switch (choiseSportsman)
                 {
                    case "1":
                        Footballers fk = new Footballers();
                        fk[0] = new Footballer(17, 170, 60) { Name = "Tom" };
                        Footballer Tom = fk[0];
                        Footballer.GetNationality();
                        Tom.GetInfo();
                        Tom.GetInfoDailyIntake();

                        int calorieNowTom = 0;
                        double drunkWaterTom = 0;

                        Console.Write("\n\n");

                        drunkWaterTom = Tom.DrunkingWater(drunkWaterTom);
                        calorieNowTom = Tom.Nutrition(calorieNowTom, meatCalorie, vegetablesCalorie, fruitsCalorie, porridgeCalorie);

                        Console.Write("\n\n");

                        Tom.GetInfo(calorieNowTom, drunkWaterTom);

                        Tom.GetEnergy(calorieNowTom, drunkWaterTom);
                        Tom.GetInfoEnergy();


                        Console.ReadKey();


                        Console.Write("\n\n///////////////\nNew personage:\n///////////////\n\n");

                        fk[1] = new Footballer(17, 190, 100) { Name = "Oleg" };
                        Footballer Oleg = fk[1];
                        Footballer.GetNationality();
                        Oleg.GetInfo();
                        Oleg.GetInfoDailyIntake();

                        int calorieNowOleg = 0;
                        double drunkWaterOleg = 0;

                        Console.Write("\n\n");

                        drunkWaterOleg = Oleg.DrunkingWater(drunkWaterOleg);
                        calorieNowOleg = Oleg.Nutrition(calorieNowOleg, meatCalorie, vegetablesCalorie, fruitsCalorie, porridgeCalorie);

                        Console.Write("\n\n");

                        Oleg.GetInfo(calorieNowOleg, drunkWaterOleg);

                        Oleg.GetEnergy(calorieNowOleg, drunkWaterOleg);
                        Oleg.GetInfoEnergy();

                        PlayGround firstPlayGround = new PlayGround();

                        firstPlayGround.StartGame();

                        Tom.GetInfo();
                        Tom.GetInfoEnergy();
                        Tom.Game();

                        Oleg.GetInfo();
                        Oleg.GetInfoEnergy();
                        Oleg.Game();

                        firstPlayGround.FinalScore(Tom, Oleg);
                        firstPlayGround.GetWinner(Tom, Oleg);


                        Console.ReadKey();


                        break;
                    case "2":
                        BasketballPlayers bk = new BasketballPlayers();
                        bk[0] = new BasketballPlayer(17, 170, 60) { Name = "Tom" };
                        BasketballPlayer Vlad = bk[0];
                        BasketballPlayer.GetNationality();
                        Vlad.GetInfo();
                        Vlad.GetInfoDailyIntake();

                        int calorieNowVlad = 0;
                        double drunkWaterVlad = 0;

                        Console.Write("\n\n");

                        drunkWaterVlad = Vlad.DrunkingWater(drunkWaterVlad);
                        calorieNowVlad = Vlad.Nutrition(calorieNowVlad, meatCalorie, vegetablesCalorie, fruitsCalorie, porridgeCalorie);

                        Console.Write("\n\n");

                        Vlad.GetInfo(calorieNowVlad, drunkWaterVlad);

                        Vlad.GetEnergy(calorieNowVlad, drunkWaterVlad);
                        Vlad.GetInfoEnergy();


                        Console.ReadKey();


                        Console.Write("\n\n///////////////\nNew personage:\n///////////////\n\n");

                        bk[1] = new BasketballPlayer(17, 190, 100) { Name = "Oleg" };
                        BasketballPlayer Artyom = bk[1];
                        BasketballPlayer.GetNationality();
                        Artyom.GetInfo();
                        Artyom.GetInfoDailyIntake();

                        int calorieNowArtyom = 0;
                        double drunkWaterArtyom = 0;

                        Console.Write("\n\n");

                        drunkWaterArtyom = Artyom.DrunkingWater(drunkWaterArtyom);
                        calorieNowArtyom = Artyom.Nutrition(calorieNowArtyom, meatCalorie, vegetablesCalorie, fruitsCalorie, porridgeCalorie);

                        Console.Write("\n\n");

                        Artyom.GetInfo(calorieNowArtyom, drunkWaterArtyom);

                        Artyom.GetEnergy(calorieNowArtyom, drunkWaterArtyom);
                        Artyom.GetInfoEnergy();

                        PlayGround secondPlayGround = new PlayGround();

                        secondPlayGround.StartGame();

                        Vlad.GetInfo();
                        Vlad.GetInfoEnergy();
                        Vlad.Game();

                        Artyom.GetInfo();
                        Artyom.GetInfoEnergy();
                        Artyom.Game();

                        secondPlayGround.FinalScore(Vlad, Artyom);
                        secondPlayGround.GetWinner(Vlad, Artyom);

                           
                        Console.ReadKey();


                        break;
                    case "3":
                        List<Sportsman> sportsmen = new List<Sportsman>() { new BasketballPlayer(10, 140, 50) { Name = "Alex" }, new Footballer(13, 163, 67){ Name = "Nikolai" } };
                        foreach (Sportsman p in sportsmen)
                        {
                            Console.WriteLine();
                            Console.Write(p.Name);
                            Console.WriteLine($" energy:{p.RecoveryEnergy()}");
                        }
                            
                        
                        Console.ReadKey();


                       break;
                    case "4":
                        isCorrect = false;
                        break;
                 }
            }
        }
    }
}
