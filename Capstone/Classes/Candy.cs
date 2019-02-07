using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Candy : IsEaten
    {
        public string noiseMade { get;  }

        public Candy()
        {
            noiseMade = "Munch, Munch, Yum";
        }

        public void NoiseProduced()
        {
            Console.WriteLine($" You received some candy! \n {noiseMade}");
        }
    }
}
