using OpenTK.Input;
using System;
using System.Drawing;

//rezolvarea exercitiilor 8 si 9

namespace Adochitei_Alexandru_3131A_Lab3
{
    internal class Color_Handler
    {
        private const double COLOR_ADJUSTMENT_STEP = 0.05;

        public Color GenerateRandomColor()
        {
            Random random = new Random();
            return Color.FromArgb(255, random.Next(256), random.Next(256), random.Next(256));
        }

        public void SetTriangleToWhite(KeyboardState kb, ref Color clr1, ref Color clr2, ref Color clr3)
        {
            if(kb[Key.X])
            {
                clr1 = Color.White;
                clr2 = Color.White;
                clr3 = Color.White;
                Console.WriteLine("Culoarea triunghiului a fost setata la alb!");
            }
        }

        //exercitiul 8, modificarea valorilor culorilor ARGB ale triunghiului din dreapta
        public void SetColor(KeyboardState kb, ref double a, ref double r, ref double g, ref double b)
        {
            //rosu
            if(kb[Key.Up] && kb[Key.R] && r < 1)
                r += COLOR_ADJUSTMENT_STEP;
            else if(kb[Key.Down] && kb[Key.R] && r > 0)
                r -= COLOR_ADJUSTMENT_STEP;

            //albastru
            if(kb[Key.Up] && kb[Key.A] && b < 1)
                b += COLOR_ADJUSTMENT_STEP;
            else if(kb[Key.Down] && kb[Key.A] && b > 0)
                b -= COLOR_ADJUSTMENT_STEP;

            //verde
            if(kb[Key.Up] &&  kb[Key.V] && g < 1)
                g += COLOR_ADJUSTMENT_STEP;
            else if(kb[Key.Down] && kb[Key.V] && g > 0)
                g -= COLOR_ADJUSTMENT_STEP;

            //transparenta
            if(kb[Key.Up] && kb[Key.T] && a < 1)
                a += COLOR_ADJUSTMENT_STEP;
            else if(kb[Key.Down] && kb[Key.T] && a > 0)
            {
                a -= COLOR_ADJUSTMENT_STEP;
                if(a < COLOR_ADJUSTMENT_STEP)
                    a = 0;
            }
        }

        //exercitiul 9, manipularea valorilor RGB pentru fiecare vortex ce defineste un triunghi
        public void SetVertexColors(KeyboardState kb, ref Color clr1, ref Color clr2, ref Color clr3)
        {
            Color temp_clr1 = clr1; //vortexul din dreapta jos
            Color temp_clr2 = clr2; //vortexul din stanga jos
            Color temp_clr3 = clr3; //vortexul din dreapta sus

            //vortexul din dreapta jos
            if(kb[Key.Number1])
                clr1 = Color.FromArgb(255, 255, 0, 0); //rosu
            if(kb[Key.Number2])
                clr1 = Color.FromArgb(255, 0, 255, 0); //verde
            if(kb[Key.Number3])
                clr1 = Color.FromArgb(255, 0, 0, 255); //albastru

            //vortexul din stanga jos
            if(kb[Key.Number4])
                clr2 = Color.FromArgb(255, 255, 0, 0); //rosu
            if(kb[Key.Number5])
                clr2 = Color.FromArgb(255, 0, 255, 0); //verde
            if(kb[Key.Number6])
                clr2 = Color.FromArgb(255, 0, 0, 255); //albastru

            //vortexul din dreapta sus
            if(kb[Key.Number7])
                clr3 = Color.FromArgb(255, 255, 0, 0); //rosu
            if(kb[Key.Number8])
                clr3 = Color.FromArgb(255, 0, 255, 0); //verde
            if(kb[Key.Number9])
                clr3 = Color.FromArgb(255, 0, 0, 255); //albastru

            //afisare in consola
            if(temp_clr1 != clr1)
                Console.WriteLine("Vertexul din dreapta jos: " + clr1);
            if(temp_clr2 != clr2)
                Console.WriteLine("Vertexul din stanga jos: " + clr2);
            if(temp_clr3 != clr3)
                Console.WriteLine("Vertexul din dreapta sus: " + clr3);
        }
    }
}