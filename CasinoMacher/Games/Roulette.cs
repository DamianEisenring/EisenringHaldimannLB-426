using CasinoMacher.Interface;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CasinoMacher.Games
{
    class Roulette : ICasinoGame
    {
        private int _chips = 200;
        public int chips()
        {
            return _chips;
        }
        private string _bet1;
        public string bet1()
        {
            return _bet1;
        }
        private string _bet2;
        public string bet2()
        {
            return _bet2;
        }
        private int _betAmount1;
        public int betAmount1()
        {
            return _betAmount1;
        }
        private int _betAmount2;
        public int betAmount2()
        {
            return _betAmount2;
        }
        bool tryCatch = true;
        private string answer;
        private Random randomNumber = new Random();
        private int thrownNumber;
        private bool playAgain = true;

        public void Play()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Roulette \n");
            while (playAgain == true)                
            {
                tryCatch = true;
                while (tryCatch == true)
                {
                    tryCatch = false;
                    try
                    {
                        Console.WriteLine("On what do you want to bet, a number between 1 and 36 or a color, for the number enter a number between 1 and 36 and for the color write black or red.");
                        _bet1 = Console.ReadLine();
                        _betAmount1=GetBet(_bet1);
                    }
                    catch
                    {
                        Console.WriteLine("\ninvalid input \n");
                        tryCatch = true;
                    }
                }
                Console.WriteLine("\nDo you want to bet a seconde time? yes/1 no/2");
                answer = Console.ReadLine();

                SecondBet(answer);

                
                thrownNumber = randomNumber.Next(37);
                
                
                Console.WriteLine("And the number is "+thrownNumber.ToString());

                _chips -= _betAmount1;
                _chips -= _betAmount2;

                CheckIfWin(_bet1, _betAmount1);
                CheckIfWin(_bet2, _betAmount2);

                Console.WriteLine("After this round you have " + _chips + " chips \n");
                Console.WriteLine("Do you want to play another round? yes/1 no/2");
                answer = Console.ReadLine();
                if (answer == "1")
                {
                    playAgain = true;
                }
                else
                {
                    playAgain= false;
                    Console.WriteLine("Have a good day");
                }
            }
        }

        public void CheckIfBetAmountIsValid(int betAmount)
        {
            if (betAmount < 1 || betAmount > _chips)
            {
                Console.WriteLine("\n You don't have enough chips for this bet \n");
                tryCatch = true;                
            }
        }

        public int GetBet(string answer)
        {
            int betAmount=0;
            if (answer == "red" || answer == "Red" || answer == "black" || answer == "Black")
            {
                Console.WriteLine("\n and how much do you want to bet?");
                betAmount = Convert.ToInt32(Console.ReadLine());
                CheckIfBetAmountIsValid(betAmount);
                return betAmount;               
            }
            else if (Convert.ToInt32(answer) < 37 && Convert.ToInt32(answer) > 0)
            {
                Console.WriteLine("\n and how much do you want to bet?");
                betAmount = Convert.ToInt32(Console.ReadLine());
                CheckIfBetAmountIsValid(betAmount);
                return betAmount;
            }
            else
            {
                Console.WriteLine("\n invalid input \n");
                tryCatch = true;
                return betAmount;
            }
        }

        public void CheckIfWin(string bet, int betAmount)
        {
            if (bet == "red" || bet == "Red")
            {
                if (IsEven(thrownNumber) == false)
                {               
                    _chips = betAmount * 2 + _chips;
                }
            }
            else if (bet == "black" || bet == "Black")
            {
                if (IsEven(thrownNumber) == true)
                {               
                    _chips = betAmount * 2 + _chips;
                }
            }
            else if (Convert.ToInt32(bet) == thrownNumber)
            {             
                _chips = betAmount * 36 + _chips;
            }           
        }

        public void SecondBet(string answer)
        {
            if (answer == "1")
            {
                tryCatch = true;
                while (tryCatch == true)
                {
                    tryCatch = false;
                    try
                    {
                        Console.WriteLine("\nOn what do you want to bet, a number between 1 and 36 or a color, for the number enter a number between 1 and 36 and for the color write black or red.");
                        _bet2 = Console.ReadLine();
                        _betAmount2 = GetBet(_bet2);
                    }
                    catch
                    {
                        Console.WriteLine("\ninvalid input \n");
                        tryCatch = true;
                    }
                }
            }
            else
            {
                _bet2 = "1";
                _betAmount2 = 0;
            }
        }

        public bool IsEven(int number)
        {
            return number % 2 == 0;
        } 
    }
}
