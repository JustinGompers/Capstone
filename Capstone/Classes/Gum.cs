﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
     public class Gum : IsEaten
    {
        public string noiseMade { get; }

        public Gum()
        {
            noiseMade = "Munch, Munch, Yum";
        }

        public void NoiseProduced()
        {
            Console.WriteLine($" You received some candy! \n {noiseMade}");
        }
    }
}
