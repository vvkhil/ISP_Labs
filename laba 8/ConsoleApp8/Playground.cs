using System;

namespace ConsoleApp8
{
    struct PlayGround
    {
        
        public void StartGame()
        {
            Console.WriteLine("\n\nThe game has started!\n\n\n");
        }

        
        public delegate void PlaygroundBasketballHandler(string message);
        public event PlaygroundBasketballHandler SecondNotify;

        public void FinalScore(BasketballPlayer bk1, BasketballPlayer bk2)
        {
            SecondNotify?.Invoke($"\n\n{bk1.Name} scored {bk1.GetIntPoints()} points");
            SecondNotify?.Invoke($"{bk2.Name} scored {bk2.GetIntPoints()} points\n\n\n");
        }

        public void GetWinner(BasketballPlayer bk1, BasketballPlayer bk2)
        {
            if (bk1.GetIntPoints() > bk2.GetIntPoints())
            {
                SecondNotify?.Invoke($"\n\n{bk1.Name} is winner \n\n\n");
            }
            else
            {
                if (bk2.GetIntPoints() > bk1.GetIntPoints())
                {
                    SecondNotify?.Invoke($"\n\n{bk2.Name} is winner \n\n\n");
                }
                else
                {
                    if (bk1.GetIntPoints() == bk2.GetIntPoints())
                    {
                        SecondNotify?.Invoke("\n\nDraw game!\n\n\n");
                    }
                }
            }
        }


        public delegate void PlaygroundFootballHandler(string message);
        PlaygroundFootballHandler _del;

        public void FinalScore(Footballer fk1, Footballer fk2, PlaygroundFootballHandler del)
        {
            _del = del;
            if (_del != null)
            {
                _del($"\n\n{fk1.Name} scored {fk1.GetIntGoals()} goals");
                _del($"{fk2.Name} scored {fk2.GetIntGoals()} goals\n\n\n");
            }
        }


        public void GetWinner(Footballer fk1, Footballer fk2, PlaygroundFootballHandler del)
        {
            _del = del;
            if (fk1.GetIntGoals() > fk2.GetIntGoals())
            {
                if (_del != null)
                {
                    _del($"\n\n{fk1.Name} is winner \n\n\n");
                }
            }
            else
            {
                if (fk2.GetIntGoals() > fk1.GetIntGoals())
                {
                    if (_del != null)
                    {
                        _del($"\n\n{fk2.Name} is winner \n\n\n");
                    }
                }
                else
                {
                    if (fk1.GetIntGoals() == fk2.GetIntGoals())
                    {
                        if (_del != null)
                        {
                            _del("\n\nDraw game!\n\n\n");
                        }
                    }
                }
            }
        }
    }
}
