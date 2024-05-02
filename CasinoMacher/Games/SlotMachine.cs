using CasinoMacher.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoMacher.Games
{
    public class SlotMachine : ICasinoGame
    {
        private readonly string[] symbols = { "Cherry", "Bar", "Seven", "Bell", "Diamond" };
        private readonly Random random = new Random();
        private int chips = 100; // Startkapital für Chips

        public void Play()
        {
            Console.WriteLine("Welcome to the Slot Machine!");
            Console.WriteLine($"You have {chips} chips.");

            while (true)
            {
                Console.WriteLine("\nEnter your bet amount (or type 'exit' to quit):");
                string input = Console.ReadLine();

                if (input.ToLower() == "exit")
                    break;

                if (!int.TryParse(input, out int bet))
                {
                    Console.WriteLine("Invalid input. Please enter a valid bet amount.");
                    continue;
                }

                if (bet <= 0 || bet > chips)
                {
                    Console.WriteLine("Invalid bet amount. Please enter a bet between 1 and your total chips.");
                    continue;
                }

                string[] result = Spin();
                Console.WriteLine($"Result: {string.Join(" - ", result)}");

                // Berechnung des Gewinns oder Verlusts basierend auf dem Ergebnis
                int payout = CalculatePayout(result, bet);
                chips += payout;

                if (payout >= 0)
                {
                    Console.WriteLine($"Congratulations! You won.");
                }
                else
                {
                    Console.WriteLine($"Sorry, you lost.");
                }

                Console.WriteLine($"Total chips: {chips}");
            }

            Console.WriteLine("Thanks for playing!");
        }

        public string[] Spin()
        {
            string[] result = new string[3];

            for (int i = 0; i < result.Length; i++)
            {
                int index = random.Next(symbols.Length);
                result[i] = symbols[index];
            }

            return result;
        }

        public int CalculatePayout(string[] symbols, int bet)
        {
            // Immer das zwei Fache wird ausgezahlt
            if (symbols[0] == symbols[1] && symbols[1] == symbols[2])
                return bet * 2;
            else
                return -bet; // Verlust des Einsatzes
        }
    }
}