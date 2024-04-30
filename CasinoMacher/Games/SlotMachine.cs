using CasinoMacher.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoMacher.Games
{
    class SlotMachine : ICasinoGame
    {
        public void Play()
        {
            Console.WriteLine("Playing Slot Machine...");
        }
    }
}
