using System;
using System.Collections.Generic;

namespace ConsoleApp8
{
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

                        static void ShowMessageFootbaler(String message)
                        {
                            Console.WriteLine(message);
                        }

                        static void ColorMessageTom(string message)
                        {
                            // Устанавливаем жёлтый цвет символов
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(message);
                            // Сбрасываем настройки цвета
                            Console.ResetColor();
                        }

                        Footballer.FootballHandler colorDelegateTom = new Footballer.FootballHandler(ColorMessageTom);

                        Tom.RegisterHandler(new Footballer.FootballHandler(ShowMessageFootbaler));
                        Tom.RegisterHandler(colorDelegateTom);
    

                        Action(Tom);

                        
                        Oleg.GetInfo();
                        Oleg.GetInfoEnergy();

                        static void ColorMessageOleg(string message)
                        {
                            // Устанавливаем синий цвет символов
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.WriteLine(message);
                            // Сбрасываем настройки цвета
                            Console.ResetColor();
                        }

                        Footballer.FootballHandler colorDelegateOleg = new Footballer.FootballHandler(ColorMessageOleg);

                        Oleg.RegisterHandler(new Footballer.FootballHandler(ShowMessageFootbaler));
                        Oleg.RegisterHandler(colorDelegateOleg);

                       
                        Action(Oleg);


                        static void ShowMessagePlayground(String message)
                        {
                            Console.WriteLine(message);
                        }

                        static void ShowColorMessagePlayground(String message)
                        {
                            // Устанавливаем зелёный цвет символов
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(message);
                            // Сбрасываем настройки цвета
                            Console.ResetColor();
                        }



                        firstPlayGround.FinalScore(Tom, Oleg, new PlayGround.PlaygroundFootballHandler(ShowMessagePlayground));
                        firstPlayGround.GetWinner(Tom, Oleg, new PlayGround.PlaygroundFootballHandler(ShowColorMessagePlayground));


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

                        secondPlayGround.SecondNotify += mes => Console.WriteLine(mes);
                        secondPlayGround.SecondNotify += message =>
                        {
                            // Устанавливаем красный цвет символов
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(message);
                            // Сбрасываем настройки цвета
                            Console.ResetColor();
                        };

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
                        BasketballPlayer Billi = new BasketballPlayer(10, 140, 50) { Name = "Billi" };
                        
                        Tomasi.GetInfo();
                        Billi.GetInfo();


                        Tomasi.FirstNotify += delegate (string message)
                        {
                            Console.WriteLine(message);
                        };
                        Tomasi.FirstNotify += delegate (string mes)
                        {
                            // Устанавливаем голубой цвет символов
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine(mes);
                            // Сбрасываем настройки цвета
                            Console.ResetColor();
                        };



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

