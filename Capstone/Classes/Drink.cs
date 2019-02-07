using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Drink : IsEaten
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
