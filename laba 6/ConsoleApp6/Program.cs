using System;
using System.Collections.Generic;

namespace ConsoleApp6
{
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
        static void Action(IGame game)
        {
            game.Game(); 
        }
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
                Console.Write($"4:Using a comparator\n");
                Console.Write($"5:Create clone\n");
                Console.Write($"6:Exit\n");
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

                        drunkWaterTom = ((IDrink<double>)Tom).DrunkingWater(drunkWaterTom);
                        calorieNowTom = ((INutrition<int>)Tom).Nutrition(calorieNowTom, meatCalorie, vegetablesCalorie, fruitsCalorie, porridgeCalorie);

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

                        drunkWaterOleg = ((IDrink<double>)Oleg).DrunkingWater(drunkWaterOleg);
                        calorieNowOleg = ((INutrition<int>)Oleg).Nutrition(calorieNowOleg, meatCalorie, vegetablesCalorie, fruitsCalorie, porridgeCalorie);

                        Console.Write("\n\n");

                        Oleg.GetInfo(calorieNowOleg, drunkWaterOleg);

                        Oleg.GetEnergy(calorieNowOleg, drunkWaterOleg);
                        Oleg.GetInfoEnergy();

                        PlayGround firstPlayGround = new PlayGround();

                        firstPlayGround.StartGame();

                        Tom.GetInfo();
                        Tom.GetInfoEnergy();
                        Action(Tom);

                        Oleg.GetInfo();
                        Oleg.GetInfoEnergy();
                        Action(Oleg);

                        firstPlayGround.FinalScore(Tom, Oleg);
                        firstPlayGround.GetWinner(Tom, Oleg);


                        Console.ReadKey();


                        break;
                    case "2":
                        BasketballPlayers bk = new BasketballPlayers();
                        bk[0] = new BasketballPlayer(17, 170, 60) { Name = "Vlad" };
                        BasketballPlayer Vlad = bk[0];
                        BasketballPlayer.GetNationality();
                        Vlad.GetInfo();
                        Vlad.GetInfoDailyIntake();

                        int calorieNowVlad = 0;
                        double drunkWaterVlad = 0;

                        Console.Write("\n\n");

                        drunkWaterVlad = ((IDrink<double>)Vlad).DrunkingWater(drunkWaterVlad);
                        calorieNowVlad = ((INutrition<int>)Vlad).Nutrition(calorieNowVlad, meatCalorie, vegetablesCalorie, fruitsCalorie, porridgeCalorie);

                        Console.Write("\n\n");

                        Vlad.GetInfo(calorieNowVlad, drunkWaterVlad);

                        Vlad.GetEnergy(calorieNowVlad, drunkWaterVlad);
                        Vlad.GetInfoEnergy();


                        Console.ReadKey();


                        Console.Write("\n\n///////////////\nNew personage:\n///////////////\n\n");

                        bk[1] = new BasketballPlayer(17, 190, 100) { Name = "Artyom" };
                        BasketballPlayer Artyom = bk[1];
                        BasketballPlayer.GetNationality();
                        Artyom.GetInfo();
                        Artyom.GetInfoDailyIntake();

                        int calorieNowArtyom = 0;
                        double drunkWaterArtyom = 0;

                        Console.Write("\n\n");

                        drunkWaterArtyom = ((IDrink<double>)Artyom).DrunkingWater(drunkWaterArtyom);
                        calorieNowArtyom = ((INutrition<int>)Artyom).Nutrition(calorieNowArtyom, meatCalorie, vegetablesCalorie, fruitsCalorie, porridgeCalorie);

                        Console.Write("\n\n");

                        Artyom.GetInfo(calorieNowArtyom, drunkWaterArtyom);

                        Artyom.GetEnergy(calorieNowArtyom, drunkWaterArtyom);
                        Artyom.GetInfoEnergy();

                        PlayGround secondPlayGround = new PlayGround();

                        secondPlayGround.StartGame();

                        Vlad.GetInfo();
                        Vlad.GetInfoEnergy();
                        Action(Vlad);

                        Artyom.GetInfo();
                        Artyom.GetInfoEnergy();
                        Action(Artyom);

                        secondPlayGround.FinalScore(Vlad, Artyom);
                        secondPlayGround.GetWinner(Vlad, Artyom);


                        Console.ReadKey();


                        break;
                    case "3":
                        List<Sportsman> sportsmen = new List<Sportsman>() { new BasketballPlayer(10, 140, 50) { Name = "Alex" }, new Footballer(13, 163, 67) { Name = "Nikolai" } };
                        foreach (Sportsman s in sportsmen)
                        {
                            Console.WriteLine();
                            Console.Write(s.Name);
                            Console.WriteLine($" energy:{s.RecoveryEnergy()}");
                        }


                        Console.ReadKey();


                        break;
                    case "4":
                        BasketballPlayer Tomasi = new BasketballPlayer(20, 156, 67) { Name = "Tomasi" };
                        Sportsman Billi = new BasketballPlayer(10, 140, 50) { Name = "Billi" };
                        
                        Tomasi.GetInfo();
                        Billi.GetInfo();
                        
                        
                        Tomasi.ResultComparator(Tomasi, Billi);


                        Console.ReadKey();

                        break;
                    case "5":
                        Sportsman p1 = new Sportsman (12,145,89){ Name = "Kolya" };
                        Sportsman p2 = (Sportsman)p1.Clone();
                        
                        Console.WriteLine(p1.Name);
                        p1.GetInfo();
                        Console.WriteLine(p2.Name);
                        p2.GetInfo();

                        Console.WriteLine();
                        Console.WriteLine("To make a change press any key");
                        Console.ReadKey();
                        Console.WriteLine();

                        p2.Name = "Alice";
                        p2.Height = 100;
                        p2.Weight = 40;

                        Console.WriteLine(p1.Name);
                        p1.GetInfo();
                        Console.WriteLine(p2.Name);
                        p2.GetInfo();

                        break;
                    case "6":
                        isCorrect = false;
                        break;
                }
            }
        }
    }
}

