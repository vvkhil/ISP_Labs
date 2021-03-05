using System;

namespace ConsoleApp2
{
    class Program
    {
        static int Search(string A, char SearchValue)
        {
            int Count = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == SearchValue)
                {
                    Count++;
                }
            }
            return Count;
        }
        static void Main(string[] args)
        {
            Console.Write("Select the task number: ");
            string Choise = Console.ReadLine();          
            switch(Choise)
            {
                //В заданной строке поменять порядок слов на обратный (слова разделены пробелами).
                case "1":
                    Console.WriteLine("Enter string:");
                    string InputString1 = Console.ReadLine();
                    string[] Words = InputString1.Split(' ');
                    for (int i = Words.Length - 1; i >= 0; i--)
                    {
                        Console.Write(Words[i] + " ");
                    }
                    break;
                //Получить текущее время и дату в двух разных форматах и вывести на экран коли-чество нулей, единиц, …, девяток в их записи.
                case "2":
                    DateTime CurrentDate = new DateTime();
                    CurrentDate = DateTime.Now;
                    Console.WriteLine(DateTime.Now);
                    string CheckedString = CurrentDate.ToString();
                    Console.WriteLine(CurrentDate.ToLongDateString() + " " + CurrentDate.ToShortTimeString());

                    Console.WriteLine("\n");

                    Console.WriteLine("Количество 0: " + Search(CheckedString, '0'));
                    Console.WriteLine("Количество 1: " + Search(CheckedString, '1'));
                    Console.WriteLine("Количество 2: " + Search(CheckedString, '2'));
                    Console.WriteLine("Количество 3: " + Search(CheckedString, '3'));
                    Console.WriteLine("Количество 4: " + Search(CheckedString, '4'));
                    Console.WriteLine("Количество 5: " + Search(CheckedString, '5'));
                    Console.WriteLine("Количество 6: " + Search(CheckedString, '6'));
                    Console.WriteLine("Количество 7: " + Search(CheckedString, '7'));
                    Console.WriteLine("Количество 8: " + Search(CheckedString, '8'));
                    Console.WriteLine("Количество 9: " + Search(CheckedString, '9'));
                    break;
                //Дана строка. Найти в ней все заглавные буквы, не входящие в английский алфавит.
                case "3":
                    Console.Write("Enter string :");
                    string InputString2 = Console.ReadLine();
                    for (int i = 0; i < InputString2.Length; i++)
                    {
                        char SearchSymbol = InputString2[i];
                        if ((SearchSymbol >= 'А') && (SearchSymbol <= 'Я'))
                        {
                            Console.WriteLine("Заглавная русская буква:" + InputString2[i]);
                        }
                    }
                    break;
            }
            Console.ReadKey();
        }
    }
}


