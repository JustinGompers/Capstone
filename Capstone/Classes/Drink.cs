using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    class Drink : MakesNoises
    {
        public string noiseMade { get; }

        public Drink()
        {
            noiseMade = "Glug Glug, Yum!";
        }

        public void NoiseProduced()
        {
            Console.WriteLine($"You received a nice cold drink!\n{noiseMade}");
        }
    }
}
