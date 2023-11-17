using OpenTK.Input;
using System;
using System.Drawing;

//rezolvarea exercitiilor 1 si 2 al laboratorului 4

namespace Adochitei_Alexandru_3131A_Lab5
{
    internal class Color_Handler
    {
        private const double COLOR_ADJUSTMENT_STEP = 0.05;

        //exercitiul 1, modificarea valorilor culorilor ARGB ale suprafetei cubul
        public void SetColor(KeyboardState kb, ref double r, ref double g, ref double b, ref double a)
        {
            //rosu
            if (kb[Key.Up] && kb[Key.R] && r < 1)
            {
                r += COLOR_ADJUSTMENT_STEP;
            }
            else if (kb[Key.Down] && kb[Key.R] && r > 0)
            {
                r -= COLOR_ADJUSTMENT_STEP;
            }

            //albastru
            if (kb[Key.Up] && kb[Key.A] && b < 1)
            {
                b += COLOR_ADJUSTMENT_STEP;
            }
            else if (kb[Key.Down] && kb[Key.A] && b > 0)
            {
                b -= COLOR_ADJUSTMENT_STEP;
            }

            //verde
            if (kb[Key.Up] && kb[Key.V] && g < 1)
            {
                g += COLOR_ADJUSTMENT_STEP;
            }
            else if (kb[Key.Down] && kb[Key.V] && g > 0)
            {
                g -= COLOR_ADJUSTMENT_STEP;
            }

            //transparenta
            if (kb[Key.Up] && kb[Key.T] && a < 1)
            {
                a += COLOR_ADJUSTMENT_STEP;
            }
            else if (kb[Key.Down] && kb[Key.T] && a > 0)
            {
                a -= COLOR_ADJUSTMENT_STEP;
                if (a < COLOR_ADJUSTMENT_STEP)
                {
                    a = 0;

                }
            }
        }

        //exercitiul 2, manipularea valorilor RGB pentru fiecare vortex ce defineste un triunghi
        public void SetVertexColors(KeyboardState kb, ref Color clr1, ref Color clr2, ref Color clr3)
        {
            Color temp_clr1 = clr1; //vortex 1
            Color temp_clr2 = clr2; //vortex 2
            Color temp_clr3 = clr3; //vortex 3

            //vorte 1
            if(kb[Key.Number1])
                clr1 = Color.FromArgb(255, 255, 0, 0); //rosu
            if(kb[Key.Number2])
                clr1 = Color.FromArgb(255, 0, 255, 0); //verde
            if(kb[Key.Number3])
                clr1 = Color.FromArgb(255, 0, 0, 255); //albastru

            //vortex 2
            if(kb[Key.Number4])
                clr2 = Color.FromArgb(255, 255, 0, 0); //rosu
            if(kb[Key.Number5])
                clr2 = Color.FromArgb(255, 0, 255, 0); //verde
            if(kb[Key.Number6])
                clr2 = Color.FromArgb(255, 0, 0, 255); //albastru

            //vortex 3
            if(kb[Key.Number7])
                clr3 = Color.FromArgb(255, 255, 0, 0); //rosu
            if(kb[Key.Number8])
                clr3 = Color.FromArgb(255, 0, 255, 0); //verde
            if(kb[Key.Number9])
                clr3 = Color.FromArgb(255, 0, 0, 255); //albastru

            //afisare in consola
            if(temp_clr1 != clr1)
                Console.WriteLine("Vertex 1: " + clr1);
            if(temp_clr2 != clr2)
                Console.WriteLine("Vertex 2: " + clr2);
            if(temp_clr3 != clr3)
                Console.WriteLine("Vertex 3: " + clr3);
        }
    }
}