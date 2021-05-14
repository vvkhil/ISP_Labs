using System;

namespace ConsoleApp7
{
    class Program
    {
        static void Main(string[] args)
        {
            Rational first = new Rational(-3, 2);
            Rational second = new Rational(3, 8);

            bool isCorrect = false;

            while (!isCorrect)
            {
                Console.WriteLine("\n\n\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\");

                Rational result;
                Console.WriteLine("\nfirst = " + first.ToString());
                Console.WriteLine("second = " + second.ToString() + "\n");

                Console.WriteLine("------------------------------------------------");

                Console.WriteLine("1 - Arithmetic operations");
                Console.WriteLine("2 - Comparison operations");
                Console.WriteLine("3 - Cast operations");
                Console.WriteLine("4 - Converting a rational number to a string");
                Console.WriteLine("5 - GetHashCode, GetTypeCode, Equals");
                Console.WriteLine("6 - Parse and TryParse");
                Console.WriteLine("7 - Exit");

                Console.WriteLine("------------------------------------------------");

                string choise = Console.ReadLine();

                Console.WriteLine("------------------------------------------------");

                switch (choise)
                {
                    case "1":
                        {
                            result = first + second;
                            Console.WriteLine($"first + second = {result.GetDouble()}");
                            result = first - second;
                            Console.WriteLine($"first - second = {result.GetDouble()}");
                            result = first * second;
                            Console.WriteLine($"first * second = {result.GetDouble()}");
                            result = first / second;
                            Console.WriteLine($"first / second = {result.GetDouble()}");

                            Rational testMultiplyAndDivision = new Rational(1, 6);
                            Console.WriteLine("test = " + testMultiplyAndDivision.ToString());
                            testMultiplyAndDivision *= 4;
                            Console.WriteLine("test after multiply = " + testMultiplyAndDivision.ToString());
                            testMultiplyAndDivision /= 2;
                            Console.WriteLine("test after division = " + testMultiplyAndDivision.ToString());
                        }
                        break;
                    case "2":
                        { 
                            Console.WriteLine();
                            Console.WriteLine($"first > second : {first > second}");
                            Console.WriteLine($"first < second : {first < second}");
                            Console.WriteLine($"first >= second : {first >= second}");
                            Console.WriteLine($"first <= second : {first <= second}");
                            Console.WriteLine($"first == second : {first == second}");
                            Console.WriteLine($"first != second : {first != second}");
                            Console.WriteLine();
                        }
                        break;
                    case "3":
                        {
                            Console.WriteLine($"To Int16 -> {first.ToInt16(null)}");
                            short testShort = (short)first;
                            Console.WriteLine($"testShort -> {testShort}\n");

                            Console.WriteLine($"To Int32 -> {first.ToInt32(null)}");
                            int testInt = (int)first;
                            Console.WriteLine($"testInt -> {testInt}\n");

                            Console.WriteLine($"To Int64 -> {first.ToInt64(null)}");
                            long testLong = (long)first;
                            Console.WriteLine($"testLong -> {testLong}\n");

                            Console.WriteLine($"To Boolean -> {first.ToBoolean(null)}");
                            bool testBoll = (bool)first;
                            Console.WriteLine($"testBool -> {testBoll}\n");

                            Console.WriteLine($"To Decimal -> {first.ToDecimal(null)}");
                            decimal testDecimal = (decimal)first;
                            Console.WriteLine($"testDecimal -> {testDecimal}\n");

                            Console.WriteLine($"To Single -> {first.ToSingle(null)}");
                            Single testSingle = (float)first;
                            Console.WriteLine($"testSingle -> {testSingle}\n");
                            Console.WriteLine();
                        }
                        break;
                    case "4":
                        {
                            Console.WriteLine("Standart->"+first.ToString("Standart"));
                            Console.WriteLine("IntegerPart->"+first.ToString("IntegerPart"));
                            Console.WriteLine("DecimalFormat->"+first.ToString("DecimalFormat"));
                        }
                        break;
                    case "5":
                        {
                            Console.WriteLine(first.GetHashCode());
                            Console.WriteLine(first.GetTypeCode());
                            Console.WriteLine(first.GetType());
                            Console.WriteLine(first.Equals(second));
                        }
                        break;
                    case "6":
                        {
                            Console.WriteLine(Rational.Parse("17/4"));
                            Console.WriteLine(Rational.Parse("2/-11"));
                            Console.WriteLine(Rational.Parse("-9"));
                            Console.WriteLine(Rational.Parse("-0.6"));
                            Console.WriteLine(Rational.Parse("-0,893"));
                            Console.WriteLine(Rational.Parse("14,13"));
                            Console.WriteLine(Rational.Parse("-1/9"));

                            Console.WriteLine();

                            Rational test;

                            Console.WriteLine(Rational.TryParse("asdfdf", out test));
                            Console.WriteLine(Rational.TryParse("7/5", out test));
                            Console.WriteLine(Rational.TryParse("(/3f))", out test));
                        }
                        break;
                    case "7":
                        isCorrect = true;
                        break;
                    default:
                        Console.WriteLine("Incorrect input! Please try again");
                        break;
                }
            }
        }
    }
}