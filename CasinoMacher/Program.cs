using CasinoMacher.Games;
using CasinoMacher.Interface;

namespace CasinoMacher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Benutzer kann zwischen Slots und Roulette wählen
            Console.WriteLine("Choose a game:");
            Console.WriteLine("1. Slots");
            Console.WriteLine("2. Roulette");
            Console.Write("Enter your choice: ");

            int choice = int.Parse(Console.ReadLine());

            ICasinoGame game;

            // Je nach Benutzerwahl wird das entsprechende Spiel erstellt
            switch (choice)
            {
                case 1:
                    game = new SlotMachine();
                    break;
                case 2:
                    game = new Roulette();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Defaulting to Slots.");
                    game = new SlotMachine();
                    break;
            }

            // Das ausgewählte Spiel wird gestartet
            game.Play();
        }
    }
}
