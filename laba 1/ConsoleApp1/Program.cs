using System;

namespace ConsoleApp1
{
    class Program
    {
        static void CheckingString(string Expression, ref bool isCorrect)
        {
            char SecTempVar, FirstTempVar;
            int Position = 0;
            int Brackets = 0;

            while (Expression[Position] == ' ')
                Position++;

            FirstTempVar = Expression[Position];
            Position++;

            if (FirstTempVar == '(')
            {
                Brackets++;
            }
            if (FirstTempVar == ')')
            {
                Brackets--;
            }
            if (FirstTempVar == '^' || FirstTempVar == ')' || FirstTempVar == '.' || FirstTempVar == '*' 
                || FirstTempVar == '/')
            {
                Console.WriteLine("Error!");
                isCorrect = true;
                return;
            }

            if (FirstTempVar == '\n' || (FirstTempVar != '-' && FirstTempVar != '+' && FirstTempVar != '(' && (FirstTempVar < '0' || FirstTempVar > '9')))
            {
                Console.WriteLine("Error!");
                isCorrect = true;
                return;
            }

            while (Expression[Position] != '\n')
            {
                while (Expression[Position] == ' ')
                {
                    Position++;
                }
                SecTempVar = Expression[Position];
                Position++;

                if (Brackets < 0)
                {
                    Console.WriteLine("Error!");
                    isCorrect = true;
                    return;
                }

                if (SecTempVar == '(')
                {
                    Brackets++;
                }
                if (SecTempVar == ')')
                {
                    Brackets--;
                }
                if (SecTempVar == '\n')
                {
                    if (FirstTempVar == '*' || FirstTempVar == '/')
                    {
                        Console.WriteLine("Error!");
                        isCorrect = true;
                    }
                    break;
                }

                if (SecTempVar != '.' && SecTempVar != ')' && SecTempVar != '/' && SecTempVar != '*' && SecTempVar != '^' 
                    && SecTempVar != '-' && SecTempVar != '+' && SecTempVar != '(' && (SecTempVar < '0' || SecTempVar > '9'))
                {
                    Console.WriteLine("Error!");
                    isCorrect = true;
                    return;
                }

                if (FirstTempVar >= '0' && FirstTempVar <= '9' && SecTempVar >= '0' && SecTempVar <= '9' && Expression[Position - 2] == ' ')
                {
                    Console.WriteLine("Error!");
                    isCorrect = true;
                    return;
                }

                if ((SecTempVar >= '0' && SecTempVar <= '9' && FirstTempVar == ')') || (FirstTempVar >= '0' && FirstTempVar <= '9' && SecTempVar == '('))
                {
                    Console.WriteLine("Error!");
                    isCorrect = true;
                    return;
                }

                if (((SecTempVar == '*' || SecTempVar == '/' || SecTempVar == '^' || SecTempVar == ')' || SecTempVar == '.' || SecTempVar == '+') 
                    && (FirstTempVar == '+' || FirstTempVar == '.' || FirstTempVar == '*' || FirstTempVar == '/' || FirstTempVar == '^' || FirstTempVar == '(')) 
                    || ((SecTempVar == '-' || SecTempVar == '+') && (FirstTempVar == '-' || FirstTempVar == '+')))
                {
                    Console.WriteLine("Error!");
                    isCorrect = true;
                    return;
                }

                if (SecTempVar == '^' && Expression[Position - 2] == ' ')
                {
                    Console.WriteLine("Error!");
                    isCorrect = true;
                    return;
                }

                if (SecTempVar == '.' && (Expression[Position] == ' ' || Expression[Position - 2] == ' '))
                {
                    Console.WriteLine("Error!");
                    isCorrect = true;
                    return;
                }

                FirstTempVar = SecTempVar;
            }

            if (Brackets != 0)
            {
                Console.WriteLine("Error!");
                isCorrect = true;
            }

            return;
        }
        static char Next(string Expression, ref int Position)
        {
            char SecTempVar = Expression[Position];
            Position++;

            while (SecTempVar == ' ')
            {
                SecTempVar = Expression[Position];
                Position++;
            }

            return SecTempVar;
        }
        //Считает числа.
        static double Number(string Expression, ref int Position, ref bool isCorrect)
        {
            double Result = 0;
            int Sign = 1;
            char SecTempVar;

            SecTempVar = Next(Expression, ref Position);

            if (SecTempVar == '-')
            {
                Sign = -1;
            }
            else
            {
                Position--;
            }
            while (true)
            {
                SecTempVar = Next(Expression, ref Position);

                if (SecTempVar >= '0' && SecTempVar <= '9')
                {
                    Result = Result * 10 + SecTempVar - '0';
                }
                else
                {
                    Position--;
                    break;
                }
            }

            SecTempVar = Next(Expression, ref Position);
            double A = 10;

            if (SecTempVar == '.')
            {
                while (true)
                {
                    SecTempVar = Next(Expression, ref Position);

                    if (SecTempVar >= '0' && SecTempVar <= '9')
                    {
                        Result += (SecTempVar - '0') / A;
                        A *= 10;
                    }
                    else
                    {
                        Position--;
                        break;
                    }
                }
            }
            else
            {
                Position--;
            }
            SecTempVar = Next(Expression, ref Position);


            if (SecTempVar == '^')
            {
                double FirstTempVar = OpenBrackets(Expression, ref Position, ref isCorrect);

                if (isCorrect == true)
                {
                    return 0;
                }
                return Sign * Math.Pow(Result, FirstTempVar);
            }
            else
            {
                Position--;
            }
            return Sign * Result;
        }
        //Делит выражение на части, в которых(частях) содержатся только *(умножение) и /(деление), 
        //а после того как выполнится функция MultiplicationAndDivision складывает части выражения. 
        static double AdditionAndSubtraction(string Expression, ref int Position, ref bool isCorrect)
        {
            double Result = MultiplicationAndDivision(Expression, ref Position, ref isCorrect);

            if (isCorrect == true)
            {
                return 0;
            }
            char SecTempVar;

            while (true)
            {
                SecTempVar = Next(Expression, ref Position);

                switch (SecTempVar)
                {
                    case '+':
                        Result += MultiplicationAndDivision(Expression, ref Position, ref isCorrect);

                        if (isCorrect == true)
                        {
                            return 0;
                        }
                        break;
                    case '-':
                        Result -= MultiplicationAndDivision(Expression, ref Position, ref isCorrect);

                        if (isCorrect == true)
                        {
                            return 0;
                        }
                        break;
                    default:
                        Position--;
                        return Result;
                }
            }
        }
        //Делит выражение с *(умножением) и /(делением) на числа, после того, как выполнится функция Number, умножает и делит эти числа. 
        static double MultiplicationAndDivision(string Expression, ref int Position, ref bool isCorrect)
        {
            double Result = OpenBrackets(Expression, ref Position, ref isCorrect);
            char SecTempVar;

            if (isCorrect == true)
            {
                return 0;
            }
            while (true)
            {
                SecTempVar = Next(Expression, ref Position);

                switch (SecTempVar)
                {
                    case '*':
                        Result *= OpenBrackets(Expression, ref Position, ref isCorrect);

                        if (isCorrect == true)
                        {
                            return 0;
                        }
                        break;
                    case '/':
                        double FirstTempVar = OpenBrackets(Expression, ref Position, ref isCorrect);

                        if (isCorrect == true)
                        {
                            return 0;
                        }
                        if (FirstTempVar == 0.0)
                        {
                            Console.WriteLine("Error!");
                            isCorrect = true;
                            return 0;
                        }

                        Result /= FirstTempVar;
                        break;
                    default:
                        Position--;
                        return Result;
                }
            }
        }
        //Если присутсвуют скобки в выражении, то выполняется данная функция, которая считает выражение по-новой, потому что из-за скобок были изменены приоритеты
        static double OpenBrackets(string Expression, ref int Position, ref bool isCorrect)
        {
            double Result;
            int Sign = 1;
            char SecTempVar;

            SecTempVar = Next(Expression, ref Position);

            if (SecTempVar == '-')
            {
                Sign = -1;
                SecTempVar = Next(Expression, ref Position);
            }

            if (SecTempVar == '(')
            {
                Result = AdditionAndSubtraction(Expression, ref Position, ref isCorrect);

                if (isCorrect == true)
                {
                    return 0;
                }
                SecTempVar = Next(Expression, ref Position);

                if (SecTempVar != ')')
                {
                    Console.WriteLine("Error!");
                    isCorrect = true;
                    return 0;
                }

                SecTempVar = Next(Expression, ref Position);

                if (SecTempVar == '^')
                {
                    double FirstTempVar = OpenBrackets(Expression, ref Position, ref isCorrect);

                    if (isCorrect == true)
                    {
                        return 0;
                    }
                    if (FirstTempVar != (int)FirstTempVar && Result < 0)
                    {
                        Console.WriteLine("Error!");
                        isCorrect = true;
                        return 0;
                    }
                    return Sign * Math.Pow(Result, FirstTempVar);
                }
                else
                {
                    Position--;
                }
                return Sign * Result;
            }
            else
            {
                Position--;
                return Sign * Number(Expression, ref Position, ref isCorrect);
            }
        }
        static void Main(string[] args)
        {
            while (true)
            {
                bool Flag = false;
                int Index = 0;
                double Result = 0;

                Console.Write("Enter expression : ");
                string Expression = Console.ReadLine();
                Expression += " \n";

                CheckingString(Expression, ref Flag);

                if (!Flag)
                {
                    Result = AdditionAndSubtraction(Expression, ref Index, ref Flag);
                }
                if (!Flag)
                {
                    Console.WriteLine(Result);
                    break;
                }
            }
        }
    }
}
    

 