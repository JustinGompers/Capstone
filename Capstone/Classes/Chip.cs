using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Chip : IsEaten
    {
        public string noiseMade { get; }

        public Chip()
        {
            noiseMade = "Crunch Crunch, Yum!";
        }

        public void NoiseProduced()
        {
            Console.WriteLine($"You received a bag of chips!\n{noiseMade}");
        }
    }
}
