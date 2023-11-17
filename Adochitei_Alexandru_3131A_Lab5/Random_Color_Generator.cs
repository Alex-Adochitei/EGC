using System;
using System.Drawing;

namespace Adochitei_Alexandru_3131A_Lab5
{
    internal class Random_Color_Generator
    {
        private Random random;

        public Random_Color_Generator()
        {
            random = new Random();
        }

        //metoda ce returneaza un obiect de tipul Color avand valori random pentru canalele RGB
        public Color Generate()
        {
            int r = random.Next(0, 255);
            int g = random.Next(0, 255);
            int b = random.Next(0, 255);

            Color color = Color.FromArgb(r, g, b);

            return color;
        }
    }
}